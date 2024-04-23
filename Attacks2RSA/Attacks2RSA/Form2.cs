using System.Numerics;
using System.Windows.Forms;

namespace Attacks2RSA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Message_TextBox.Text = 19.ToString();
            e1_TextBox.Text = 17.ToString();
            e2_TextBox.Text = 17.ToString();
            e3_TextBox.Text = 17.ToString();
            n1_TextBox.Text = 119.ToString();
            n2_TextBox.Text = 221.ToString();
            n3_TextBox.Text = 323.ToString();



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

        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            a = a % m;
            for (BigInteger x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                    return x;
                }
            }
            return 1;
        }
        public static BigInteger Solve(BigInteger[] remainders, BigInteger[] moduli)
        {
            BigInteger prod = 1;
            for (int i = 0; i < moduli.Length; i++)
            {
                prod *= moduli[i];
            }

            BigInteger result = 0;
            for (int i = 0; i < moduli.Length; i++)
            {
                BigInteger pp = prod / moduli[i];
                BigInteger inv = ModInverse(pp, moduli[i]);
                result += remainders[i] * pp * inv;
            }

            return result % prod;
        }

        private void Decrypt_Button_Click(object sender, EventArgs e)
        {
            BigInteger[] C = { BigInteger.Parse(C1_TextBox.Text), BigInteger.Parse(C2_TextBox.Text), BigInteger.Parse(C3_TextBox.Text) };
            BigInteger[] n = { BigInteger.Parse(n1_TextBox.Text), BigInteger.Parse(n2_TextBox.Text), BigInteger.Parse(n3_TextBox.Text) };

            BigInteger result = Solve(C, n);
            Decrypted_TextBox.Text = result.ToString();
        }
    }
}
