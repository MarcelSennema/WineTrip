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
    public partial class PaymentForm : Form
    {
        private Trip trip;
        private Event evnt;
        public PaymentForm(Trip trip, Event evnt)
        {
            this.trip = trip;
            this.evnt = evnt;
            InitializeComponent();
            Icon = Properties.Resources.logo;
            foreach(Member member in trip.members)
            {
                Payment payment = evnt.payments.Where(x => x.member == member).FirstOrDefault();
                if (payment == null)
                {
                    payment = new Payment() { member = member };
                    evnt.payments.Add(payment);
                }
                panelPaymentControls.Controls.Add(new PaymentControl(payment, PaymentButtonPressed));
                panelPaymentControls.RowCount++;
            }
        }

        private void PaymentButtonPressed(Payment payment)
        {
            payment.amount = evnt.TotalPrice(null) - evnt.payments.Where(x => x.member != payment.member).Sum(x => x.amount);
        }

        /// <summary>
        /// remove the paymentrecords that do not have a value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<Payment> emptyPayments = evnt.payments.Where(x => x.amount == 0).ToList();
            foreach (Payment payment in emptyPayments)
                evnt.payments.Remove(payment);
        }
    }
}
