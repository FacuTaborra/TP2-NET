using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Security.Principal;

namespace UI.WebForm
{
    public partial class Site : System.Web.UI.MasterPage
    {

        public Business.Entities.Usuario UsrActual
        {
            get
            {
                return (Business.Entities.Usuario)this.Session["UsrActual"];
            }
            set
            {
                this.Session["UsrActual"] = value;
            }
        }

        public string TipoPersonaActual
        {
            get
            {
                
                if (UsrActual!= null)
                {
                    PersonaLogic pl = new PersonaLogic();
                    Persona per = pl.GetOne(this.UsrActual.Persona.ID);
                    return per.TipoPersona.ToString();
                }
                else
                {
                    return "unloaded";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] rol = { this.TipoPersonaActual};
            HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, rol);
        }

        protected void lbCerrarSession_Click(object sender, EventArgs e)
        {
            UsrActual = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}