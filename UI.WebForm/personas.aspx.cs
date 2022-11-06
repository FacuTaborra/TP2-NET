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
    public partial class Personas : UI.WebForm.Default
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

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPlan_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
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
            }
        }

        protected void ddlTipoPersona_Load(object sender, EventArgs e)
        {
            ddlTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TiposPersonas));
            ddlTipoPersona.SelectedIndex = 0;
        }
    }
}