using System;
using System.Windows.Forms;
using GameClient.EventArgs;

namespace GameClient
{
	public partial class Chat : Form
	{
		private event EventHandler BtnSendOnClick;
		private delegate void SetVisibleDelegate(bool visible);
		private delegate void WriteMessageDelegate(string userName, string messageText);

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

		public void SetVisible(bool visible)
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new SetVisibleDelegate(SetVisible), new object[]
				{
					visible
				});
			}
			else
			{
				this.Visible = visible;
			}
		}

		public void WriteMessage(string userName, string messageText)
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new WriteMessageDelegate(WriteMessage), new object[]
				{
					userName,
					messageText
				});
			}
			else
			{
				this.txtHistory.AppendText($"{userName}: {messageText}");
				this.txtHistory.AppendText(Environment.NewLine);
			}
		}

		private void txtMessage_TextChanged(object sender, System.EventArgs e)
		{
			btnSend.Enabled = txtMessage.Text.Trim() != String.Empty;
		}
	}
}
