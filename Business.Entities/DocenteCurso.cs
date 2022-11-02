using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargos _cargo;
        private Curso _Curso;
        private Persona _Docente;
        
        public TiposCargos Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        } 

        public Persona Docente
        {
            get { return _Docente; }
            set { _Docente = value; }
        }

        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }

        public enum TiposCargos
        {
            Auxiliar,
            Profesor
        }

        // devoluciones para mapear datos en grilla de CursosProfesor

        public String MateriaCurso
        {
            get { return Curso.Materia.Descripcion; }
        }

        public int AñoCalendarioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public String PlanCurso
        {
            get { return Curso.Comision.Plan.DescripcionYEspecialidad; }
        }

        public String ComisionCurso
        {
            get { return Curso.Comision.Descripcion; }
        }

        public int IDCurso
        {
            get{ return Curso.ID; }
        }

    }
}
