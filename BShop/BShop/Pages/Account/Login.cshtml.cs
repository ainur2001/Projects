using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace BShop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BarberShop;Integrated Security=True";

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if(IsRegistrated(credential.Login) && GetHashPasswordByLogin(credential.Login) == ComputeSHA256Hash(credential.Password))
            {
                var cliams = new List<Claim> { new Claim(ClaimTypes.Name, "staff") };

                var identity = new ClaimsIdentity(cliams, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Appointments/Index");
            }
            return Page();
        }
        public bool IsRegistrated(string Login)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CASE WHEN EXISTS(SELECT * FROM Staff WHERE Login = @Login) THEN 1 ELSE 0 END;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", Login);
                    result = (int)command.ExecuteScalar();
                }
            }
            if (result == 0) return false;
            else return true;
        }
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        public string GetHashPasswordByLogin(string Login)
        {
            string password = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT HashPassword FROM Staff WHERE Login = @Login;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", Login);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader.GetString(0);
                        }
                    }
                }
            }
            return password;
        }
    }

    public class Credential
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
