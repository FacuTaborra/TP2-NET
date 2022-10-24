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
    public partial class Comisiones : Default
    {
        ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Comision Entity
        {
            get; 
            set;
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
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                LoadGrid();
                LoadDropDown();
            }
        }
        private void LoadDropDown()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> listaPlanes = new List<Plan>();
            listaPlanes = pl.GetAll();
            Plan extraPlan = new Plan();
            extraPlan.ID = 0;
            extraPlan.Descripcion = "Seleccionar Plan";
            listaPlanes.Add(extraPlan);
            this.ddlPlanes.DataSource = listaPlanes;
            this.ddlPlanes.DataValueField = "ID";
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataBind();
            this.ddlPlanes.SelectedValue = 0.ToString();
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.DescripcionLabel.Text = Entity.Descripcion;
            this.txtDescripcion.Text = Entity.Descripcion;
            this.txtAnioEspecialidad.Text = Entity.AnioEspecialidad.ToString();
            this.ddlPlanes.SelectedValue = Entity.Plan.ID.ToString();
        }

        private void LoadEntity(Comision com)
        {
            com.Descripcion = this.txtDescripcion.Text;
            com.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
            int idPlan = int.Parse(this.ddlPlanes.SelectedValue);
            PlanLogic pl = new PlanLogic();
            com.Plan = pl.GetOne(idPlan);
            this.txtDescripcion.Text = com.Plan.Descripcion;
            
        }

        private void SaveEntity(Comision com)
        {
            this.Logic.Save(com);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.txtAnioEspecialidad.Enabled = enable;
            this.txtDescripcion.Enabled = enable;
            this.ddlPlanes.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtAnioEspecialidad.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.ddlPlanes.SelectedValue = 0.ToString();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
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