using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }


        public override bool Validar()
        {
            if(this.txtUsuario.Text!="" && this.txtPass.Text != "")
            {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario usu = new Usuario();
                usu = ul.GetOneByUserName(this.txtUsuario.Text);
                if (usu==null)
                {
                    Notificar("El nombre de usuario ingresado es incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (usu.Clave != this.txtPass.Text)
                {
                    Notificar("La contraseña es incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
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

        private void linkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Notificar("Por el momento no es posible cambiar la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
        }
    }
}
