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
    public partial class Cursos : Form
    {

        CursoLogic cl = new CursoLogic();
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }


        public void Listar()
        {
            this.dgvCursos.DataSource = cl.GetAll(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
            this.cbConsultaAño.DataSource = cl.GetAños();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            CursosDesktop cd = new CursosDesktop(ApplicationForm.ModoForm.alta);
            cd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count == 1)
            {
                int selectedID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosDesktop cd = new CursosDesktop(selectedID, ApplicationForm.ModoForm.modificacion);
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
            if (this.dgvCursos.SelectedRows.Count == 1)
            {
                int selectedID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosDesktop cd = new CursosDesktop(selectedID, ApplicationForm.ModoForm.baja);
                cd.ShowDialog();
                Listar();
            }
        }

        private void cbConsultaAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
