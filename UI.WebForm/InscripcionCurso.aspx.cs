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
    public partial class InscripcionCurso : System.Web.UI.Page
    {
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsrActual"]; }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }

        private AlumnoInscripcion AlumnoInscripcion
        {
            get; set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GridViewCursos.DataSource = Logic.GetCursosDisponibles(2022, UsuarioActual.Persona);
                this.GridViewCursos.DataBind();
            }
        }

        protected void GridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridViewCursos.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.txtCurso.Text= this.
        }


        protected void inscribirLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void InscibirLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void CancelarLinkButton_Click1(object sender, EventArgs e)
        {

        }
    }
}