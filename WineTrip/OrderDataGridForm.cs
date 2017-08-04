using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineTrip.DataModel;

namespace WineTrip
{
    public partial class OrderDataGridForm : Form
    {
        private Event evnt;
        private ObservableCollection<Member> members;
        private DataTable dataTable = new DataTable();

        public OrderDataGridForm(Event evnt, ObservableCollection<Member> members)
        {
            this.evnt = evnt;
            this.members = members;
            InitializeComponent();
            Text = evnt.name;
            InitDataTable();
        }

        private void InitDataTable()
        {
            dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Vintage", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Volume", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));

            string memberAggregate = "";
            foreach (Member member in members)
            {
                dataTable.Columns.Add(new DataColumn(member.Name, typeof(int)) { AllowDBNull = true });
                memberAggregate += $"ISNULL({member.Name},0) + ";
            }
            memberAggregate = memberAggregate.Substring(0, memberAggregate.Length - 2);

            dataTable.Columns.Add(new DataColumn("Total volume", typeof(int)) { Expression = memberAggregate });
            dataTable.Columns.Add(new DataColumn("Total price", typeof(decimal)) { Expression = $"({memberAggregate}) * ISNULL(Price,0)"  });
            foreach (Bottle bottle in evnt.bottles)
            {
                DataRow datarow = dataTable.NewRow();
                datarow["Description"] = bottle.name;
                datarow["Vintage"] = bottle.vintage;
                datarow["Volume"] = bottle.volume;
                datarow["Price"] = bottle.price;
                foreach (Order order in bottle.orders)
                    datarow[order.member.Name] = order.count;
                dataTable.Rows.Add(datarow);
            }
            dataGridViewOrder.DataSource = dataTable;
            foreach(DataGridViewColumn column in dataGridViewOrder.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
         }

        private void dataGridViewOrder_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Volume"].Value = 0.75;
            //foreach (Member member in members)
            //    e.Row.Cells[member.Name].Value = 0;
        }

        private void OrderForm_Deactivate(object sender, EventArgs e)
        {
            evnt.bottles.Clear();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Bottle bottle = new Bottle() { name = getString(dataRow["Description"]), vintage = getInt(dataRow["Vintage"]), volume = getDecimal(dataRow["Volume"]), price = getDecimal(dataRow["Price"]) };
                evnt.bottles.Add(bottle);
                foreach (Member member in members)
                {
                    int count = getInt(dataRow[member.Name]);
                    if (count > 0)
                        bottle.orders.Add(new Order() { member = member, count = count });
                }
            }
        }

        private int getInt(object obj)
        {
            return obj is int ? (int)obj : 0;
        }

        private decimal getDecimal(object obj)
        {
            return obj is decimal ? (decimal)obj : 0;
        }

        private string getString(object obj)
        {
            return obj is string ? (string)obj :null;
        }


    }
}
