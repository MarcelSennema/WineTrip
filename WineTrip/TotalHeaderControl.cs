using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WineTrip
{
    public partial class TotalHeaderControl : UserControl
    {
        public TotalHeaderControl()
        {
            InitializeComponent();
        }

        private void totalLabel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Height);
        }
    }
}
