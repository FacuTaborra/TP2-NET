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
    public partial class InscripcionExamen : System.Web.UI.Page
    {
        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}