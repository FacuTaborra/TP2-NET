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
    public partial class Especialidades : UI.WebForm.Default
    {

        EspecialidadLogic _logic;


        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        public Especialidad Entity
        {
            get;
            set;
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm (int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.IDTextBox.Text = this.Entity.ID.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                LoadGrid();
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
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadEntity(Especialidad esp)
        {
            esp.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad esp)
        {
            this.Logic.Save(esp);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
        }

        private void ClearForm()
        {
            this.IDTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;

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
                    this.Entity = new Especialidad();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Especialidad();
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
            this.ClearForm();
            this.LoadGrid();
            this.formPanel.Visible = false;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
    }
}