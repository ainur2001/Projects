using System.Collections;
using System.Text;

namespace Reed_Solomon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerationMessage_Button_Click(object sender, EventArgs e)
        {
            int countBits = int.Parse(CountBits_TextBox.Text);
            Random random = new();
            StringBuilder binarySequence = new();

            for (int i = 0; i < countBits; i++)
            {
                int bit = random.Next(2); // Генерируем случайное число 0 или 1
                binarySequence.Append(bit);
            }
            SourceMessage_TextBox.Text = binarySequence.ToString();
        }

        private void Encoding_Button_Click(object sender, EventArgs e)
        {
            int dataLength = 4;
            int parityLength = 2;
            string sourceMessage = SourceMessage_TextBox.Text;
            ReedSolomon reedSolomon = new(dataLength, parityLength);
            byte[] encodedData = reedSolomon.Encode(sourceMessage);
            EncodeMessage_TextBox.Text = string.Join("", encodedData.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }
    }

    public class ReedSolomon
    {
        private int dataLength;
        private int parityLength;
        public ReedSolomon(int dataLength, int parityLength)
        {
            this.dataLength = dataLength;
            this.parityLength = parityLength;
        }

        public byte[] Encode(string input)
        {
            if (input.Length != dataLength)
            {
                throw new ArgumentException("Длина входных данных должна быть равна длине данных кода Рида-Соломона.");
            }
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);
            byte[] encodedData = new byte[dataLength + parityLength];
            Array.Copy(dataBytes, encodedData, dataLength);
            return encodedData;
        }
    }
}