using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Text;
using XSystem.Security.Cryptography;
using System.Numerics;
using System.Text.Json;
using System.Security.Policy;
using Newtonsoft.Json;
//using System.Security.Cryptography;
using class_RSA;

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

            //task = new Task(() => EDidS());
            //task.Start();

            task = new Task(() => DiffieHellman());
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

                    BigInteger S1 = data.S1;
                    BigInteger nonce1 = data.nonce1;
                    BigInteger e1 = data.e1;
                    BigInteger n1 = data.n1;


                    string hashNonce = ComputeSHA256Hash(nonce1.ToString());
                    var temp = hashNonce.Select(item => ((int)item).ToString()).ToArray();

                    BigInteger T = BigInteger.Parse(string.Join("", temp));
                    BigInteger T_strih = BigInteger.ModPow(S1, e1, n1);

                    if (T == T_strih)
                    {
                        MessageBox.Show("Ok");
                        RSA rsa = new();
                        BigInteger nonce2 = GenerateNumber(256);

                        string hashNonce2 = ComputeSHA256Hash(nonce2.ToString());
                        var temp2 = hashNonce2.Select(item => ((int)item).ToString()).ToArray();
                        BigInteger T2 = BigInteger.Parse(string.Join("", temp2)); // T = sha256(nonce)

                        BigInteger d2 = rsa.par.d;
                        BigInteger n2 = rsa.par.n;
                        BigInteger e2 = rsa.par.e_;

                        BigInteger S2 = BigInteger.ModPow(T2, d2, n2);

                        var data2 = new
                        {
                            S2 = S2,
                            nonce2 = nonce2,
                            e2 = e2,
                            n2 = n2,
                        };

                        var json2 = JsonConvert.SerializeObject(data2);

                        var buffer2 = Encoding.UTF8.GetBytes(json2);
                        stream.Write(buffer2, 0, buffer2.Length);
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

        public void DiffieHellman()
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

                    BigInteger p = data.p; // �������� ��������� ������(g) � ������(p)
                    BigInteger g = data.g;

                    BigInteger A = data.A; // �������� A 

                    BigInteger b = GenerateNumber(256);
                    BigInteger B = BigInteger.ModPow(g, b, p);

                    var data2 = new
                    {
                        B = B,
                    };
                    var json2 = JsonConvert.SerializeObject(data2);
                    var buffer2 = Encoding.UTF8.GetBytes(json2);
                    stream.Write(buffer2, 0, buffer2.Length); // ��������� �

                    BigInteger CommonKey = BigInteger.ModPow(A, b, p);
                    CommonKey_TextBox.Text = "������: " + p.ToString() + "\r\n��������� ������: " + g.ToString() + "\r\n���������� b: " + b.ToString() + "\r\n����� ����: " + CommonKey.ToString();
                    stream.Flush();
                    clientSocket.Close();
                    DiffieHellman();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            stream.Flush();
            clientSocket.Close();
            DiffieHellman();
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
        private static BigInteger GenerateNumber(int bitNumber)
        {
            Random random = new();
            List<char> bits = new();
            for (int i = 0; i < bitNumber; ++i)
            {
                bits.Add((char)(random.Next(2) + '0'));
            }
            return BinToDec(bits);
        }
        private static BigInteger BinToDec(List<char> number)
        {
            BigInteger result = 0;
            for (int i = 0; number.Count > 0; ++i)
            {
                result += BigInteger.Pow(2, i) * (number.Last() - '0');
                number.RemoveAt(number.Count - 1);
            }
            return result;
        }
    }
}