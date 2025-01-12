namespace CLIENT
{
    partial class registrar
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
			this.label5 = new System.Windows.Forms.Label();
			this.passwordbox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.usernamebox = new System.Windows.Forms.TextBox();
			this.LoginButton = new System.Windows.Forms.Button();
			this.RegisterButton = new System.Windows.Forms.Button();
			this.disconnectbtn = new System.Windows.Forms.Button();
			this.connectbtn = new System.Windows.Forms.Button();
			this.Connectedlbl = new System.Windows.Forms.Label();
			this.unregisterbtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.PlayerName = new System.Windows.Forms.TextBox();
			this.InvitePlayer = new System.Windows.Forms.Button();
			this.CreateGame = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.query6_response = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.finish_time = new System.Windows.Forms.TextBox();
			this.start_time = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.query6 = new System.Windows.Forms.Button();
			this.query5_response = new System.Windows.Forms.Label();
			this.button_query5 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label5.Location = new System.Drawing.Point(30, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "password :";
			// 
			// passwordbox
			// 
			this.passwordbox.Location = new System.Drawing.Point(34, 108);
			this.passwordbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.passwordbox.Name = "passwordbox";
			this.passwordbox.Size = new System.Drawing.Size(194, 27);
			this.passwordbox.TabIndex = 27;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(30, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 20);
			this.label4.TabIndex = 26;
			this.label4.Text = "username :";
			// 
			// usernamebox
			// 
			this.usernamebox.Location = new System.Drawing.Point(34, 45);
			this.usernamebox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.usernamebox.Name = "usernamebox";
			this.usernamebox.Size = new System.Drawing.Size(194, 27);
			this.usernamebox.TabIndex = 25;
			this.usernamebox.TextChanged += new System.EventHandler(this.usernamebox_TextChanged);
			// 
			// LoginButton
			// 
			this.LoginButton.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginButton.Location = new System.Drawing.Point(287, 26);
			this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(140, 37);
			this.LoginButton.TabIndex = 24;
			this.LoginButton.Text = "LOGIN";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// RegisterButton
			// 
			this.RegisterButton.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterButton.Location = new System.Drawing.Point(287, 70);
			this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(140, 37);
			this.RegisterButton.TabIndex = 23;
			this.RegisterButton.Text = "REGISTER";
			this.RegisterButton.UseVisualStyleBackColor = true;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// disconnectbtn
			// 
			this.disconnectbtn.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.disconnectbtn.Location = new System.Drawing.Point(33, 82);
			this.disconnectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.disconnectbtn.Name = "disconnectbtn";
			this.disconnectbtn.Size = new System.Drawing.Size(209, 43);
			this.disconnectbtn.TabIndex = 22;
			this.disconnectbtn.Text = "DISCONNECT";
			this.disconnectbtn.UseVisualStyleBackColor = true;
			this.disconnectbtn.Click += new System.EventHandler(this.disconnectbtn_Click);
			// 
			// connectbtn
			// 
			this.connectbtn.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectbtn.Location = new System.Drawing.Point(33, 31);
			this.connectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.connectbtn.Name = "connectbtn";
			this.connectbtn.Size = new System.Drawing.Size(209, 43);
			this.connectbtn.TabIndex = 21;
			this.connectbtn.Text = "CONNECT";
			this.connectbtn.UseVisualStyleBackColor = true;
			this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
			// 
			// Connectedlbl
			// 
			this.Connectedlbl.BackColor = System.Drawing.Color.Transparent;
			this.Connectedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Connectedlbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Connectedlbl.Location = new System.Drawing.Point(16, 22);
			this.Connectedlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Connectedlbl.Name = "Connectedlbl";
			this.Connectedlbl.Size = new System.Drawing.Size(357, 103);
			this.Connectedlbl.TabIndex = 42;
			// 
			// unregisterbtn
			// 
			this.unregisterbtn.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.unregisterbtn.Location = new System.Drawing.Point(287, 115);
			this.unregisterbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.unregisterbtn.Name = "unregisterbtn";
			this.unregisterbtn.Size = new System.Drawing.Size(140, 37);
			this.unregisterbtn.TabIndex = 44;
			this.unregisterbtn.Text = "UNREGISTER";
			this.unregisterbtn.UseVisualStyleBackColor = true;
			this.unregisterbtn.Click += new System.EventHandler(this.unregisterbtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(46, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(866, 98);
			this.label2.TabIndex = 45;
			this.label2.Text = "EXPLODING ROCKETS";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this.disconnectbtn);
			this.groupBox1.Controls.Add(this.connectbtn);
			this.groupBox1.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(52, 151);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(282, 163);
			this.groupBox1.TabIndex = 47;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "FIRST";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox2.Controls.Add(this.unregisterbtn);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.passwordbox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.usernamebox);
			this.groupBox2.Controls.Add(this.LoginButton);
			this.groupBox2.Controls.Add(this.RegisterButton);
			this.groupBox2.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(354, 151);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(452, 163);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "SECOND";
			// 
			// PlayerName
			// 
			this.PlayerName.Location = new System.Drawing.Point(33, 130);
			this.PlayerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Size = new System.Drawing.Size(249, 27);
			this.PlayerName.TabIndex = 41;
			// 
			// InvitePlayer
			// 
			this.InvitePlayer.BackColor = System.Drawing.Color.Transparent;
			this.InvitePlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.InvitePlayer.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InvitePlayer.Location = new System.Drawing.Point(33, 96);
			this.InvitePlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.InvitePlayer.Name = "InvitePlayer";
			this.InvitePlayer.Size = new System.Drawing.Size(253, 26);
			this.InvitePlayer.TabIndex = 40;
			this.InvitePlayer.Text = "INVITE PLAYER";
			this.InvitePlayer.UseVisualStyleBackColor = false;
			this.InvitePlayer.Click += new System.EventHandler(this.InvitePlayer_Click_1);
			// 
			// CreateGame
			// 
			this.CreateGame.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreateGame.Location = new System.Drawing.Point(33, 42);
			this.CreateGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.CreateGame.Name = "CreateGame";
			this.CreateGame.Size = new System.Drawing.Size(253, 26);
			this.CreateGame.TabIndex = 39;
			this.CreateGame.Text = "CREATE GAME";
			this.CreateGame.UseVisualStyleBackColor = true;
			this.CreateGame.Click += new System.EventHandler(this.CreateGame_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox3.Controls.Add(this.CreateGame);
			this.groupBox3.Controls.Add(this.InvitePlayer);
			this.groupBox3.Controls.Add(this.PlayerName);
			this.groupBox3.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(52, 329);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(316, 181);
			this.groupBox3.TabIndex = 49;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "LAST";
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.Color.Cornsilk;
			this.groupBox4.Controls.Add(this.Connectedlbl);
			this.groupBox4.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(388, 329);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Size = new System.Drawing.Size(418, 181);
			this.groupBox4.TabIndex = 50;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "CONNECTED PLAYERS";
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox5.Controls.Add(this.query6_response);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.finish_time);
			this.groupBox5.Controls.Add(this.start_time);
			this.groupBox5.Controls.Add(this.label8);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.query6);
			this.groupBox5.Controls.Add(this.query5_response);
			this.groupBox5.Controls.Add(this.button_query5);
			this.groupBox5.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.Location = new System.Drawing.Point(821, 151);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Size = new System.Drawing.Size(555, 454);
			this.groupBox5.TabIndex = 51;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "QUERYS";
			// 
			// query6_response
			// 
			this.query6_response.AutoSize = true;
			this.query6_response.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.query6_response.Location = new System.Drawing.Point(33, 255);
			this.query6_response.Name = "query6_response";
			this.query6_response.Size = new System.Drawing.Size(0, 17);
			this.query6_response.TabIndex = 59;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(22, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(260, 20);
			this.label3.TabIndex = 58;
			this.label3.Text = "Players i have played with:";
			// 
			// finish_time
			// 
			this.finish_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.finish_time.Location = new System.Drawing.Point(380, 210);
			this.finish_time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.finish_time.Name = "finish_time";
			this.finish_time.Size = new System.Drawing.Size(148, 21);
			this.finish_time.TabIndex = 57;
			// 
			// start_time
			// 
			this.start_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.start_time.Location = new System.Drawing.Point(380, 177);
			this.start_time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.start_time.Name = "start_time";
			this.start_time.Size = new System.Drawing.Size(148, 21);
			this.start_time.TabIndex = 56;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label8.Location = new System.Drawing.Point(23, 215);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(270, 15);
			this.label8.TabIndex = 55;
			this.label8.Text = "FINISH PERIOD (yyyy-mm-dd hh:mm:ss) :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label7.Location = new System.Drawing.Point(23, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(268, 15);
			this.label7.TabIndex = 54;
			this.label7.Text = "START PERIOD (yyyy-mm-dd hh:mm:ss) :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label6.Location = new System.Drawing.Point(23, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(369, 20);
			this.label6.TabIndex = 53;
			this.label6.Text = "Matches list played in a period of time:";
			// 
			// query6
			// 
			this.query6.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.query6.Location = new System.Drawing.Point(433, 136);
			this.query6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.query6.Name = "query6";
			this.query6.Size = new System.Drawing.Size(95, 33);
			this.query6.TabIndex = 52;
			this.query6.Text = "search";
			this.query6.UseVisualStyleBackColor = true;
			this.query6.Click += new System.EventHandler(this.query6_Click);
			// 
			// query5_response
			// 
			this.query5_response.AutoSize = true;
			this.query5_response.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.query5_response.Location = new System.Drawing.Point(23, 50);
			this.query5_response.Name = "query5_response";
			this.query5_response.Size = new System.Drawing.Size(0, 17);
			this.query5_response.TabIndex = 45;
			// 
			// button_query5
			// 
			this.button_query5.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_query5.Location = new System.Drawing.Point(310, 18);
			this.button_query5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_query5.Name = "button_query5";
			this.button_query5.Size = new System.Drawing.Size(99, 26);
			this.button_query5.TabIndex = 23;
			this.button_query5.Text = "SEARCH";
			this.button_query5.UseVisualStyleBackColor = true;
			this.button_query5.Click += new System.EventHandler(this.button_query5_Click);
			// 
			// registrar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1387, 641);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "registrar";
			this.Text = "Form3";
			this.Load += new System.EventHandler(this.registrar_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernamebox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button disconnectbtn;
        private System.Windows.Forms.Button connectbtn;
        private System.Windows.Forms.Label Connectedlbl;
        private System.Windows.Forms.Button unregisterbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PlayerName;
        private System.Windows.Forms.Button InvitePlayer;
        private System.Windows.Forms.Button CreateGame;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_query5;
        private System.Windows.Forms.Label query5_response;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox finish_time;
        private System.Windows.Forms.TextBox start_time;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button query6;
        private System.Windows.Forms.Label query6_response;
    }
}