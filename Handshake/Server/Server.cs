using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Text;
using XSystem.Security.Cryptography;
using System.Numerics;
using System.Text.Json;
using System.Security.Policy;
using Newtonsoft.Json;

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
            //task = new Task(() => StartServer());
            //task.Start();

            task = new Task(() => EDidS());
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
                MessageBox.Show("������� �� ������. �������� ����� ����� ��� ����������!");
                return;
            }
            MessageBox.Show("������� ������");
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
                    string request = Encoding.UTF8.GetString(bytesIn, 0, length); //�������� �����
                    string login = request;
                    

                    if (!IsRegistered(login)) //���� ������������ �� ���������������
                    {
                        answer = "2";
                        bytesOut = Encoding.UTF8.GetBytes(answer); // �������� ������ 2(����� �� ������)
                        stream.Write(bytesOut, 0, bytesOut.Length);
                        stream.Flush();
                        clientSocket.Close();
                        StartServer();
                        //throw new Exception("������������ � ����� ������� �� ����������!");
                    }
                    string HashPassword, Salt;
                    (HashPassword, Salt) = GetRegistrationData(login);
                    //string HashSalt = ComputeSHA256Hash(Salt);

                    string CW = DateTime.Now.ToString();
;
                    

                    bytesOut = Encoding.UTF8.GetBytes(CW);
                    stream.Write(bytesOut, 0, bytesOut.Length); // �������� ��� ����

                    length = stream.Read(bytesIn, 0, bytesIn.Length);
                    request = Encoding.UTF8.GetString(bytesIn, 0, length); // �������� � �������

                    string T_c = request;
                    string T_s = ComputeSHA256Hash(HashPassword + CW);
                    


                    if (T_c != T_s) // ���� � ������� != � �������
                    {
                        answer = "3"; // �������� ������ 3(������ ������ �������)
                        bytesOut = Encoding.UTF8.GetBytes(answer);
                        stream.Write(bytesOut, 0, bytesOut.Length);
                        stream.Flush();
                        clientSocket.Close();
                        StartServer();
                        //throw new Exception("������ ������������ ������ �������!");
                    }
                    else break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartServer();
            }
            //MessageBox.Show("������������ ������� �����");
            answer = "1";
            bytesOut = Encoding.UTF8.GetBytes(answer);
            stream.Write(bytesOut, 0, bytesOut.Length);
            stream.Flush();
            clientSocket.Close();
            StartServer();
        }
        public void EDidS()
        {
            try
            {
                serverSocket.Start();
                while (true)
                {
                    clientSocket = serverSocket.AcceptTcpClient();
                    stream = clientSocket.GetStream();

                    var buffer = new byte[1280];
                    var bytesRead = stream.Read(buffer, 0, buffer.Length);
                    var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    var data = JsonConvert.DeserializeObject<dynamic>(json);

                    BigInteger S = data.S;
                    BigInteger nonce = data.nonce;
                    BigInteger e = data.e;
                    BigInteger n = data.n;


                    string hashNonce = ComputeSHA256Hash(nonce.ToString());
                    var temp = hashNonce.Select(item => ((int)item).ToString()).ToArray();

                    BigInteger T = BigInteger.Parse(string.Join("", temp));
                    BigInteger T_strih = BigInteger.ModPow(S, e, n);

                    if (T == T_strih)
                    {
                        MessageBox.Show("Ok");
                        stream.Flush();
                        clientSocket.Close();
                        EDidS();
                    }
                    else
                    {
                        MessageBox.Show("Not ok");
                        stream.Flush();
                        clientSocket.Close();
                        EDidS();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                EDidS();
            }
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