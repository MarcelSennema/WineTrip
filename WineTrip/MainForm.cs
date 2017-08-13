using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WineTrip.DataModel;


namespace WineTrip
{
    public partial class MainForm : Form
    {
        private Trip trip = new Trip();
        private string filename = null;

        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            toolStrip.CausesValidation = true;
            tripBindingSource.DataSource = trip;
            InitCalenderTab();
            detailsPanel.Visible = false;
        }

        private void InitCalenderTab()
        {
            calenderTabControl.TabPages.Clear();
            calenderTabControl.Dock = DockStyle.None;
            calenderTabControl.Height = 0;
            SelectedEvent.SelectedEventChangeHandler += selectedEventChanged;
            for (int i = 0; i < trip.numberOfDays; i++)
            {
                calenderTabControl.TabPages.Add(trip.startDate.AddDays(i).ToShortDateString());
                CalenderControl calenderControl = new CalenderControl(i, trip);
                calenderTabControl.TabPages[i].Controls.Add(calenderControl);
                calenderTabControl.TabPages[i].AutoScroll = true;
                calenderTabControl.TabPages[i].AllowDrop = true;
                calenderTabControl.TabPages[i].DragEnter += dragenterTabPageHandler;
                calenderControl.Dock = DockStyle.Fill;
                calenderControl.AllowDrop = true;
             }
             calenderTabControl.Dock = DockStyle.Fill;
        }

        private void LoadModel(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(Trip));
            using (FileStream stream = File.OpenRead(filePath))
                trip = (Trip)serializer.ReadObject(stream);

            // to hanlde project files that do not yet contain payment information we must initilise the payment list.
            foreach(Event evnt in trip.events)
                if(evnt.payments == null)
                    evnt.payments = new ObservableCollection<Payment>();
            tripBindingSource.DataSource = trip;
            InitCalenderTab();
        }

        private void SaveModel(string filePath)
        {
            var serializer = new DataContractSerializer(typeof(Trip));
            using (FileStream stream = File.Create(filePath))
            {
                serializer.WriteObject(stream, trip);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Validate();
                filename = openFileDialog.FileName;
                LoadModel(filename);
                toolStripFileName.Text = filename;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Validate();
            if (filename == null)
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                    SaveModel(filename);
                    toolStripFileName.Text = filename;
                }
            }
            else
            {
                SaveModel(filename);
                toolStripFileName.Text = filename;
            }
        }

        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            if (filename != null)
                saveFileDialog.FileName = filename;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                SaveModel(filename);
                toolStripFileName.Text = filename;
            }
        }


        private void textBoxNumberOfDays_Validated(object sender, EventArgs e)
        {
            if (trip.numberOfDays != calenderTabControl.TabPages.Count)
                InitCalenderTab();
        }

        private void selectedEventChanged(Event evnt)
        {
            if(evnt != null)
                eventBindingSource.DataSource = evnt;
            detailsPanel.Visible = (evnt != null);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Event evnt = (Event)eventBindingSource.DataSource;
            if (evnt != null)
            {
                trip.events.Remove(evnt);
                detailsPanel.Visible = false;
                SelectedEvent.selectedEvent = null;
                RefreshEventDataSource();
           }
        }

        private void buttonVerifyAdress_Click(object sender, EventArgs e)
        {
            Event evnt = (Event)eventBindingSource.DataSource;
            if (evnt.address != null && evnt.address != string.Empty)
            {
                GoogleMaps.VerifyAdress(evnt);
                GoogleMaps.GetSingleEventMap(evnt);
                RefreshEventDataSource();
            }
        }

        private void generic_Validated(object sender, EventArgs e)
        {
            calenderTabControl.SelectedTab.Invalidate(true);
        }

        private void RefreshEventDataSource()
        {
            eventBindingSource.ResetBindings(false);
            calenderTabControl.Invalidate(true);
            detailsPanel.Invalidate(true);
        }

        private void CalenderTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedEvent.selectedEvent = null;
        }

        private void dragenterTabPageHandler(object sender, DragEventArgs e)
        {
        }

        private void CalenderTabs_DragEnter(object sender, DragEventArgs e)
        {
            Event evnt = SelectedEvent.selectedEvent;
            string[] formats = e.Data.GetFormats(false);
            Point clientPoint = calenderTabControl.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < calenderTabControl.TabCount; i++)
            {
                if (calenderTabControl.GetTabRect(i).Contains(clientPoint))
                {
                    calenderTabControl.SelectedIndex = i;
                    SelectedEvent.selectedEvent = evnt;
                    break;
                }
            }
        }

        private void calenderTabControl_DragOver(object sender, DragEventArgs e)
        {
            Event evnt = SelectedEvent.selectedEvent;
            string[] formats = e.Data.GetFormats(false);
            Point clientPoint = calenderTabControl.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < calenderTabControl.TabCount; i++)
            {
                if (calenderTabControl.GetTabRect(i).Contains(clientPoint) && calenderTabControl.SelectedIndex != i)
                {
                    calenderTabControl.SelectedIndex = i;
                    SelectedEvent.selectedEvent = evnt;
                    break;
                }
            }

        }

        private void toolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            // ToDo: add visula clue we are recalculating
            trip.CalculateTransfers();
            RefreshEventDataSource();
        }

        private void buttonVisitWebSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SelectedEvent.selectedEvent.webSite);
        }

        private void buttonBottleOrder_Click(object sender, EventArgs e)
        {
            BottleOrderForm orderForm= new BottleOrderForm(trip, SelectedEvent.selectedEvent);
            orderForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Windows.Automation.AutomationElement.FromHandle(Handle); // for creating the on screen keyboard if in tablet mode
        }

        private void toolStripButtonMemberUpdate_Click(object sender, EventArgs e)
        {
            foreach (Member member in trip.members.Where(x => x.Email != null))
            {
                string body = $"<p>Dear {member.Name},</p><p>Below follows a list of purchases you made and costs that were made on our winetrip. Also, a list of payments you made is included.</p>";
                foreach(Event evnt in trip.events.Where(x => x.TotalBottleCount(member) > 0))
                {
                    body += $"<b>{trip.startDate.AddDays(evnt.start.day).ToShortDateString()}: {evnt.name}</b>";
                    body += CreateHtmlEventWinePurchases(evnt, member);
                    body += CreateHtmlEventWinePayments(evnt, member);
                }
                body += CreateHtmlBalance(member);
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.webBrowserCtrl.DocumentText = body;
                webBrowser.ShowDialog();
                //Mailer.SendHtmlMail(member.Email, member.Name, "Wine trip report", body);
            }
        }

        private string CreateHtmlEventWinePurchases(Event evnt, Member member)
        {
            string body = "<table>\n";
            body += "<tr><th>Count</th><th>Description</th><th>Price</th></tr>\n";
            foreach (Bottle bottle in evnt.bottles)
            {
                int count = bottle.orders.Where(x => x.member == member).Sum(x => x.count);
                if (count > 0)
                {
                    body += $"<tr><td align=right>{count}</td><td align=left>{bottle.name} </td><td align=right>{count * bottle.price:###0.00}</td></tr> \n";
                }
            }
            body += $"<tr><td align=right>{evnt.TotalBottleCount(member)}</td><td></td><td align=right>{evnt.TotalPrice(member):###0.00}</td></tr>\n";
            body += "</table>\n";
            return body;
        }

        private string CreateHtmlEventWinePayments(Event evnt, Member member)
        {
            decimal payed = evnt.payments.Where(x => x.member == member).Sum(x => x.amount);
            return $"<p>Amount payed: {payed}</p>";
        }

        private string CreateHtmlBalance(Member member)
        {
            var purchase = trip.events.SelectMany(x => x.bottles).Select(bottle => new {count = bottle.orders.Where(y => y.member == member).Sum(x => x.count), price = bottle.price });
            return $"<p>Bumber of bottles bought: {purchase.Sum(x => x.count)}</p><p>Total amount due: { purchase.Sum(x => x.price)}";
        }
    }
}
