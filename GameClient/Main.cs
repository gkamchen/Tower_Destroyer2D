using Base;
using System.Windows.Forms;
using GameClient.EventArgs;
using GameClient;
using System;

namespace GameClient
{
	public partial class Main : Form
	{
		private const int MESSAGE_TYPE_GET_MESSAGES = 1;

		private const int MESSAGE_TYPE_SEND_NEW_MESSAGE = 2;
		private const int MESSAGE_TYPE_READ_NEW_MESSAGE = 3;

		private const int MESSAGE_TYPE_GET_USER_REQUEST = 4;
		private const int MESSAGE_TYPE_GET_USER_SUCCESS = 5;
		private const int MESSAGE_TYPE_GET_USER_ERROR = 6;

		private const int MESSAGE_TYPE_INSERT_USER_REQUEST = 7;
		private const int MESSAGE_TYPE_INSERT_USER_SUCCESS = 8;
		private const int MESSAGE_TYPE_INSERT_USER_ERROR = 9;

		private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_REQUEST = 10;
		private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_SUCCESS = 11;
		private const int MESSAGE_TYPE_RECOVERY_USER_PASSWORD_ERROR = 12;

		private const int MESSAGE_TYPE_UPDATE_PASSWORD_REQUEST = 13;
		private const int MESSAGE_TYPE_UPDATE_PASSWORD_SUCCESS = 14;
		private const int MESSAGE_TYPE_UPDATE_PASSWORD_ERROR = 15;


		private const int MESSAGE_TYPE_MATCH_DATA_REQUEST = 16;
		private const int MESSAGE_TYPE_MATCH_DATA_SUCCESS = 17;
		private const int MESSAGE_TYPE_MATCH_DATA_ERROR = 18;

		private int userId;
		private string userName;
		private string name;
		private Client client;
		private Match match;
		private Login login;
		private Register register;
		private Recovery recovery;
		private Chat chat;

		private delegate void SetVisibleMenuBarDelegate(bool visible);

		public Main()
		{
			InitializeComponent();
			menuBar.Visible = false;
		}

		protected override void OnClosed(System.EventArgs e)
		{
			if (this.client != null)
			{
				this.client.Close();
			}

			base.OnClosed(e);
		}
		public void SetVisibleMenuBar(bool visible)
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new SetVisibleMenuBarDelegate(SetVisibleMenuBar), new object[]
				{
					visible
				});
			}
			else
			{
				this.menuBar.Visible = visible;
			}
		}

		private void Main_Load(object sender, System.EventArgs e)
		{
			StartConnection();
		}

		private void StartConnection()
		{
			try
			{
				this.client = new Client("127.0.0.1", 5000);

				this.client.Connect(this.OnReceiveMessage);

				this.login = new Login(this.BtnRegisterOnClick, this.BtnLoginOnClick, this.BtnRecoveryDataOnClick);
				this.register = new Register(this.BtnCancelOnClick, this.BtnSaveOnClick);
				this.chat = new Chat(this.BtnSendOnClick);
				this.recovery = new Recovery(this.BtnCancelOnClick, this.BtnRecoveryOnClick);
				this.match = new Match();

				this.login.MdiParent = this;
				this.chat.MdiParent = this;
				this.match.MdiParent = this;
				this.recovery.MdiParent = this;
				this.register.MdiParent = this;

				this.login.SetVisible(true);
			}
			catch
			{
				this.client = null;

				MessageBox.Show("Falha ao tentar conectar com o servidor");
			}
		}

		private void BtnRegisterOnClick(object sender, System.EventArgs eventArgs)
		{
			this.login.Visible = false;
			this.register.Visible = true;
		}

		private void BtnLoginOnClick(object sender, System.EventArgs eventArgs)
		{
			BtnLoginOnClickEventArgs btnLoginOnClickEventArgs = eventArgs as BtnLoginOnClickEventArgs;

			if (btnLoginOnClickEventArgs != null && this.client != null)
			{
				this.client.SendMessage(new
				{
					type = MESSAGE_TYPE_GET_USER_REQUEST,
					login = btnLoginOnClickEventArgs.Login,
					password = btnLoginOnClickEventArgs.Password
				});
			}
		}
		private void BtnRecoveryDataOnClick(object sender, System.EventArgs eventArgs)
		{
			this.login.Visible = false;
			this.register.Visible = false;
			this.recovery.Visible = true;
			recovery.Clear();
		}
		private void BtnRecoveryOnClick(object sender, System.EventArgs eventArgs)
		{
			if (this.client != null)
			{
				BtnRecoveryOnClickEventArgs btnRecoreyOnClickEventArgs = eventArgs as BtnRecoveryOnClickEventArgs;

				if (btnRecoreyOnClickEventArgs != null)
				{
					this.client.SendMessage(new
					{
						type = MESSAGE_TYPE_RECOVERY_USER_PASSWORD_REQUEST,
						username = btnRecoreyOnClickEventArgs.Username,
						birthDate = btnRecoreyOnClickEventArgs.BirthDate,
						securityText = btnRecoreyOnClickEventArgs.SecurityText,
					});
				}
				else
				{
					BtnUpdatePasswordOnClickEventArgs btnUpdatePasswordOnClickEventArgs = eventArgs as BtnUpdatePasswordOnClickEventArgs;
					if (btnUpdatePasswordOnClickEventArgs != null)
					{
						this.client.SendMessage(new
						{
							type = MESSAGE_TYPE_UPDATE_PASSWORD_REQUEST,
							idPlayer = btnUpdatePasswordOnClickEventArgs.IdPlayer,
							password = btnUpdatePasswordOnClickEventArgs.Password
						});
					}

					}
			}
		}

		private void BtnCancelOnClick(object sender, System.EventArgs eventArgs)
		{
			this.login.Visible = true;
			this.register.Visible = false;
			this.recovery.Visible = false;
		}

		private void BtnSaveOnClick(object sender, System.EventArgs eventArgs)
		{
			BtnSaveOnClickEventArgs btnSaveOnClickEventArgs = eventArgs as BtnSaveOnClickEventArgs;

			if (btnSaveOnClickEventArgs != null && this.client != null)
			{
				this.client.SendMessage(new
				{
					type = MESSAGE_TYPE_INSERT_USER_REQUEST,
					name = btnSaveOnClickEventArgs.Name,
					username = btnSaveOnClickEventArgs.Username,
					password = btnSaveOnClickEventArgs.Password,
					birthDate = btnSaveOnClickEventArgs.BirthDate,
					securityText = btnSaveOnClickEventArgs.SecurityText

				});
			}
		}

		private void BtnSendOnClick(object sender, System.EventArgs eventArgs)
		{
			BtnSendOnClickEventArgs btnSendOnClickEventArgs = eventArgs as BtnSendOnClickEventArgs;

			if (btnSendOnClickEventArgs != null && this.client != null)
			{
				this.client.SendMessage(new
				{
					type = MESSAGE_TYPE_SEND_NEW_MESSAGE,
					userId = this.userId,
					userName = this.userName,
					namePlayer = this.name,
					dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
					messageText = btnSendOnClickEventArgs.MessageText
				}) ;
			}
		}

		private void OnReceiveMessage(object sender, System.EventArgs eventArgs)
		{
			MessageEventArgs messageEventArgs = eventArgs as MessageEventArgs;

			if (messageEventArgs != null)
			{
				Base.Message message = messageEventArgs.Message;

				int type = message.GetInt32("type");

				switch (type)
				{
					case MESSAGE_TYPE_READ_NEW_MESSAGE:
						if (this.chat != null)
						{
							string userName = message.GetString("userName");
							string namePlayer = message.GetString("namePlayer");
							string dateTime = message.GetString("dateTime");
							string messageText = message.GetString("messageText");

							this.chat.WriteMessage(namePlayer,dateTime, messageText);
						}
						break;
					case MESSAGE_TYPE_GET_USER_SUCCESS:
						if (this.client != null)
						{
							this.userId = message.GetInt32("userId");
							this.userName = message.GetString("userName");
							this.name = message.GetString("name");

							this.login.Clear();
							this.login.SetVisible(false);
							//Chamar chat direto
							//this.chat.SetVisible(true, this.name);  // Comentado

							this.SetVisibleMenuBar(true);

							
						}
						break;
					case MESSAGE_TYPE_GET_USER_ERROR:
						MessageBox.Show(message.GetString("error"));
						break;
					case MESSAGE_TYPE_INSERT_USER_SUCCESS:
						this.register.Clear();
						MessageBox.Show(message.GetString("success"));
						break;
					case MESSAGE_TYPE_INSERT_USER_ERROR:
						MessageBox.Show(message.GetString("error"));
						break;
					case MESSAGE_TYPE_RECOVERY_USER_PASSWORD_SUCCESS:
						this.recovery.EnabledPassword(message.GetInt32("idPlayer"));
						break;
					case MESSAGE_TYPE_RECOVERY_USER_PASSWORD_ERROR:
						MessageBox.Show(message.GetString("error"));
						break;
					case MESSAGE_TYPE_UPDATE_PASSWORD_SUCCESS:
						this.register.Clear();
						MessageBox.Show("Senha alterada com sucesso!");
						break;
					case MESSAGE_TYPE_UPDATE_PASSWORD_ERROR:
						MessageBox.Show(message.GetString("error"));
						break;
					case MESSAGE_TYPE_MATCH_DATA_SUCCESS:
						if (this.match != null)
						{
							this.match.InitializeMatrix(message.GetSingleDimArrayInt32("data"));
						}
						break;
				}
			}
		}
		
		private void chatToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			//new System.Threading.Thread(() =>
			//{
			//	System.Threading.Thread.Sleep(1000);
			//	this.chat.SetVisible(true, this.name);
			//}).Start();
			this.chat.SetVisible(true, this.name);
			this.client.SendMessage(new
			{
				
				type = MESSAGE_TYPE_GET_MESSAGES
			});

			//this.chat.SetVisible(true, this.name);
			//this.chat.Visible = true;
			//this.chat.Name = this.name;
			//this.login.Visible = false;
			//this.register.Visible = false;
		}

		private void jogarToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.match.SetVisible(true);
			this.client.SendMessage(new
			{
				type = MESSAGE_TYPE_MATCH_DATA_REQUEST
			});
		}

		private void sairToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.chat.rtxtHistory.Text = "";
			this.login.Visible = true;
			this.register.Visible = false;
			this.chat.SetVisible(false, this.name);
			this.recovery.Visible = false;
			this.menuBar.Visible = false;
			this.match.Visible = false;
		}

        private void surpresaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
			DialogResult resposta = MessageBox.Show("Não leu o título? Não recomendo abrir, mas caso realmente queira, pressione \"SIM\"", "Não Clique", MessageBoxButtons.YesNo);

			if (resposta == DialogResult.Yes)
			{
				lblSurpriseText.Text = "TE AVISEI PARA NÃO CLICAR BOBÃO, QUEM MANDA SER CURIOSO??? TRAVOU TODO O SISTEMA AGORA!!";
				lblSurpriseText.Visible = true;
			}
			lblSurprise.Image = global::GameClient.Properties.Resources.Surpresa_120;
			lblSurprise.Visible = true;
		}
    }
}
