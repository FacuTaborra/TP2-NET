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
    public partial class personas : UI.WebForm.Default
    {
        private PersonaLogic _logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            List<Persona> personas = logic.GetAll();
            foreach (Persona p in personas)
            {
                PlanLogic pl = new PlanLogic();
                p.Plan = pl.GetOne(p.Plan.ID);
            }
            this.gvPersonas.DataSource = personas;
            this.gvPersonas.DataBind();
        }

        private PersonaLogic logic
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

        private Persona Entity
        {
            get;
            set;
        }

        private int  SelectedID
        {
            get
            {
                if(this.ViewState["SelectedID"] != null)
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

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)gvPersonas.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = logic.GetOne(id);
            this.NombreTextBox.Text = Entity.Nombre;
            this.ApellidoTextBox.Text = Entity.Apellido;
            this.DireccionTextBox.Text = Entity.Direccion;
            this.EmailTextBox.Text = Entity.Email;
            this.TelefonoTextBox.Text = Entity.Telefono;
            this.LegajoTextBox.Text = Entity.Legajo.ToString();
            this.DateTimeTextBox.Text = Entity.FechaNacimiento.ToString();
            this.PlanDropDownList.SelectedValue = Entity.Plan.ID.ToString();
            this.TipoPersonaDropDownList.SelectedIndex = (int)Entity.TipoPersona;
        }

        protected void PlanDropDownList_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = pl.GetAll();
                Plan plan = new Plan();
                plan.Descripcion = "Seleccionar Plan";
                planes.Insert(0, plan);
                this.PlanDropDownList.DataSource = planes;
                this.PlanDropDownList.DataTextField = "Descripcion";
                this.PlanDropDownList.DataValueField = "ID";
                this.PlanDropDownList.DataBind();
            }
        }
        protected void TipoPersonaDropDownList_Load(object sender, EventArgs e)
        {
            this.TipoPersonaDropDownList.DataSource = Enum.GetValues(typeof(Persona.TiposPersonas));
            this.TipoPersonaDropDownList.DataBind();
        }

        protected void EditarLinkButton_Click(object sender, EventArgs e)
        {
            if(this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        private void EnableForm(bool enable)
        {
            this.NombreTextBox.Enabled = enable;
            this.ApellidoTextBox.Enabled = enable;
            this.DireccionTextBox.Enabled = enable;
            this.EmailTextBox.Enabled = enable;
            this.DateTimeTextBox.Enabled = enable;
            this.PlanDropDownList.Enabled = enable;
            this.LegajoTextBox.Enabled = enable;
            this.TelefonoTextBox.Enabled = enable;
            this.TipoPersonaDropDownList.Enabled = enable;
        }


        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.NombreTextBox.Text;
            persona.Apellido = this.ApellidoTextBox.Text;
            persona.Direccion = this.DireccionTextBox.Text;
            persona.Email = this.EmailTextBox.Text;
            persona.Telefono = this.TelefonoTextBox.Text;
            persona.Legajo = int.Parse(this.LegajoTextBox.Text);
            persona.FechaNacimiento = DateTime.Parse(this.DateTimeTextBox.Text);
            persona.TipoPersona = (Persona.TiposPersonas)this.TipoPersonaDropDownList.SelectedIndex;
            Plan p = new Plan(int.Parse(this.PlanDropDownList.SelectedItem.Value));
            persona.Plan = p;
        }

        private void SaveEntity(Persona persona)
        {
            logic.Save(persona);
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
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

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            if(this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.logic.Delete(id);
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.NombreTextBox.Text = string.Empty;
            this.ApellidoTextBox.Text = string.Empty;
            this.DireccionTextBox.Text = string.Empty;
            this.EmailTextBox.Text = string.Empty;
            this.DateTimeTextBox.Text = string.Empty;
            this.PlanDropDownList.SelectedIndex = 0;
            this.LegajoTextBox.Text = string.Empty;
            this.TelefonoTextBox.Text = string.Empty;
            this.TipoPersonaDropDownList.SelectedIndex = 0;
        }

    }
}