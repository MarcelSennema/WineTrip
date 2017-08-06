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
    public partial class BottleRowHeaderControl : UserControl
    {
        public delegate void NameChanged(BottleRowHeaderControl bottleControl);
        public static event NameChanged NameChangedEvent; // the event raised when a the name of the bottle has changed

        public delegate void DeleteButtonClicked(BottleRowHeaderControl bottleControl);
        public static event DeleteButtonClicked deleteButtonClicked; // the event raised when a the delete button has been clicked

        public BottleRowHeaderControl(Bottle bottle)
        {
            InitializeComponent();
            // SetTextboxHeight(null);
            bottlesBindingSource.DataSource = bottle;
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            SetTextboxHeight(nameTextBox.Text);
            NameChangedEvent.Invoke(this); // just let the subscribers know that the text has changed
        }

        private void SetTextboxHeight(string text)
        {
            if(text == null || text == string.Empty)
                text = "Tg";
            Size sz = new Size(nameTextBox.ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = nameTextBox.Height - nameTextBox.ClientSize.Height;
            sz = TextRenderer.MeasureText(text, nameTextBox.Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (nameTextBox.Top + h > this.ClientSize.Height - 10)
            {
                h = this.ClientSize.Height - 10 - nameTextBox.Top;
            }
            if(nameTextBox.Height != h)
                nameTextBox.Height = h;
        }

        public bool canDelete
        {
            get { return deleteButton.Visible; }
            set { deleteButton.Visible = value; }
        }

        public Bottle bottle { get { return (Bottle)bottlesBindingSource.DataSource; } }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButtonClicked.Invoke(this); // let our parent handle this
        }
    }
}
