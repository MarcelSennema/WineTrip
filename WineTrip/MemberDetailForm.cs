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
        
    public partial class MemberDetailForm : Form
    {
        public delegate void Formclosed();
        private Formclosed formclosed;

        private Trip trip;

        public MemberDetailForm(Trip trip, Member member, Formclosed formclosed, Form parentForm)
        {
            this.trip = trip;
            this.formclosed += formclosed;
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parentForm.Location.X + (parentForm.Width - Width) / 2, parentForm.Location.Y + (parentForm.Height - Height) / 2);
            membersBindingSource.DataSource = member;
        }

        private void BottleDetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validate();
            formclosed.Invoke();
        }

    }
}
