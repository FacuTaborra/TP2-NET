using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Entities
{
    public class AlumnoInscripcion: BusinessEntity
    {
        private string _Condicion;
        private Persona _Alumno;
        private Curso _Curso;
        private int _Nota;

        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public Persona Alumno
        {
            get { return _Alumno; }
            set { _Alumno = value; }
        }
        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        public Materia MateriaCurso
        {
            get { return Curso.Materia; }
        }

        public Plan PlanCurso
        {
            get { return Curso.Comision.Plan; }
        }
    }
}
