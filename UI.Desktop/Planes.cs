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


        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            foreach(Plan p in planes)
            {
                EspecialidadLogic el = new EspecialidadLogic();
                p.Especialidad = el.GetOne(p.Especialidad.ID);
            }
            this.dgvPlanes.DataSource = planes;
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
            formMenu mn = new formMenu();
            mn.Show();
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
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

        private int MateriasDePlan(int id)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> listaMaterias = ml.GetAll();
            int cant = 0;
            foreach(var mat in listaMaterias)
            {
                if (mat.Plan.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }

        private int ComisionesdePlan(int id)
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comision> listaCom = cl.GetAll();
            int cant = 0;
            foreach (var com in listaCom)
            {
                if (com.Plan.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }

        private int PersonasDePlan(int id)
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> listaPersonas = pl.GetAll();
            int cant = 0;
            foreach (var per in listaPersonas)
            {
                if (per.Plan.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                if (MateriasDePlan(id) == 0)
                {
                    if (ComisionesdePlan(id) == 0)
                    {
                        if (PersonasDePlan(id) == 0)
                        {
                            PlanDesktop formPlan = new PlanDesktop(id, ApplicationForm.ModoForm.baja);
                            formPlan.ShowDialog();
                            this.Listar();
                        }
                        else
                        {
                            ApplicationForm af = new ApplicationForm();
                            af.Notificar("No es posible eliminar el Plan por tener Personas asociadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        ApplicationForm af = new ApplicationForm();
                        af.Notificar("No es posible eliminar el Plan por tener Comisiones asociadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ApplicationForm af = new ApplicationForm();
                    af.Notificar("No es posible eliminar el Plan por tener Materias asociadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
