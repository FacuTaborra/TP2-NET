using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            tcUsuarios tcu = new tcUsuarios();
            tcu.Show();
            this.Close();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            tcEspecialidades tce = new tcEspecialidades();
            tce.Show();
            this.Close();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes();
            pl.Show();
            this.Close();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mt = new Materias();
            mt.Show();
            this.Close();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas per = new Personas();
            per.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisionesForm = new Comisiones();
            comisionesForm.Show();
            this.Close();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursosForm = new Cursos();
            cursosForm.Show();
            this.Close();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            Personas perfom = new Personas();
        }
    }
}
