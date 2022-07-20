using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            
        }


        private void GenerarColumnaEspecialidad()
        {




            /*
            DataGridViewTextBoxColumn colEsp = new DataGridViewTextBoxColumn();
            DataTable tablaEsp = new DataTable();
            tablaEsp = getEspecialidades();
            */



        }


        private DataTable getEspecialidades()
        {
            DataTable dtEsp = new DataTable();
            dtEsp.Columns.Add("id_esp", typeof(int));
            dtEsp.Columns.Add("desc_esp", typeof(string));
            List<Especialidad> listaEsp = new List<Especialidad>();
            EspecialidadLogic el = new EspecialidadLogic();
            listaEsp = el.GetAll();
            foreach (Especialidad esp in listaEsp)
            {
                dtEsp.Rows.Add(new Object[] { esp.ID, esp.Descripcion });
            }
            return dtEsp;
        }



      /*  
        private void GenerarColumnaEspecialidad()
        {
            DataGridViewComboBoxColumn colEspecialidad = new DataGridViewComboBoxColumn();
            colEspecialidad.Name = "Especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.DataPropertyName = "Especialidad";
            colEspecialidad.DisplayIndex = 5;
            
             colEspecialidad.Items.Add(1);
             colEspecialidad.Items.Add(2);
             colEspecialidad.Items.Add(3);
             colEspecialidad.Items.Add(4);
            this.dgvPlanes.Columns.Add(colEspecialidad);
           

        }
    */

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.alta);
            formPlan.CompletarCBEspecialidad(formPlan.cbEspecialidad);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                PlanDesktop formPlan = new PlanDesktop(id, ApplicationForm.ModoForm.modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                PlanDesktop formPlan = new PlanDesktop(id, ApplicationForm.ModoForm.baja);
                formPlan.ShowDialog();
                this.Listar();
            }
        }
    }
}
