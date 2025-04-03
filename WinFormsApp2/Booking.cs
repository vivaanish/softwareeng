using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Model;
using WinFormsApp2.Repository;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string fname = textBox1.Text;
            string surname = textBox2.Text;
            string address = richTextBox1.Text;
            int age = int.Parse(numericUpDown2.Text);
            int numOfDays = int.Parse(numericUpDown1.Text);
            bool checkBoxValid = checkBox1.Checked;
            string carType = comboBox1.Text;
            string fuelType = comboBox2.Text;
            bool unlimitedMileage = checkBox2.Checked;
            bool breakDownCover = checkBox3.Checked;
            string message = $"";

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(address) || checkBoxValid == false || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter all the mandatory.", message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int totalCost = 0, basicCost = 25, umCostPerDay = 10, bdcCostPerDay = 2;
                totalCost = numOfDays * basicCost;
                if (comboBox1.SelectedIndex == 1)

                {
                    totalCost = totalCost + 50; //city car
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    totalCost = totalCost + 75; // sports car
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    totalCost = totalCost + 65;// suv
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    totalCost = totalCost + 30; //hybrid
                }
                else if (comboBox2.SelectedIndex == 3)
                {
                    totalCost = totalCost + 50; // electric
                }
                if (unlimitedMileage)
                {
                    totalCost = totalCost + (umCostPerDay + numOfDays); //unlimited mileage
                }
                if (breakDownCover)
                {
                    totalCost = totalCost + (bdcCostPerDay + numOfDays);//breakdown coverage
                }
                if (totalCost > 0)
                {

                    //meesage pop up
                    MessageBox.Show("Booking Details", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ModelBooking mb = new ModelBooking();
                    //insert into database 
                    mb.FirstName = fname;
                    mb.Surname = surname;
                    mb.Address = address;
                    mb.Age = age;
                    mb.ValidLicense = checkBoxValid;
                    mb.TotalBookingDays = numOfDays;
                    mb.CarType = carType;
                    mb.FuelType = fuelType;
                    mb.Totalcost = totalCost;
                    mb.UnlimitedMileage = unlimitedMileage;
                    mb.BreakdownCover = breakDownCover;

                    var repo = new Bookingrepo();
                    repo.CreateBooking(mb);
                    MessageBox.Show("Sucessfully store", "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Dashboard().Show();
                }
            }
        }
    }
}
