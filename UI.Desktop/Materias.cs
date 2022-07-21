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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.alta);
            formMateria.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.modificacion);
                formMateria.ShowDialog();
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
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
