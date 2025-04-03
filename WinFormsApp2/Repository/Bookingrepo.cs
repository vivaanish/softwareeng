using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WinFormsApp2.Model;

namespace WinFormsApp2.Repository
{
    public class Bookingrepo
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=abc;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<ModelBooking> GetbookingDetails()
        {

            var bookings = new List<ModelBooking>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Select * from Booking ORDER By ID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ModelBooking bk = new ModelBooking();
                                bk.Id = reader.GetInt32(0);
                                bk.FirstName = reader.GetString(1);
                                bk.Surname = reader.GetString(2);
                                bk.Address = reader.GetString(3);
                                bk.Age = reader.GetInt32(4);
                                bk.ValidLicense = reader.GetBoolean(5);
                                bk.CarType = reader.GetString(6);
                                bk.FuelType = reader.GetString(7);
                                bk.UnlimitedMileage = reader.GetBoolean(8);
                                bk.BreakdownCover = reader.GetBoolean(9);
                                bk.Totalcost = reader.GetDecimal(10);
                                bk.TotalBookingDays = reader.GetInt32(11);
                                bookings.Add(bk);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return bookings;
        }
        public void CreateBooking(ModelBooking bk)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "insert into Booking" +
                        "([FirstName],[Surname],[Address],[Age],[ValidLicense],[CarType]," +
                        "[FuelType],[UnlimitedMileage],[BreakdownCover],[TotalCost],[TotalBookingDays]) VALUES" +
                        "(@fn,@SN,@add,@age,@vdl,@ct,@ft,@ulm,@bdc,@tc,@td)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fn", bk.FirstName);
                        cmd.Parameters.AddWithValue("@SN", bk.Surname);
                        cmd.Parameters.AddWithValue("@add", bk.Address);
                        cmd.Parameters.AddWithValue("@age", bk.Age);
                        cmd.Parameters.AddWithValue("@vdl", bk.ValidLicense);
                        cmd.Parameters.AddWithValue("@ct", bk.CarType);
                        cmd.Parameters.AddWithValue("@ft", bk.FuelType);
                        cmd.Parameters.AddWithValue("@ulm", bk.UnlimitedMileage);
                        cmd.Parameters.AddWithValue("@bdc", bk.BreakdownCover);
                        cmd.Parameters.AddWithValue("@tc", bk.Totalcost);
                        cmd.Parameters.AddWithValue("@td", bk.TotalBookingDays);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

    }
}