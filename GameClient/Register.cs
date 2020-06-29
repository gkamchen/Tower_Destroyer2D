using GameClient.EventArgs;
using System;
using System.Text;
using System.Windows.Forms;

namespace GameClient
{
	public partial class Register : Form
	{
		private event EventHandler BtnCancelOnClick;
		private event EventHandler BtnSaveOnClick;
		private delegate void ClearDelegate();

		public Register(EventHandler BtnCancelOnClick, EventHandler BtnSaveOnClick)
		{
			InitializeComponent();

			this.BtnCancelOnClick = BtnCancelOnClick;
			this.BtnSaveOnClick = BtnSaveOnClick;
		}

		private bool IsFormValid()
		{
			StringBuilder msgErro = new StringBuilder("Favor informar o(s) seguinte(s) campo(s):"); // Alerta
			bool isValid = true;

			if (txtName.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Nome");
				isValid = false;
			}

			if (txtUsername.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Username");
				isValid = false;
			}

			if(txtPassword.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Senha");
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

			if (txtConfirmPassword.Text.Trim() == String.Empty)
			{
				msgErro.Append("\n- Confirmar Senha");
				isValid = false;
			}

			if(isValid == false)
			{
				MessageBox.Show(msgErro.ToString());
			}
			else if(txtPassword.Text != txtConfirmPassword.Text)
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(this.IsFormValid() == true && this.BtnSaveOnClick != null)  // Alerta
			{ 
				this.BtnSaveOnClick.Invoke(this, new BtnSaveOnClickEventArgs()
				{
					Name = txtName.Text,
					Username = txtUsername.Text,
					Password = txtPassword.Text,
					BirthDate = txtBirthDate.Text,
					SecurityText = txtSecretText.Text
				});
			}
			this.Visible = false;
			
		}

		public void Clear()
		{
			if (this.InvokeRequired == true)
			{
				this.Invoke(new ClearDelegate(Clear), new object[] { });
			}
			else
			{
				this.txtUsername.Clear();
				this.txtPassword.Clear();
				this.txtConfirmPassword.Clear();
				this.txtName.Clear();
				this.txtSecretText.Clear();
				this.txtBirthDate.Clear();
			}
		}
	}
}
