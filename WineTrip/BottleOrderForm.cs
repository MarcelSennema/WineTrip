using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineTrip.DataModel;

namespace WineTrip
{
    public partial class BottleOrderForm : Form
    {
        private static Brush selectedOrderRectangleBrush { get; } = Brushes.Bisque;
        private static Brush orderFontBrush { get; } = Brushes.Black;
        private static Brush focusBrush { get; } = new SolidBrush(Color.FromArgb(80, Color.LightBlue));
        private static Pen gridPen { get; } = Pens.DarkGray;

        private static Font memberNameFont = new Font(
        new FontFamily("Arial"),
        12,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Font bottleNameFont = new Font(
        new FontFamily("Arial"),
        18,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Font attributeFont = new Font(
        new FontFamily("Arial"),
        12,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Font countFont = new Font(
        new FontFamily("Arial"),
        18,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

        private static Font priceFont = new Font(
        new FontFamily("Arial"),
        12,
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

        private static int extraBodyHeight = 70; // space for the other attributes Todo: make this dynamic
        private static int headerColumnWidth = 200;
        private static int gridColumnWidth = 0;
        private static int deleteIconSize = 25;


        private List<RoundButton> orderFocusButtons = new List<RoundButton>();

        private Event evnt;
        private Trip trip;


        private List<int> rowHeights = new List<int>();
        private List<int> columnWidths = new List<int>();

        // the currentcell
        int? currentRow = null;
        int? currentColumn = null;

        public BottleOrderForm(Trip trip, Event evnt)
        {
            this.trip = trip;
            this.evnt = evnt;
            InitializeComponent();
            Icon = Properties.Resources.logo;
            Text = evnt.name;

            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.top, RoundButton.HorizontalPostition.left, "c", buttonEraseBrush, () => ClearOrder()));
            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.top, RoundButton.HorizontalPostition.right, "+1", button1Brush, () => Add1BottlesToOrder()));
            orderFocusButtons.Add(new RoundButton(RoundButton.VerticalPostion.bottom, RoundButton.HorizontalPostition.right, "+6", button6Brush, () => Add6BottlesToOrder()));

            CalcRowHeights(headerColumnWidth);
        }

        private void CalcRowHeights(int width) // depends on the size of the rowheader text
        {
            rowHeights = new List<int>();
            foreach (Bottle bottle in evnt.bottles)
            {
                Size sz = CalcRowHeight(width, bottle);
                rowHeights.Add(sz.Height + extraBodyHeight);
            }
            gridPanel.Height = rowHeights.Sum(x => x);
         }

        private static Size CalcRowHeight(int width, Bottle bottle)
        {
            string text = bottle.name;
            if (text == null || text == string.Empty)
                text = "Tg";
            Size sz = new Size(width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            sz = TextRenderer.MeasureText(text, bottleNameFont, sz, flags);
            return sz;
        }

        private void CalcColumnWidths()
        {
            columnWidths = new List<int>();
            columnWidths.Add(headerColumnWidth);
            gridColumnWidth = (ClientRectangle.Width - headerColumnWidth) / (trip.members.Count + 1);
            for (int i = 0; i < trip.members.Count; i++)
                columnWidths.Add(gridColumnWidth);
            columnWidths.Add(gridColumnWidth); // total column
        }

        private Rectangle GetGridRow(int row)
        {
            int top = 0;
            for (int i = 0; i < row; i++)
                top += rowHeights[i];
            return new Rectangle(0, top, gridPanel.ClientRectangle.Width, rowHeights[row]);
        }

        private Rectangle GetGridColumn(int column)
        {
            int left = 0;
            for (int i = 0; i < column; i++)
                left += columnWidths[i];
            return new Rectangle(left,0, columnWidths[column], gridPanel.ClientRectangle.Height);
        }


        private Rectangle GetGridRectangle(int row, int column)
        {
            int left = 0, top = 0;
            for (int i = 0; i < column; i++)
                left += columnWidths[i];
            for (int i = 0; i < row; i++)
                top += rowHeights[i];
            return new Rectangle(left, top, columnWidths[column], rowHeights[row]);
        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect;
            // draw the focus background
            if (currentRow != null && currentRow >= 0)
                e.Graphics.FillRectangle(focusBrush, GetGridRow((int)currentRow));
            if (currentColumn != null && currentColumn > 0)
                e.Graphics.FillRectangle(focusBrush, GetGridColumn((int)currentColumn));
            // draw the grid
            int rightPos = 0;
            for (int i = 0; i < columnWidths.Count - 1; i++)
            {
                int leftpos = rightPos;
                rightPos += columnWidths[i];
                e.Graphics.DrawLine(gridPen, rightPos, 0, rightPos, gridPanel.ClientRectangle.Height);
            }
            int bottomPos = 0;
            for(int i = 0; i < rowHeights.Count - 1; i++)
            {
                int topPos = bottomPos;
                bottomPos += rowHeights[i];
                e.Graphics.DrawLine(gridPen, 0, bottomPos, gridPanel.ClientRectangle.Width, bottomPos);
            }
            // draw the bottle cells
            StringFormat drawFormat = new StringFormat();
            int row = 0, column = 1;
            foreach (Bottle bottle in evnt.bottles)
            {
                rect = GetGridRectangle(row, 0);
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString($"{bottle.name}\n{bottle.vintage:####}", bottleNameFont, orderFontBrush, rect, drawFormat);
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"Size: {bottle.volume:0.00}\nPrice: {bottle.price:##0.00}", attributeFont, orderFontBrush, rect, drawFormat);
                rect = new Rectangle(rect.Right - deleteIconSize, rect.Top, deleteIconSize, deleteIconSize);
                // e.Graphics.DrawRectangle(gridPen, rect);
                e.Graphics.DrawLine(gridPen, rect.Left, rect.Top, rect.Right, rect.Bottom);
                e.Graphics.DrawLine(gridPen, rect.Left, rect.Bottom, rect.Right, rect.Top);

                foreach (Order order in bottle.orders)
                {
                    column = trip.members.IndexOf(order.member) + 1;
                    rect = GetGridRectangle(row, column);
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString($"{order.count:###}", countFont, orderFontBrush, rect, drawFormat);
                    if(toolStripButtonShowPrice.Checked)
                    {
                        drawFormat.LineAlignment = StringAlignment.Far;
                        e.Graphics.DrawString($"{order.count * bottle.price:##0.00}", priceFont, orderFontBrush, rect, drawFormat);
                    }
                }
                // total column
                rect = GetGridRectangle(row, columnWidths.Count-1);
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString($"{bottle.TotalOrderCount:###}", countFont, orderFontBrush, rect, drawFormat);
                if (toolStripButtonShowPrice.Checked)
                {
                    drawFormat.LineAlignment = StringAlignment.Far;
                    e.Graphics.DrawString($"{bottle.TotalOrderPrice:##0.00}", priceFont, orderFontBrush, rect, drawFormat);
                }
                row++;
            }
             // draw the buttons for the focused cell
            if (currentRow != null && currentColumn != null && currentColumn > 0)
            {
                rect = GetGridRectangle((int)currentRow, (int)currentColumn);
                foreach (RoundButton button in orderFocusButtons)
                    button.Draw(rect, e.Graphics, buttonSize, buttonPen, buttonTextBrush, buttonFont);
            }
        }

        private void gridPanel_Resize(object sender, EventArgs e)
        {
            gridPanel.Invalidate();
            bottomPanel.Invalidate();
            topPanel.Invalidate();
            CalcColumnWidths();
        }

        private void toolStripButtonShowPrice_Click(object sender, EventArgs e)
        {
            gridPanel.Invalidate();
        }

        private void ClearOrder()
        {
            if (currentRow != null && currentRow > 0 && currentColumn != null && currentColumn > 0)
            {
                Order order = evnt.bottles[(int)currentRow].orders.Where(x => x.member == trip.members[(int)currentColumn -1]).FirstOrDefault();
                if (order != null)
                {
                    evnt.bottles[(int)currentRow].orders.Remove(order);
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
            Order order = evnt.bottles[(int)currentRow].orders.Where(x => x.member == trip.members[(int)currentColumn-1]).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { member = trip.members[(int)currentColumn -1], count = increment };
                evnt.bottles[(int)currentRow].orders.Add(order);
            }
            else
                order.count += increment;
        }

        int? mousedown = null;
        private void gridPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                mousedown = e.Y;
        }

        private void gridPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousedown != null)
            {
                int diff = e.Y - (int)mousedown;

            }
            else
                mousedown = null;
        }

        private void gridPanel_MouseClick(object sender, MouseEventArgs e)
        {
            int? newRow = RowFromY(e.Y);
            int? newColumn = ColFromX(e.X);
            SetCurrentCell(newRow, newColumn, e.X, e.Y);
            if(newColumn == 0 && newRow != null)
            {
                Bottle bottle = evnt.bottles[(int)newRow];
                Rectangle rect = GetGridRectangle((int)newRow, (int)newColumn);
                rect = new Rectangle(rect.Right - deleteIconSize, rect.Top, deleteIconSize, deleteIconSize);
                if(new Region(rect).IsVisible(e.Location)) // delete button pressed
                {
                    evnt.bottles.Remove(bottle);
                    if (currentRow >= evnt.bottles.Count)
                        currentRow = evnt.bottles.Count > 0 ? (int?)evnt.bottles.Count - 1 : null;
                    RefreshGrid();
                }
                else
                {
                    BottleDetailForm bottleDetailForm = new BottleDetailForm(trip, bottle, RefreshGrid, this);
                    bottleDetailForm.Show(this);
                }
            }
        }

        private void SetCurrentCell(int? newRow, int? newColumn, int x, int y)
        {
            if (currentRow == newRow && currentColumn == newColumn) // make clicking a selected cell unselected
            {
                if (currentRow != null && currentColumn != null && currentColumn > 0)
                {
                    bool buttonPressed = false;
                    int i = 0;
                    while (!buttonPressed && i < orderFocusButtons.Count())
                    {
                        RoundButton button = orderFocusButtons[i];
                        if (button.GetButtonRegion(GetGridRectangle((int)currentRow, (int)currentColumn), buttonSize).IsVisible(x, y))
                        {
                            buttonPressed = true;
                            button.Invoke();
                        }
                        i++;
                    }
                    if (buttonPressed)
                    {
                        gridPanel.Invalidate();
                        return;
                    }
                    newRow = null;
                    newColumn = null;
                }
            }
            currentRow = newRow;
            currentColumn = newColumn;
            if (currentRow != null && currentRow != null)
                gridPanel.Invalidate();
        }

        private int ColFromX(int x)
        {
            int width = 0;
            int col = 0;
            while (col < columnWidths.Count && x > width + columnWidths[col])
            {
                width += columnWidths[col];
                col++;
            }

            return col;
        }

        private int RowFromY(int y)
        {
            int height = 0;
            int row = 0;
            while (row < rowHeights.Count && y > height + rowHeights[row])
            {
                height += rowHeights[row];
                row++;
            }

            return row;
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(gridPen, 0, topPanel.ClientRectangle.Height-1, topPanel.ClientRectangle.Width, topPanel.ClientRectangle.Height-1);
            Rectangle rect;
            int column = 1;
            int left = columnWidths[0];
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            foreach (Member member in trip.members)
            {
                e.Graphics.DrawLine(gridPen, left, 0, left, topPanel.ClientRectangle.Height);
                rect = new Rectangle(left, 0, columnWidths[column], topPanel.ClientRectangle.Height);
                e.Graphics.DrawString($"{member.Name}", memberNameFont, orderFontBrush, rect, drawFormat);
                left += columnWidths[column++];
            }
            e.Graphics.DrawLine(gridPen, left, 0, left, topPanel.ClientRectangle.Height);
            rect = new Rectangle(left, 0, columnWidths[column], topPanel.ClientRectangle.Height);
            e.Graphics.DrawString($"Total", memberNameFont, orderFontBrush, rect, drawFormat);
        }

        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(gridPen, 0, 0, bottomPanel.ClientRectangle.Width, 0);
            Rectangle rect;
            int column = 0;
            int left = 0;
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Center;
            rect = new Rectangle(left, 0, columnWidths[column++], bottomPanel.ClientRectangle.Height);
            e.Graphics.DrawString("Total", bottleNameFont, orderFontBrush, rect, drawFormat);

            drawFormat.Alignment = StringAlignment.Center;
            left = columnWidths[0];
            foreach (Member member in trip.members)
            {
                e.Graphics.DrawLine(gridPen, left, 0, left, bottomPanel.ClientRectangle.Height);
                drawFormat.LineAlignment = StringAlignment.Center;
                rect = new Rectangle(left, 0, columnWidths[column], bottomPanel.ClientRectangle.Height);
                e.Graphics.DrawString($"{evnt.TotalBottleCount(member):###}", countFont, orderFontBrush, rect, drawFormat);
                if (toolStripButtonShowPrice.Checked)
                {
                    drawFormat.LineAlignment = StringAlignment.Far;
                    e.Graphics.DrawString($"{evnt.TotalPrice(member):##0.00}", priceFont, orderFontBrush, rect, drawFormat);
                }
                left += columnWidths[column++];
            }
            e.Graphics.DrawLine(gridPen, left, 0, left, bottomPanel.ClientRectangle.Height);
            drawFormat.LineAlignment = StringAlignment.Center;
            rect = new Rectangle(left, 0, columnWidths[column], bottomPanel.ClientRectangle.Height);
            e.Graphics.DrawString($"{evnt.TotalBottleCount(null):###}", countFont, orderFontBrush, rect, drawFormat);
            if (toolStripButtonShowPrice.Checked)
            {
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"{evnt.TotalPrice(null):##0.00}", priceFont, orderFontBrush, rect, drawFormat);
            }
        }

        private void buttonAddBottle_Click(object sender, EventArgs e)
        {
            Bottle bottle = new Bottle();
            evnt.bottles.Add(bottle);
            CalcRowHeights(headerColumnWidth);
            BottleDetailForm bottleDetailForm = new BottleDetailForm(trip, bottle, RefreshGrid, this);
            bottleDetailForm.ShowDialog();
        }

        private void RefreshGrid()
        {
            CalcRowHeights(headerColumnWidth);
            gridPanel.Invalidate();
        }

        private void toolStripButtonCreatePDF_Click(object sender, EventArgs e)
        {
            string filename = "order.pdf";
            OrderPDF orderPDF = new OrderPDF();
            orderPDF.Create(trip, evnt, filename);
            Process.Start(filename);
        }

        private void toolStripButtonSendOrderMail_Click(object sender, EventArgs e)
        {
            string filename = "order.pdf";
            OrderPDF orderPDF = new OrderPDF();
            orderPDF.Create(trip, evnt,filename);
            Mailer.SendMail(evnt.eMail, evnt.name, "Order", "Dear Sir or Madam,\n\nAttached you will find the order of our group.\n\nCheers,\nMarcel Sennema\n", filename);
        }

        private void toolStripButtonPayments_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(trip, evnt.TotalPrice(null), evnt.tastingPayments);
            paymentForm.ShowDialog();
        }
    }
}
