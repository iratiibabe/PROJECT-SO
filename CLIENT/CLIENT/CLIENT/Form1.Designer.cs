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
            this.QUERY1 = new System.Windows.Forms.Button();
            this.QUERY2 = new System.Windows.Forms.Button();
            this.QUERY3 = new System.Windows.Forms.Button();
            this.QUERY4 = new System.Windows.Forms.Button();
            this.explicacion1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.X1 = new System.Windows.Forms.TextBox();
            this.X2 = new System.Windows.Forms.TextBox();
            this.X3 = new System.Windows.Forms.TextBox();
            this.X4 = new System.Windows.Forms.TextBox();
            this.VALUEOFX = new System.Windows.Forms.Label();
            this.connectbtn = new System.Windows.Forms.Button();
            this.disconnectbtn = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.usernamebox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.LIST_PLAYERS = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttn_CeldasSeleccionadas = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.MessageChatBox = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // QUERY1
            // 
            this.QUERY1.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.QUERY1.Location = new System.Drawing.Point(35, 272);
            this.QUERY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY1.Name = "QUERY1";
            this.QUERY1.Size = new System.Drawing.Size(147, 46);
            this.QUERY1.TabIndex = 0;
            this.QUERY1.Text = "QUERY 1";
            this.QUERY1.UseVisualStyleBackColor = true;
            this.QUERY1.Click += new System.EventHandler(this.QUERY1_Click);
            // 
            // QUERY2
            // 
            this.QUERY2.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.QUERY2.Location = new System.Drawing.Point(35, 339);
            this.QUERY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY2.Name = "QUERY2";
            this.QUERY2.Size = new System.Drawing.Size(147, 46);
            this.QUERY2.TabIndex = 1;
            this.QUERY2.Text = "QUERY 2";
            this.QUERY2.UseVisualStyleBackColor = true;
            this.QUERY2.Click += new System.EventHandler(this.QUERY2_Click);
            // 
            // QUERY3
            // 
            this.QUERY3.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.QUERY3.Location = new System.Drawing.Point(35, 406);
            this.QUERY3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY3.Name = "QUERY3";
            this.QUERY3.Size = new System.Drawing.Size(147, 46);
            this.QUERY3.TabIndex = 2;
            this.QUERY3.Text = "QUERY 3";
            this.QUERY3.UseVisualStyleBackColor = true;
            this.QUERY3.Click += new System.EventHandler(this.QUERY3_Click);
            // 
            // QUERY4
            // 
            this.QUERY4.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.QUERY4.Location = new System.Drawing.Point(35, 474);
            this.QUERY4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY4.Name = "QUERY4";
            this.QUERY4.Size = new System.Drawing.Size(147, 46);
            this.QUERY4.TabIndex = 3;
            this.QUERY4.Text = "QUERY 4";
            this.QUERY4.UseVisualStyleBackColor = true;
            this.QUERY4.Click += new System.EventHandler(this.QUERY4_Click);
            // 
            // explicacion1
            // 
            this.explicacion1.AutoSize = true;
            this.explicacion1.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.explicacion1.Location = new System.Drawing.Point(203, 284);
            this.explicacion1.Name = "explicacion1";
            this.explicacion1.Size = new System.Drawing.Size(347, 28);
            this.explicacion1.TabIndex = 4;
            this.explicacion1.Text = "\"WHO\'S  THE  WINNER  OF  THE  MATCH  \'X\'?\"";
            this.explicacion1.Click += new System.EventHandler(this.explicacion1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(190, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "\"HOW  MANY  POINTS  DOES  THE  PLAYER  \'X\'  HAVE?\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(190, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "\"IN  HOW  MANY  MATCHES  IS  THE  PLAYER  \'X\'  PLAYING?\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(188, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(425, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "\"HOW  MANY  PLAYERS  ARE  PLAYING  IN  MATCH  \'X\'?\"";
            // 
            // X1
            // 
            this.X1.Location = new System.Drawing.Point(661, 284);
            this.X1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(285, 26);
            this.X1.TabIndex = 8;
            // 
            // X2
            // 
            this.X2.Location = new System.Drawing.Point(661, 351);
            this.X2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(285, 26);
            this.X2.TabIndex = 9;
            // 
            // X3
            // 
            this.X3.Location = new System.Drawing.Point(661, 418);
            this.X3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X3.Name = "X3";
            this.X3.Size = new System.Drawing.Size(285, 26);
            this.X3.TabIndex = 10;
            // 
            // X4
            // 
            this.X4.Location = new System.Drawing.Point(663, 486);
            this.X4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X4.Name = "X4";
            this.X4.Size = new System.Drawing.Size(285, 26);
            this.X4.TabIndex = 11;
            // 
            // VALUEOFX
            // 
            this.VALUEOFX.AutoSize = true;
            this.VALUEOFX.Font = new System.Drawing.Font("Reem Kufi", 16F, System.Drawing.FontStyle.Bold);
            this.VALUEOFX.Location = new System.Drawing.Point(688, 197);
            this.VALUEOFX.Name = "VALUEOFX";
            this.VALUEOFX.Size = new System.Drawing.Size(223, 58);
            this.VALUEOFX.TabIndex = 12;
            this.VALUEOFX.Text = "VALUE OF \'X\'";
            // 
            // connectbtn
            // 
            this.connectbtn.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectbtn.Location = new System.Drawing.Point(29, 25);
            this.connectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(285, 69);
            this.connectbtn.TabIndex = 13;
            this.connectbtn.Text = "CONNECT";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // disconnectbtn
            // 
            this.disconnectbtn.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectbtn.Location = new System.Drawing.Point(29, 102);
            this.disconnectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disconnectbtn.Name = "disconnectbtn";
            this.disconnectbtn.Size = new System.Drawing.Size(285, 69);
            this.disconnectbtn.TabIndex = 14;
            this.disconnectbtn.Text = "DISCONNECT";
            this.disconnectbtn.UseVisualStyleBackColor = true;
            this.disconnectbtn.Click += new System.EventHandler(this.disconnectbtn_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.RegisterButton.Location = new System.Drawing.Point(667, 81);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(147, 46);
            this.RegisterButton.TabIndex = 15;
            this.RegisterButton.Text = "REGISTER";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.LoginButton.Location = new System.Drawing.Point(667, 25);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(147, 46);
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // usernamebox
            // 
            this.usernamebox.Location = new System.Drawing.Point(462, 68);
            this.usernamebox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(147, 26);
            this.usernamebox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Reem Kufi", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(464, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 36);
            this.label4.TabIndex = 18;
            this.label4.Text = "username :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Reem Kufi", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(464, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 36);
            this.label5.TabIndex = 20;
            this.label5.Text = "password :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(462, 145);
            this.passwordbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(147, 26);
            this.passwordbox.TabIndex = 19;
            // 
            // LIST_PLAYERS
            // 
            this.LIST_PLAYERS.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.LIST_PLAYERS.Location = new System.Drawing.Point(661, 586);
            this.LIST_PLAYERS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LIST_PLAYERS.Name = "LIST_PLAYERS";
            this.LIST_PLAYERS.Size = new System.Drawing.Size(287, 46);
            this.LIST_PLAYERS.TabIndex = 21;
            this.LIST_PLAYERS.Text = "LIST  OF  CONNECTED  PLAYERS";
            this.LIST_PLAYERS.UseVisualStyleBackColor = true;
            this.LIST_PLAYERS.Click += new System.EventHandler(this.LIST_PLAYERS_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1072, 36);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(648, 434);
            this.dataGridView1.TabIndex = 22;
            // 
            // bttn_CeldasSeleccionadas
            // 
            this.bttn_CeldasSeleccionadas.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.bttn_CeldasSeleccionadas.Location = new System.Drawing.Point(1276, 568);
            this.bttn_CeldasSeleccionadas.Margin = new System.Windows.Forms.Padding(2);
            this.bttn_CeldasSeleccionadas.Name = "bttn_CeldasSeleccionadas";
            this.bttn_CeldasSeleccionadas.Size = new System.Drawing.Size(168, 45);
            this.bttn_CeldasSeleccionadas.TabIndex = 23;
            this.bttn_CeldasSeleccionadas.Text = "SEND  SELECTION";
            this.bttn_CeldasSeleccionadas.UseVisualStyleBackColor = true;
            this.bttn_CeldasSeleccionadas.Click += new System.EventHandler(this.bttn_CeldasSeleccionadas_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 28;
            this.ChatBox.Location = new System.Drawing.Point(35, 586);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(574, 200);
            this.ChatBox.TabIndex = 25;
            // 
            // MessageChatBox
            // 
            this.MessageChatBox.BackColor = System.Drawing.Color.Azure;
            this.MessageChatBox.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.MessageChatBox.Location = new System.Drawing.Point(35, 801);
            this.MessageChatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MessageChatBox.Name = "MessageChatBox";
            this.MessageChatBox.Size = new System.Drawing.Size(371, 31);
            this.MessageChatBox.TabIndex = 0;
            // 
            // sendMessage
            // 
            this.sendMessage.Font = new System.Drawing.Font("Reem Kufi", 8F, System.Drawing.FontStyle.Bold);
            this.sendMessage.Location = new System.Drawing.Point(433, 794);
            this.sendMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(145, 49);
            this.sendMessage.TabIndex = 1;
            this.sendMessage.Text = "SEND";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 880);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MessageChatBox);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.bttn_CeldasSeleccionadas);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LIST_PLAYERS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usernamebox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.disconnectbtn);
            this.Controls.Add(this.connectbtn);
            this.Controls.Add(this.VALUEOFX);
            this.Controls.Add(this.X4);
            this.Controls.Add(this.X3);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.X1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.explicacion1);
            this.Controls.Add(this.QUERY4);
            this.Controls.Add(this.QUERY3);
            this.Controls.Add(this.QUERY2);
            this.Controls.Add(this.QUERY1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button QUERY1;
		private System.Windows.Forms.Button QUERY2;
		private System.Windows.Forms.Button QUERY3;
		private System.Windows.Forms.Button QUERY4;
		private System.Windows.Forms.Label explicacion1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox X1;
		private System.Windows.Forms.TextBox X2;
		private System.Windows.Forms.TextBox X3;
		private System.Windows.Forms.TextBox X4;
		private System.Windows.Forms.Label VALUEOFX;
		private System.Windows.Forms.Button connectbtn;
		private System.Windows.Forms.Button disconnectbtn;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox usernamebox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Button LIST_PLAYERS;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttn_CeldasSeleccionadas;
		private System.Windows.Forms.ListBox ChatBox;
		private System.Windows.Forms.TextBox MessageChatBox;
		private System.Windows.Forms.Button sendMessage;
	}
}

