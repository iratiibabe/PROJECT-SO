namespace CLIENT
{
    partial class invitacionForm
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
            this.lblMensajeInvitacion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnDenegar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensajeInvitacion
            // 
            this.lblMensajeInvitacion.AutoSize = true;
            this.lblMensajeInvitacion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMensajeInvitacion.Location = new System.Drawing.Point(211, 43);
            this.lblMensajeInvitacion.Name = "lblMensajeInvitacion";
            this.lblMensajeInvitacion.Size = new System.Drawing.Size(0, 30);
            this.lblMensajeInvitacion.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(69, 109);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(127, 48);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Accept";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnDenegar
            // 
            this.btnDenegar.Location = new System.Drawing.Point(266, 109);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(127, 48);
            this.btnDenegar.TabIndex = 2;
            this.btnDenegar.Text = "Deny";
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // invitacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(481, 184);
            this.Controls.Add(this.btnDenegar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMensajeInvitacion);
            this.Name = "invitacionForm";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.invitacionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeInvitacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnDenegar;
    }
}