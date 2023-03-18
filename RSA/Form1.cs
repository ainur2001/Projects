using System.Numerics;
using System.Diagnostics;

namespace RSA
{
    public partial class Form1 : Form
    {
        public const string alphabet_rus = "јЅ¬√ƒ≈∆«»… ЋћЌќѕ–—“”‘’÷„ЎўЏџ№Ёёяабвгдежзийклмнопрстуфхцчшщъыьэю€";
        public bool stopThread = false;
        public Form1()
        {
            InitializeComponent();
        }
        public static bool TestMR(BigInteger number, int bitNumber)
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
            catch (Exception) {}
            return result;
        }
        public static int CountBits(BigInteger number)
        {
            int count = 0;
            while (number != 0)
            {
                number >>= 1;
                count++;
            }
            return count;
        }
        public static BigInteger BinToDec(List<char> number)
        {
            BigInteger result = 0;
            for (int i = 0; number.Count > 0; ++i)
            {
                result += BigInteger.Pow(2, i) * (number.Last() - '0');
                number.RemoveAt(number.Count - 1);
            }
            return result;
        }
        public static BigInteger GenerateNumber(int bitNumber)
        {
            Random random = new();
            List<char> bits = new();
            for (int i = 0; i < bitNumber; ++i)
            {
                bits.Add((char)(random.Next(2) + '0'));
            }
            return BinToDec(bits);
        }
        public static BigInteger GenerateNumberWithLimits(BigInteger min, BigInteger max) => GenerateNumber(CountBits(max - min)) % (max - min) + min;
        public static BigInteger ModPow(BigInteger number, BigInteger exponent, BigInteger modulus)
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
        public static (BigInteger, BigInteger, BigInteger) PAE(BigInteger a, BigInteger b)
        {
            BigInteger s1 = 1, s2 = 0;
            BigInteger t1 = 0, t2 = 1;
            while(b != 0)
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
        private void Encryption_TextBox_Click(object sender, EventArgs e)
        {
            Cryptogram_TextBox.Text = "";
            string text = SourseText_TextBox.Text;
            try
            {
                if (!BigInteger.TryParse(n_TextBox.Text, out BigInteger n)) throw new Exception("ѕараментры шифровани€ не заданы!");
                if (!BigInteger.TryParse(e_TextBox.Text, out BigInteger e_)) throw new Exception("ѕараментры шифровани€ не заданы!");
                for (int i = 0; i < text.Length; i++)
                {
                    if(!alphabet_rus.Contains(text[i])) throw new Exception("¬ тексте присутствуют символы, не принадлежащие алфавиту!");
                }
                for (int i = 0; i < text.Length; i++)
                {
                    Cryptogram_TextBox.Text += ModPow(alphabet_rus.IndexOf(text[i]), e_, n) + " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Decryption_Button_Click(object sender, EventArgs e)
        {
            List<string> result = new();
            result.Clear();
            DecryptedText_TextBox.Text = "";
            try
            {
                List<BigInteger> cryptogram = Cryptogram_TextBox.Text.Trim().Split(" ").Select(item => BigInteger.Parse(item)).ToList();
                if (!BigInteger.TryParse(n_TextBox.Text, out BigInteger n)) throw new Exception("ѕараментры шифровани€ не заданы!");
                if (!BigInteger.TryParse(d_TextBox.Text, out BigInteger d)) throw new Exception("ѕараментры шифровани€ не заданы!");
                for (int i = 0; i < cryptogram.Count; i++)
                {
                    BigInteger index = ModPow(cryptogram[i], d, n) % alphabet_rus.Length;
                    if(index > alphabet_rus.Length) throw new Exception("ќшибка!");
                    result.Add(alphabet_rus[int.Parse(index.ToString())].ToString());
                }
                for (int i = 0; i < result.Count; i++)
                {
                    DecryptedText_TextBox.Text += result[i].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ќшибка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OpenForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new();
            f2.ShowDialog();
        }
        private void Generation_Button_Click(object sender, EventArgs e)
        {
            BigInteger p = 0;
            BigInteger q = 0;
            int _bitNumber = 0;
            Thread qt = new(() => q = qf(_bitNumber));
            Thread pt = new(() => p = pf(_bitNumber));
            string time;
            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                if (!int.TryParse(NumberBytes_TextBox.Text, out int bitNumber)) throw new ArgumentException("ќшибка ввода количества бит");
                _bitNumber = bitNumber;
                if (bitNumber < 15) throw new ArgumentException("¬ведите количество бит превышающее 15");
                pt.Start();
                qt.Start();
                pt.Join();
                qt.Join();
                p_TextBox.Text = p.ToString();
                q_TextBox.Text = q.ToString();
                BigInteger n = p * q;
                n_TextBox.Text = n.ToString();
                BigInteger fi = (p - 1) * (q - 1);
                fi_TextBox.Text = fi.ToString();
                BigInteger e_ = GenerateNumberWithLimits(2, fi);
                e_ = n / 3;
                while (BigInteger.GreatestCommonDivisor(e_, fi) != 1) e_ += 1;
                e_TextBox.Text = e_.ToString();
                BigInteger y = PAE(fi, e_).Item2;
                BigInteger d;
                if (y < 0) d = y + fi;
                else d = y;
                d_TextBox.Text = d.ToString();
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds.ToString();
                time_TextBox.Text = "¬рем€ параллельной генерации: " + time.ToString() + "ms.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static BigInteger pf(int bitNumber)
        {
            BigInteger p = 16384;
            while (!TestMR(p, bitNumber))
            {
                p = GenerateNumber(bitNumber);
                while (p <= 16384) p += 1;
            }
            return p;
        }
        public static BigInteger qf(int bitNumber)
        {
            BigInteger q = 16384;
            while (!TestMR(q, bitNumber))
            {
                q = GenerateNumber(bitNumber);
                while (q <= 16384) q += 1;
            }
            return q;
        }
        public BigInteger Ro_MethodPolarda1(BigInteger x, BigInteger n)
        {
            BigInteger y = 1; BigInteger i = 0; BigInteger stage = 2;
            while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1) 
            {
                if (stopThread) return 0;
                if (i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (BigInteger.Pow(x,2) + 1) % n;
                i++;
            }
            stopThread = true;
            return BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));
        }
        public BigInteger Ro_MethodPolarda2(BigInteger x, BigInteger n)
        {
            BigInteger y = 1; BigInteger i = 0; BigInteger stage = 2;
            while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1) 
            {
                if (stopThread) return 0;
                if (i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (BigInteger.Pow(x, 2) - 1) % n;
                i++;
            }
            stopThread = true;
            return BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));
        }
        public BigInteger Ro_MethodPolarda3(BigInteger x, BigInteger n)
        {
            BigInteger y = 1; BigInteger i = 0; BigInteger stage = 2;
            while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1)
            {
                if (stopThread) return 0;
                if (i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (BigInteger.Pow(x, 2) + 4) % n;
                i++;
            }
            stopThread = true;
            return BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));
        }
        public BigInteger Ro_MethodPolarda4(BigInteger x, BigInteger n)
        {
            BigInteger y = 1; BigInteger i = 0; BigInteger stage = 2;
            while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1)
            {
                if (stopThread) return 0;
                if (i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (BigInteger.Pow(x, 2) - 4) % n;
                i++;
            }
            stopThread = true;
            return BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));
        }
        private void Hack_Button_Click(object sender, EventArgs e)
        {
            stopThread = false;
            List<BigInteger> res = new();
            List<string> result = new();
            List<string> lettersIndex = new();
            lettersIndex.Clear();
            result.Clear();
            res.Clear();
            DecryptedText_TextBox.Text = "";
            BigInteger p1 = 0,  p2 = 0, p3 = 0, p4 = 0, p = 0, d = 0;
            try
            {
                List<BigInteger> cryptogram = Cryptogram_TextBox.Text.Trim().Split(" ").Select(item => BigInteger.Parse(item)).ToList();
                if (!BigInteger.TryParse(e_TextBox.Text, out BigInteger e_)) throw new Exception("ѕараментры дешифровки не заданы!");
                if (!BigInteger.TryParse(n_TextBox.Text, out BigInteger n)) throw new Exception("ѕараментры дешифровки не заданы!");
                Thread t1 = new(() => p1 = Ro_MethodPolarda1(2, n));
                Thread t2 = new(() => p2 = Ro_MethodPolarda2(n / 4, n));
                Thread t3 = new(() => p3 = Ro_MethodPolarda3(n / 2, n));
                Thread t4 = new(() => p4 = Ro_MethodPolarda4((n * 3) / 4, n));
                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t1.Join();
                t2.Join();
                t3.Join();
                t4.Join();
                res.Add(p1);
                res.Add(p2);
                res.Add(p3);
                res.Add(p4);
                res.Sort();
                p = res[3];
                BigInteger q = n / p;
                BigInteger fi = (p - 1) * (q - 1);
                BigInteger y = PAE(fi, e_).Item2;
                if (y < 0) d = y + fi;
                else d = y;

                for (int i = 0; i < cryptogram.Count; i++)
                {
                    BigInteger temp = ModPow(cryptogram[i], d, n);

                    for (int j = 0; temp.ToString().Length != 2; ++j)
                    {
                        lettersIndex.Add(temp.ToString()[0..2]);
                        temp = BigInteger.Parse(temp.ToString()[2..]);
                    }
                    lettersIndex.Add(temp.ToString());
                }
                for (int i = 0; i < lettersIndex.Count; i++)
                {
                    result.Add(alphabet_rus[int.Parse(lettersIndex[i]) - 16].ToString());
                }
                for (int i = 0; i < result.Count; i++)
                {
                    DecryptedText_TextBox.Text += result[i].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ќшибка!");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("ќшибка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}