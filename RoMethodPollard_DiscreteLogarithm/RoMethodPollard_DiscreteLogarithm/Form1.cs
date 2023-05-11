using System.Numerics;
using System.Security.Cryptography;

namespace RoMethodPollard_DiscreteLogarithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DiffiHelman_Button_Click(object sender, EventArgs e)
        {
            BigInteger p = GeneratingPrimeNumber(15);
            BigInteger g = FindPrimitiveRoot(p);
            BigInteger a = GenerateNumber(20);
            BigInteger A = BigInteger.ModPow(g, a, p);
            p_TextBox.Text = p.ToString();
            g_TextBox.Text = g.ToString();
            a_TextBox.Text = a.ToString();
            AA_TextBox.Text = A.ToString();
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
        private static BigInteger GenerateNumberWithLimits(BigInteger min, BigInteger max) => GenerateNumber(CountBits(max - min)) % (max - min) + min;
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

        private void RoMethodPollard_Button_Click(object sender, EventArgs e)
        {
            //BigInteger p = BigInteger.Parse(p_TextBox.Text);
            //BigInteger g = BigInteger.Parse(g_TextBox.Text);
            //BigInteger A = BigInteger.Parse(AA_TextBox.Text);

            BigInteger p = 77;
            BigInteger g = 6;
            BigInteger A = 6;


            a2_TextBox.Text = PollardRhoAlgorithm(g,p,A).ToString();
        }

        
        public static BigInteger GetRandom(BigInteger N)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = N.ToByteArray();
            BigInteger R;

            do
            {
                rng.GetBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                R = new BigInteger(bytes);
            } while (R <= 0 || R >= N);

            return R;
        }
    }
}
