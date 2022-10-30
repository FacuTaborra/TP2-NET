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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.labelErrorInicio.Visible = false;
        }
        
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario usr = ul.GetOneByUserName(this.txtUsrName.Text);
            if (usr != null && usr.Clave == this.txtPassword.Text)
            {
                Session["UsrActual"] = usr;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.divErrorInicio.Visible = true;
            }
        }
        
    }
}