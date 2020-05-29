using System;
using System.Drawing;
using System.Windows.Forms;
using GameClient.EventArgs;

namespace GameClient
{
    public partial class Chat : Form
    {
        public string Name { get; set; }
        private event EventHandler BtnSendOnClick;
        private delegate void SetVisibleDelegate(bool visible, string name);
        private delegate void WriteMessageDelegate(string name, string dateTime, string messageText);

        public Chat(EventHandler BtnSendOnClick)
        {
            InitializeComponent();

            this.BtnSendOnClick = BtnSendOnClick;
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            if (this.BtnSendOnClick != null)
            {
                this.BtnSendOnClick.Invoke(this, new BtnSendOnClickEventArgs()
                {
                    MessageText = this.txtMessage.Text
                });

                this.txtMessage.Clear();
            }
        }

        public void SetVisible(bool visible, string name)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetVisibleDelegate(SetVisible), new object[]
                {
                    visible,
                    name
                });
            }
            else
            {
                this.Visible = visible;
                this.Name = name;

                lblName.Text = this.Name;
            }
        }

        public void WriteMessage(string name, string dateTime, string messageText)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new WriteMessageDelegate(WriteMessage), new object[]
                {
                    name,
                    dateTime,
                    messageText
                });
            }
            else
            {
                TextAlingtment(messageText, dateTime, name);
                //this.rtxtHistory.AppendText($"{name} - {dateTime}: {messageText}");
                //this.rtxtHistory.AppendText(Environment.NewLine);
            }
        }
        private void TextAlingtment(string msg,string dateTime, string name)
        {

            if (name == this.Name)
            {
                rtxtHistory.SelectionAlignment = HorizontalAlignment.Right;
                rtxtHistory.Refresh();

                rtxtHistory.SelectionColor = Color.BlueViolet;
                rtxtHistory.SelectionFont = new Font("Comic Sans MS", 8, FontStyle.Bold);
                
                rtxtHistory.AppendText(Environment.NewLine + $"{msg}");

                rtxtHistory.SelectionColor = Color.BlueViolet;
                rtxtHistory.SelectionFont = new Font("Comic Sans MS", 6);
                rtxtHistory.SelectionAlignment = HorizontalAlignment.Right;
                rtxtHistory.AppendText(Environment.NewLine + $"{dateTime}");
                
                rtxtHistory.Refresh();
                rtxtHistory.SelectionAlignment = HorizontalAlignment.Right;
                rtxtHistory.ScrollToCaret();
                rtxtHistory.AppendText(Environment.NewLine);
            }
            if (name != this.Name)
            {
              
                rtxtHistory.SelectionAlignment = HorizontalAlignment.Left;
                rtxtHistory.Refresh();

                rtxtHistory.SelectionColor = Color.Green;
                rtxtHistory.SelectionFont = new Font("Comic Sans MS", 8, FontStyle.Bold);
                //rtxtHistory.SelectionAlignment = HorizontalAlignment.Left;
                rtxtHistory.AppendText(Environment.NewLine + $"{name}: {msg}");

                rtxtHistory.SelectionColor = Color.Green;
                rtxtHistory.SelectionFont = new Font("Comic Sans MS", 6);
                //rtxtHistory.SelectionAlignment = HorizontalAlignment.Left;
                rtxtHistory.AppendText(Environment.NewLine + $"{dateTime}");
                rtxtHistory.Refresh();
                rtxtHistory.ScrollToCaret();

                rtxtHistory.AppendText(Environment.NewLine);
            }
            rtxtHistory.SelectionStart = rtxtHistory.Text.Length;
            rtxtHistory.ScrollToCaret();

        }

        private void txtMessage_TextChanged(object sender, System.EventArgs e)
        {
            btnSend.Enabled = txtMessage.Text.Trim() != String.Empty;
        }
    }
}
