using Newtonsoft.Json;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace Client
{
    public partial class Voting : Form
    {
        public static string Vote = "";
        public static TcpClient client = new("127.0.0.1", 7000);
        public static NetworkStream stream;
        public static BigInteger n = Authorization.n;
        public static BigInteger e_ = Authorization.e_;
        public static string loginn = Authorization.loginn;
        public Voting()
        {
            InitializeComponent();
        }
        private void Za_Button_Click(object sender, EventArgs e)
        {
            Vote = "за";
            Protiv_Button.Hide();
            Vozderzalsya_Button.Hide();
            SendVoice(Vote);
            MessageBox.Show("Вы проголосовали ЗА.\r\nВаш голос учтен!");
        }
        private void Protiv_Button_Click(object sender, EventArgs e)
        {
            Vote = "против";
            Vozderzalsya_Button.Hide();
            Za_Button.Hide();
            SendVoice(Vote);
            MessageBox.Show("Вы проголосовали ПРОТИВ.\r\nВаш голос учтен!");
        }
        private void Vozderzalsya_Button_Click(object sender, EventArgs e)
        {
            Vote = "воздержался";
            Za_Button.Hide();
            Protiv_Button.Hide();
            SendVoice(Vote);
            MessageBox.Show("Вы ВОЗДЕРЖАЛИСЬ.\r\nВаш голос учтен!");
        }
        private void SendVoice(string Vote)
        {
            int B = 0;
            if (Vote == "за") B = 2;
            else if (Vote == "против") B = 3;
            else if (Vote == "воздержался") B = 1;

            BigInteger Q = GeneratePrimeNumber(16);
            BigInteger T = B * Q;
            BigInteger F = BigInteger.ModPow(T, e_, n);
            string code = "2";
            stream = client.GetStream();
            var data = new
            {
                code = code,
                F = F,
                loginn = loginn,
            };
            var json = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(json);
            stream.Write(buffer, 0, buffer.Length);
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
    }
}
