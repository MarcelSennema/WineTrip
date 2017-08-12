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
        
    public partial class BottleDetailForm : Form
    {
        public delegate void Formclosed();
        private Formclosed formclosed;

        public BottleDetailForm(Bottle bottle, Formclosed formclosed, Form parentForm)
        {
            this.formclosed += formclosed;
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parentForm.Location.X + (parentForm.Width - Width) / 2, parentForm.Location.Y + (parentForm.Height - Height) / 2);
            bottlesBindingSource.DataSource = bottle;
            radioButtonRed.Checked = (bottle.wine == Bottle.Wine.red);
            radioButtonWhite.Checked = (bottle.wine == Bottle.Wine.white);
            radioButtonRose.Checked = (bottle.wine == Bottle.Wine.rose);
        }

        private void BottleDetailForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void BottleDetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validate();
            ((Bottle)bottlesBindingSource.DataSource).wine = radioButtonRed.Checked ? Bottle.Wine.red : radioButtonWhite.Checked ? Bottle.Wine.white : radioButtonRose.Checked ? Bottle.Wine.rose : Bottle.Wine.unspecified;
            formclosed.Invoke();
        }

    }
}
