using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameClient.EventArgs;

namespace GameClient
{
    public partial class Login : Form
    {
        private event EventHandler BtnRegisterOnClick;
        private event EventHandler BtnLoginOnClick;
        private event EventHandler BtnRecoveryDataOnClick;
        private delegate void SetVisibleDelegate(bool visible);
        private delegate void ClearDelegate();

        public Login(EventHandler BtnRegisterOnClick, EventHandler BtnLoginOnClick, EventHandler BtnRecoveryDataOnClick)
        {
            InitializeComponent();
            this.BtnRegisterOnClick = BtnRegisterOnClick;
            this.BtnLoginOnClick = BtnLoginOnClick;
            this.BtnRecoveryDataOnClick = BtnRecoveryDataOnClick;
        }

        private bool IsFormValid()
        {
            StringBuilder msgErro = new StringBuilder("Favor informar o(s) seguinte(s) campo(s):");
            bool isValid = true;

            if (txtLogin.Text.Trim() == String.Empty)
            {
                msgErro.Append("\n- Login");
                isValid = false;
            }

            if (txtPassword.Text.Trim() == String.Empty)
            {
                msgErro.Append("\n- Senha");
                isValid = false;
            }

            if (isValid == false)
            {
                lblSummaryError.Text = msgErro.ToString(); // Sumario
            }
            return isValid;
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            if (this.BtnRegisterOnClick != null)
            {
                this.BtnRegisterOnClick.Invoke(this, e);
            }
        }

        private void btnRecoveryData_Click(object sender, System.EventArgs e)
        {
            if (this.BtnRecoveryDataOnClick != null)
            {
                this.BtnRecoveryDataOnClick.Invoke(this, e);
            }
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (this.IsFormValid() == true && this.BtnLoginOnClick != null)
            {
                this.BtnLoginOnClick.Invoke(this, new BtnLoginOnClickEventArgs()
                {
                    Login = txtLogin.Text,
                    Password = txtPassword.Text
                });
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

        public void Clear()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new ClearDelegate(Clear), new object[] { });
            }
            else
            {
                this.txtLogin.Clear();
                this.txtPassword.Clear();
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }
        protected override void OnClosing(CancelEventArgs e) => Close();
    }
}
