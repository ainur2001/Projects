using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void ModPow_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BigInteger.TryParse(a_TextBox.Text, out BigInteger a)) throw new Exception("Ошибка ввода данных");
                if (!BigInteger.TryParse(x_TextBox.Text, out BigInteger x)) throw new Exception("Ошибка ввода данных");
                if (!BigInteger.TryParse(n_TextBox.Text, out BigInteger n)) throw new Exception("Ошибка ввода данных");
                result_TextBox.Text = Form1.ModPow(a, x, n).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PAE_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BigInteger.TryParse(AA_TextBox.Text, out BigInteger a)) throw new Exception("Ошибка ввода данных");
                if (!BigInteger.TryParse(BB_TextBox.Text, out BigInteger b)) throw new Exception("Ошибка ввода данных");
                ResultPAE_TextBox.Text = $"x={Form1.PAE(a, b).Item1}\r\ny={Form1.PAE(a, b).Item2}\r\nНОД={Form1.PAE(a, b).Item3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
