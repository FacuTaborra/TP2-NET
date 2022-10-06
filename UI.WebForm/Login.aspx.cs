using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.WebForm
{
    public partial class Login : System.Web.UI.Page
    {

        public bool ValidarIngreso()
        {
            UsuarioLogic usrLogic = new UsuarioLogic();
            Usuario usr = new Usuario();
            usr = usrLogic.GetOneByUserName(this.usrTextBox.Text);
            if (usr == null)
            {
                return false;
            }
            else if (usr.Clave != this.passwordTextBox.Text)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ingresarLinkButton_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {
                // Ingresó
            }
            else
            {
                this.usrExiste.Visible = true;
            }
        }
    }
}