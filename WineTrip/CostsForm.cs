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
    public partial class CostsForm : Form
    {

        private Trip trip;
        private Event evnt;
        public CostsForm(Trip trip, Event evnt)
        {
            this.trip = trip;
            this.evnt = evnt;
            if (evnt.costsParticipatingMembers == null) // backward compatible...
                evnt.costsParticipatingMembers = new System.Collections.ObjectModel.ObservableCollection<Member>();
            InitializeComponent();
            Icon = Properties.Resources.logo;
            eventBindingSource.DataSource = evnt;
            int column = 0;
            int row = 0;
            foreach (Member member in trip.members)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Text = member.Name;
                checkbox.Tag = member;
                checkbox.Checked = evnt.costsParticipatingMembers.Count == 0 || evnt.costsParticipatingMembers.Contains(member); // default to participating
                panelMemberCheckboxes.Controls.Add(checkbox, column, row);
                panelMemberCheckboxes.RowCount += column;
                row += column; // only increment if we are in column number 1
                column = 1 - column; // switch between 0 and 1 
            }
        }

        private void CostsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validate();
            evnt.costsParticipatingMembers = new System.Collections.ObjectModel.ObservableCollection<Member>();
            foreach(Control control in panelMemberCheckboxes.Controls)
            {
                if (control is CheckBox && ((CheckBox)control).Checked && control.Tag is Member)
                    evnt.costsParticipatingMembers.Add((Member)control.Tag);
            }
        }
    }
}
