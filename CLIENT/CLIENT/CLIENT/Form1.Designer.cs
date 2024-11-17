namespace CLIENT
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.connectbtn = new System.Windows.Forms.Button();
            this.disconnectbtn = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.usernamebox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttn_CeldasSeleccionadas = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.MessageChatBox = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.CreateGame = new System.Windows.Forms.Button();
            this.InvitePlayer = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Connectedlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // connectbtn
            // 
            this.connectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectbtn.Location = new System.Drawing.Point(43, 61);
            this.connectbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(380, 86);
            this.connectbtn.TabIndex = 13;
            this.connectbtn.Text = "CONNECT";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // disconnectbtn
            // 
            this.disconnectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectbtn.Location = new System.Drawing.Point(43, 160);
            this.disconnectbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.disconnectbtn.Name = "disconnectbtn";
            this.disconnectbtn.Size = new System.Drawing.Size(380, 86);
            this.disconnectbtn.TabIndex = 14;
            this.disconnectbtn.Text = "DISCONNECT";
            this.disconnectbtn.UseVisualStyleBackColor = true;
            this.disconnectbtn.Click += new System.EventHandler(this.disconnectbtn_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.RegisterButton.Location = new System.Drawing.Point(875, 161);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(196, 58);
            this.RegisterButton.TabIndex = 15;
            this.RegisterButton.Text = "REGISTER";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.LoginButton.Location = new System.Drawing.Point(875, 90);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(196, 58);
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // usernamebox
            // 
            this.usernamebox.Location = new System.Drawing.Point(613, 90);
            this.usernamebox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(192, 31);
            this.usernamebox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(619, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 31);
            this.label4.TabIndex = 18;
            this.label4.Text = "username :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(619, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "password :";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(613, 186);
            this.passwordbox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(192, 31);
            this.passwordbox.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(36, 329);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(864, 542);
            this.dataGridView1.TabIndex = 22;
            // 
            // bttn_CeldasSeleccionadas
            // 
            this.bttn_CeldasSeleccionadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.bttn_CeldasSeleccionadas.Location = new System.Drawing.Point(308, 954);
            this.bttn_CeldasSeleccionadas.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.bttn_CeldasSeleccionadas.Name = "bttn_CeldasSeleccionadas";
            this.bttn_CeldasSeleccionadas.Size = new System.Drawing.Size(224, 52);
            this.bttn_CeldasSeleccionadas.TabIndex = 23;
            this.bttn_CeldasSeleccionadas.Text = "SEND  SELECTION";
            this.bttn_CeldasSeleccionadas.UseVisualStyleBackColor = true;
            this.bttn_CeldasSeleccionadas.Click += new System.EventHandler(this.bttn_CeldasSeleccionadas_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 25;
            this.ChatBox.Location = new System.Drawing.Point(36, 1071);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(764, 179);
            this.ChatBox.TabIndex = 25;
            // 
            // MessageChatBox
            // 
            this.MessageChatBox.BackColor = System.Drawing.Color.Azure;
            this.MessageChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.MessageChatBox.Location = new System.Drawing.Point(36, 1340);
            this.MessageChatBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MessageChatBox.Name = "MessageChatBox";
            this.MessageChatBox.Size = new System.Drawing.Size(496, 32);
            this.MessageChatBox.TabIndex = 0;
            // 
            // sendMessage
            // 
            this.sendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.sendMessage.Location = new System.Drawing.Point(572, 1331);
            this.sendMessage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(196, 61);
            this.sendMessage.TabIndex = 1;
            this.sendMessage.Text = "SEND";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // CreateGame
            // 
            this.CreateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGame.Location = new System.Drawing.Point(1291, 61);
            this.CreateGame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateGame.Name = "CreateGame";
            this.CreateGame.Size = new System.Drawing.Size(380, 86);
            this.CreateGame.TabIndex = 26;
            this.CreateGame.Text = "CREATE GAME";
            this.CreateGame.UseVisualStyleBackColor = true;
            this.CreateGame.Click += new System.EventHandler(this.CreateGame_Click);
            // 
            // InvitePlayer
            // 
            this.InvitePlayer.BackColor = System.Drawing.Color.Transparent;
            this.InvitePlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.InvitePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvitePlayer.Location = new System.Drawing.Point(1939, 61);
            this.InvitePlayer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.InvitePlayer.Name = "InvitePlayer";
            this.InvitePlayer.Size = new System.Drawing.Size(380, 86);
            this.InvitePlayer.TabIndex = 27;
            this.InvitePlayer.Text = "INVITE PLAYER";
            this.InvitePlayer.UseVisualStyleBackColor = false;
            this.InvitePlayer.Click += new System.EventHandler(this.InvitePlayer_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1056, 329);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(864, 542);
            this.dataGridView2.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1404, 954);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 52);
            this.button1.TabIndex = 30;
            this.button1.Text = "SEND  BOMB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bttn_BombSeleccionadas_Click);
            // 
            // Connectedlbl
            // 
            this.Connectedlbl.BackColor = System.Drawing.Color.Transparent;
            this.Connectedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connectedlbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Connectedlbl.Location = new System.Drawing.Point(1964, 294);
            this.Connectedlbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Connectedlbl.Name = "Connectedlbl";
            this.Connectedlbl.Size = new System.Drawing.Size(388, 444);
            this.Connectedlbl.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(1964, 261);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 48);
            this.label1.TabIndex = 32;
            this.label1.Text = "CONNECTED PLAYERS";
            // 
            // PlayerName
            // 
            this.PlayerName.Location = new System.Drawing.Point(1939, 161);
            this.PlayerName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(380, 31);
            this.PlayerName.TabIndex = 33;
            this.PlayerName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2445, 1521);
            this.Controls.Add(this.PlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Connectedlbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.InvitePlayer);
            this.Controls.Add(this.CreateGame);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MessageChatBox);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.bttn_CeldasSeleccionadas);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usernamebox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.disconnectbtn);
            this.Controls.Add(this.connectbtn);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button connectbtn;
		private System.Windows.Forms.Button disconnectbtn;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox usernamebox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttn_CeldasSeleccionadas;
		private System.Windows.Forms.ListBox ChatBox;
		private System.Windows.Forms.TextBox MessageChatBox;
		private System.Windows.Forms.Button sendMessage;
		private System.Windows.Forms.Button CreateGame;
		private System.Windows.Forms.Button InvitePlayer;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label Connectedlbl;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlayerName;
    }
}

