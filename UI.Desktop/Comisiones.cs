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
    public partial class Comisiones : Master
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
        }

        private int CursosDeComision(int id)
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> listaCursos = cl.GetAll();
            int cant = 0;
            foreach (var cur in listaCursos)
            {
                if (cur.Comision.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }


        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
            MenuAdmin menu = new MenuAdmin();
            menu.Show();
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop cd = new ComisionesDesktop(ApplicationForm.ModoForm.alta);
            cd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count == 1)
            {
                int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop cd = new ComisionesDesktop(id, ApplicationForm.ModoForm.modificacion);
                cd.ShowDialog();
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
            if (this.dgvComisiones.SelectedRows.Count == 1)
            {
                int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                if (CursosDeComision(id) == 0)
                {
                    ComisionesDesktop cd = new ComisionesDesktop(id, ApplicationForm.ModoForm.baja);
                    cd.ShowDialog();
                    this.Listar();
                }
                else
                {
                    ApplicationForm af = new ApplicationForm();
                    af.Notificar("No es posible eliminar la Comisión por tener Cursos asociados", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
