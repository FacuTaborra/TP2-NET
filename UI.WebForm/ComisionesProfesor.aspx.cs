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
    public partial class ComisionesProfesor : Default
    {
        private new Usuario UsuarioActual
        {
            get
            {
                Default d = new Default();
                return d.UsuarioActual;
            }
        }

        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
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
            get
            {
                return (this.SelectedID != 0);
            }
        }


        private void LoadGrid()
        {
            DocenteCursoLogic _DataCurso = new DocenteCursoLogic();

            List<DocenteCurso> docenteCursos = _DataCurso.GetCursosProfesor(UsuarioActual.Persona.ID);
            this.GridView.DataSource = docenteCursos;
            this.GridView.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }


        protected void alumnosComLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                CursoLogic cl = new CursoLogic();
                this.CursoActual = cl.GetOne(this.SelectedID);
                Response.Redirect("~/AlumnosComision.aspx");
            }
        }

        protected void GridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
    }
}