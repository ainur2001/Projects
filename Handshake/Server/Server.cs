using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Text;
using XSystem.Security.Cryptography;

namespace Server
{
    public partial class Server : Form
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Handshake;Integrated Security=True";
        public static TcpListener serverSocket = new(IPAddress.Parse("127.0.0.1"), 7000);
        public static TcpClient clientSocket = new();
        public static NetworkStream stream;
        Task task;

        public Server()
        {
            InitializeComponent();
            task = new Task(() => StartServer());
            task.Start();
        }
        private void Registration_Button_Click(object sender, EventArgs e)
        {
            string login = R_Login_TextBox.Text;
            string password = Password_Textbox.Text;
            string hashPassword = ComputeSHA256Hash(password);

            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Clients " +
                                 "(Login, HashPassword) VALUES " +
                                 "(@Login, @HashPassword);";
                    using (SqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@HashPassword", hashPassword);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Аккаунт не создан. Возможно такой логин уже существует!");
                return;
            }
            MessageBox.Show("Аккаунт создан");
        }
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        public void StartServer()
        {
            string answer = "";
            byte[] bytesIn = new byte[256];
            byte[] bytesOut = new byte[256];
            try
            {
                serverSocket.Start();
                while (true)
                {
                    clientSocket = serverSocket.AcceptTcpClient();
                    stream = clientSocket.GetStream();

                    int length = stream.Read(bytesIn, 0, bytesIn.Length);
                    string request = Encoding.UTF8.GetString(bytesIn, 0, length); //получаем логин
                    string login = request;
                    Login_TextBox.Text = request;

                    if (!IsRegistered(login)) //если пользователь не зарегистрирован
                    {
                        answer = "2";
                        bytesOut = Encoding.UTF8.GetBytes(answer); // отсылаем ошибку 2(Логин не найден)
                        stream.Write(bytesOut, 0, bytesOut.Length);
                        stream.Flush();
                        clientSocket.Close();
                        
                        HashPW_TextBox.Text = "";
                        HashSalt_TextBox.Text = "";
                        T_client_TextBox.Text = "";
                        T_server_TextBox.Text = "";
                        StartServer();
                        //throw new Exception("Пользователя с таким логином не существует!");
                    }
                    string HashPassword, Salt;
                    (HashPassword, Salt) = GetRegistrationData(login);
                    string HashSalt = ComputeSHA256Hash(Salt);

                    HashPW_TextBox.Text = HashPassword;
                    HashSalt_TextBox.Text = HashSalt;

                    bytesOut = Encoding.UTF8.GetBytes(HashSalt);
                    stream.Write(bytesOut, 0, bytesOut.Length); // отсылаем хеш соли

                    length = stream.Read(bytesIn, 0, bytesIn.Length);
                    request = Encoding.UTF8.GetString(bytesIn, 0, length); // получаем Т клиента

                    string T_c = request;
                    string T_s = ComputeSHA256Hash(HashPassword + HashSalt);
                    T_client_TextBox.Text = T_c;
                    T_server_TextBox.Text = T_s;


                    if (T_c != T_s) // если Т клиента != Т сервера
                    {
                        answer = "3"; // отсылаем ошибку 3(Пароль введен неверно)
                        bytesOut = Encoding.UTF8.GetBytes(answer);
                        stream.Write(bytesOut, 0, bytesOut.Length);
                        stream.Flush();
                        clientSocket.Close();
                        StartServer();
                        //throw new Exception("Пароль пользователя введен неверно!");
                    }
                    else break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartServer();
            }
            //MessageBox.Show("Пользователь успешно вошел");
            answer = "1";
            bytesOut = Encoding.UTF8.GetBytes(answer);
            stream.Write(bytesOut, 0, bytesOut.Length);
            stream.Flush();
            clientSocket.Close();
            StartServer();
        }

        private bool IsRegistered(string login)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CASE WHEN EXISTS(SELECT * FROM Clients WHERE Login = @Login) THEN 1 ELSE 0 END;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    result = (int)command.ExecuteScalar();
                }
            }
            if (result == 0) return false;
            else return true;
        }
        private (string, string) GetRegistrationData(string login)
        {
            string password = "";
            string salt = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT HashPassword, Salt FROM Clients WHERE Login = @Login;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader.GetString(0);
                            salt = reader.GetDateTime(1).ToString();
                        }
                    }
                }
            }
            return (password, salt);
        }

    }
}