using class_RSA;
using System.Numerics;
using System.Diagnostics;
using System.Text;

namespace Attacks2RSA
{
    public partial class Form1 : Form
    {
        public RSA rsa;
        public Form1()
        {
            InitializeComponent();
            SelectAttack_ComboBox.SelectedIndex = 0;
            ConutBits_TextBox.Text = "16";
        }
        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            string sourceText = SourceText_TextBox.Text;
            EncryptedText_TextBox.Text = rsa.EncryptText(sourceText);
        }
        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            string encyptedText = EncryptedText_TextBox.Text;
            DecryptedText_TextBox.Text = rsa.DecryptText(encyptedText);
        }
        private void InitializationRSA_Button_Click(object sender, EventArgs e)
        {
            int countBits = int.Parse(ConutBits_TextBox.Text);
            rsa = new(countBits);
            p_TextBox.Text = rsa.par.p.ToString();
            q_TextBox.Text = rsa.par.q.ToString();
            n_TextBox.Text = rsa.par.n.ToString();
            pfi_TextBox.Text = rsa.par.pfi.ToString();
            e_TextBox.Text = rsa.par.e_.ToString();
            d_TextBox.Text = rsa.par.d.ToString();
        }
        private void Attack_Button_Click(object sender, EventArgs e)
        {
            string typeAttack = SelectAttack_ComboBox.Text;
            Stopwatch stopwatch = new();
            switch (typeAttack)
            {
                case "Ро - метод Полларда":
                    stopwatch.Start();
                    RoMethodPollarda();
                    stopwatch.Stop();
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                    DecryptedText_TextBox.Text = DecryptText(EncryptedText_TextBox.Text, BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text));
                    break;

                case "Ро-1 - метод Полларда":
                    stopwatch.Start();
                    RoMinusOneMethodPollarda();
                    stopwatch.Stop();
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                    DecryptedText_TextBox.Text = DecryptText(EncryptedText_TextBox.Text, BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text));
                    break;

                case "Диксона":
                    stopwatch.Start();
                    DixonFactor();
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                    DecryptedText_TextBox.Text = DecryptText(EncryptedText_TextBox.Text, BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text));
                    stopwatch.Stop();
                    break;

                case "Полное возведение в степень":
                    stopwatch.Start();
                    FullExponentiation();
                    stopwatch.Stop();
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                    break;
            }
        }
        private void RoMethodPollarda()
        {
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger y = 1; BigInteger i = 0; BigInteger stage = 2; BigInteger x = 2;
            while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1)
            {
                if (i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (BigInteger.Pow(x, 2) + 1) % n;
                i++;
            }
            BigInteger p = BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));
            BigInteger q = n / p;
            p_TextBox.Text = p.ToString();
            q_TextBox.Text = q.ToString();
            BigInteger pfi = (p - 1) * (q - 1);
            pfi_TextBox.Text = pfi.ToString();
            BigInteger d = ModInverse(e_, pfi);
            d_TextBox.Text = d.ToString();
        }
        private void RoMinusOneMethodPollarda()
        {
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger p;
            List<BigInteger> B = ReshetoEratosphena((int)NewtonSqrt(n));
            Random rnd = new();
            BigInteger b = B[rnd.Next(0, B.Count)];
            while (true)
            {
                BigInteger m = 1;
                foreach (BigInteger item in B)
                {
                    if (item != b)
                    {
                        m *= BigInteger.Pow(item, (int)BigInteger.Log(b, (double)item));
                    }
                    else break;
                }
                Random rnd2 = new();
                int a = rnd2.Next(2, (int)NewtonSqrt(NewtonSqrt(n)));
                BigInteger g = BigInteger.GreatestCommonDivisor(BigInteger.ModPow(a, m, n) - 1, n);
                if (1 < g && g < n)
                {
                    p = g;
                    break;
                }
                if (g == 1)
                {
                    if (B.IndexOf(b) == B[B.Count - 1])
                    {
                        p = 1;
                        break;
                    }
                    else b = B[B.IndexOf(b) + 100];
                }
                if (g == n)
                {
                    if (B.IndexOf(b) == B[0])
                    {
                        p = 1;
                        break;
                    }
                    else if (B.IndexOf(b) >= 100)
                    {
                        b = B[B.IndexOf(b) - 100];
                    }
                }
            }
            p_TextBox.Text = p.ToString();
            BigInteger q = n / p;
            q_TextBox.Text = q.ToString();
            BigInteger pfi = (p - 1) * (q - 1);
            pfi_TextBox.Text = pfi.ToString();
            BigInteger d = ModInverse(e_, pfi);
            d_TextBox.Text = d.ToString();
        }
        public static BigInteger NewtonSqrt(BigInteger n)
        {
            if (n <= 0) return 0;

            BigInteger x = n;
            BigInteger prevX = BigInteger.Zero;

            while (true)
            {
                prevX = x;
                x = (x + n / x) / 2;

                if (x >= prevX)
                    break;
            }

            return x;
        }
        private static bool isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
        private List<BigInteger> ReshetoEratosphena(int number)
        {
            List<BigInteger> primeNumbers = new();
            bool[] IsPrime = new bool[number + 1];
            for (int i = 0; i <= number; i++)
            {
                IsPrime[i] = true;
            }
            for (int i = 2; i * i <= number; i++)
            {
                if (IsPrime[i])
                {
                    for (int j = 2 * i; j <= number; j += i)
                    {
                        IsPrime[j] = false;
                    }
                }
            }
            for (int i = 2; i <= number; i++)
            {
                if (IsPrime[i])
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers;
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
        private string DecryptText(string text, BigInteger d, BigInteger n)
        {
            StringBuilder result = new();
            List<BigInteger> cryptogram = text.Trim().Split(" ").Select(item => BigInteger.Parse(item)).ToList();
            for (int i = 0; i < cryptogram.Count; i++)
            {
                BigInteger index = ModPow(cryptogram[i], d, n) % rsa.alphabet.Length;
                result.Append(rsa.alphabet[int.Parse(index.ToString())].ToString());
            }
            return result.ToString();
        }
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
        private void FullExponentiation()
        {
            DecryptedText_TextBox.Text = "";
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            string[] tmp = EncryptedText_TextBox.Text.Split(" ");
            List<BigInteger> cryptogramms = new();
            for (int i = 0; i < tmp.Length - 1; i++) cryptogramms.Add(BigInteger.Parse(tmp[i]));
            int j = 1;
            BigInteger C_temp = BigInteger.ModPow(cryptogramms[0], e_, n);
            while (C_temp != cryptogramms[0])
            {
                j++;
                C_temp = BigInteger.ModPow(C_temp, e_, n);
            }
            List<BigInteger> decrypted = new();
            for (int i = 0; i < cryptogramms.Count; i++)
            {
                BigInteger tmp1 = BigInteger.ModPow(cryptogramms[i], BigInteger.Pow(e_, j - 1), n);
                decrypted.Add(tmp1 % rsa.alphabet.Length);
            }
            foreach (BigInteger dec in decrypted) DecryptedText_TextBox.Text += rsa.alphabet[(int)dec];
        }
        static BigInteger gcd(BigInteger num1, BigInteger num2)
        {
            BigInteger a = BigInteger.Abs(num1);
            BigInteger b = BigInteger.Abs(num2);
            while ((a != 0) && (b != 0) && (a != b))
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return BigInteger.Max(a, b);
        }
        public void DixonFactor()
        {
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            List<BigInteger> base1 = ReshetoEratosphena(500);
            BigInteger start = NewtonSqrt(n);
            List<(BigInteger, BigInteger)> pairs = new List<(BigInteger, BigInteger)>();
            foreach (int baseNumber in base1)
            {
                for (BigInteger i = start; i < n; i++)
                {
                    BigInteger lhs = BigInteger.ModPow(i, 2, n);
                    BigInteger rhs = BigInteger.ModPow(baseNumber, 2, n);
                    if (lhs == rhs)
                    {
                        pairs.Add((i, baseNumber));
                    }
                }
            }

            List<BigInteger> factors = new List<BigInteger>();
            foreach (var pair in pairs)
            {
                BigInteger factor = gcd(pair.Item1 - pair.Item2, n);
                if (factor != 1)
                    factors.Add(factor);
            }

            HashSet<BigInteger> uniqueFactors = new HashSet<BigInteger>(factors);
            BigInteger[] uniqueFactorsArray = new BigInteger[uniqueFactors.Count];
            uniqueFactors.CopyTo(uniqueFactorsArray);
            BigInteger p = uniqueFactorsArray[0], q = uniqueFactorsArray[1];
            p_TextBox.Text = p.ToString();
            q_TextBox.Text = q.ToString();
            BigInteger pfi = (p - 1) * (q - 1);
            pfi_TextBox.Text = pfi.ToString();
            BigInteger d = ModInverse(e_, pfi);
            d_TextBox.Text = d.ToString();
        }
        private void OpenSecondForm_Button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            form2.Show();
        }
    }
}