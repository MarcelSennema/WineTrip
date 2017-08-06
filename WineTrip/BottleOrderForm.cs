using System;
using System.Collections.Generic;
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
    public partial class BottleOrderForm : Form
    {
        private static Brush selectedOrderRectangleBrush { get; } = Brushes.Bisque;
        private static Brush orderFontBrush { get; } = Brushes.Black;
        private Pen gridPen { get; } = Pens.DarkGray;

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
        10,
        FontStyle.Regular,
        GraphicsUnit.Pixel);

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

        private int headerRowHeight = 50;
        private int footerRowHeight = 50;
        private int extraBodyHeight = 30; // space for the other attributes Todo: make this dynamic
        private int headerColumnWidth = 200;
        private int gridColumnWidth = 0;
        private int scrolledRows = 0;

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
            rowHeights.Add(headerRowHeight);
            foreach (Bottle bottle in evnt.bottles)
            {
                Size sz = CalcRowHeight(width, bottle);
                rowHeights.Add(sz.Height + extraBodyHeight);
            }
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
            CalcColumnWidths();
            // draw the grid
            int rightPos = 0;
            for (int i = 0; i < columnWidths.Count - 1; i++)
            {
                int leftpos = rightPos;
                rightPos += columnWidths[i];
                e.Graphics.DrawLine(gridPen, rightPos, 0, rightPos, gridPanel.ClientRectangle.Height);
            }
            int bottomPos = 0;
            for(int i = scrolledRows; i < rowHeights.Count - 1; i++)
            {
                int topPos = bottomPos;
                bottomPos += rowHeights[i];
                if (bottomPos > gridPanel.ClientRectangle.Height - footerRowHeight)
                    break;
                e.Graphics.DrawLine(gridPen, 0, bottomPos, gridPanel.ClientRectangle.Width, bottomPos);
            }
            e.Graphics.DrawLine(gridPen, 0, gridPanel.ClientRectangle.Height - footerRowHeight, gridPanel.ClientRectangle.Width, gridPanel.ClientRectangle.Height - footerRowHeight);
            // draw the header and footer cells
            int column = 1;
            StringFormat drawFormat = new StringFormat();
            Rectangle rect;
            foreach (Member member in trip.members)
            {
                rect = GetGridRectangle(0, column++);
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString($"{member.Name}", memberNameFont, orderFontBrush, rect, drawFormat);

                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                rect = new Rectangle(rect.Left, gridPanel.ClientRectangle.Height - footerRowHeight, rect.Width, rect.Height);
                e.Graphics.DrawString($"{evnt.TotalBottleCount(member):###}", countFont, orderFontBrush, rect, drawFormat);
                if (toolStripButtonShowPrice.Checked)
                {
                    drawFormat.LineAlignment = StringAlignment.Far;
                    e.Graphics.DrawString($"{evnt.TotalPrice(member):##0.00}", priceFont, orderFontBrush, rect, drawFormat);
                }
            }
            rect = GetGridRectangle(0, column);
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString($"Total", memberNameFont, orderFontBrush, rect, drawFormat);

            rect = new Rectangle(rect.Left, gridPanel.ClientRectangle.Height - footerRowHeight, rect.Width, rect.Height);
            e.Graphics.DrawString($"{evnt.TotalBottleCount(null):###}", countFont, orderFontBrush, rect, drawFormat);
            if (toolStripButtonShowPrice.Checked)
            {
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"{evnt.TotalPrice(null):##0.00}", priceFont, orderFontBrush, rect, drawFormat);
            }
            // draw the bottle cells
            int row = 1;
            foreach (Bottle bottle in evnt.bottles)
            {
                rect = GetGridRectangle(row, 0);
                if (rect.Bottom > gridPanel.ClientRectangle.Height - footerRowHeight)
                    break;
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString($"{bottle.name}", bottleNameFont, orderFontBrush, rect, drawFormat);
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"Vintage: {bottle.vintage:####} Size: {bottle.volume:0.00} Price: {bottle.price:##0.00}", attributeFont, orderFontBrush, rect, drawFormat);
                foreach(Order order in bottle.orders)
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
            rect = new Rectangle(0,gridPanel.ClientRectangle.Height - footerRowHeight, gridPanel.ClientRectangle.Width, gridPanel.ClientRectangle.Height - footerRowHeight);
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            e.Graphics.DrawString($"Total", bottleNameFont, orderFontBrush, rect, drawFormat);
            // draw the buttons for the focused cell
            if (currentRow != null && currentColumn != null)
            {
                rect = GetGridRectangle((int)currentRow, (int)currentColumn);
                foreach (RoundButton button in orderFocusButtons)
                    button.Draw(rect, e.Graphics, buttonSize, buttonPen, buttonTextBrush, buttonFont);
            }
        }

        private void gridPanel_Resize(object sender, EventArgs e)
        {
            gridPanel.Invalidate();
        }

        private void toolStripButtonShowPrice_Click(object sender, EventArgs e)
        {
            gridPanel.Invalidate();
        }

        private void ClearOrder()
        {
            if (currentRow != null && currentRow > 0 && currentColumn != null && currentColumn > 0)
            {
                Order order = evnt.bottles[(int)currentRow -1].orders.Where(x => x.member == trip.members[(int)currentColumn -1]).FirstOrDefault();
                if (order != null)
                {
                    evnt.bottles[(int)currentRow].orders.Remove(order);
                    Invalidate();
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
            Order order = evnt.bottles[(int)currentRow].orders.Where(x => x.member == trip.members[(int)currentColumn]).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { member = trip.members[(int)currentColumn], count = increment };
                evnt.bottles[(int)currentRow].orders.Add(order);
            }
            else
                order.count += increment;
            Invalidate();
        }

        private bool IsVisibleRow(int row)
        {
            if (row >= rowHeights.Count)
                return false;
            int height = 0;
            for (int i = 0; i <= row; i++)
                height += rowHeights[i];
            {
            }
            return height < gridPanel.ClientRectangle.Height - footerRowHeight;
        }

        private void gridPanel_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void gridPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SetCurrentCell(e.X, e.Y);
        }

        private void SetCurrentCell(int x, int y)
        {
            if (currentRow != null && currentRow != null)
                gridPanel.Invalidate(GetGridRectangle((int)currentRow, (int)currentColumn));
            int height = 0;
            int row = 0;
            while (row < rowHeights.Count && y > height + rowHeights[row])
            {
                height += rowHeights[row];
                row++;
            }
            int? newRow = IsVisibleRow(row) ? (int?)row : null;

            int width = 0;
            int col = 0;
            while (col < columnWidths.Count && x > width + columnWidths[col])
            {
                width += columnWidths[col];
                col++;
            }
            int? newColumn = col;
            if(currentRow == newRow && currentColumn == newColumn) // make clicking a selected cell unselected
            {
                newRow = null;
                newColumn = null;
            }
            currentRow = newRow;
            currentColumn = newColumn;

            if (currentRow != null && currentRow != null)
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
                if (buttonPressed) // we handled a button press, nothing else to do here
                    return;
                gridPanel.Invalidate(GetGridRectangle((int)currentRow, (int)currentColumn));
            }
        }
    }
}
