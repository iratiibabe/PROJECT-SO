using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class invitacionForm : Form
    {

        public invitacionForm(string mensaje)
        {
            InitializeComponent();
            lblMensajeInvitacion.Text = mensaje; // it will show the message
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public void btnDenegar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        public invitacionForm()
        {
            InitializeComponent();
        }

        private void invitacionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
