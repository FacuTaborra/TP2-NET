using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }


        private bool Validar()
        {
            if(this.txtUsuario.Text!="" && this.txtPass.Text != "")
            {

            }
            else
            {
                Notificar("Ninguno de los campos puede estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Notificar("Bienvenido al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }
    }
}
