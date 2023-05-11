using class_RSA;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using XSystem.Security.Cryptography;
using Newtonsoft.Json;
using Client;
using System.Threading.Tasks;

namespace Handshake
{
    public partial class Authorization : Form
    {
        public static BigInteger CommonKey;
        public static TcpClient client = new("127.0.0.1", 7000);
        public static NetworkStream stream;

        public Authorization()
        {
            InitializeComponent();
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
                    S1 = S1,
                    nonce1 = nonce1,
                    e1 = e1,
                    n1 = n1,
                };

                var json = JsonConvert.SerializeObject(data);

                var buffer = Encoding.UTF8.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length); // отправляем S, nonce, (e,n)


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

                if (T2 == T_strih2)
                {
                    MessageBox.Show("Ок");
                    stream.Flush();
                    client.Close();
                }
                else
                {
                    MessageBox.Show("not ok");
                    stream.Flush();
                    client.Close();
                }

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
        public BigInteger GeneratingPrimeNumber(int bitNumber)
        {
            BigInteger q = 16384;
            while (!TestMR(q, bitNumber))
            {
                q = GenerateNumber(bitNumber);
                while (q <= 16384) q += 1;
            }
            return q;
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
        private static bool TestMR(BigInteger number, int bitNumber)
        {
            bool result = true;
            BigInteger t = number - 1;
            int s = 0;
            try
            {
                while (t % 2 == 0)
                {
                    t /= 2;
                    s += 1;
                }
                for (int i = 0; i <= bitNumber; i++)
                {
                    BigInteger a = GenerateNumberWithLimits(2, number - 2);
                    BigInteger x = BigInteger.ModPow(a, t, number);
                    if (x == 1 || x == number - 1)
                        continue;
                    for (int r = 1; r < s; r++)
                    {
                        x = BigInteger.ModPow(x, 2, number);
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
        public static BigInteger FindPrimitiveRoot(BigInteger p)
        {
            if (p == 2 || p == 3)
            {
                return p - 1;
            }

            BigInteger q = p - 1;
            BigInteger s = q;

            List<BigInteger> primeFactors = new List<BigInteger>();
            for (BigInteger i = 2; i * i <= q; i++)
            {
                if (q % i == 0)
                {
                    primeFactors.Add(i);
                    while (q % i == 0)
                    {
                        q /= i;
                    }
                }
            }

            if (q > 1)
            {
                primeFactors.Add(q);
            }

            for (BigInteger g = 2; g <= p; g++)
            {
                bool ok = true;
                foreach (BigInteger factor in primeFactors)
                {
                    if (BigInteger.ModPow(g, s / factor, p) == 1)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    return g;
                }
            }

            return -1;
        }
        public void DiffieHellman()
        {
            BigInteger p = GeneratingPrimeNumber(50);
            BigInteger g = FindPrimitiveRoot(p);

            BigInteger a = GenerateNumber(256);
            BigInteger A = BigInteger.ModPow(g, a, p);

            var data = new
            {
                p = p,
                g = g,
                A = A
            };
            var json = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(json);
            stream.Write(buffer, 0, buffer.Length);

            var buffer2 = new byte[512];
            var bytesRead = stream.Read(buffer2, 0, buffer2.Length);
            var json2 = Encoding.UTF8.GetString(buffer2, 0, bytesRead);
            var data2 = JsonConvert.DeserializeObject<dynamic>(json2);

            BigInteger B = data2.B;

            CommonKey = BigInteger.ModPow(B, a, p);
        }
        private void Voiti_Button_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            string code = "1";
            string answer = "";
            try
            {

                string login = Login_TextBox.Text;
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
                string HashSalt = answer;

                if (answer == "2") throw new Exception("Пользователя с таким логином не существует!");

                string T = ComputeSHA256Hash(ComputeSHA256Hash(password) + HashSalt);

                bytesOut = Encoding.UTF8.GetBytes(T);
                stream.Write(bytesOut, 0, bytesOut.Length);

                length = stream.Read(bytesIn, 0, bytesIn.Length);
                answer = Encoding.UTF8.GetString(bytesIn, 0, length);
                if (answer == "3") throw new Exception("Пароль введен неверно!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (answer == "1")
            {
                DiffieHellman();
                MessageBox.Show("Вы успешно авторизовались!");

                ChatClientServer chat = new();
                Hide();
                chat.Show();
            }
        }
    }
}