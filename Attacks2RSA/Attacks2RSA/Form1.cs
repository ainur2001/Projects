using class_RSA;

namespace Attacks2RSA
{
    public partial class Form1 : Form
    {
        public RSA rsa;
        public Form1()
        {
            InitializeComponent();
            SelectAttack_ComboBox.SelectedIndex = 0;
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
    }
}