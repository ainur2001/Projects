using class_RSA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSystem.Security.Cryptography;

namespace Client
{
    public partial class ChatClientServer : Form
    {
        private BigInteger CommonKey = Handshake.Authorization.CommonKey;
        public static TcpClient client = new("127.0.0.1", 7000);
        public static NetworkStream stream;


        public ChatClientServer()
        {
            InitializeComponent();
            CommonKey_Label.Text = "Общий ключ: " + CommonKey.ToString();
            Task task;
            task = new Task(() => Chat());
            task.Start();
        }

        private void SendMessage_Button_Click(object sender, EventArgs e)
        {
            string code = "2";
            stream = client.GetStream();

            string message = Message_TextBox.Text;
            Chat_TextBox.Text += "Вы:\r\n" + message + "\r\n";

            string BinaryCodeText, BinaryCode;
            (BinaryCodeText, BinaryCode) = Encode(message, CommonKey);
            var cryptogram = Encrypt(BinaryCodeText, BinaryCode); // зашифровали сообщение
            Chat_TextBox.Text += "Криптограмма:\r\n" + cryptogram + "\r\n\r\n";

            var data = new
            {
                code = code,
                cryptogram = cryptogram
            };

            var json = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(json);
            stream.Write(buffer, 0, buffer.Length);
        }
        private void EDS_Button_Click(object sender, EventArgs e)
        {
            string code = "3";
            stream = client.GetStream();
            try
            {
                stream = client.GetStream();
                RSA rsa = new();
                BigInteger nonce1 = GenerateNumber(256);

                string hashNonce = ComputeSHA256Hash(nonce1.ToString());
                var temp = hashNonce.Select(item => ((int)item).ToString()).ToArray();
                BigInteger T1 = BigInteger.Parse(string.Join("", temp)); // T = sha256(nonce)

                BigInteger d1 = rsa.par.d;
                BigInteger n1 = rsa.par.n;
                BigInteger e1 = rsa.par.e_;

                BigInteger S1 = BigInteger.ModPow(T1, d1, n1);

                var data = new
                {
                    code = code,
                    S1 = S1,
                    nonce1 = nonce1,
                    e1 = e1,
                    n1 = n1,
                };

                var json = JsonConvert.SerializeObject(data);

                var buffer = Encoding.UTF8.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);


                var buffer2 = new byte[1280];
                var bytesRead = stream.Read(buffer2, 0, buffer2.Length);
                var json2 = Encoding.UTF8.GetString(buffer2, 0, bytesRead);

                var data2 = JsonConvert.DeserializeObject<dynamic>(json2);

                BigInteger S2 = data2.S2;
                BigInteger nonce2 = data2.nonce2;
                BigInteger e2 = data2.e2;
                BigInteger n2 = data2.n2;

                string hashNonce2 = ComputeSHA256Hash(nonce2.ToString());
                var temp2 = hashNonce2.Select(item => ((int)item).ToString()).ToArray();

                BigInteger T2 = BigInteger.Parse(string.Join("", temp2));
                BigInteger T_strih2 = BigInteger.ModPow(S2, e2, n2);

                if (T2 == T_strih2) throw new Exception("Ок");
                else throw new Exception("not ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Chat()
        {
            byte[] bytesIn = new byte[512];
            try
            {
                while (true)
                {
                    stream = client.GetStream();

                    string answer = "";
                    int length = stream.Read(bytesIn, 0, bytesIn.Length);
                    answer = Encoding.UTF8.GetString(bytesIn, 0, length); // получили криптограмму
                    string receivedMessage = answer;
                    Chat_TextBox.Text += "Сообщение(критограмма):\r\n" + receivedMessage + "\r\n";


                    var BinaryCode = Encode(receivedMessage, CommonKey).Item2;
                    var BinarySourceText = Decrypt(receivedMessage, BinaryCode); // расшифровали сообщение
                    var sourceText = Decode(BinarySourceText);
                    Chat_TextBox.Text += "Расшифрованное сообщение\r\n" + sourceText + "\r\n\r\n";
                }
            }
            catch (Exception)
            {
            }
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
                result += (((int)BinaryCodeText[i] + (int)BinaryKey[i % BinaryKey.Length]) % 2).ToString();
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
                while (true)
                {
                    result.Append((char)Convert.ToInt32(BinaryCodeText[0..8], 2));
                    BinaryCodeText = BinaryCodeText[8..];
                }
            }
            catch (ArgumentOutOfRangeException) { }
            return result.ToString();
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
        public static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
    }
}
