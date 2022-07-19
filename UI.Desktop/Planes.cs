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
            GenerarColumnaEspecialidad();
            
        }
        

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
    }
}
