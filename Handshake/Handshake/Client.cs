using class_RSA;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using XSystem.Security.Cryptography;
using Newtonsoft.Json;

namespace Handshake
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            TcpClient client = new("127.0.0.1", 7000);
            NetworkStream stream;
            stream = client.GetStream();
            string answer = "";
            try
            {
                string login = Login_TextBox.Text;
                string password = Password_TextBox.Text;
                if (login == "" || password == "") throw new Exception("Необходимо заполнить все поля регистрации");
                if (login.Contains(' ') || password.Contains(' ')) throw new Exception("Логин и пароль не может содержать в себе пробелы");
                
                
                byte[] bytesIn = new byte[256];
                byte[] bytesOut = new byte[256];

                bytesOut = Encoding.UTF8.GetBytes(login); 
                stream.Write(bytesOut, 0, bytesOut.Length); // отсылаем логин

                int length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length); //получаем хеш соли, если логин найден. получаем 2, если логин не найден
                string HashSalt = answer;

                if(answer == "2") throw new Exception("Пользователя с таким логином не существует!");

                string T = ComputeSHA256Hash(ComputeSHA256Hash(password) + HashSalt); //высчитываем Т клиента

                bytesOut = Encoding.UTF8.GetBytes(T);
                stream.Write(bytesOut, 0, bytesOut.Length); //отсылаем Т клиента

                length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length); //получаем ответ от сервера: 3 - пароль неверный, 1 - аутентификация успешна
                stream.Flush();
                client.Close();
                if (answer == "3") throw new Exception("Пароль введен неверно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (answer == "1") MessageBox.Show("Вы успешно авторизовались!");
        }
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
        private void EDS_Button_Click(object sender, EventArgs e)
        {
            TcpClient client = new("127.0.0.1", 7000);
            NetworkStream stream;
            stream = client.GetStream();
            try
            {
                stream = client.GetStream();
                RSA rsa = new();
                BigInteger nonce = GenerateNumber(256);

                string hashNonce = ComputeSHA256Hash(nonce.ToString());
                var temp = hashNonce.Select(item => ((int)item).ToString()).ToArray();
                BigInteger T = BigInteger.Parse(string.Join("", temp)); // T = sha256(nonce)

                BigInteger d = rsa.par.d;
                BigInteger n = rsa.par.n;
                BigInteger e1 = rsa.par.e_;

                BigInteger S = BigInteger.ModPow(T, d, n);

                var data = new
                {
                    S = S,
                    nonce = nonce,
                    e = e1,
                    n = n,
                };

                var json = JsonConvert.SerializeObject(data);

                var buffer = Encoding.UTF8.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            stream.Flush();
            client.Close();
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