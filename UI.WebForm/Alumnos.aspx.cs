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
    public partial class Alumnos : UI.WebForm.Default
    {
        PersonaLogic _logic;

        private Persona Entity
        {
            get; set;
        }

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private void LoadDropDown()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            Plan plan = new Plan();
            plan.Descripcion = "Plan";
            planes.Insert(0, plan);
            this.ddlPlan.DataSource = planes;
            this.ddlPlan.DataTextField = "Descripcion";
            this.ddlPlan.DataValueField = "ID";
            this.ddlPlan.DataBind();

            if (this.FormMode == FormModes.Alta)
            {
                ddlTipoPersona.SelectedValue = 3.ToString();
            }
            else
            {
                switch (Entity.TipoPersona)
                {
                    case Persona.TiposPersonas.Administrador:
                        ddlTipoPersona.SelectedIndex = 0;
                        break;
                    case Persona.TiposPersonas.Alumno:
                        ddlTipoPersona.SelectedIndex = 1;
                        break;
                    case Persona.TiposPersonas.Profesor:
                        ddlTipoPersona.SelectedIndex = 2;
                        break;
                    default:
                        ddlTipoPersona.SelectedIndex = 3;
                        break;
                }
            }

        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAlumnos();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.LoadDropDown();
            this.legajoTextBox.Text = Entity.Legajo.ToString();
            this.nombreTextBox.Text = Entity.Nombre;
            this.apellidoTextBox.Text = Entity.Apellido;
            this.emailTextBox.Text = Entity.Email;
            this.direcTextBox.Text = Entity.Direccion;
            this.fechaNacTextBox.Text = Entity.FechaNacimiento.ToString();
            this.telefonoTextBox.Text = Entity.Telefono;
            this.ddlTipoPersona.SelectedValue = Entity.TipoPersona.ToString();
            this.ddlPlan.SelectedValue = Entity.Plan.ID.ToString();
        }

        private void LoadEntity(Persona per)
        {
            per.Legajo = int.Parse(this.legajoTextBox.Text);
            per.Apellido = this.apellidoTextBox.Text;
            per.Nombre = this.nombreTextBox.Text;
            per.Email = this.emailTextBox.Text;
            per.Telefono = this.telefonoTextBox.Text;
            per.FechaNacimiento = DateTime.Parse(this.fechaNacTextBox.Text);
            per.Direccion = this.direcTextBox.Text;
            per.TipoPersona = (Persona.TiposPersonas)ddlTipoPersona.SelectedIndex;
            int idPlan = int.Parse(this.ddlPlan.SelectedValue);
            PlanLogic pl = new PlanLogic();
            per.Plan = pl.GetOne(idPlan);
        }

        private void SaveEntity(Persona per)
        {
            this.Logic.Save(per);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        private void EnableForm(bool enable)
        {
            this.legajoTextBox.Enabled = enable;
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direcTextBox.Enabled = enable;
            this.fechaNacTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.ddlTipoPersona.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            this.legajoTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direcTextBox.Text = string.Empty;
            this.fechaNacTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.ddlPlan.SelectedValue = 0.ToString();
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
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

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
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
    }
}