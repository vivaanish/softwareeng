using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Model
{
    public class ModelBooking
    {
        public int Id;
        public string FirstName = "";
        public string Surname = "";
        public string Address = "";
        public int Age;
        public bool ValidLicense;
        public int TotalBookingDays;
        public string CarType = "";
        public string FuelType = "";
        public decimal Totalcost;
        public bool UnlimitedMileage;
        public bool BreakdownCover;
    }
}

