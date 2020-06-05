namespace GameClient
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.jogarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSurpriseText = new System.Windows.Forms.Label();
            this.lblSurprise = new System.Windows.Forms.Label();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogarToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.surpresaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1403, 31);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuBar";
            // 
            // jogarToolStripMenuItem
            // 
            this.jogarToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jogarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.jogarToolStripMenuItem.Name = "jogarToolStripMenuItem";
            this.jogarToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.jogarToolStripMenuItem.Text = "Jogar";
            this.jogarToolStripMenuItem.Click += new System.EventHandler(this.jogarToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(58, 27);
            this.chatToolStripMenuItem.Text = "Chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sairToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(54, 27);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // surpresaToolStripMenuItem
            // 
            this.surpresaToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surpresaToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.surpresaToolStripMenuItem.Name = "surpresaToolStripMenuItem";
            this.surpresaToolStripMenuItem.Size = new System.Drawing.Size(102, 27);
            this.surpresaToolStripMenuItem.Text = "Não Clique";
            this.surpresaToolStripMenuItem.Click += new System.EventHandler(this.surpresaToolStripMenuItem_Click);
            // 
            // lblSurpriseText
            // 
            this.lblSurpriseText.AutoSize = true;
            this.lblSurpriseText.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurpriseText.ForeColor = System.Drawing.Color.Red;
            this.lblSurpriseText.Location = new System.Drawing.Point(631, 242);
            this.lblSurpriseText.Name = "lblSurpriseText";
            this.lblSurpriseText.Size = new System.Drawing.Size(29, 38);
            this.lblSurpriseText.TabIndex = 1;
            this.lblSurpriseText.Text = ".";
            this.lblSurpriseText.Visible = false;
            // 
            // lblSurprise
            // 
            this.lblSurprise.Location = new System.Drawing.Point(631, 302);
            this.lblSurprise.Name = "lblSurprise";
            this.lblSurprise.Size = new System.Drawing.Size(120, 120);
            this.lblSurprise.TabIndex = 1;
            this.lblSurprise.Text = ".";
            this.lblSurprise.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1403, 647);
            this.Controls.Add(this.lblSurpriseText);
            this.Controls.Add(this.lblSurprise);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuBar;
		private System.Windows.Forms.ToolStripMenuItem jogarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surpresaToolStripMenuItem;
        private System.Windows.Forms.Label lblSurprise;
        private System.Windows.Forms.Label lblSurpriseText;
    }
}