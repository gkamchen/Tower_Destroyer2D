namespace GameClient
{
	partial class Chat
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.rtxtHistory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsTab = true;
            this.txtMessage.Location = new System.Drawing.Point(11, 501);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(778, 56);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(714, 565);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 3;
            // 
            // rtxtHistory
            // 
            this.rtxtHistory.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtHistory.Location = new System.Drawing.Point(11, 28);
            this.rtxtHistory.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtHistory.Name = "rtxtHistory";
            this.rtxtHistory.ReadOnly = true;
            this.rtxtHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtHistory.Size = new System.Drawing.Size(778, 468);
            this.rtxtHistory.TabIndex = 4;
            this.rtxtHistory.Text = "";
            // 
            // Chat
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.rtxtHistory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.RichTextBox rtxtHistory;
    }
}

