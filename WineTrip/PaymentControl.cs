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
    public delegate void PaymentButtonPressed(Payment payment);
    public partial class PaymentControl : UserControl
    {
        public PaymentControl(Payment payment, PaymentButtonPressed externalMethod)
        {
            paymentButtonpressed += externalMethod;
            InitializeComponent();
            paymentsBindingSource.DataSource = payment;
            buttonMember.Text = payment.member.ShortName;
        }
        private PaymentButtonPressed paymentButtonpressed;

        private void buttonMember_Click(object sender, EventArgs e)
        {
            paymentButtonpressed.Invoke((Payment)paymentsBindingSource.DataSource);
            paymentsBindingSource.ResetBindings(false);
        }
    }
}
