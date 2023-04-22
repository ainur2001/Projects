using System.Data;
using System.Numerics;
using System.Text;

namespace Client
{
    public partial class Chat : Form
    {
        public string rus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
        private BigInteger CommonKey = Handshake.Authorization.CommonKey;
        public Chat()
        {
            InitializeComponent();
            label1.Text = "Общий ключ: " + CommonKey.ToString();
        }

        private void SendMessage_Button_Click(object sender, EventArgs e)
        {
            string message = Message_TextBox.Text;
            Chat_TextBox.Text += "Вы:\r\n" + message + "\r\n\r\n";

            string BinaryCodeText, BinaryCode;

            (BinaryCodeText, BinaryCode) = Encode(message, CommonKey);
            var cryptogram = Encrypt(BinaryCodeText, BinaryCode);
            Chat_TextBox.Text += cryptogram + "\r\n";

            var BinarySourceText = Decrypt(cryptogram, BinaryCode);
            var sourceText = Decode(BinarySourceText);
            Chat_TextBox.Text += sourceText + "\r\n";
        }
        (string, string) Encode(string message, BigInteger key)
        {
            string BinaryCodeText = "";
            string BinaryKey = "";

            BinaryCodeText = string.Join(separator: "", message.Select(item => Convert.ToString((int)item, 2)).ToArray());
            BinaryKey = string.Join(separator: "", key.ToString().Select(item => Convert.ToString((int)item, 2)).ToArray());
            if (BinaryCodeText.Length < BinaryKey.Length)
                BinaryKey = string.Join("", Enumerable.Repeat(BinaryKey, ((BinaryCodeText.Length - BinaryKey.Length) / BinaryKey.Length) + 1));
            return (BinaryCodeText, BinaryKey);
        }

        private string Encrypt(string BinaryCodeText, string BinaryKey)
        {
            string result = "";

            for (int i = 0; i < BinaryCodeText.Length; i++)
            {
                result += (((int)BinaryCodeText[i] + (int)BinaryKey[i]) % 2).ToString();
            }
            return result;
        }

        private string Decrypt(string BinaryCodeText, string BinaryKey)
        {
            return Encrypt(BinaryCodeText, BinaryKey);
        }

        string Decode(string BinaryCodeText) => Encoding.Unicode.GetString(BinaryCodeText.Split("").Select(item => Convert.ToByte(item[0]-'0')).ToArray());

    }
}
