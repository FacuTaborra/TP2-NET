﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.WebForm
{
    public partial class Materias : UI.WebForm.Default
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

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Materia Entity
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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
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
                List<Plan> planes = pl.GetAll();
                Plan plan = new Plan();
                plan.Descripcion = "Sin filtro";
                planes.Insert(0, plan);
                this.ddlFiltroPlan.DataSource = planes;
                this.ddlFiltroPlan.DataTextField = "Descripcion";
                this.ddlFiltroPlan.DataValueField = "ID";
                this.ddlFiltroPlan.DataBind();
        }

        protected void FiltrarLinkButton_Click(object sender, EventArgs e)
        {
            int idPlan = int.Parse(this.ddlFiltroPlan.SelectedValue);
            this.gridView.DataSource = Logic.GetAllWhithPlan(idPlan);
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = Entity.ID.ToString();
            this.DescripcionTextBox.Text = Entity.Descripcion;
            this.HSSemanalesTextBox.Text = Entity.HSSemanales.ToString();
            this.HSTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            this.ddlPlan.SelectedValue = this.Entity.Plan.ID.ToString();
        }

        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.DescripcionTextBox.Text;
            materia.HSSemanales = int.Parse(this.HSSemanalesTextBox.Text);
            materia.HSTotales = int.Parse(this.HSTotalesTextBox.Text);
            int idPlan = int.Parse(this.ddlPlan.SelectedValue);
            PlanLogic pl = new PlanLogic();
            materia.Plan = pl.GetOne(idPlan);
        }
        private void SaveEntity(Materia mat)
        {
            this.Logic.Save(mat);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.DescripcionTextBox.Enabled = enable;
            this.HSSemanalesTextBox.Enabled = enable;
            this.HSTotalesTextBox.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        public int CursosDeMateria(int id)
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> listaCursos = cl.GetAll();
            int cant = listaCursos.Select(cur => cur.Materia.ID == id).Count();
            return cant;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    if (CursosDeMateria(this.SelectedID)==0)
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                    }
                    else
                    {
                        this.labelErrorFK.Visible = true;
                    }
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
                    this.Entity.State = BusinessEntity.States.New;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                default:
                    break;
            }
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
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.LoadGrid();
            this.formPanel.Visible = false;
        }

        private void ClearForm()
        {
            this.IDTextBox.Text = string.Empty;
            this.DescripcionTextBox.Text = string.Empty;
            this.HSSemanalesTextBox.Text = string.Empty;
            this.HSTotalesTextBox.Text = string.Empty;
            this.ddlPlan.SelectedValue = 0.ToString();
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
    }
}