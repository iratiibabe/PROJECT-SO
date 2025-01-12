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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bttn_CeldasSeleccionadas = new System.Windows.Forms.Button();
			this.ChatBox = new System.Windows.Forms.ListBox();
			this.MessageChatBox = new System.Windows.Forms.TextBox();
			this.sendMessage = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.LBLnumForm = new System.Windows.Forms.Label();
			this.TITLE_ID = new System.Windows.Forms.Label();
			this.IDLBL = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.datagridRockets = new System.Windows.Forms.DataGridView();
			this.PLAYER = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ROCKETS_LEFT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.datagridRockets)).BeginInit();
			this.SuspendLayout();
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
			this.dataGridView1.Location = new System.Drawing.Point(69, 111);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 82;
			this.dataGridView1.RowTemplate.Height = 33;
			this.dataGridView1.Size = new System.Drawing.Size(576, 347);
			this.dataGridView1.TabIndex = 22;
			// 
			// bttn_CeldasSeleccionadas
			// 
			this.bttn_CeldasSeleccionadas.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bttn_CeldasSeleccionadas.Location = new System.Drawing.Point(272, 521);
			this.bttn_CeldasSeleccionadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bttn_CeldasSeleccionadas.Name = "bttn_CeldasSeleccionadas";
			this.bttn_CeldasSeleccionadas.Size = new System.Drawing.Size(149, 34);
			this.bttn_CeldasSeleccionadas.TabIndex = 23;
			this.bttn_CeldasSeleccionadas.Text = "SEND  SELECTION";
			this.bttn_CeldasSeleccionadas.UseVisualStyleBackColor = true;
			this.bttn_CeldasSeleccionadas.Click += new System.EventHandler(this.bttn_CeldasSeleccionadas_Click);
			// 
			// ChatBox
			// 
			this.ChatBox.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChatBox.FormattingEnabled = true;
			this.ChatBox.ItemHeight = 20;
			this.ChatBox.Location = new System.Drawing.Point(69, 599);
			this.ChatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ChatBox.Name = "ChatBox";
			this.ChatBox.Size = new System.Drawing.Size(767, 124);
			this.ChatBox.TabIndex = 25;
			this.ChatBox.SelectedIndexChanged += new System.EventHandler(this.ChatBox_SelectedIndexChanged);
			// 
			// MessageChatBox
			// 
			this.MessageChatBox.BackColor = System.Drawing.Color.Azure;
			this.MessageChatBox.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MessageChatBox.Location = new System.Drawing.Point(191, 782);
			this.MessageChatBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MessageChatBox.Name = "MessageChatBox";
			this.MessageChatBox.Size = new System.Drawing.Size(497, 27);
			this.MessageChatBox.TabIndex = 0;
			// 
			// sendMessage
			// 
			this.sendMessage.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sendMessage.Location = new System.Drawing.Point(708, 775);
			this.sendMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.sendMessage.Name = "sendMessage";
			this.sendMessage.Size = new System.Drawing.Size(248, 39);
			this.sendMessage.TabIndex = 1;
			this.sendMessage.Text = "SEND";
			this.sendMessage.UseVisualStyleBackColor = true;
			this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
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
			this.dataGridView2.Location = new System.Drawing.Point(699, 111);
			this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersWidth = 82;
			this.dataGridView2.RowTemplate.Height = 33;
			this.dataGridView2.Size = new System.Drawing.Size(576, 347);
			this.dataGridView2.TabIndex = 29;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Stencil", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(933, 521);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(149, 34);
			this.button1.TabIndex = 30;
			this.button1.Text = "SEND  BOMB";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.bttn_BombSeleccionadas_Click);
			// 
			// LBLnumForm
			// 
			this.LBLnumForm.AutoSize = true;
			this.LBLnumForm.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.LBLnumForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LBLnumForm.Location = new System.Drawing.Point(1593, 735);
			this.LBLnumForm.Name = "LBLnumForm";
			this.LBLnumForm.Size = new System.Drawing.Size(2, 18);
			this.LBLnumForm.TabIndex = 31;
			this.LBLnumForm.Click += new System.EventHandler(this.LBLnumForm_Click);
			// 
			// TITLE_ID
			// 
			this.TITLE_ID.AutoSize = true;
			this.TITLE_ID.Font = new System.Drawing.Font("Stencil", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TITLE_ID.Location = new System.Drawing.Point(35, 25);
			this.TITLE_ID.Name = "TITLE_ID";
			this.TITLE_ID.Size = new System.Drawing.Size(148, 40);
			this.TITLE_ID.TabIndex = 32;
			this.TITLE_ID.Text = "MATCH:";
			// 
			// IDLBL
			// 
			this.IDLBL.AutoSize = true;
			this.IDLBL.Font = new System.Drawing.Font("Stencil", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IDLBL.Location = new System.Drawing.Point(203, 23);
			this.IDLBL.Name = "IDLBL";
			this.IDLBL.Size = new System.Drawing.Size(0, 40);
			this.IDLBL.TabIndex = 33;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this.TITLE_ID);
			this.groupBox1.Controls.Add(this.IDLBL);
			this.groupBox1.Location = new System.Drawing.Point(69, 14);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(348, 80);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			// 
			// datagridRockets
			// 
			this.datagridRockets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datagridRockets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PLAYER,
            this.ROCKETS_LEFT});
			this.datagridRockets.Location = new System.Drawing.Point(1280, 111);
			this.datagridRockets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.datagridRockets.Name = "datagridRockets";
			this.datagridRockets.RowHeadersWidth = 51;
			this.datagridRockets.RowTemplate.Height = 24;
			this.datagridRockets.Size = new System.Drawing.Size(412, 190);
			this.datagridRockets.TabIndex = 35;
			this.datagridRockets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick_1);
			// 
			// PLAYER
			// 
			this.PLAYER.HeaderText = "PLAYER";
			this.PLAYER.MinimumWidth = 6;
			this.PLAYER.Name = "PLAYER";
			this.PLAYER.Width = 125;
			// 
			// ROCKETS_LEFT
			// 
			this.ROCKETS_LEFT.HeaderText = "ROCKETS LEFT";
			this.ROCKETS_LEFT.MinimumWidth = 6;
			this.ROCKETS_LEFT.Name = "ROCKETS_LEFT";
			this.ROCKETS_LEFT.Width = 125;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1924, 844);
			this.Controls.Add(this.datagridRockets);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.LBLnumForm);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.ChatBox);
			this.Controls.Add(this.MessageChatBox);
			this.Controls.Add(this.sendMessage);
			this.Controls.Add(this.bttn_CeldasSeleccionadas);
			this.Controls.Add(this.dataGridView1);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.datagridRockets)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttn_CeldasSeleccionadas;
		private System.Windows.Forms.ListBox ChatBox;
		private System.Windows.Forms.TextBox MessageChatBox;
		private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LBLnumForm;
		private System.Windows.Forms.Label TITLE_ID;
		private System.Windows.Forms.Label IDLBL;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView datagridRockets;
		private System.Windows.Forms.DataGridViewTextBoxColumn PLAYER;
		private System.Windows.Forms.DataGridViewTextBoxColumn ROCKETS_LEFT;
	}
}

