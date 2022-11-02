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
    public partial class InscripcionCurso : MasterAlumno
    {
        public InscripcionCurso(Persona alumno)
        {
            Alumno = alumno;
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvInscripciones.DataSource = cl.GetCursosDisponibles(DateTime.Now.Year, Alumno.Plan.ID);
        }

        private void dgvInscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //falta validad que para que no este inscripto 2 veces
                if(Validaciones.EstaInscripto())
                {
                    if(Validaciones.HayCupo()){
                        AlumnoInscripcion alumnoInscripcio = new AlumnoInscripcion();
                        alumnoInscripcio.Alumno = Alumno;
                        Curso curso = new Curso();
                        curso.ID = int.Parse(this.dgvInscripciones.CurrentRow.Cells[0].Value.ToString());
                        alumnoInscripcio.Curso = curso;
                        AlumnoInscripcionLogic ai = new AlumnoInscripcionLogic();
                        ai.Insert(alumnoInscripcio);

                        CursoLogic cl = new CursoLogic();
                        cl.RestoCupo(curso);

                        Notificar("Inscripto", "Se relizo la inscripcion al curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Notificar("Error", "No hay cupo disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Notificar("Error", "Ya se inscribio en el curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuAlumno mn = new MenuAlumno(Alumno);
            mn.Show();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void InscripcionCurso_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
