using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BShop.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace BShop.Pages.Appointments
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<Appointment> appointments = new();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=WIN-NJ7HQJ5ADFM\\SQLEXPRESS;Initial Catalog=BarberShop;User ID=sa;Password=787898Ainur!"; ;

                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Appointment";
                    using (SqlCommand command = new(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment appointment = new();
                                appointment.Id = "" + reader.GetInt32(0);
                                appointment.Name = reader.GetString(1);
                                appointment.phoneNumber = reader.GetString(2);
                                appointment.MasterName = reader.GetString(3);
                                appointment.DateOfHaircut = reader.GetString(4);
                                appointment.created_at = reader.GetDateTime(5).ToString();

                                appointments.Add(appointment);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("����������: " + ex.Message);
            }
        }
    }
}
