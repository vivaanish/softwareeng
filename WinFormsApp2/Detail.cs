using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Repository;

namespace WinFormsApp2
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
            ReadBookingDetails();
        }
        public void ReadBookingDetails()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Customer Name");
            dataTable.Columns.Add("Age");
            dataTable.Columns.Add("Valid License");
            dataTable.Columns.Add("Number Of Days");
            dataTable.Columns.Add("Car Type");
            dataTable.Columns.Add("Fuel Type");
            dataTable.Columns.Add("Unlimited Mileage");
            dataTable.Columns.Add("BreakdownCover");
            dataTable.Columns.Add("Total Cost");
            var repo = new Bookingrepo();
            var detail = repo.GetbookingDetails();
            foreach (var item in detail)
            {
                var row = dataTable.NewRow();
                row["Id"] = item.Id;
                row["Customer Name"] = item.FirstName + " " + item.Surname;
                row["Age"] = (int)item.Age;
                row["Valid license"] = item.ValidLicense;
                row["Number of Days"] = item.TotalBookingDays;
                row["Car Type"] = item.CarType;
                row["Fuel type"] = item.FuelType;
                row["Unlimited Mileage"] = item.UnlimitedMileage;
                row["BreakDownCover"] = item.BreakdownCover;
                row["Total Cost"] = item.Totalcost;
                dataTable.Rows.Add(row);
            }
            this.dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
