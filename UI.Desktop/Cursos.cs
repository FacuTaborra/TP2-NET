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
    public partial class Cursos : MasterAdmin
    {

        CursoLogic cl = new CursoLogic();
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar(int año)
        {
            this.dgvCursos.DataSource = cl.GetAll(año);
            var index = this.cbConsultaAño.SelectedIndex;
            this.cbConsultaAño.DataSource = cl.GetAños();
            this.cbConsultaAño.SelectedIndex = index;
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar(DateTime.UtcNow.Year);
            //tira un error si dejo el cb vacio
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuAdmin ma = new MenuAdmin();
            ma.Show();
            this.Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            EligePlanCurso eligePlanCurso = new EligePlanCurso();
            eligePlanCurso.ShowDialog();
            if (this.cbConsultaAño.SelectedValue != null)
            {
                this.Listar(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
            }
            
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count == 1)
            {
                int selectedID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosDesktop cd = new CursosDesktop(selectedID, ApplicationForm.ModoForm.modificacion);
                cd.ShowDialog();
                this.Listar(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
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
                Listar(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Listar(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
        }
    }
}
