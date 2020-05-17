using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.Util;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sender_Receiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IConnectionFactory conf = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection con = conf.CreateConnection();
            con.Start();

            ISession session = con.CreateSession();
            IDestination des = SessionUtil.GetDestination(session, "examplequeue");
            IMessageProducer msgp = session.CreateProducer(des);

            msgp.Send(textBox1.Text);

            session.Close();
            con.Stop();
        }
    }
}
