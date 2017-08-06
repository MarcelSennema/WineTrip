using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineTrip.DataModel;

namespace WineTrip
{
    public partial class OrderForm : Form
    {
        private static Brush selectedOrderRectangleBrush { get; } = Brushes.Bisque;
        private static Brush orderFontBrush { get; } = Brushes.Black;

        private static Font countFont = new Font(
        new FontFamily("Arial"),
        18,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Font priceFont = new Font(
        new FontFamily("Arial"),
        10,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Brush buttonTextBrush = new SolidBrush(Color.Black);
        private static Brush buttonEraseBrush = new SolidBrush(Color.Red);
        private static Brush button6Brush = new SolidBrush(Color.YellowGreen);
        private static Brush button1Brush = new SolidBrush(Color.YellowGreen);
        private static int buttonSize = 31;
        private static Pen buttonPen = new Pen(Color.Gray, 2);
        private static Font buttonFont = new Font(
        new FontFamily("Arial"),
        14,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private List<RoundButton> orderFocusButtons = new List<RoundButton>();

        private Event evnt;
        private Trip trip;

        private TotalHeaderControl totalHeaderControl;
        private UserHeaderControl currentColumn = null;
        private BottleRowHeaderControl currentRow = null;

        public OrderForm(Trip trip, Event evnt)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.trip = trip;
            this.evnt = evnt;
            InitializeComponent();
            Icon = Properties.Resources.logo;
            Text = evnt.name;
            CreateMemberHeaders();
            CreateGrid();
            BottleRowHeaderControl.NameChangedEvent += BottleTextChanged; // let us know when the text of any bottle changes
            BottleRowHeaderControl.deleteButtonClicked += DeleteBottle; // let us know when the text of any bottle changes
            // just to make sure we get the initial layout correct...
            columnHeaderFillerPanel.Width = rowHeaderLayoutPanel.Width + rowHeaderSplitContainer.SplitterWidth;
            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.top, RoundButton.HorizontalPostition.left, "c", buttonEraseBrush, () => ClearOrder()));
            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.top, RoundButton.HorizontalPostition.right, "+1", button1Brush, () => Add1BottlesToOrder()));
            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.bottom, RoundButton.HorizontalPostition.right, "+6", button6Brush, () => Add6BottlesToOrder()));
        }
    

        private void CreateMemberHeaders()
        {
            columnHeaderLayoutPanel.SuspendLayout();
            columnHeaderLayoutPanel.Controls.Clear();
            columnHeaderLayoutPanel.ColumnCount = 1;
            Panel filler = new Panel();
            columnHeaderLayoutPanel.Controls.Add(filler);
            columnHeaderLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, buttonSize / 2);
            filler.Dock = DockStyle.Fill;
            columnHeaderLayoutPanel.ColumnCount++;
            if (trip.members.Count > 0)
            {
                foreach (Member member in trip.members)
                {
                    columnHeaderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    UserHeaderControl userHeaderControl = new UserHeaderControl(member);
                    columnHeaderLayoutPanel.Controls.Add(userHeaderControl);
                    userHeaderControl.Dock = DockStyle.Fill;
                    columnHeaderLayoutPanel.ColumnCount++;
                }
                totalHeaderControl = new TotalHeaderControl();
                columnHeaderLayoutPanel.Controls.Add(totalHeaderControl);
                columnHeaderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                totalHeaderControl.Dock = DockStyle.Fill;
            }
            columnHeaderLayoutPanel.ResumeLayout();
        }

        private void CreateGrid()
        {
            rowHeaderLayoutPanel.SuspendLayout();
            rowHeaderLayoutPanel.Controls.Clear();
            rowHeaderLayoutPanel.RowCount = 1; // creates an empty grid

            foreach (Bottle bottle in evnt.bottles)
            {
                NewBottleRow(bottle);
                rowHeaderLayoutPanel.RowCount++;
            }
            NewBottleRow(new Bottle(), false); // lastrow is empty
            rowHeaderLayoutPanel.ResumeLayout();
        }

        private void NewBottleRow(Bottle bottle, bool canDelete = true)
        {
            BottleRowHeaderControl bottleControl = new BottleRowHeaderControl(bottle);
            rowHeaderLayoutPanel.Controls.Add(bottleControl);
            bottleControl.Dock = DockStyle.Top;
            bottleControl.canDelete = canDelete;
        }



        private void BottleTextChanged(BottleRowHeaderControl bottleControl)
        {
            if(!evnt.bottles.Contains(bottleControl.bottle)) // if the name of a bottle changes and its not part of the collection, add it
            {
                evnt.bottles.Add(bottleControl.bottle);
                bottleControl.canDelete = true; // its part of the collection now, so it can be deleted
                NewBottleRow(new Bottle(), false);
            }
        }

        private void DeleteBottle(BottleRowHeaderControl bottleControl)
        {
            if (evnt.bottles.Contains(bottleControl.bottle)) // should always be there..
                evnt.bottles.Remove(bottleControl.bottle);
            CreateGrid();
        }

        private void bottleLayoutPanel_Resize(object sender, EventArgs e)
        {
            columnHeaderFillerPanel.Width = rowHeaderLayoutPanel.Width + rowHeaderSplitContainer.SplitterWidth;
            columnFooterFillerPanel.Width = rowHeaderLayoutPanel.Width + rowHeaderSplitContainer.SplitterWidth;
            rowHeaderSplitContainer.Height = rowHeaderLayoutPanel.Height;
        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            int vertScroll = rowHeaderLayoutPanel.AutoScrollPosition.Y;
            // draw the focus rectangle
            if(currentRow != null && currentColumn != null)
                 e.Graphics.FillRectangle(selectedOrderRectangleBrush, currentColumn.Left, currentRow.Top, currentColumn.Width, currentRow.Height);
            foreach (Control ctrl in columnHeaderLayoutPanel.Controls)
                if(ctrl is UserHeaderControl || ctrl is TotalHeaderControl) e.Graphics.DrawLine(Pens.DarkGray, ctrl.Left, 0, ctrl.Left, Height);
            foreach (Control ctrl in rowHeaderLayoutPanel.Controls)
                e.Graphics.DrawLine(Pens.DarkGray, 0, ctrl.Top, Width, ctrl.Top);
            foreach (Bottle bottle in evnt.bottles)
            {
                Rectangle? rect = GetTotalColumnPosition(bottle);
                if (rect != null)
                     DrawCountAndPrice(e, bottle.TotalOrderCount, bottle.TotalOrderPrice, rect);
                foreach (Order order in bottle.orders)
                {
                    rect = GetOrderPosition(bottle, order);
                    if (rect != null)
                        DrawCountAndPrice(e, order.count, order.count * bottle.price, rect);
                }
            }
            // draw the buttons for the focused cell
            if (currentRow != null && currentColumn != null)
            {
                Rectangle rect = new Rectangle(currentColumn.Left, currentRow.Top, currentColumn.Width, currentRow.Height);
                foreach(RoundButton button in orderFocusButtons)
                    button.Draw(rect, e.Graphics, buttonSize, buttonPen, buttonTextBrush, buttonFont);
            }
        }


        private void DrawButton(Rectangle focusRect, RoundButton.VerticalPostion verticalPosition, RoundButton.HorizontalPostition horizontalPostition, string text, Brush brush, PaintEventArgs e )
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int left = 0;
            int top = 0;
            switch (verticalPosition)
            {
                case RoundButton.VerticalPostion.top: top = focusRect.Top; break;
                case RoundButton.VerticalPostion.centre: top = focusRect.Top + (focusRect.Height + buttonSize) /2; break;
                case RoundButton.VerticalPostion.bottom: top = focusRect.Bottom - buttonSize; break;
            }
            switch (horizontalPostition)
            {
                case RoundButton.HorizontalPostition.left: left = focusRect.Left - buttonSize / 2; break;
                case RoundButton.HorizontalPostition.centre: left = focusRect.Left + (focusRect.Width + buttonSize) / 2; break;
                case RoundButton.HorizontalPostition.right: left = focusRect.Right - buttonSize / 2; break;
            }                 
            Rectangle drawingRect = new Rectangle(left, top, buttonSize, buttonSize);
            drawingRect.Inflate(-2, -2);
            e.Graphics.FillEllipse(brush, drawingRect);
            e.Graphics.DrawEllipse(buttonPen, drawingRect);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString($"{text}", buttonFont, buttonTextBrush, (Rectangle)drawingRect, drawFormat);
        }

        private void DrawCountAndPrice(PaintEventArgs e, int count, decimal price, Rectangle? rect)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString($"{count}", countFont, orderFontBrush, (Rectangle)rect, drawFormat);
            if (showPriceCheckBox.Checked)
            {
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"{price}", priceFont, orderFontBrush, (Rectangle)rect, drawFormat);
            }
        }

        private Rectangle? GetOrderPosition(Bottle bottle, Order order)
        {
            int left = 0, top = 0, width = 0, height = 0;
            bool found = false;
            foreach (Control ctrl in columnHeaderLayoutPanel.Controls)
                if (ctrl is UserHeaderControl && ((UserHeaderControl)ctrl).member == order.member)
                {
                    left = ctrl.Left;
                    width = ctrl.Width;
                    found = true;
                    break;
                }
            if (!found)
                return null;
            found = false;
            foreach (Control ctrl in rowHeaderLayoutPanel.Controls)
                if (ctrl is BottleRowHeaderControl && ((BottleRowHeaderControl)ctrl).bottle == bottle)
                {
                    top = ctrl.Top;
                    height = ctrl.Height;
                    found = true;
                }
            if (!found)
                return null;
            return new Rectangle(left, top, width, height);
        }

        private Rectangle? GetTotalColumnPosition(Bottle bottle)
        {
            int left = totalHeaderControl.Left, top = 0, width = totalHeaderControl.Width, height = 0;
            bool found = false;
            foreach (Control ctrl in rowHeaderLayoutPanel.Controls)
                if (ctrl is BottleRowHeaderControl && ((BottleRowHeaderControl)ctrl).bottle == bottle)
                {
                    top = ctrl.Top;
                    height = ctrl.Height;
                    found = true;
                }
            if (!found)
                return null;
            return new Rectangle(left, top, width, height);
        }

        private Rectangle? GetTotalRowPosition(Member member)
        {
            int left = 0, top = 0, width = 0, height = columnFooterLayoutPanel.Height;
            bool found = false;
            foreach (Control ctrl in columnHeaderLayoutPanel.Controls)
                if (ctrl is UserHeaderControl && ((UserHeaderControl)ctrl).member == member)
                {
                    left = ctrl.Left;
                    width = ctrl.Width;
                    found = true;
                }
            if (!found)
                return null;
            return new Rectangle(left, top, width, height);
        }

        private void gridPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentRow != null && currentColumn != null)
            {
                bool buttonPressed = false;
                int i = 0;
                while(!buttonPressed && i < orderFocusButtons.Count())
                {
                    RoundButton button = orderFocusButtons[i];
                    if(button.GetButtonRegion(new Rectangle(currentColumn.Left, currentRow.Top, currentColumn.Width, currentRow.Height), buttonSize).IsVisible(e.Location))
                    {
                        buttonPressed = true;
                        button.Invoke();
                    }
                    i++;
                }
                if (buttonPressed) // we handled a button press, nothing else to do here
                    return;
                gridPanel.Invalidate(new Rectangle(currentColumn.Left - buttonSize, currentRow.Top, currentColumn.Width + buttonSize * 2, currentRow.Height));
            }
            Control columnCtrl = columnHeaderLayoutPanel.GetChildAtPoint(new Point(e.X, 0));
            Control rowCtrl = rowHeaderLayoutPanel.GetChildAtPoint(new Point(0, e.Y));
            if (rowCtrl is BottleRowHeaderControl && columnCtrl is UserHeaderControl && (rowCtrl != currentRow || columnCtrl != currentColumn))
            {
                currentRow = (BottleRowHeaderControl) rowCtrl;
                currentColumn = (UserHeaderControl) columnCtrl;
            }
            else
            {
                currentRow = null;
                currentColumn = null;
            }
            if (currentRow != null && currentColumn != null)
                gridPanel.Invalidate(new Rectangle(currentColumn.Left - buttonSize, currentRow.Top, currentColumn.Width + buttonSize * 2, currentRow.Height));
        }

        private void showPriceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gridPanel.Invalidate();
            columnFooterLayoutPanel.Invalidate();
        }

        private void ClearOrder()
        {
            if(currentRow != null && currentColumn != null)
            {
                Order order = currentRow.bottle.orders.Where(x => x.member == currentColumn.member).FirstOrDefault();
                if (order != null)
                {
                    currentRow.bottle.orders.Remove(order);
                    InvalidateCurrentCellAndTotal();
                }
            }
        }

        private void Add6BottlesToOrder()
        {
            AddBottlesToOrder(6);
        }


        private void Add1BottlesToOrder()
        {
            AddBottlesToOrder(1);
        }

        private void AddBottlesToOrder(int increment)
        {
            Order order = currentRow.bottle.orders.Where(x => x.member == currentColumn.member).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { member = currentColumn.member, count = increment };
                currentRow.bottle.orders.Add(order);
            }
            else
                order.count += increment;
            InvalidateCurrentCellAndTotal();
        }

        private void InvalidateCurrentCellAndTotal()
        {
            gridPanel.Invalidate(new Rectangle(currentColumn.Left - buttonSize, currentRow.Top, currentColumn.Width + buttonSize * 2, currentRow.Height));
            gridPanel.Invalidate(new Rectangle(totalHeaderControl.Left, currentRow.Top, totalHeaderControl.Width, currentRow.Height));
            columnFooterLayoutPanel.Invalidate();
        }

        private void rowHeaderLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            gridPanel.Invalidate();
        }

        private void columnFooterLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle? rect;

            foreach (Member member in trip.members)
            {
                rect = GetTotalRowPosition(member);
                if (rect != null)
                    DrawCountAndPrice(e, evnt.TotalBottleCount(member), evnt.TotalPrice(member), rect);
            }
            rect = new Rectangle(totalHeaderControl.Left, 0, totalHeaderControl.Width, columnFooterLayoutPanel.Height);
            DrawCountAndPrice(e, evnt.TotalBottleCount(null), evnt.TotalPrice(null), rect);
        }

        private void buttonCreatePDF_Click(object sender, EventArgs e)
        {
            OrderPDF orderPDF = new OrderPDF();
            orderPDF.Create(trip, evnt);
        }

        private void buttonPayments_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(trip,  evnt);
            paymentForm.ShowDialog();
        }

        private void OrderForm_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
