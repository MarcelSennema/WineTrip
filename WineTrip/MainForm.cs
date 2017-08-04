﻿using System;
using System.Collections.Generic;
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
        private string filename;

        public MainForm()
        {
            InitializeComponent();
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
            {
                trip = (Trip)serializer.ReadObject(stream);
            }
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
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Validate();
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

        private void buttonOrder_Click(object sender, EventArgs e)
        {

            OrderForm orderForm = new OrderForm(SelectedEvent.selectedEvent, trip.members);

            orderForm.Show();
        }
    }
}