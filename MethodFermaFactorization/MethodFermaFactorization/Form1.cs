using System.Numerics;

namespace MethodFermaFactorization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Factorize_Button_Click(object sender, EventArgs e)
        {
            BigInteger a = 0, b = 0, n = BigInteger.Parse(n_TextBox.Text);
            BigInteger x = BigInteger.Sqrt(n) + 1;
            BigInteger ySquare = x * x - n;

            while (!IsSquare(ySquare))
            {
                x++;
                ySquare = x * x - n;
            }

            BigInteger y = BigInteger.Sqrt(ySquare);
            a = x - y;
            b = x + y;
        }
    }
}