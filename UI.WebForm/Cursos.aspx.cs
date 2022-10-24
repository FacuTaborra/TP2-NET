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
    public partial class Cursos : Default
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

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }


        private Curso Entity
        {
            get; set;
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
            this.GridViewCursos.DataSource = this.Logic.GetAll();
            this.GridViewCursos.DataBind();
        }

        private void LoadDropDown()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            Materia matExtra = new Materia();
            matExtra.ID = 0;
            matExtra.Descripcion = "Seleccionar Materia";
            materias.Add(matExtra);
            this.ddlMateria.DataSource = materias;
            this.ddlMateria.DataValueField = "ID";
            this.ddlMateria.DataTextField = "Descripcion";
            this.ddlMateria.DataBind();
            this.ddlMateria.SelectedValue = 0.ToString();

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            Comision comExtra = new Comision();
            comExtra.ID = 0;
            comExtra.Descripcion = "Seleccionar Comision";
            comisiones.Add(comExtra);
            this.ddlComision.DataSource = comisiones;
            this.ddlComision.DataValueField = "ID";
            this.ddlComision.DataTextField = "Descripcion";
            this.ddlComision.DataBind();
            this.ddlComision.SelectedValue = 0.ToString();
        }


        new protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadGrid();
                LoadDropDown();
            }
        }


        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtAnio.Text = Entity.AnioCalendario.ToString();
            this.txtCupo.Text = Entity.Cupo.ToString();
            this.ddlComision.SelectedValue = Entity.Comision.ID.ToString();
            this.ddlMateria.SelectedValue = Entity.Materia.ID.ToString();
        }

        private void LoadEntity(Curso cur)
        {
            cur.AnioCalendario = int.Parse(this.txtAnio.Text);
            cur.Cupo = int.Parse(this.txtCupo.Text);
            int idMat = int.Parse(this.ddlMateria.SelectedValue);
            MateriaLogic ml = new MateriaLogic();
            cur.Materia = ml.GetOne(idMat);
            int idCom = int.Parse(this.ddlComision.SelectedValue);
            ComisionLogic cl = new ComisionLogic();
            cur.Comision = cl.GetOne(idCom);
        }

        private void SaveEntity(Curso cur)
        {
            this.Logic.Save(cur);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }


        private void EnableForm(bool enable)
        {
            this.ddlComision.Enabled = enable;
            this.ddlMateria.Enabled = enable;
            this.txtAnio.Enabled = enable;
            this.txtCupo.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtCupo.Text = string.Empty;
            this.txtAnio.Text = string.Empty;
            this.ddlMateria.SelectedValue = 0.ToString();
            this.ddlComision.SelectedValue = 0.ToString();
        }


        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.Entity.State = BusinessEntity.States.New;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;
        }

        protected void GridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridViewCursos.SelectedValue;
        }
    }
}