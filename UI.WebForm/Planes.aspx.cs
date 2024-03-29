﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Planes : UI.WebForm.Default
    {
        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Plan Entity 
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
            get { return (this.SelectedID != 0); }
        }

        private void LoadGrid()
        {


            this.gridView.DataSource =  this.Logic.GetAll(); // cambiar y traer las especialidades
            this.gridView.DataBind();
        }

        private void LoadDropDown()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> listaEsp = new List<Especialidad>();
            listaEsp = el.GetAll();
            Especialidad extraEsp = new Especialidad();
            extraEsp.ID = 0;
            extraEsp.Descripcion = "Seleccionar Plan";
            listaEsp.Add(extraEsp);
            this.ddlEspecialidad.DataSource = listaEsp;
            this.ddlEspecialidad.DataValueField = "ID";
            this.ddlEspecialidad.DataTextField = "Descripcion";
            this.ddlEspecialidad.DataBind();
            this.ddlEspecialidad.SelectedValue = 0.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.LoadGrid();
                this.LoadDropDown();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDPlanTextBox.Text = this.Entity.ID.ToString();
            this.DescripcionTextBox.Text = this.Entity.Descripcion;
            this.ddlEspecialidad.SelectedValue = this.Entity.Especialidad.ID.ToString();
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

        protected void LoadEntity(Plan plan)
        {
            int idEsp = int.Parse(this.ddlEspecialidad.SelectedValue);
            EspecialidadLogic el = new EspecialidadLogic();
            plan.Especialidad = el.GetOne(idEsp);
            plan.Descripcion = this.DescripcionTextBox.Text;
        }

        protected void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
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
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
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

        private void EnableForm(bool enable)
        {
            this.DescripcionTextBox.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
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

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.ddlEspecialidad.SelectedValue = 0.ToString();
            this.DescripcionTextBox.Text = string.Empty;
            this.IDPlanTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;
        }
    }
}