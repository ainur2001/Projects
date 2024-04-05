using System.Numerics;
using System.Text;

namespace class_RSA
{
    public class RSA
    {
        public Parameters par;
        public string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz0123456789 ";
        public RSA(int bitNumber) 
        {
            par = GenerateParam(bitNumber);
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
        private static Parameters GenerateParam(int bitNumber)
        {
            int _bitNumber = bitNumber;
            BigInteger p = 0;
            BigInteger q = 0;
            BigInteger n = 0;
            BigInteger pfi = 0;
            BigInteger e_ = 0;
            BigInteger d = 0;
            Parameters param = new Parameters();
            Thread qt = new(() => q = qf(_bitNumber));
            Thread pt = new(() => p = pf(_bitNumber));
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
            param.p = p;
            param.q = q;
            param.n = n;
            param.pfi = pfi;
            param.e_ = e_;
            param.d = d;
            return param;
        }
        public struct Parameters
        {
            public BigInteger p, q, n, pfi, e_, d;
        }
        public string EncryptText(string text)
        {
            StringBuilder result = new();
            for (int i = 0; i < text.Length; i++)
            {
                BigInteger index = ModPow(alphabet.IndexOf(text[i]), par.e_, par.n);
                result.Append(index);
                result.Append(' ');
            }
            return result.ToString();
        }
        public string DecryptText(string text)
        {
            StringBuilder result = new();
            List<BigInteger> cryptogram = text.Trim().Split(" ").Select(item => BigInteger.Parse(item)).ToList();
            for (int i = 0; i < cryptogram.Count; i++)
            {
                BigInteger index = ModPow(cryptogram[i], par.d, par.n) % alphabet.Length;
                result.Append(alphabet[int.Parse(index.ToString())].ToString());
            }
            return result.ToString();
        }
    }
}