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
    public partial class EventDlg : Form
    {
        public Event evnt = null;
        public EventDlg(Trip trip, Time time)
        {
            InitializeComponent();
            evnt = new Event(trip);
            evnt.start = time;
            eventBindingSource.DataSource = evnt;
            Text = "Create a new event";
        }

        public EventDlg(Event evnt)
        {
            InitializeComponent();
            this.evnt = evnt;
            eventBindingSource.DataSource = evnt;
            Text = "Edit event";
        }

        private void Duration_Validating(object sender, CancelEventArgs e)
        {
            string errormessage = String.Empty;
            int minute;
            if (!int.TryParse(duration.Text, out minute) || minute < 0 || minute > 14440) 
            {
                errormessage = "Invalid duration, must be between 0 and 1440";
            }
            errorProvider.SetError(startTime, errormessage);

        }

        private void startTime_Validating(object sender, CancelEventArgs e)
        {
            string errormessage = String.Empty;
            if (Time.Create(evnt.day, startTime.Text)== null)
            {
                errormessage = "Invalid time format must be hh:mm, 0 < hh < 24 and 0 < mm < 59";
            }
            errorProvider.SetError(startTime, errormessage);
         }
    }
}
