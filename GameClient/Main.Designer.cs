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
            this.sairDoJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMove = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogarToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.sairDoJogoToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1287, 31);
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
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.sairToolStripMenuItem.Text = "Logout";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sairDoJogoToolStripMenuItem
            // 
            this.sairDoJogoToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.sairDoJogoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sairDoJogoToolStripMenuItem.Name = "sairDoJogoToolStripMenuItem";
            this.sairDoJogoToolStripMenuItem.Size = new System.Drawing.Size(121, 27);
            this.sairDoJogoToolStripMenuItem.Text = "Sair do Jogo";
            this.sairDoJogoToolStripMenuItem.Click += new System.EventHandler(this.sairDoJogoToolStripMenuItem_Click);
            // 
            // pnlMove
            // 
            this.pnlMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(80)))));
            this.pnlMove.Location = new System.Drawing.Point(329, 0);
            this.pnlMove.Name = "pnlMove";
            this.pnlMove.Size = new System.Drawing.Size(913, 31);
            this.pnlMove.TabIndex = 1;
            this.pnlMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::GameClient.Properties.Resources.Close_321;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1248, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.BackgroundImage = global::GameClient.Properties.Resources.Fundo_Red_Blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1287, 743);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlMove);
            this.Controls.Add(this.menuBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuBar;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Panel pnlMove;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem sairDoJogoToolStripMenuItem;
    }
}