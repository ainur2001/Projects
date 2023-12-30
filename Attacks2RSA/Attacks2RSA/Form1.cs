using class_RSA;

namespace Attacks2RSA
{
    public partial class Form1 : Form
    {
        public RSA rsa;
        public Form1()
        {
            InitializeComponent();
            rsa = new(20);
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
    }
}