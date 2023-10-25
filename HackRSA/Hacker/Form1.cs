using System;
using SharpPcap;
using PacketDotNet;


namespace Hacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Interception_Button_Click(object sender, EventArgs e)
        {
            var devices = CaptureDeviceList.Instance;
            var selectedDevice = devices[0];
            string ip1 = IP1_TextBox.Text;
            string ip2 = IP2_TextBox.Text;

            string filterExpression = $"ip src host {ip1} and ip dst host {ip2} or ip src host {ip2} and ip dst host {ip1}";

            // Начало захвата трафика с фильтром
            selectedDevice.OnPacketArrival += (sender, e) =>
            {
                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                Console.WriteLine(packet.ToString());
            };

            // Применение фильтра
            selectedDevice.Filter = filterExpression;

            // Начало захвата
            selectedDevice.StartCapture();
        }
    }
}