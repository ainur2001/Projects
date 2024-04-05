using class_RSA;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using XSystem.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FairVoting
{
    public partial class Server : Form
    {
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=DB_Voting;Integrated Security=True";
        public static TcpListener serverSocket = new(IPAddress.Parse("127.0.0.1"), 7000);
        public static TcpClient clientSocket = new();
        public static NetworkStream stream;
        public static RSA rsa;
        public BigInteger prime;
        public Server()
        {
            InitializeComponent();
            Task serverWork;
            serverWork = new Task(() => WorkServer());
            serverWork.Start();
            rsa = new(20);
            prime = GeneratePrimeNumber(100);
            BigInteger secret = rsa.par.d;
            BigInteger[] shares = SplitSecret(secret, 3, 3);

            KeyAdmin1_TextBox.TextChanged += KeyAdmin1_TextBox_TextChanged;
            KeyAdmin2_TextBox.TextChanged += KeyAdmin2_TextBox_TextChanged;
            KeyAdmin3_TextBox.TextChanged += KeyAdmin3_TextBox_TextChanged;

            using (StreamWriter writer = new StreamWriter("shares.txt"))
            {
                writer.WriteLine("Части секрета:");
                writer.WriteLine("admin1 " + shares[0].ToString());
                writer.WriteLine("admin2 " + shares[1].ToString());
                writer.WriteLine("admin3 " + shares[2].ToString());
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Admins SET part_key = @part_key WHERE name = @name";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@name", "admin1");
                    updateCommand.Parameters.AddWithValue("@part_key", shares[0].ToString());
                    updateCommand.ExecuteNonQuery();

                    updateCommand.Parameters["@name"].Value = "admin2";
                    updateCommand.Parameters["@part_key"].Value = shares[1].ToString();
                    updateCommand.ExecuteNonQuery();

                    updateCommand.Parameters["@name"].Value = "admin3";
                    updateCommand.Parameters["@part_key"].Value = shares[2].ToString();
                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            string login = R_Login_TextBox.Text;
            string password = R_Password_TextBox.Text;
            string hashPassword = ComputeSHA256Hash(password);
            string callWord = GenerateCallWord();
            DateTime deadTime = DateTime.Today.AddDays(5);

            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Clients " +
                                 "(Login, HashPassword, CallWord, DeadTimeCW) VALUES " +
                                 "(@Login, @HashPassword, @CallWord, @DeadTimeCW);";
                    using (SqlCommand command = new(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@HashPassword", hashPassword);
                        command.Parameters.AddWithValue("@CallWord", callWord);
                        command.Parameters.AddWithValue("@DeadTimeCW", deadTime);
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
        private static string GenerateCallWord()
        {
            Random random = new Random();
            Random rand = random;
            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str += letter;
            }
            return str;
        }
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
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
        private (string, string, DateTime) GetRegistrationData(string login)
        {
            string password = "";
            string callWord = "";
            DateTime deadTimeCW = new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT HashPassword, CallWord, DeadTimeCW FROM Clients WHERE Login = @Login;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader.GetString(0);
                            callWord = reader.GetString(1);
                            deadTimeCW = reader.GetDateTime(2);
                        }
                    }
                }
            }
            return (password, callWord, deadTimeCW);
        }
        public void WorkServer()
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
                string code = data.code;

                if (code == "1") // аутентификация
                {
                    string answer = "";
                    byte[] bytesIn = new byte[256];
                    byte[] bytesOut = new byte[256];
                    try
                    {
                        int length;
                        string request;

                        string login = data.login;

                        if (!IsRegistered(login))
                        {
                            answer = "2";
                            bytesOut = Encoding.UTF8.GetBytes(answer); // отсылаем ошибку 2(логин не найден)
                            stream.Write(bytesOut, 0, bytesOut.Length);
                            break;
                        }
                        string HashPassword, callWord;
                        DateTime DeadTimeCW = new();
                        (HashPassword, callWord, DeadTimeCW) = GetRegistrationData(login);

                        if (DeadTimeCW < DateTime.Today)
                        {
                            callWord = GenerateCallWord();
                            DeadTimeCW = DateTime.Today.AddDays(5);
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                string sql = "UPDATE Clients SET CallWord = @CallWord, DeadTimeCW = @DeadTimeCW WHERE Login = @Login";
                                using (SqlCommand command = new SqlCommand(sql, connection))
                                {
                                    command.Parameters.AddWithValue("@CallWord", callWord);
                                    command.Parameters.AddWithValue("@DeadTimeCW", DeadTimeCW);
                                    command.Parameters.AddWithValue("@Login", login);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }

                        bytesOut = Encoding.UTF8.GetBytes(callWord);
                        stream.Write(bytesOut, 0, bytesOut.Length); // отсылаем хеш соли

                        length = stream.Read(bytesIn, 0, bytesIn.Length);
                        request = Encoding.UTF8.GetString(bytesIn, 0, length); // получаем Т клиента

                        string T_c = request;
                        string T_s = ComputeSHA256Hash(HashPassword + callWord);


                        if (T_c != T_s) // если Т клиента != Т сервера
                        {
                            answer = "3"; // отсылаем ошибку 3(Пароль введен неверно)
                            bytesOut = Encoding.UTF8.GetBytes(answer);
                            stream.Write(bytesOut, 0, bytesOut.Length);
                        }
                        else
                        {
                            answer = "1"; // отсылаем успех 1(авторизация успешно) пройдена и посылаем открытый ключ сервера

                            var dataPlusOpenKey = new
                            {
                                code = answer,
                                n = rsa.par.n,
                                e_ = rsa.par.e_,
                            };

                            var jsonNew = JsonConvert.SerializeObject(dataPlusOpenKey);
                            var bufferNew = Encoding.UTF8.GetBytes(jsonNew);
                            stream.Write(bufferNew, 0, bufferNew.Length);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("какая то ошибка при авторизации");
                    }
                }
                if (code == "2") // голосование
                {
                    BigInteger Fi = data.F;
                    string loginn = data.loginn;
                    BigInteger Ti = BigInteger.ModPow(Fi, rsa.par.d, rsa.par.n);
                    Voices_TextBox.Text += loginn + " " + Ti.ToString() + "\r\n";
                    EncryptedVoices_TextBox.Text += loginn + " " + Fi.ToString() + "\r\n";
                }
            }
        }
        public static List<BigInteger> ExtractNumbers(string input)
        {
            List<BigInteger> numbers = new List<BigInteger>();
            Regex regex = new Regex(@"\b\d+\b");

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (BigInteger.TryParse(match.Value, out BigInteger number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }
        private void CheckVoices_Button_Click(object sender, EventArgs e)
        {
            List<BigInteger> T = ExtractNumbers(Voices_TextBox.Text);
            BigInteger Q = 1;
            for (int i = 0; i < T.Count; i++)
            {
                Q *= T[i];
            }
            int r = 0, p = 0;
            BigInteger tmp1 = Q, tmp2 = Q;
            while (tmp1 % 2 == 0)
            {
                r++;
                tmp1 /= 2;
            }
            while (tmp2 % 3 == 0)
            {
                p++;
                tmp2 /= 3;
            }
            Voices_TextBox.Text += "За = " + r.ToString() + "\r\nПротив = " + p.ToString() + "\r\nВозрержались = " + (T.Count - r - p).ToString();
        }

        public BigInteger[] SplitSecret(BigInteger secret, int numShares, int threshold)
        {
            Random rand = new();
            BigInteger[] coefficients = new BigInteger[threshold];
            coefficients[0] = secret;

            for (int i = 1; i < threshold; i++)
            {
                BigInteger nextCoeff;
                do
                {
                    nextCoeff = new BigInteger(rand.Next());
                } while (nextCoeff.CompareTo(prime) >= 0 || nextCoeff.Sign == 0);

                coefficients[i] = nextCoeff;
            }

            BigInteger[] shares = new BigInteger[numShares];
            for (int i = 0; i < numShares; i++)
            {
                BigInteger x = new BigInteger(i + 1);
                shares[i] = 0;

                for (int j = 0; j < threshold; j++)
                {
                    shares[i] += coefficients[j] * BigInteger.Pow(x, j);
                    shares[i] %= prime;
                }
            }

            return shares;
        }

        public BigInteger ReconstructSecret(BigInteger[] shares)
        {
            BigInteger secret = 0;

            for (int i = 0; i < shares.Length; i++)
            {
                BigInteger numerator = 1;
                BigInteger denominator = 1;

                for (int j = 0; j < shares.Length; j++)
                {
                    if (i == j) continue;
                    numerator *= -new BigInteger(j + 1);
                    denominator *= (new BigInteger(i + 1) - new BigInteger(j + 1));
                }

                BigInteger term = shares[i] * numerator * BigInteger.ModPow(denominator, prime - 2, prime);
                secret += term;
                secret %= prime;
            }

            return secret;
        }

        private void ShamirVoting_Button_Click(object sender, EventArgs e)
        {
            if (KeyAdmin1_TextBox.Text == "" || KeyAdmin2_TextBox.Text == "" || KeyAdmin3_TextBox.Text == "")
            {
                MessageBox.Show("Не все администраторы ввели свои ключи!");
                return;
            }
            BigInteger key1 = BigInteger.Parse(KeyAdmin1_TextBox.Text), key2 = BigInteger.Parse(KeyAdmin2_TextBox.Text), key3 = BigInteger.Parse(KeyAdmin3_TextBox.Text);
            BigInteger reconstructedSecret = ReconstructSecret(new BigInteger[] { key1, key2, key3 });
            List<BigInteger> F = ExtractNumbers(EncryptedVoices_TextBox.Text);
            List<BigInteger> T = new();
            foreach (BigInteger voice in F)
            {
                T.Add(BigInteger.ModPow(voice, reconstructedSecret, rsa.par.n));
            }
            BigInteger Q = 1;
            for (int i = 0; i < T.Count; i++)
            {
                Q *= T[i];
            }
            int r = 0, p = 0;
            BigInteger tmp1 = Q, tmp2 = Q;
            while (tmp1 % 2 == 0)
            {
                r++;
                tmp1 /= 2;
            }
            while (tmp2 % 3 == 0)
            {
                p++;
                tmp2 /= 3;
            }
            EncryptedVoices_TextBox.Text += "За = " + r.ToString() + "\r\nПротив = " + p.ToString() + "\r\nВозрержались = " + (T.Count - r - p).ToString();
        }


        private bool CheckKey(string adminName, string enteredKey)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT part_key FROM Admins WHERE name = @name";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@name", adminName);
                    string storedKey = selectCommand.ExecuteScalar() as string;

                    return enteredKey == storedKey;
                }
            }
        }
        private void KeyAdmin1_TextBox_TextChanged(object sender, EventArgs e)
        {
            string enteredKey = KeyAdmin1_TextBox.Text;
            if (CheckKey("admin1", enteredKey)) pictureBox1.Visible = true; else pictureBox1.Visible = false;
            if (pictureBox1.Visible && pictureBox2.Visible && pictureBox3.Visible) ShamirVoting_Button.Enabled = true;
        }
        private void KeyAdmin2_TextBox_TextChanged(object sender, EventArgs e)
        {
            string enteredKey = KeyAdmin2_TextBox.Text;
            if (CheckKey("admin2", enteredKey)) pictureBox2.Visible = true; else pictureBox2.Visible = false;
            if (pictureBox1.Visible && pictureBox2.Visible && pictureBox3.Visible) ShamirVoting_Button.Enabled = true;
        }
        private void KeyAdmin3_TextBox_TextChanged(object sender, EventArgs e)
        {
            string enteredKey = KeyAdmin3_TextBox.Text;
            if (CheckKey("admin3", enteredKey)) pictureBox3.Visible = true; else pictureBox3.Visible = false;
            if (pictureBox1.Visible && pictureBox2.Visible && pictureBox3.Visible) ShamirVoting_Button.Enabled = true;
        }


        private BigInteger GeneratePrimeNumber(int bitNumber)
        {
            BigInteger p = 16384;
            while (!TestMR(p, bitNumber))
            {
                p = GenerateNumber(bitNumber);
                while (p <= 16384) p += 1;
            }
            return p;
        }
        private static bool TestMR(BigInteger number, int bitNumber)
        {
            bool result = true;
            BigInteger t = number - 1;
            int s = 0;
            try
            {
                if (bitNumber == 0) bitNumber = CountBits(number);
                while (t % 2 == 0)
                {
                    t /= 2;
                    s += 1;
                }
                for (int i = 0; i <= bitNumber; i++)
                {
                    BigInteger a = GenerateNumberWithLimits(2, number - 2);
                    BigInteger x = ModPow(a, t, number);
                    if (x == 1 || x == number - 1)
                        continue;
                    for (int r = 1; r < s; r++)
                    {
                        x = ModPow(x, 2, number);
                        if (x == 1)
                        {
                            result = false;
                            return result;
                        }
                        if (x == number - 1)
                            break;
                    }
                    if (x != number - 1)
                    {
                        result = false;
                        return result;
                    }
                }
            }
            catch (Exception) { }
            return result;
        }
        private static int CountBits(BigInteger number)
        {
            int count = 0;
            while (number != 0)
            {
                number >>= 1;
                count++;
            }
            return count;
        }
        private static BigInteger GenerateNumberWithLimits(BigInteger min, BigInteger max) => GenerateNumber(CountBits(max - min)) % (max - min) + min;
        private static BigInteger ModPow(BigInteger number, BigInteger exponent, BigInteger modulus)
        {
            BigInteger B, D;
            B = number;
            B %= modulus;
            D = 1;
            if ((exponent & 1) == 1)
            {
                D = B;
            }
            while (exponent > 1)
            {
                exponent >>= 1;
                B = (B * B) % modulus;
                if ((exponent & 1) == 1)
                {
                    D = (D * B) % modulus;
                }
            }
            return D;
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KeyAdmin1_TextBox.Text == "" || KeyAdmin2_TextBox.Text == "" || KeyAdmin3_TextBox.Text == "")
            {
                MessageBox.Show("Не все администраторы ввели свои ключи!");
                return;
            }
            BigInteger key1 = BigInteger.Parse(KeyAdmin1_TextBox.Text), key2 = BigInteger.Parse(KeyAdmin2_TextBox.Text), key3 = BigInteger.Parse(KeyAdmin3_TextBox.Text);
            BigInteger reconstructedSecret = ReconstructSecret(new BigInteger[] { key1, key2, key3 });
            List<BigInteger> F = ExtractNumbers(EncryptedVoices_TextBox.Text);
            List<BigInteger> T = new();
            foreach (BigInteger voice in F)
            {
                T.Add(BigInteger.ModPow(voice, reconstructedSecret, rsa.par.n));
            }
            BigInteger Q = 1;
            for (int i = 0; i < T.Count; i++)
            {
                Q *= T[i];
            }
            int r = 0, p = 0;
            BigInteger tmp1 = Q, tmp2 = Q;
            while (tmp1 % 2 == 0)
            {
                r++;
                tmp1 /= 2;
            }
            while (tmp2 % 3 == 0)
            {
                p++;
                tmp2 /= 3;
            }
            EncryptedVoices_TextBox.Text += "За = " + r.ToString() + "\r\nПротив = " + p.ToString() + "\r\nВозрержались = " + (T.Count - r - p).ToString();
        }
    }
}