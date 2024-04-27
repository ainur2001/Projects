using System.Diagnostics;
using System.Numerics;

namespace Attacks2RSA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            BigInteger message = BigInteger.Parse(Message_TextBox.Text);
            BigInteger[] e_ = { BigInteger.Parse(e1_TextBox.Text), BigInteger.Parse(e2_TextBox.Text), BigInteger.Parse(e3_TextBox.Text) };
            BigInteger[] n = { BigInteger.Parse(n1_TextBox.Text), BigInteger.Parse(n2_TextBox.Text), BigInteger.Parse(n3_TextBox.Text) };

            BigInteger[] C = { BigInteger.ModPow(message, e_[0], n[0]), BigInteger.ModPow(message, e_[1], n[1]), BigInteger.ModPow(message, e_[2], n[2]) };

            C1_TextBox.Text = C[0].ToString();
            C2_TextBox.Text = C[1].ToString();
            C3_TextBox.Text = C[2].ToString();
        }
        public static BigInteger Solve(BigInteger[] cryptogramms, BigInteger[] moduls)
        {
            BigInteger prod = 1;
            for (int i = 0; i < moduls.Length; i++)
            {
                prod *= moduls[i];
            }

            BigInteger result = 0;
            for (int i = 0; i < moduls.Length; i++)
            {
                BigInteger pp = prod / moduls[i];
                BigInteger inv = ModInverse(pp, moduls[i]);
                result += cryptogramms[i] * pp * inv;
            }

            return result % prod;
        }
        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            BigInteger[] C = { BigInteger.Parse(C1_TextBox.Text), BigInteger.Parse(C2_TextBox.Text), BigInteger.Parse(C3_TextBox.Text) };
            BigInteger[] n = { BigInteger.Parse(n1_TextBox.Text), BigInteger.Parse(n2_TextBox.Text), BigInteger.Parse(n3_TextBox.Text) };
            Stopwatch stopwatch = new();
            stopwatch.Start();
            BigInteger tmp = Solve(C, n);
            BigInteger result = NthRoot(tmp, int.Parse(e1_TextBox.Text));
            stopwatch.Stop();
            Decrypted_TextBox.Text = result.ToString();
            label12.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
        }
        private void GenerateOpenKeys_Button_Click(object sender, EventArgs e)
        {
            (BigInteger e1, BigInteger d1, BigInteger n1) = GenerateOpenAndCloseKeys();
            BigInteger e2, d2, n2;
            BigInteger e3, d3, n3;

            do
            {
                (e2,d2,n2) = GenerateOpenAndCloseKeys();
            } while (BigInteger.GreatestCommonDivisor(n1, n2) != 1);

            do
            {
                (e3, d3, n3) = GenerateOpenAndCloseKeys();
            } while (BigInteger.GreatestCommonDivisor(n1, n3) != 1 && BigInteger.GreatestCommonDivisor(n2, n3) != 1);


            e1_TextBox.Text = e1.ToString();
            n1_TextBox.Text = n1.ToString();

            e2_TextBox.Text = e2.ToString();
            n2_TextBox.Text = n2.ToString();

            e3_TextBox.Text = e3.ToString();
            n3_TextBox.Text = n3.ToString();
        }
        public (BigInteger, BigInteger, BigInteger) GenerateOpenAndCloseKeys()
        {
            BigInteger d = 0, p, q, n = 0, phi, e = 0;
            try
            {
                while (true)
                {
                    e = 11;
                    p = GeneratePrimeNumber(256);
                    q = GeneratePrimeNumber(256);
                    n = p * q;
                    phi = (p - 1) * (q - 1);
                    d = ModInverse(e, phi);
                    if (d != 0) break;
                }
            }
            catch (Exception)
            {
                (e, d, n) = GenerateOpenAndCloseKeys();
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
        private static BigInteger ExtendedEuclidean(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            BigInteger x1, y1;
            BigInteger gcd = ExtendedEuclidean(b % a, a, out x1, out y1);

            x = y1 - (b / a) * x1;
            y = x1;

            return gcd;
        }
        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger x, y;
            BigInteger gcd = ExtendedEuclidean(a, m, out x, out y);

            if (gcd != 1)
                throw new ArithmeticException("Обратный элемент не существует.");

            if (x < 0)
                x += m;

            return x;
        }
        public static BigInteger NthRoot(BigInteger number, int root)
        {
            if (number == 0 || root == 0)
                return 0;

            BigInteger lowerBound = 0;
            BigInteger upperBound = number;

            while (true)
            {
                BigInteger mid = (lowerBound + upperBound) / 2;
                BigInteger midToPower = BigInteger.Pow(mid, root);

                if (midToPower == number || lowerBound == mid)
                {
                    return mid;
                }
                else if (midToPower < number)
                {
                    lowerBound = mid;
                }
                else
                {
                    upperBound = mid;
                }
            }
        }
    }
}
