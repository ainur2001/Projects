using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handshake;

namespace Client
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            Chat_TextBox.Text = CommonKey.ToString();
        }
        private BigInteger CommonKey = Handshake.Authorization.CommonKey;

        private void SendMessage_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
