using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using WineTrip.DataModel;
using System.Diagnostics;

namespace WineTrip
{
    public partial class CalenderControl : UserControl
    {
        public Trip trip { get; set; }
        public int day { get; set; }
 
        private Brush calenderFontBrush { get; } = Brushes.DarkGray;
        private Brush plannedEventRectangleBrush { get; } = Brushes.LightYellow;
        private Brush unplannedEventRectangleBrush { get; } = Brushes.White;
        private Brush selectedEventRectangleBrush { get; } = Brushes.Bisque;
        private Brush eventFontBrush { get; } = Brushes.Black;
        private Brush transferTimeBrush { get; } = new SolidBrush(Color.FromArgb(80, Color.Red));
        private Brush draggingBrush { get; } = new SolidBrush(Color.FromArgb(80, Color.LightBlue));
        private Pen calenderLinesPen { get; } = Pens.DarkGray;
        private Pen selectedBorderPen { get; } = Pens.Blue;
 
        private Font timeFont = new Font(
               new FontFamily("Arial"),
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        private Font eventFont = new Font(
                new FontFamily("Arial"),
                10,
                FontStyle.Regular,
                GraphicsUnit.Pixel);

        private int slotCnt { get { return 60 / trip.settings.resolution; } } // the number of secheduable slots in an hour


        public CalenderControl(int day, Trip trip)
        {
            InitializeComponent();
            this.day = day;
            this.trip = trip;
            CalculateOverlappingEvents();
        }

        private void CalenderControl_Paint(object sender, PaintEventArgs e)
        {
            int rowHeight = Height / (trip.settings.endHour - trip.settings.startHour);
            int leftMargin = 50;
            int rightMargin = 10;
            int transferBlockWidth = Width - leftMargin;
            int calenderWidth = Width - leftMargin - rightMargin;

            // draw the grid
            PaintGrid(e, rowHeight, leftMargin);
            var selectedEvents = trip.events.Where(x => x.day == day);
            // prepare the drawing rectangles
            FillDrawingRectangles(rowHeight, leftMargin, calenderWidth, selectedEvents);
            // draw the planned events
            DrawEvents(e, selectedEvents.Where(x => x.GPSLocation != null), plannedEventRectangleBrush);
            // tranfer times
            DrawTransfers(e, transferBlockWidth);
            // events with location not determined need to do this after transfers have been drawn
            DrawEvents(e, selectedEvents.Where(x => x.GPSLocation == null), unplannedEventRectangleBrush);
            // dragging
            if (SelectedEvent.selectedEvent != null && SelectedEvent.dragging)
            {
                Event evnt = SelectedEvent.selectedEvent.ShallowCopy();
                int actualWidth = calenderWidth;
                int actualLeft = leftMargin;
                evnt.start = TimeFromPosition(PositionFromTime(evnt.start) + SelectedEvent.dragOffset - SelectedEvent.dragInitialOffset);
                evnt.drawingRect.X = actualLeft;
                evnt.drawingRect.Y = PositionFromTime(evnt.start) ;
                evnt.drawingRect.Width = actualWidth;
                evnt.drawingRect.Height = evnt.duration * rowHeight / 60;
                DrawEvents(e, new List<Event> { evnt } , draggingBrush);
            }
        }

        private void PaintGrid(PaintEventArgs e, int rowHeight, int leftMargin)
        {
            for (int i = 0; i < trip.settings.endHour - trip.settings.startHour; i++)
            {
                e.Graphics.DrawLine(calenderLinesPen, new Point(0, i * rowHeight), new Point(Width, i * rowHeight));
                e.Graphics.DrawString(string.Format("{0:00}:00", trip.settings.startHour + i), timeFont, calenderFontBrush, 0, i * rowHeight);
                for (int j = 1; j < slotCnt; j++)
                {
                    int subdevheight = i * rowHeight + (int)(((double)j / slotCnt) * rowHeight);
                    e.Graphics.DrawLine(calenderLinesPen, new Point(leftMargin, subdevheight), new Point(Width, subdevheight));
                }
            }
            // margin
            e.Graphics.DrawLine(calenderLinesPen, new Point(leftMargin, 0), new Point(leftMargin, Height));
        }

        private void FillDrawingRectangles(int rowHeight, int leftMargin, int calenderWidth, IEnumerable<Event> selectedEvents)
        {
            // fill the drawing rectangles;
            foreach (Event evnt in selectedEvents)
            {
                int actualWidth = calenderWidth;
                int actualLeft = leftMargin;
                if (evnt.overlappingEventCluster != null)
                {
                    actualWidth = calenderWidth / evnt.overlappingEventCluster.Count;
                    int pos = evnt.overlappingEventCluster.FindIndex(x => x == evnt);
                    actualLeft = leftMargin + pos * calenderWidth / evnt.overlappingEventCluster.Count;
                }
                evnt.drawingRect.X = actualLeft;
                evnt.drawingRect.Y = PositionFromTime(evnt.start);
                evnt.drawingRect.Width = actualWidth;
                evnt.drawingRect.Height = evnt.duration * rowHeight / 60;
            }
        }

        private void DrawEvents(PaintEventArgs e, IEnumerable<Event> selectedEvents, Brush brush)
        {
            // events with location determined
            foreach (Event evnt in selectedEvents)
            {
                e.Graphics.FillRectangle(brush, evnt.drawingRect);
                e.Graphics.DrawString($"{evnt.startString} {evnt.name}", eventFont, eventFontBrush, evnt.drawingRect);
                if (evnt == SelectedEvent.selectedEvent)
                    e.Graphics.DrawRectangle(selectedBorderPen, evnt.drawingRect);
            }
        }

        private void DrawTransfers(PaintEventArgs e, int transferBlockWidth)
        {
            if (SelectedEvent.selectedEvent != null && SelectedEvent.selectedEvent.day == day && SelectedEvent.selectedEvent.GPSLocation != null)
            {
                Transfer transferFromPrevious = trip.GetTransferFromPrevious(SelectedEvent.selectedEvent);
                if (transferFromPrevious != null)
                {
                    int duration = GetDuration(transferFromPrevious);
                    Point leftTop = new Point(Width - transferBlockWidth, PositionFromTime(SelectedEvent.selectedEvent.start - duration));
                    Size size = new Size(transferBlockWidth, HeightFromDuration(duration));
                    Rectangle fromRect = new Rectangle(leftTop, size);
                    e.Graphics.FillRectangle(transferTimeBrush, fromRect);
                }
                Transfer transferToNext = trip.GetTransferToNext(SelectedEvent.selectedEvent);
                if (transferToNext != null)
                {
                    int duration = GetDuration(transferToNext);
                    Point leftTop = new Point(Width - transferBlockWidth, SelectedEvent.selectedEvent.drawingRect.Bottom);
                    Size size = new Size(transferBlockWidth, HeightFromDuration(duration));
                    Rectangle toRect = new Rectangle(leftTop, size);
                    e.Graphics.FillRectangle(transferTimeBrush, toRect);
                }
            }
        }

        private void CalenderControl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

         private void CalenderControl_MouseDown(object sender, MouseEventArgs e)
        {
            Time clickTime = TimeFromPosition(e.Y);
            Event clickedEvent = trip.events.Where(x => x.day == day && x.drawingRect.Contains(e.Location)).FirstOrDefault();;
            if (clickedEvent != SelectedEvent.selectedEvent)
            {
                SelectedEvent.selectedEvent = clickedEvent;
                Invalidate(); // redraw the calender
            }
            if (SelectedEvent.selectedEvent != null)
            {
                SelectedEvent.dragOffset = e.Y - PositionFromTime(SelectedEvent.selectedEvent.start);
                SelectedEvent.dragInitialOffset = SelectedEvent.dragOffset;
                SelectedEvent.dragging = true;
            }
        }
 
        private void CalenderControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(SelectedEvent.dragging && SelectedEvent.selectedEvent != null && e.Button == MouseButtons.Left && SelectedEvent.dragOffset != e.Y - PositionFromTime(SelectedEvent.selectedEvent.start))
            {
                SelectedEvent.dragOffset = e.Y - PositionFromTime(SelectedEvent.selectedEvent.start);
                DragDropEffects dropEffect = DoDragDrop(SelectedEvent.selectedEvent, DragDropEffects.Move);
            }
        }

        private void CalenderControl_DragOver(object sender, DragEventArgs e)
        {
            Point clientPoint = PointToClient(new Point(e.X, e.Y));
            if (SelectedEvent.dragOffset != clientPoint.Y - PositionFromTime(SelectedEvent.selectedEvent.start))
            {
                SelectedEvent.dragOffset = clientPoint.Y - PositionFromTime(SelectedEvent.selectedEvent.start);
                Invalidate();
            }
        }

        private void CalenderControl_DragDrop(object sender, DragEventArgs e) // ToDS: allow for dragging from another source
        {
            Point clientPoint = PointToClient(new Point(e.X, e.Y)) ;
            SelectedEvent.selectedEvent.start = TimeFromPosition(clientPoint.Y - SelectedEvent.dragInitialOffset);
            SelectedEvent.dragging = false;
            CalculateOverlappingEvents();
            Invalidate();
        }

        private void CalenderControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void CalenderControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedEvent.selectedEvent == null)
            {
            }
        }

        private void CalenderControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedEvent.selectedEvent == null)
            {
                Time time = TimeFromPosition(e.Location.Y);
                if (time != null)
                {
                    Event evnt = new Event(trip, time);
                    CalculateOverlappingEvents();
                    Invalidate(); // redraw the calender
                    SelectedEvent.selectedEvent = evnt;
                }
            }
        }

       void HandleSelectedEventChanged(Event selectedEvent)
        {
            Invalidate();
        }

 
        /// <summary>
        /// Create clusters of overlapping events
        /// note that overlappingeventcluster is shared by all overlapping events..
        /// </summary>
        private void CalculateOverlappingEvents()
        {
            List<Event> OverlappingEvents = new List<Event>();
            foreach (var evnt in trip.events.Where(x => x.day == day))
                evnt.overlappingEventCluster = null;
            var orderedEvents = trip.events.Where(x => x.day == day).OrderBy(x => x.startString).ToList();
            if (orderedEvents.Count > 0)
            {
                foreach (Event evnt in orderedEvents.Where(x => x.day == day))
                {
                    if (evnt.overlappingEventCluster == null)
                    {
                        evnt.overlappingEventCluster = new List<Event>();
                        evnt.overlappingEventCluster.Add(evnt); // include yourself
                    }
                    foreach (Event overlappingEvent in trip.events.Where(x => x.day == day && evnt.Overlaps(x)))
                    {
                        if (!evnt.overlappingEventCluster.Contains(overlappingEvent))
                        {
                            evnt.overlappingEventCluster.Add(overlappingEvent);
                            overlappingEvent.overlappingEventCluster = evnt.overlappingEventCluster;
                        }
                    }
                }
            }
        }

        private Time TimeFromPosition(int y)
        {
            int rowHeight = Height / (trip.settings.endHour - trip.settings.startHour);
            int hour = (trip.settings.startHour + y / rowHeight);
            if (hour >= 24 || hour < 0)
                return null;
            y -= (hour - trip.settings.startHour) * rowHeight;
            int minute = (( (y* 60) / rowHeight)/ trip.settings.resolution) * trip.settings.resolution;
            return new Time(day, hour, minute);
        }

        private int PositionFromTime(Time time)
        {
            if (time == null)
                return 0;
            int rowHeight = Height / (trip.settings.endHour - trip.settings.startHour);
            return (time.hour - trip.settings.startHour) * rowHeight + rowHeight * time.minute / 60;
        }

        private int HeightFromDuration(int duration)
        {
           int rowHeight = Height / (trip.settings.endHour - trip.settings.startHour);
           return rowHeight * duration / 60;
        }

        private int GetDuration(Transfer transfer)
        {
            return trip.events.Where(x => x.day == day && x.GPSLocation == null && x.startMinute < transfer.endEvent.startMinute && x.startMinute >= transfer.startEvent.endMinute).Sum( x => x.duration) + transfer.duration;
        }

    }
}
