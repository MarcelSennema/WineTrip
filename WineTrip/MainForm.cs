﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WineTrip.DataModel;


namespace WineTrip
{
    public partial class MainForm : Form
    {
        private Trip trip = new Trip();
        private string filename = null;

        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            toolStrip.CausesValidation = true;
            tripBindingSource.DataSource = trip;
            InitCalenderTab();
            memberGridControl.Init(trip, this);
            detailsPanel.Visible = false;
        }

        private void InitCalenderTab()
        {
            calenderTabControl.TabPages.Clear();
            calenderTabControl.Dock = DockStyle.None;
            calenderTabControl.Height = 0;
            SelectedEvent.SelectedEventChangeHandler += selectedEventChanged;
            for (int i = 0; i < trip.numberOfDays; i++)
            {
                calenderTabControl.TabPages.Add(trip.startDate.AddDays(i).ToShortDateString());
                CalenderControl calenderControl = new CalenderControl(i, trip);
                calenderTabControl.TabPages[i].Controls.Add(calenderControl);
                calenderTabControl.TabPages[i].AutoScroll = true;
                calenderTabControl.TabPages[i].AllowDrop = true;
                calenderTabControl.TabPages[i].DragEnter += dragenterTabPageHandler;
                calenderControl.Dock = DockStyle.Fill;
                calenderControl.AllowDrop = true;
             }
             calenderTabControl.Dock = DockStyle.Fill;
        }

        private void LoadModel(string filePath)
        {
            Validate(); // make sure we have everything in the model
            var serializer = new DataContractSerializer(typeof(Trip));
            using (FileStream stream = File.OpenRead(filePath))
                trip = (Trip)serializer.ReadObject(stream);

            // backward compatibility initialisers
            foreach (Event evnt in trip.events)
            {
                if(evnt.tastingPayments == null)
                    evnt.tastingPayments = new ObservableCollection<Payment>();
                if(evnt.expenseParticipatingMembers == null)
                    evnt.expenseParticipatingMembers = new ObservableCollection<Member>();
                if (evnt.expensePayments == null)
                    evnt.expensePayments = new ObservableCollection<Payment>();
            }
            tripBindingSource.DataSource = trip;
            InitCalenderTab();
            memberGridControl.Init(trip, this);
            detailsPanel.Visible = false;
            Invalidate(true);
        }

        private void SaveModel(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(Trip));
            using (FileStream stream = File.Create(filePath))
            {
                serializer.WriteObject(stream, trip);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Validate();
                filename = openFileDialog.FileName;
                LoadModel(filename);
                toolStripFileName.Text = filename;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Validate();
            if (filename == null)
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                    SaveModel(filename);
                    toolStripFileName.Text = filename;
                }
            }
            else
            {
                SaveModel(filename);
                toolStripFileName.Text = filename;
            }
        }

        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            if (filename != null)
                saveFileDialog.FileName = filename;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                SaveModel(filename);
                toolStripFileName.Text = filename;
            }
        }


        private void textBoxNumberOfDays_Validated(object sender, EventArgs e)
        {
            if (trip.numberOfDays != calenderTabControl.TabPages.Count)
                InitCalenderTab();
        }

        private void selectedEventChanged(Event evnt)
        {
            if(evnt != null)
                eventBindingSource.DataSource = evnt;
            detailsPanel.Visible = (evnt != null);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Event evnt = (Event)eventBindingSource.DataSource;
            if (evnt != null)
            {
                trip.events.Remove(evnt);
                detailsPanel.Visible = false;
                SelectedEvent.selectedEvent = null;
                RefreshEventDataSource();
           }
        }

        private void buttonVerifyAdress_Click(object sender, EventArgs e)
        {
            Event evnt = (Event)eventBindingSource.DataSource;
            if (evnt.address != null && evnt.address != string.Empty)
            {
                GoogleMaps.VerifyAdress(evnt);
                GoogleMaps.GetSingleEventMap(evnt);
                RefreshEventDataSource();
            }
        }

        private void generic_Validated(object sender, EventArgs e)
        {
            calenderTabControl.SelectedTab.Invalidate(true);
        }

        private void RefreshEventDataSource()
        {
            eventBindingSource.ResetBindings(false);
            calenderTabControl.Invalidate(true);
            detailsPanel.Invalidate(true);
        }

        private void CalenderTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedEvent.selectedEvent = null;
        }

        private void dragenterTabPageHandler(object sender, DragEventArgs e)
        {
        }

        private void CalenderTabs_DragEnter(object sender, DragEventArgs e)
        {
            Event evnt = SelectedEvent.selectedEvent;
            string[] formats = e.Data.GetFormats(false);
            Point clientPoint = calenderTabControl.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < calenderTabControl.TabCount; i++)
            {
                if (calenderTabControl.GetTabRect(i).Contains(clientPoint))
                {
                    calenderTabControl.SelectedIndex = i;
                    SelectedEvent.selectedEvent = evnt;
                    break;
                }
            }
        }

        private void calenderTabControl_DragOver(object sender, DragEventArgs e)
        {
            Event evnt = SelectedEvent.selectedEvent;
            string[] formats = e.Data.GetFormats(false);
            Point clientPoint = calenderTabControl.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < calenderTabControl.TabCount; i++)
            {
                if (calenderTabControl.GetTabRect(i).Contains(clientPoint) && calenderTabControl.SelectedIndex != i)
                {
                    calenderTabControl.SelectedIndex = i;
                    SelectedEvent.selectedEvent = evnt;
                    break;
                }
            }

        }

        private void toolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            // ToDo: add visula clue we are recalculating
            trip.CalculateTransfers();
            RefreshEventDataSource();
        }

        private void buttonVisitWebSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SelectedEvent.selectedEvent.webSite);
        }

        private void buttonBottleOrder_Click(object sender, EventArgs e)
        {
            BottleOrderForm orderForm= new BottleOrderForm(trip, SelectedEvent.selectedEvent);
            orderForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Windows.Automation.AutomationElement.FromHandle(Handle); // for creating the on screen keyboard if in tablet mode
        }

        private void toolStripButtonMemberUpdate_Click(object sender, EventArgs e)
        {
            foreach (Member member in trip.members.Where(x => x.Email != null && x.Email != ""))
            {
                try
                {
                    string message = MemberUpdateMessage.CreateMessage(trip, member);
                    //WebBrowser webBrowser = new WebBrowser();
                    //webBrowser.webBrowserCtrl.DocumentText = message;
                    //webBrowser.ShowDialog();

                    Mailer.SendHtmlMail(member.Email, member.ShortName, "Wine trip report", message);
                }
                catch(Exception exception)
                {
                    MessageBox.Show($"Failed to sen email to {member.FullName}. Error: {exception.Message}");
                }
            }
        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(trip, SelectedEvent.selectedEvent);
            expenseForm.ShowDialog();
        }

        private void toolStripButtonCreateRoadBook_Click(object sender, EventArgs e)
        {
            string filename = $@"{ConfigurationManager.AppSettings["TempDir"]}\Road Book.pdf";
            RoadBookPDF.Create(trip, filename);
            Process.Start(filename);
        }


        //// todo: move this to a user control
        //private static Font memberNameFont = new Font(
        //     new FontFamily("Arial"),
        //     18,
        //     FontStyle.Regular,
        //     GraphicsUnit.Pixel);

        //private static Pen gridPen { get; } = Pens.DarkGray;
        //private static int memberRowHeight { get; } = 40;
        //private static int deleteIconSize = 25;
        //private static Brush memberNameBrush { get; } = Brushes.Black;

        //private void panelMember_Paint(object sender, PaintEventArgs e)
        //{
        //    panelMember.Height = Math.Max(memberRowHeight, trip.members.Count * memberRowHeight);
        //    StringFormat drawFormat = new StringFormat();
        //    int top = 0;
        //    foreach (Member member in trip.members)
        //    {
        //        Rectangle rect = new Rectangle(0, top, panelMember.Width, memberRowHeight);
        //        drawFormat.Alignment = StringAlignment.Near;
        //        drawFormat.LineAlignment = StringAlignment.Near;
        //        e.Graphics.DrawString($"{member.ShortName}", memberNameFont, memberNameBrush, rect, drawFormat);
        //        rect = new Rectangle(rect.Right - deleteIconSize, rect.Top, deleteIconSize, deleteIconSize);
        //         e.Graphics.DrawLine(gridPen, rect.Left, rect.Top, rect.Right, rect.Bottom);
        //        e.Graphics.DrawLine(gridPen, rect.Left, rect.Bottom, rect.Right, rect.Top);
        //        top += memberRowHeight;
        //    }
        //}
    }
}
