using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EstadoAcademico : UI.Desktop.MasterAlumno
    {
        public EstadoAcademico(Persona alumno)
        {
            Alumno = alumno;
            InitializeComponent();
            this.dgvEstadoAcademico.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            this.dgvEstadoAcademico.DataSource = alumnoInscripcionLogic.GetEstadoAcademico(Alumno.Legajo);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuAlumno menuAlumno = new MenuAlumno(Alumno);
            menuAlumno.Show();
            this.Close();
        }
    }
}
