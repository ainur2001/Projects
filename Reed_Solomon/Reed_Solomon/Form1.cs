using System.Collections;
using System.Text;

namespace Reed_Solomon
{
    public partial class Form1 : Form
    {
        private ReedSolomon reedSolomon;
        public Form1()
        {
            InitializeComponent();
            reedSolomon = new ReedSolomon();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string inputText = input_TextBox.Text;
                byte[] inputData = Encoding.UTF8.GetBytes(inputText);

                int ecBytes = (int)Math.Ceiling(0.1 * inputData.Length);
                byte[] encodedData = reedSolomon.Encode(inputData, ecBytes);

                string encodedText = ByteArrayToBinaryString(encodedData);
                encoded_TextBox.Text = encodedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при кодировании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ByteArrayToBinaryString(byte[] byteArray)
        {
            StringBuilder binaryStringBuilder = new StringBuilder();

            foreach (byte b in byteArray)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return binaryStringBuilder.ToString();
        }


        private void decodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string encodedText = encoded_TextBox.Text;
                byte[] encodedData = StringToByteArray(encodedText);

                bool decodingSuccessful = reedSolomon.Decode(ref encodedData);

                if (decodingSuccessful)
                {
                    string decodedText = Encoding.UTF8.GetString(encodedData);
                    decoded_TextBox.Text = decodedText;

                    MessageBox.Show("Декодирование успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Декодирование не удалось. Присутствуют ошибки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при декодировании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void introduceErrorButton_Click(object sender, EventArgs e)
        {
            // Умышленное внесение ошибки для тестирования декодирования
            Random random = new();
            int errorIndex = random.Next(encoded_TextBox.Text.Length);
            StringBuilder corruptedText = new(encoded_TextBox.Text);
            corruptedText[errorIndex] = (char)('0' + ('1' - corruptedText[errorIndex]));

            encoded_TextBox.Text = corruptedText.ToString();
        }

        private byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }



    public class GaloisField
    {
        private const int Size = 256; // Размер поля Галуа (2^8)

        private readonly int[] expTable = new int[Size * 2];
        private readonly int[] logTable = new int[Size + 1];

        public GaloisField()
        {
            int x = 1;
            for (int i = 0; i < Size; i++)
            {
                expTable[i] = x;
                logTable[x] = i;
                x <<= 1;
                if ((x & 0x100) != 0)
                {
                    x ^= 0x11D; // Полином для поля Галуа GF(2^8)
                }
            }

            for (int i = Size; i < Size * 2; i++)
            {
                expTable[i] = expTable[i - Size];
            }
        }

        public int Add(int a, int b)
        {
            return (a + b)%256;
        }

        public int Subtract(int a, int b)
        {
            return a ^ b;
        }

        public int Multiply(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else
            {
                return expTable[logTable[a] + logTable[b]];
            }
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            else if (a == 0)
            {
                return 0;
            }
            else
            {
                return expTable[logTable[a] + Size - logTable[b]];
            }
        }

        public int Exp(int a)
        {
            return expTable[a];
        }

        public int Inverse(int a)
        {
            if (a == 0)
            {
                throw new InvalidOperationException("Cannot compute the inverse of zero.");
            }

            return expTable[Size - logTable[a]];
        }

    }

    public class ReedSolomon
    {
        private GaloisField gf;

        public ReedSolomon()
        {
            gf = new GaloisField();
        }

        public byte[] Encode(byte[] data, int ecBytes)
        {
            int dataBytes = data.Length; // k
            int totalBytes = dataBytes + ecBytes; // n

            byte[] message = new byte[totalBytes];
            Array.Copy(data, message, dataBytes);

            byte[] ecBytesArray = new byte[ecBytes];
            CalculateParity(message, ecBytesArray);

            Array.Copy(ecBytesArray, 0, message, dataBytes, ecBytes);

            return message;
        }

        public bool Decode(ref byte[] data)
        {
            int dataBytes = data.Length;

            int ecBytes = data.Length / 10;
            if (ecBytes < 2)
            {
                ecBytes = 2;
            }

            byte[] syndromes = new byte[ecBytes];
            byte[] recd = new byte[dataBytes];

            Array.Copy(data, recd, dataBytes);

            CalculateSyndromes(recd, syndromes);

            int errorCount = FindErrorLocator(syndromes);
            if (errorCount > 0)
            {
                FindErrors(recd, syndromes, errorCount);
                return false;
            }

            return true;
        }

        private void CalculateParity(byte[] data, byte[] parity)
        {
            int dataBytes = data.Length;
            int ecBytes = parity.Length;

            for (int i = 0; i < ecBytes; i++)
            {
                int feedback = gf.Multiply(data[dataBytes - 1], parity[i]);

                for (int j = dataBytes - 1; j > 0; j--)
                {
                    data[j] = (byte)gf.Add(data[j - 1], gf.Multiply(feedback, Constants.ALPHA_TO[(dataBytes + j - i - 1) % 255]));
                }

                data[0] = (byte)gf.Multiply(feedback, Constants.ALPHA_TO[(dataBytes + 0 - i - 1) % 255]);
            }
        }

        private void CalculateSyndromes(byte[] recd, byte[] syndromes)
        {
            int ecBytes = syndromes.Length;

            for (int i = 0; i < ecBytes; i++)
            {
                int sum = 0;
                for (int j = 0; j < recd.Length; j++)
                {
                    sum ^= gf.Multiply(recd[j], Constants.ALPHA_TO[(i * j) % 255]);
                }
                syndromes[i] = (byte)sum;
            }
        }

        private int FindErrorLocator(byte[] syndromes)
        {
            int errorLocatorDegree = -1;
            int[] oldLocator = new int[Constants.MAX_ERRORS + 1];
            int[] newLocator = new int[Constants.MAX_ERRORS + 1];
            int[] discrepancy = new int[Constants.MAX_ERRORS + 1];
            int[] lambda = new int[Constants.MAX_ERRORS + 2]; // Увеличиваем размерность
            int[] omega = new int[Constants.MAX_ERRORS + 1];


            oldLocator[0] = 1;
            oldLocator[1] = gf.Exp(syndromes[0]);

            lambda[0] = 1;
            lambda[1] = gf.Exp(syndromes[0]);

            for (int i = 1; i < Constants.MAX_ERRORS; i++)
            {
                discrepancy[i] = 0;
                lambda[i + 1] = 0;
            }

            int syndromesLength = syndromes.Length;

            for (int i = 1; i <= Constants.MAX_ERRORS; i++)
            {
                for (int j = 0; j <= errorLocatorDegree; j++)
                {
                    if (oldLocator[j] != 0)
                    {
                        discrepancy[i] ^= gf.Multiply(oldLocator[j], syndromes[i - j - 1]);
                    }
                }

                int delta = gf.Multiply(discrepancy[i], gf.Inverse(lambda[errorLocatorDegree]));

                Array.Copy(oldLocator, newLocator, oldLocator.Length);
                for (int j = 0; j <= errorLocatorDegree; j++)
                {
                    if (delta != 0)
                    {
                        newLocator[j] ^= gf.Multiply(delta, lambda[j]);
                    }
                }

                if (2 * errorLocatorDegree <= i)
                {
                    errorLocatorDegree = i - errorLocatorDegree;
                    Array.Copy(discrepancy, lambda, discrepancy.Length);
                }

                Array.Copy(newLocator, oldLocator, newLocator.Length);
            }

            return errorLocatorDegree;
        }

        private void FindErrors(byte[] recd, byte[] syndromes, int errorCount)
        {
            int syndromesLength = syndromes.Length;

            int[] errorLocator = new int[Constants.MAX_ERRORS + 2]; // Увеличиваем размерность
            int[] errorLocations = new int[Constants.MAX_ERRORS];

            int errorLocatorDegree = FindErrorLocator(syndromes);

            if (errorLocatorDegree <= errorCount)
            {
                int count = 0;
                for (int i = 1; i <= syndromesLength; i++)
                {
                    int sum = 0;
                    for (int j = 0; j <= errorLocatorDegree; j++)
                    {
                        sum ^= gf.Multiply(errorLocator[j], gf.Exp((2 * syndromesLength - i) * j));
                    }

                    if (sum == 0)
                    {
                        errorLocations[count] = syndromesLength - i;
                        count++;

                        if (count == errorCount)
                        {
                            break;
                        }
                    }
                }

                for (int i = 0; i < errorCount; i++)
                {
                    int errorLocation = errorLocations[i];
                    int delta = syndromes[syndromesLength - 1 - errorLocation];

                    for (int j = errorLocation + 1; j < recd.Length; j++)
                    {
                        delta ^= gf.Multiply(errorLocator[j - errorLocation - 1], recd[j]);
                    }

                    recd[errorLocation] = (byte)(recd[errorLocation] ^ delta);
                }
            }
            else
            {
                throw new InvalidOperationException("Too many errors to correct.");
            }
        }
    }

    public static class Constants
    {
        public static readonly int[] ALPHA_TO = new int[]
        {
            1, 2, 4, 8, 16, 32, 64, 128, 29, 58, 116, 232, 205, 135, 19, 38, 76, 152, 44, 88, 176, 105, 210, 193, 159, 15, 30, 60, 120, 240, 253, 231,
        };
        public const int MAX_ERRORS = 10;

    }
}