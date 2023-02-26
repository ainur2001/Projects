using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SecurityOfCS
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            string answer = "";
            try
            {
                string login = Login_TextBox.Text;
                string password = Password_TextBox.Text;
                if (login == "" || password == "") throw new Exception("Необходимо заполнить все поля регистрации");
                if (login.Contains(' ') || password.Contains(' ')) throw new Exception("Логин и пароль не может содержать в себе пробелы");
                string registrationData = "1 " + login + " " + password;
                TcpClient client = new("127.0.0.1", 7000);
                NetworkStream stream = client.GetStream();
                byte[] bytesIn = new byte[256];
                byte[] bytesOut = new byte[256];

                bytesOut = Encoding.UTF8.GetBytes(registrationData);
                stream.Write(bytesOut, 0, bytesOut.Length);

                int length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length);

                stream.Flush();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(answer);
        }
    }
}