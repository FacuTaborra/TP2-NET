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
    public partial class MasterAdmin : ApplicationForm
    {
        public MasterAdmin()
        {
            InitializeComponent();
        }

        private void gestionarPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes();
            pl.Show();
            this.Close();
        }

        private void gestionarEspecializacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcEspecialidades tce = new tcEspecialidades();
            tce.Show();
            this.Close();
        }

        private void tsUsuarios_ButtonClick(object sender, EventArgs e)
        {
            tcUsuarios us = new tcUsuarios(); this.Close();
            us.Show();
            this.Close();
        }

        private void tsProfesores_Click(object sender, EventArgs e)
        {
            Personas perfom = new Personas(Business.Entities.Persona.TiposPersonas.Profesor);
            perfom.Show();
            this.Close();
        }

        private void tsAlumnos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Personas perfom = new Personas(Business.Entities.Persona.TiposPersonas.Alumno);
            perfom.Show();
            this.Close();
        }

        private void tsAdministrativos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Personas perfom = new Personas(Business.Entities.Persona.TiposPersonas.Administrador);
            perfom.Show();
            this.Close();
        }

        private void tsCursos_ButtonClick(object sender, EventArgs e)
        {
            Cursos cursosForm = new Cursos();
            cursosForm.Show();
            this.Close();
        }

        private void tsMaterias_Click(object sender, EventArgs e)
        {
            Materias mt = new Materias();
            mt.Show();
            this.Close();
        }

        private void tsComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisionesForm = new Comisiones();
            comisionesForm.Show();
            this.Close();
        }

        private void tsReporteCursos_Click(object sender, EventArgs e)
        {
            EligeAñoInformeCurso eligeAñoInformeCurso = new EligeAñoInformeCurso();
            eligeAñoInformeCurso.ShowDialog();
        }

        private void reportePlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPlanes report = new ReportPlanes();
            report.ShowDialog();
        }
    }
}
