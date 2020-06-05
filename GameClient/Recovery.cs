using GameClient.EventArgs;
using System;
using System.Text;
using System.Windows.Forms;

namespace GameClient
{
	public partial class Recovery : Form
	{
		private event EventHandler BtnCancelOnClick;
		private event EventHandler BtnRecoveryOnClick;
		private Int32? idPlayer;
		private delegate void EnabledPasswordDelegate(Int32 idPlayer);
		private delegate void ClearDelegate();

		public Recovery(EventHandler BtnCancelOnClick, EventHandler BtnRecoveryOnClick)
		{
			InitializeComponent();

			this.BtnCancelOnClick = BtnCancelOnClick;
			this.BtnRecoveryOnClick = BtnRecoveryOnClick;
		}

		private bool IsFormValid()
		{
			StringBuilder msgErro = new StringBuilder("Favor informar o(s) seguinte(s) campo(s):"); // Alerta
			bool isValid = true;

			if (txtUsername.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Usuário");
				isValid = false;
			}

			if (txtBirthDate.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Data de Nascimento");
				isValid = false;
			}

			if (txtSecretText.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Texto Secreto");
				isValid = false;
			}


			
			return isValid;
		}
		private bool IsFormValidPassword()
		{
			StringBuilder msgErro = new StringBuilder("Favor informar o(s) seguinte(s) campo(s):"); // Alerta
			bool isValid = true;
			
			if (txtPassword.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Senha");
				isValid = false;
			}

			if (txtConfirmPassword.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Confirmar Senha");
				isValid = false;
			}

			if (isValid == false)
			{
				MessageBox.Show(msgErro.ToString());
			}
			else if (txtPassword.Text != txtConfirmPassword.Text)
			{
				isValid = false;
				MessageBox.Show("As senhas não conferem");
			}
			return isValid;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (this.BtnCancelOnClick != null)
			{
				this.BtnCancelOnClick.Invoke(this, e);
			}
		}

		private void btnRecovery_Click(object sender, System.EventArgs e)
		{
			if (this.idPlayer == null)
			{
				if (this.IsFormValid() == true && this.BtnRecoveryOnClick != null)  // Alerta
				{				
					this.BtnRecoveryOnClick.Invoke(this, new BtnRecoveryOnClickEventArgs()
					{
						Username = txtUsername.Text,
						BirthDate = txtBirthDate.Text,
						SecurityText = txtSecretText.Text
					});
					
				}
			}
			else
			{
				if (this.IsFormValidPassword() == true && this.BtnRecoveryOnClick != null)  // Alerta
				{
					this.BtnRecoveryOnClick.Invoke(this, new BtnUpdatePasswordOnClickEventArgs()
					{
						IdPlayer = (int)this.idPlayer,
						Password = txtPassword.Text
					});
				}
			}
		}

		public void Clear()
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new ClearDelegate(Clear), new object[] { });
			}
			else
			{
				this.idPlayer = null;
				this.txtUsername.Clear();
				this.txtSecretText.Clear();
				this.txtBirthDate.Clear();
				this.txtPassword.Clear();
				this.txtConfirmPassword.Clear();

				this.txtSecretText.Enabled = true;
				this.txtUsername.Enabled = true;
				this.txtBirthDate.Enabled = true;
				this.lblSecretText.Enabled = true;
				this.lblUsername.Enabled = true;
				this.lblBirthDate.Enabled = true;

				this.txtPassword.Enabled = false;
				this.txtConfirmPassword.Enabled = false;
				this.lblPassword.Enabled = false;
				this.lblConfirmPassword.Enabled = false;

				this.btnRecovery.BackgroundImage = global::GameClient.Properties.Resources.Check_32;
			}
		}

		public void EnabledPassword(Int32 idPlayer)
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new EnabledPasswordDelegate(EnabledPassword), new object[] {idPlayer });
			}
			else
			{
				this.txtSecretText.Enabled = false;
				this.txtUsername.Enabled = false;
				this.txtBirthDate.Enabled = false;
				this.lblSecretText.Enabled = false;
				this.lblUsername.Enabled = false;
				this.lblBirthDate.Enabled = false;

				
				this.idPlayer = idPlayer;
				this.txtPassword.Enabled = true;
				this.txtConfirmPassword.Enabled = true;
				this.lblPassword.Enabled = true;
				this.lblConfirmPassword.Enabled = true;

				this.btnRecovery.BackgroundImage = global::GameClient.Properties.Resources.Save_32;
			}
		}
	}
}
