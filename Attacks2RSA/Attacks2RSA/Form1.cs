using class_RSA;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using static class_RSA.RSA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Attacks2RSA
{
    public partial class Form1 : Form
    {
        public RSA rsa;
        public Form1()
        {
            InitializeComponent();
            SelectAttack_ComboBox.SelectedIndex = 0;
            ConutBits_TextBox.Text = "25";
            ConutBitsQ_TextBox.Text = "25";
        }
        private void Encrypt_Button_Click(object sender, EventArgs e)
        {
            string sourceText = SourceText_TextBox.Text;
            //EncryptedText_TextBox.Text = rsa.EncryptText(sourceText);
            EncryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(SourceText_TextBox.Text), BigInteger.Parse(e_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
        }
        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            string encyptedText = EncryptedText_TextBox.Text;
            //DecryptedText_TextBox.Text = rsa.DecryptText(encyptedText);
            DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
        }
        private void InitializationRSA_Button_Click(object sender, EventArgs e)
        {
            int countBits = int.Parse(ConutBits_TextBox.Text);
            /*rsa = new(countBits);
            p_TextBox.Text = rsa.par.p.ToString();
            q_TextBox.Text = rsa.par.q.ToString();
            n_TextBox.Text = rsa.par.n.ToString();
            pfi_TextBox.Text = rsa.par.pfi.ToString();
            e_TextBox.Text = rsa.par.e_.ToString();
            d_TextBox.Text = rsa.par.d.ToString();*/
            List<BigInteger> param = GenerateParam(int.Parse(ConutBits_TextBox.Text), int.Parse(ConutBitsQ_TextBox.Text));
            p_TextBox.Text = param[0].ToString();
            q_TextBox.Text = param[1].ToString();
            n_TextBox.Text = param[2].ToString();
            pfi_TextBox.Text = param[3].ToString();
            e_TextBox.Text = param[4].ToString();
            d_TextBox.Text = param[5].ToString();
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
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms.";
                    //DecryptedText_TextBox.Text = DecryptText(EncryptedText_TextBox.Text, BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text));
                    DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
                    break;

                case "Ро-1 - метод Полларда":
                    stopwatch.Start();
                    RoMinusOneMethodPollarda();
                    stopwatch.Stop();
                    Time_Label.Text = "Дешифровка произошла за: " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms.";
                    //DecryptedText_TextBox.Text = DecryptText(EncryptedText_TextBox.Text, BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text));
                    DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
                    break;

                    /*case "Факторизация Диксона":
                        stopwatch.Start();
                        DixonFactor();
                        Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                        DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
                        stopwatch.Stop();
                        break;

                    case "Факторизация Ленстры":
                        stopwatch.Start();
                        List<BigInteger> pq = FactorizeEllipticCurve(BigInteger.Parse(n_TextBox.Text));
                        BigInteger p = pq[0], q = pq[1];
                        p_TextBox.Text = p.ToString();
                        q_TextBox.Text = q.ToString();
                        BigInteger pfi = (p - 1) * (q - 1);
                        pfi_TextBox.Text = pfi.ToString();
                        BigInteger d = ModInverse(BigInteger.Parse(e_TextBox.Text), pfi);
                        d_TextBox.Text = d.ToString();
                        Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                        DecryptedText_TextBox.Text = BigInteger.ModPow(BigInteger.Parse(EncryptedText_TextBox.Text), BigInteger.Parse(d_TextBox.Text), BigInteger.Parse(n_TextBox.Text)).ToString();
                        stopwatch.Stop();
                        break;*/

                    /*case "Полное возведение в степень":
                        stopwatch.Start();
                        FullExponentiation();
                        stopwatch.Stop();
                        Time_Label.Text = "Дешифровка произошла за: " + stopwatch.ElapsedMilliseconds.ToString() + "ms.";
                        break;*/
            }
        }
        private void RoMethodPollarda()
        {
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            //BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
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
            //BigInteger d = ModInverse(e_, pfi);
            //d_TextBox.Text = d.ToString();
        }
        private void RoMinusOneMethodPollarda()
        {
            BigInteger n = BigInteger.Parse(n_TextBox.Text);
            BigInteger e_ = BigInteger.Parse(e_TextBox.Text);
            BigInteger p;
            List<BigInteger> B = ReshetoEratosphena(100);
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
                    int newIndex = B.IndexOf(b) + 100;
                    b = newIndex < B.Count ? B[newIndex] : B[B.Count - 1];
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
        private void OpenHastad_Button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            form2.Show();
        }
        private void OpenViner_Button_Click(object sender, EventArgs e)
        {
            Form3 form3 = new();
            form3.Show();
        }
        /*public void DixonFactor()
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
        }*/
        private static List<BigInteger> GenerateParam(int bitP, int bitQ)
        {
            List<BigInteger> param = new();
            BigInteger p = 0;
            BigInteger q = 0;
            BigInteger n = 0;
            BigInteger pfi = 0;
            BigInteger e_ = 0;
            BigInteger d = 0;
            Thread qt = new(() => q = qf(bitQ));
            Thread pt = new(() => p = pf(bitP));
            pt.Start();
            qt.Start();
            pt.Join();
            qt.Join();
            n = p * q;
            pfi = (p - 1) * (q - 1);
            e_ = GenerateNumberWithLimits(2, pfi);
            e_ = n / 3;
            while (BigInteger.GreatestCommonDivisor(e_, pfi) != 1) e_ += 1;
            BigInteger y = PAE(pfi, e_).Item2;
            if (y < 0) d = y + pfi;
            else d = y;
            param.Add(p);
            param.Add(q);
            param.Add(n);
            param.Add(pfi);
            param.Add(e_);
            param.Add(d);
            return param;
        }
        private static (BigInteger, BigInteger, BigInteger) PAE(BigInteger a, BigInteger b)
        {
            BigInteger s1 = 1, s2 = 0;
            BigInteger t1 = 0, t2 = 1;
            while (b != 0)
            {
                BigInteger q = a / b;
                BigInteger r = a % b;
                a = b;
                b = r;
                BigInteger s = s1 - q * s2;
                s1 = s2;
                s2 = s;
                BigInteger t = t1 - q * t2;
                t1 = t2;
                t2 = t;
            }
            return (s1, t1, a);
        }
        private static BigInteger pf(int bitNumber)
        {
            BigInteger p = 1024;
            while (!TestMR(p, bitNumber))
            {
                p = GenerateNumber(bitNumber);
                while (p <= 1024) p += 1;
            }
            return p;
        }
        private static BigInteger qf(int bitNumber)
        {
            BigInteger q = 1024;
            while (!TestMR(q, bitNumber))
            {
                q = GenerateNumber(bitNumber);
                while (q <= 1024) q += 1;
            }
            return q;
        }
        /*static List<BigInteger> FactorizeEllipticCurve(BigInteger n)
        {
            List<BigInteger> factors = new List<BigInteger>();

            // Начальные значения параметров
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger x = 2;
            BigInteger y = 2;
            BigInteger p = n;
            BigInteger q = n;
            BigInteger x1 = 0;
            BigInteger y1 = 0;
            BigInteger i = 1;

            // Параметры алгоритма
            BigInteger B = 20;
            BigInteger j = 0;

            // Генерация случайной точки на кривой
            Random rand = new Random();
            BigInteger seed = BigInteger.Abs(new BigInteger(rand.Next()));
            BigInteger x0 = seed % n;
            BigInteger y0 = (x0 * x0 * x0 + a * x0 + b) % n;

            // Основной цикл факторизации
            while (true)
            {
                BigInteger k = i * B + j;
                x1 = (BigInteger.ModPow(x0, 2, n) + a + k * B) % n;
                y1 = (x0 * x1 + b) % n;
                x1 = (BigInteger.ModPow(x1, 2, n) + a + k * B) % n;
                y1 = (x1 * x1 + a * x1 + b) % n;
                p = BigInteger.GreatestCommonDivisor(BigInteger.Abs(x - x1), n);
                q = BigInteger.GreatestCommonDivisor(BigInteger.Abs(y - y1), n);
                if (p > 1 && p < n)
                {
                    factors.Add(p);
                    factors.Add(n / p); // Добавляем второй фактор, разделив n на первый фактор
                    return factors;
                }
                if (q > 1 && q < n)
                {
                    factors.Add(q);
                    factors.Add(n / q); // Добавляем второй фактор, разделив n на первый фактор
                    return factors;
                }
                if (i == j)
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }
            }
        }*/
    }
}