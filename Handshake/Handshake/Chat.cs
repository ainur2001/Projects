using System.Data;
using System.Numerics;
using System.Text;

namespace Client
{
    public partial class Chat : Form
    {
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

            BinaryCodeText = string.Join(separator: "", message.Select(item => string.Join("", Enumerable.Repeat("0", 8 - Convert.ToString((int)item, 2).Length).ToArray()) + Convert.ToString((int)item, 2)).ToArray());
            BinaryKey = string.Join(separator: "", key.ToString().Select(item => string.Join("", Enumerable.Repeat("0", 8 - Convert.ToString((int)item, 2).Length).ToArray()) + Convert.ToString((int)item, 2)).ToArray());

            if (BinaryCodeText.Length < BinaryKey.Length)
                BinaryKey = string.Join(separator: "", Enumerable.Repeat(BinaryKey, ((BinaryCodeText.Length - BinaryKey.Length) / BinaryKey.Length) + 1));
            return (BinaryCodeText, BinaryKey);
        }

        private string Encrypt(string BinaryCodeText, string BinaryKey)
        {
            string result = "";

            for (int i = 0; i < BinaryCodeText.Length; i++)
            {
                result += (((int)BinaryCodeText[i] + (int)BinaryKey[i%BinaryKey.Length]) % 2).ToString();
            }
            return result;
        }

        private string Decrypt(string BinaryCodeText, string BinaryKey)
        {
            return Encrypt(BinaryCodeText, BinaryKey);
        }

        string Decode(string BinaryCodeText)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                while(true)
                {
                    result.Append((char)Convert.ToInt32(BinaryCodeText[0..8], 2));
                    BinaryCodeText = BinaryCodeText[8..];
                }
            }
            catch (ArgumentOutOfRangeException) { }
            return result.ToString();
        }

    }
}
