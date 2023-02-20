using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BShop.Models;
using System.Data.SqlClient;

namespace BShop.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        public Appointment appointment = new();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            appointment.Name = Request.Form["Name"];
            appointment.phoneNumber = Request.Form["phoneNumber"];
            appointment.MasterName = Request.Form["MasterName"];
            appointment.DateOfHaircut = DateTime.Parse(Request.Form["DateOfHaircut"]);


            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BarberShop;Integrated Security=True";
                using(SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Appointment " +
                                 "(Name, phoneNumber, MasterName, DateOfHaircut) VALUES " +
                                 "(@Name, @phoneNumber, @MasterName, @DateOfHaircut);";

                    using (SqlCommand command = new(sql,connection))
                    {
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

            appointment.Name = "";
            appointment.MasterName = "";
            appointment.phoneNumber = "";
            appointment.DateOfHaircut = default;

            Response.Redirect("/Appointments/Index");
        }
    }
}
