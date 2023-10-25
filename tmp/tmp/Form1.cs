using System;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;


namespace tmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var devices = CaptureDeviceList.Instance;
            var selectedDevice = devices[0];
            string ip1 = IP1_TextBox.Text;
            string ip2 = IP2_TextBox.Text;

            string filterExpression = $"ip src host {ip1} and ip dst host {ip2} or ip src host {ip2} and ip dst host {ip1}";

            // Начало захвата трафика с фильтром
            selectedDevice.OnPacketArrival += (sender1, e1) =>
            {
                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                Packets_TextBox.Text = packet.ToString();
            };

            selectedDevice.Filter = filterExpression;
            selectedDevice.StartCapture();
        }
    }
}
