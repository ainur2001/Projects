using BShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BShop.Pages.Appointments
{
    public class EditModel : PageModel
    {
        public Appointment appointment = new();
       
        public void OnGet()
        {
            string Id = Request.Query["Id"];

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BarberShop;Integrated Security=True";

                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Appointment WHERE Id=@Id";
                    using (SqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                appointment.Id = "" + reader.GetInt32(0);
                                appointment.Name = reader.GetString(1);
                                appointment.phoneNumber = reader.GetString(2);
                                appointment.MasterName = reader.GetString(3);
                                appointment.DateOfHaircut = reader.GetDateTime(4);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void OnPost()
        {
            appointment.Id = Request.Form["Id"];
            appointment.Name = Request.Form["Name"];
            appointment.phoneNumber = Request.Form["phoneNumber"];
            appointment.MasterName = Request.Form["MasterName"];
            appointment.DateOfHaircut = DateTime.Parse(Request.Form["DateOfHaircut"]);

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BarberShop;Integrated Security=True";
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Appointment " +
                                 "SET Name=@Name, phoneNumber=@phoneNumber, MasterName=@MasterName, DateOfHaircut=@DateOfHaircut " +
                                 "WHERE Id=@Id";

                    using (SqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", appointment.Id);
                        command.Parameters.AddWithValue("@Name", appointment.Name);
                        command.Parameters.AddWithValue("@phoneNumber", appointment.phoneNumber);
                        command.Parameters.AddWithValue("@MasterName", appointment.MasterName);
                        command.Parameters.AddWithValue("@DateOfHaircut", appointment.DateOfHaircut);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

            Response.Redirect("/Appointments/Index");
        }
    }
}
