using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Payment> payments;
        decimal totalPrice;
        public PaymentForm(Trip trip, Decimal totalPrice, ObservableCollection<Payment> payments)
        {
            this.trip = trip;
            this.payments = payments;
            this.totalPrice = totalPrice;
            InitializeComponent();
            Icon = Properties.Resources.logo;
            foreach(Member member in trip.members)
            {
                Payment payment = payments.Where(x => x.member == member).FirstOrDefault();
                if (payment == null)
                {
                    payment = new Payment() { member = member };
                    payments.Add(payment);
                }
                panelPaymentControls.Controls.Add(new PaymentControl(payment, PaymentButtonPressed));
                panelPaymentControls.RowCount++;
            }
        }

        private void PaymentButtonPressed(Payment payment)
        {
            payment.amount = totalPrice - payments.Where(x => x.member != payment.member).Sum(x => x.amount);
        }

        /// <summary>
        /// remove the paymentrecords that do not have a value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<Payment> emptyPayments = payments.Where(x => x.amount == 0).ToList();
            foreach (Payment payment in emptyPayments)
                payments.Remove(payment);
        }
    }
}
