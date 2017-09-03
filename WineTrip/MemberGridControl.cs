using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineTrip.DataModel;

namespace WineTrip
{
    public partial class MemberGridControl : UserControl
    {
        private static Font memberNameFont = new Font(
             new FontFamily("Arial"),
             18,
             FontStyle.Regular,
             GraphicsUnit.Pixel);

        private static Font memberAdditionalInfoFont = new Font(
             new FontFamily("Arial"),
             12,
             FontStyle.Regular,
             GraphicsUnit.Pixel);

        private static Pen gridPen { get; } = Pens.DarkGray;
        private static int memberRowHeight { get; } = 40;
        private static int deleteIconSize = 25;
        private static Brush memberNameBrush { get; } = Brushes.Black;

        public MemberGridControl()
        {
            InitializeComponent();
        }

        private Trip trip;
        private Form hostForm;

        public void Init(Trip trip, Form hostForm)
        {
            this.trip = trip;
            this.hostForm = hostForm;
            if (trip != null)
                panelMember.Height = Math.Max(memberRowHeight, this.trip.members.Count * memberRowHeight);
            panelMember.Invalidate();
        }


        private void panelMember_Paint(object sender, PaintEventArgs e)
        {
            if (trip == null) return; // designer mode
            StringFormat drawFormat = new StringFormat();
            int top = 0;
            foreach (Member member in trip.members)
            {
                Rectangle rect = new Rectangle(0, top, panelMember.Width, memberRowHeight);
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString($"{member.FullName}", memberNameFont, memberNameBrush, rect, drawFormat);
                drawFormat.LineAlignment = StringAlignment.Far;
                e.Graphics.DrawString($"{member.Email} {member.PhoneNumber}", memberAdditionalInfoFont, memberNameBrush, rect, drawFormat);
                rect = new Rectangle(rect.Right - deleteIconSize, rect.Top, deleteIconSize, deleteIconSize);
                e.Graphics.DrawLine(gridPen, rect.Left, rect.Top, rect.Right, rect.Bottom);
                e.Graphics.DrawLine(gridPen, rect.Left, rect.Bottom, rect.Right, rect.Top);
                top += memberRowHeight;
            }
        }

        private void panelMember_MouseClick(object sender, MouseEventArgs e)
        {
            int row = e.Y / memberRowHeight;
            if (row >= 0 && row < trip.members.Count)
            {
                Rectangle rect = new Rectangle(0, row * memberRowHeight, panelMember.Width, memberRowHeight);
                rect = new Rectangle(rect.Right - deleteIconSize, rect.Top, deleteIconSize, deleteIconSize);
                if (new Region(rect).IsVisible(e.Location)) // delete button pressed
                {
                    if (trip.events.SelectMany(x => x.bottles).SelectMany(x => x.orders).Where(x => x.member == trip.members[row]).Any())
                        MessageBox.Show("This member has placed orders and can not be removed");
                    else
                    {
                        trip.members.RemoveAt(row);
                        RefreshGrid();
                    }
                }
                else
                {
                    MemberDetailForm memberDetailForm = new MemberDetailForm(trip, trip.members[row], RefreshGrid, hostForm);
                    memberDetailForm.ShowDialog(this);
                }
            }
        }

        private void RefreshGrid()
        {
            panelMember.Height = Math.Max(memberRowHeight, this.trip.members.Count * memberRowHeight);
            panelMember.Invalidate();
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            trip.members.Add(member);
            MemberDetailForm memberDetailForm = new MemberDetailForm(trip, member, RefreshGrid, hostForm);
            memberDetailForm.ShowDialog(this);
        }

 
        private void MemberGridControl_Resize(object sender, EventArgs e)
        {
            panelMember.Invalidate();
        }
    }
}
