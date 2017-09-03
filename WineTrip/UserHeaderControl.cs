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
    public partial class UserHeaderControl : UserControl
    {
        public Member member { get; }
        public UserHeaderControl(Member member)
        {
            InitializeComponent();
            this.member = member;
            nameLabel.Text = member.ShortName;
        }

        private void nameLabel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Height);
        }
    }
}
