using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.Util;
using BusinessObject;
using Sender_Receiver;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receive
{
    public partial class Receive : Form
    {

        public Receive()
        {
            InitializeComponent();
        }

        private void receive()
        {
            IConnectionFactory conf = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection con = conf.CreateConnection();
            con.Start();
            ISession session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination des = SessionUtil.GetDestination(session, "examplequeue");
            IMessageConsumer receiver = session.CreateConsumer(des);
            receiver.Listener += new MessageListener(Message_Listener);
        }

        private void Message_Listener(IMessage mes)
        {
            IObjectMessage objmes = mes as IObjectMessage;
            Class1 ope = ((BusinessObject.Class1)(objmes.Body));
            MessageBox.Show(ope.Shortcode);
        }
    }
}
