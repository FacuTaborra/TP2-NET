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
    public partial class MateriasPlan : System.Web.UI.Page
    {
        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }



        private void LoadGrid()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridView.DataSource = Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void descPlan_Load(object sender, EventArgs e)
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

        protected void FiltrarLinkButton_Click(object sender, EventArgs e)
        {
            int idPlan = int.Parse(this.ddlPlan.SelectedValue);
            this.gridView.DataSource = Logic.GetAllWhithPlan(idPlan);
            this.gridView.DataBind();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}