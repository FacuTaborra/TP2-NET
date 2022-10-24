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
    public partial class tcEspecialidades : Form
    {
        public tcEspecialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidad_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            formMenu mn = new formMenu();
            mn.Show();
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.alta);
            formEspecialidad.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(dgvEspecialidades.SelectedRows.Count == 1)
            {
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.modificacion);
                formEspecialidad.ShowDialog();
                Listar();
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int PlanesDeEspecialidad(int id)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> listaPlanes = pl.GetAll();
            int cant = 0;
            foreach (var plan in listaPlanes)
            {
                if (plan.Especialidad.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }


        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 1)
            {
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                if (PlanesDeEspecialidad(ID) == 0)
                {
                    EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.baja);
                    formEspecialidad.ShowDialog();
                    Listar();
                }
                else
                {
                    ApplicationForm af = new ApplicationForm();
                    af.Notificar("No es posible eliminar la Especialidad por tener Planes asociados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
