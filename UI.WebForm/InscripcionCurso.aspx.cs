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
    public partial class InscripcionCurso : Default
    {
        private AlumnoInscripcion Entity
        {
            get; set;
        }

        private Curso CursoActual
        {
            get; set;
        }

        private AlumnoInscripcionLogic _aiLogic;
        private AlumnoInscripcionLogic AILogic
        {
            get
            {
                if (_aiLogic == null)
                {
                    _aiLogic = new AlumnoInscripcionLogic();
                }
                return _aiLogic;
            }
        }

        private CursoLogic _cLogic;
        private CursoLogic CLogic
        {
            get
            {
                if (_cLogic == null)
                {
                    _cLogic = new CursoLogic();
                }
                return _cLogic;
            }
        }

        private PersonaLogic PerLogic
        {
            get; set;
        }

        private new Usuario UsuarioActual
        {
            get
            {
                Default d = new Default();
                return d.UsuarioActual;
            }
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
        
        private void LoadGrid()
        { 
            this.GridViewCursos.DataSource =CLogic.GetCursosDisponibles(2022, UsuarioActual.Persona); ;
            this.GridViewCursos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void GridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridViewCursos.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.CursoActual = this.CLogic.GetOne(id);
            this.txtCurso.Text = this.CursoActual.ID.ToString();
            this.txtMateria.Text = this.CursoActual.Materia.Descripcion;
            this.txtComision.Text = this.CursoActual.Comision.Descripcion;
            this.txtAnioCurso.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtAnioEsp.Text = this.CursoActual.Comision.AnioEspecialidad.ToString();
            this.txtPlan.Text = this.CursoActual.PlanComision;
        }

        private void LoadEntity()
        {
            this.Entity = new AlumnoInscripcion();
            this.Entity.Alumno = UsuarioActual.Persona;
            this.Entity.Curso = CursoActual;
            this.Entity.Condicion = "Inscripto";
        }

        private void SaveEntity()
        {
            this.Entity.State = BusinessEntity.States.New;
            AILogic.Save(this.Entity);
            this.Entity.Curso.Cupo = this.Entity.Curso.Cupo - 1;
            this.Entity.Curso.State =BusinessEntity.States.Modified;
            CLogic.Save(this.Entity.Curso);
        }

        protected void finalizarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new AlumnoInscripcion();
            this.LoadEntity();
            this.SaveEntity();
            Response.Redirect("~/EstadoAcademico.aspx");
        }

        protected void CancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void InscibirLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void CancelarInscLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;
        }
    }
}