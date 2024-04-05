using Newtonsoft.Json;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using XSystem.Security.Cryptography;

namespace Client
{
    public partial class Authorization : Form
    {
        public static TcpClient client = new("127.0.0.1", 7000);
        public static NetworkStream stream;
        public static BigInteger n, e_;
        public static string loginn;
        public Authorization()
        {
            InitializeComponent();
        }

        private void Enter_TextBox_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            string code = "1";
            string answer = "";
            try
            {

                string login = Login_TextBox.Text;
                loginn = login;
                string password = Password_TextBox.Text;
                if (login == "" || password == "") throw new Exception("Необходимо заполнить все поля авторизации");
                if (login.Contains(' ') || password.Contains(' ')) throw new Exception("Логин и пароль не может содержать в себе пробелы");


                byte[] bytesIn = new byte[256];
                byte[] bytesOut = new byte[256];

                var data = new
                {
                    code = code,
                    login = login
                };

                var json = JsonConvert.SerializeObject(data);

                var buffer = Encoding.UTF8.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);

                int length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length);
                string callWord = answer;

                if (answer == "2") throw new Exception("Пользователя с таким логином не существует!");

                string T = ComputeSHA256Hash(ComputeSHA256Hash(password) + callWord);

                bytesOut = Encoding.UTF8.GetBytes(T);
                stream.Write(bytesOut, 0, bytesOut.Length);



                var bufferIN = new byte[5000];

                var bytesRead = stream.Read(bufferIN, 0, bufferIN.Length);
                var jsonIN = Encoding.UTF8.GetString(bufferIN, 0, bytesRead);
                var dataIN = JsonConvert.DeserializeObject<dynamic>(jsonIN);

                answer = dataIN.code;
                n = dataIN.n;
                e_ = dataIN.e_;
                
                if (answer == "3") throw new Exception("Пароль введен неверно!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (answer == "1")
            {
                MessageBox.Show("Вы успешно авторизовались!");

                Voting voting = new();
                Hide();
                voting.Show();
            }
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