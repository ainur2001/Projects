using System.Data.SqlClient;
using System.Text;
using XSystem.Security.Cryptography;

namespace RegistrationNewStaff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddNewStaff_Button_Click(object sender, EventArgs e)
        {
            string Name = Name_TextBox.Text;
            string SecondName = SecondName_TextBox.Text;
            string PhoneNumber = Phone_TextBox.Text;
            string Login = Login_TextBox.Text;
            string Password = Password_Textbox.Text;

            string HashPassword = ComputeSHA256Hash(Password);
            try
            {
                string connectionString = "Data Source=WIN-NJ7HQJ5ADFM\\SQLEXPRESS;Initial Catalog=BarberShop;User ID=sa;Password=787898Ainur!";
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Staff " +
                                 "(Name, SecondName, PhoneNumber, Login, HashPassword) VALUES " +
                                 "(@Name, @SecondName, @PhoneNumber, @Login, @HashPassword);";

                    using (SqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Login", Login);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@HashPassword", HashPassword);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Возможно такой логин уже сущесвтует!");
                return;
            }
            Name_TextBox.Text = "";
            SecondName_TextBox.Text = "";
            Phone_TextBox.Text = "";
            Login_TextBox.Text = "";
            Password_Textbox.Text = "";
            MessageBox.Show("Успешно!");
        }
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
    }
}