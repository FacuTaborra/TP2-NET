using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsrActual"]; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}