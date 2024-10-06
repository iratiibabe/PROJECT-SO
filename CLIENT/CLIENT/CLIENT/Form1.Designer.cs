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
            this.SuspendLayout();
            // 
            // QUERY1
            // 
            this.QUERY1.Location = new System.Drawing.Point(77, 283);
            this.QUERY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY1.Name = "QUERY1";
            this.QUERY1.Size = new System.Drawing.Size(161, 49);
            this.QUERY1.TabIndex = 0;
            this.QUERY1.Text = "QUERY 1";
            this.QUERY1.UseVisualStyleBackColor = true;
            this.QUERY1.Click += new System.EventHandler(this.QUERY1_Click);
            // 
            // QUERY2
            // 
            this.QUERY2.Location = new System.Drawing.Point(77, 367);
            this.QUERY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY2.Name = "QUERY2";
            this.QUERY2.Size = new System.Drawing.Size(161, 49);
            this.QUERY2.TabIndex = 1;
            this.QUERY2.Text = "QUERY 2";
            this.QUERY2.UseVisualStyleBackColor = true;
            this.QUERY2.Click += new System.EventHandler(this.QUERY2_Click);
            // 
            // QUERY3
            // 
            this.QUERY3.Location = new System.Drawing.Point(77, 460);
            this.QUERY3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY3.Name = "QUERY3";
            this.QUERY3.Size = new System.Drawing.Size(161, 49);
            this.QUERY3.TabIndex = 2;
            this.QUERY3.Text = "QUERY 3";
            this.QUERY3.UseVisualStyleBackColor = true;
            this.QUERY3.Click += new System.EventHandler(this.QUERY3_Click);
            // 
            // QUERY4
            // 
            this.QUERY4.Location = new System.Drawing.Point(77, 554);
            this.QUERY4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QUERY4.Name = "QUERY4";
            this.QUERY4.Size = new System.Drawing.Size(161, 49);
            this.QUERY4.TabIndex = 3;
            this.QUERY4.Text = "QUERY 4";
            this.QUERY4.UseVisualStyleBackColor = true;
            this.QUERY4.Click += new System.EventHandler(this.QUERY4_Click);
            // 
            // explicacion1
            // 
            this.explicacion1.AutoSize = true;
            this.explicacion1.Location = new System.Drawing.Point(282, 297);
            this.explicacion1.Name = "explicacion1";
            this.explicacion1.Size = new System.Drawing.Size(331, 20);
            this.explicacion1.TabIndex = 4;
            this.explicacion1.Text = "\"WHO\'S THE WINNER OF THE MATCH \'X\'?\"";
            this.explicacion1.Click += new System.EventHandler(this.explicacion1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "\"HOW MANY POINTS DOES THE PLAYER \'X\' HAVE?\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "\"IN HOW MANY MATCHES IS THE PLAYER \'X\' PLAYING?\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 568);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "\"HOW MANY PLAYERS ARE PLAYING IN MATCH \'X\'?\"";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // X1
            // 
            this.X1.Location = new System.Drawing.Point(838, 291);
            this.X1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(313, 26);
            this.X1.TabIndex = 8;
            this.X1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // X2
            // 
            this.X2.Location = new System.Drawing.Point(838, 367);
            this.X2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(313, 26);
            this.X2.TabIndex = 9;
            // 
            // X3
            // 
            this.X3.Location = new System.Drawing.Point(838, 454);
            this.X3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X3.Name = "X3";
            this.X3.Size = new System.Drawing.Size(313, 26);
            this.X3.TabIndex = 10;
            // 
            // X4
            // 
            this.X4.Location = new System.Drawing.Point(838, 548);
            this.X4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X4.Name = "X4";
            this.X4.Size = new System.Drawing.Size(313, 26);
            this.X4.TabIndex = 11;
            // 
            // VALUEOFX
            // 
            this.VALUEOFX.AutoSize = true;
            this.VALUEOFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VALUEOFX.Location = new System.Drawing.Point(856, 194);
            this.VALUEOFX.Name = "VALUEOFX";
            this.VALUEOFX.Size = new System.Drawing.Size(286, 46);
            this.VALUEOFX.TabIndex = 12;
            this.VALUEOFX.Text = "VALUE OF \'X\'";
            // 
            // connectbtn
            // 
            this.connectbtn.Location = new System.Drawing.Point(79, 49);
            this.connectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(298, 71);
            this.connectbtn.TabIndex = 13;
            this.connectbtn.Text = "CONNECT";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // disconnectbtn
            // 
            this.disconnectbtn.Location = new System.Drawing.Point(79, 139);
            this.disconnectbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.disconnectbtn.Name = "disconnectbtn";
            this.disconnectbtn.Size = new System.Drawing.Size(298, 71);
            this.disconnectbtn.TabIndex = 14;
            this.disconnectbtn.Text = "DISCONNECT";
            this.disconnectbtn.UseVisualStyleBackColor = true;
            this.disconnectbtn.Click += new System.EventHandler(this.disconnectbtn_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(716, 106);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(161, 49);
            this.RegisterButton.TabIndex = 15;
            this.RegisterButton.Text = "REGISTER";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(716, 49);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(161, 49);
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // usernamebox
            // 
            this.usernamebox.Location = new System.Drawing.Point(506, 60);
            this.usernamebox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(161, 26);
            this.usernamebox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "password";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(506, 130);
            this.passwordbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(161, 26);
            this.passwordbox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 731);
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
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

