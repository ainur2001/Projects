using System.Diagnostics;
using System.Numerics;

namespace Attacks2RSA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void GenerateOpenAndCloseKeys_Button_Click(object sender, EventArgs e)
        {
            (BigInteger e_, BigInteger d, BigInteger n) = GenerateOpenAndCloseKeys();
            e_TextBox.Text = e_.ToString();
            n_TextBox.Text = n.ToString();
        }
        public BigInteger VinerAttackMethod()
        {
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            double l = BigInteger.Log(n, 2);
            BigInteger numerator = e_;
            BigInteger denominator = n;
            BigInteger[] Q = { 0, 1 };
            for (BigInteger i = 0; i < (BigInteger)l; i++)
            {
                BigInteger buf = denominator;
                denominator = numerator;
                numerator = buf;
                BigInteger a = numerator / denominator;
                BigInteger Q_i = a * Q[1] + Q[0];
                Random rand = new();
                BigInteger m = rand.Next(1000, 1000000);
                if (BigInteger.ModPow(m, e_ * Q_i, n) == m % n)
                    return Q_i;
                if (denominator == 1)
                    return 0;
                numerator %= denominator;
                Q[0] = Q[1];
                Q[1] = Q_i;
            }
            return 0;
        }
        public (BigInteger, BigInteger, BigInteger) GenerateOpenAndCloseKeys()
        {
            BigInteger d = 0, p, q, n = 0, phi, e = 0;
            try
            {
                while (true)
                {
                    d = GeneratePrimeNumber(13);
                    p = GeneratePrimeNumber(100);
                    q = GeneratePrimeNumber(100);
                    n = p * q;
                    phi = (p - 1) * (q - 1);
                    e = ModInverse(d, phi);
                    if (e != 0) break;
                }
            }
            catch (Exception)
            {
                GenerateOpenAndCloseKeys();
            }
            return (e, d, n);
        }
        private static BigInteger GeneratePrimeNumber(int bitNumber)
        {
            BigInteger p = 1024;
            while (!TestMR(p, bitNumber))
            {
                p = GenerateNumber(bitNumber);
                while (p <= 1024) p += 1;
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
        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger x0 = 0;
            BigInteger x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q - частное
                BigInteger q = a / m;

                BigInteger t = m;

                // m - остаток
                m = a % m;
                a = t;
                t = x0;

                x0 = x1 - q * x0;
                x1 = t;
            }

            // Убеждаемся, что x1 положительное
            if (x1 < 0)
                x1 += m0;

            return x1;
        }
        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            BigInteger message = BigInteger.Parse(Message_TextBox.Text);
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            EncryptedText_TextBox.Text = BigInteger.ModPow(message, e_, n).ToString();
        }
        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            BigInteger d = VinerAttackMethod();
            stopwatch.Stop();
            d_TextBox.Text = d.ToString();
            DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), d, BigInteger.Parse(n_TextBox.Text)).ToString();
            label5.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
        }
    }
}
