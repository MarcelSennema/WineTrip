using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip
{

    public class RoundButton
    {
        public enum VerticalPostion { top, centre, bottom }
        public enum HorizontalPostition { left, centre, right }
        public delegate void ButtonAction();


        private VerticalPostion verticalPosition;
        private HorizontalPostition horizontalPostition;
        private string text;
        private Brush brush;
        private ButtonAction buttonAction;

        public RoundButton(VerticalPostion verticalPosition, HorizontalPostition horizontalPostition, string text, Brush brush, ButtonAction buttonAction)
        {
            this.verticalPosition = verticalPosition;
            this.horizontalPostition = horizontalPostition;
            this.text = text;
            this.brush = brush;
            this.buttonAction = buttonAction;
        }

        public void Draw(Rectangle rect, Graphics graphics, int buttonSize, Pen buttonPen, Brush buttonTextBrush, Font buttonFont)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle drawingRect = GetDrawingRect(rect, buttonSize);
            graphics.FillEllipse(brush, drawingRect);
            graphics.DrawEllipse(buttonPen, drawingRect);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            graphics.DrawString($"{text}", buttonFont, buttonTextBrush, (Rectangle)drawingRect, drawFormat);

        }

        private Rectangle GetDrawingRect(Rectangle rect, int buttonSize)
        {
            int left = 0;
            int top = 0;
            switch (verticalPosition)
            {
                case VerticalPostion.top: top = rect.Top; break;
                case VerticalPostion.centre: top = rect.Top + (rect.Height - buttonSize) / 2; break;
                case VerticalPostion.bottom: top = rect.Bottom - buttonSize; break;
            }
            switch (horizontalPostition)
            {
                //case HorizontalPostition.left: left = rect.Left - buttonSize / 2; break;
                case HorizontalPostition.left: left = rect.Left ; break;
                case HorizontalPostition.centre: left = rect.Left + (rect.Width - buttonSize) / 2; break;
                // case HorizontalPostition.right: left = rect.Right - buttonSize / 2; break;
                case HorizontalPostition.right: left = rect.Right - buttonSize; break;
            }
            Rectangle drawingRect = new Rectangle(left, top, buttonSize, buttonSize);
            drawingRect.Inflate(-2, -2);
            return drawingRect;
        }

        public Region GetButtonRegion(Rectangle rect, int buttonSize)
        {
            Rectangle drawingRect = GetDrawingRect(rect, buttonSize);
            var path = new GraphicsPath();
            path.AddEllipse(drawingRect);
            return new Region(path);
        }

        public void Invoke()
        {
            buttonAction.Invoke();
        }
    }
}
