using System.Net.Sockets;
using System.Text;
using XSystem.Security.Cryptography;

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
            string answer = "";
            try
            {
                string login = Login_TextBox.Text;
                string password = Password_TextBox.Text;
                if (login == "" || password == "") throw new Exception("���������� ��������� ��� ���� �����������");
                if (login.Contains(' ') || password.Contains(' ')) throw new Exception("����� � ������ �� ����� ��������� � ���� �������");
                TcpClient client = new("127.0.0.1", 7000);
                NetworkStream stream = client.GetStream();
                byte[] bytesIn = new byte[256];
                byte[] bytesOut = new byte[256];

                bytesOut = Encoding.UTF8.GetBytes(login); 
                stream.Write(bytesOut, 0, bytesOut.Length); // �������� �����

                int length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length); //�������� ��� ����, ���� ����� ������. �������� 2, ���� ����� �� ������
                string HashSalt = answer;

                if(answer == "2") throw new Exception("������������ � ����� ������� �� ����������!");

                string T = ComputeSHA256Hash(ComputeSHA256Hash(password) + HashSalt); //����������� � �������

                bytesOut = Encoding.UTF8.GetBytes(T);
                stream.Write(bytesOut, 0, bytesOut.Length); //�������� � �������

                length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length); //�������� ����� �� �������: 3 - ������ ��������, 1 - �������������� �������
                stream.Flush();
                client.Close();
                if (answer == "3") throw new Exception("������ ������ �������!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (answer == "1") MessageBox.Show("�� ������� ��������������!");
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