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

namespace UI.Desktop
{
    public partial class MasterAlumno : ApplicationForm
    {
        public Persona _alumno;

        public Persona Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }
        }

        public MasterAlumno()
        {
            InitializeComponent();
        }

        private void materiasDelPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanEstudio pl = new PlanEstudio(Alumno);
            pl.Show();
            this.Close();
        }

        private void estadoAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadoAcademico estadoAcademico = new EstadoAcademico(Alumno);
            estadoAcademico.Show();
            this.Close();
        }

        private void inscripcionACursadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InscripcionCurso ic = new InscripcionCurso(Alumno);
            ic.Show();
            this.Close();
        }
    }
}
