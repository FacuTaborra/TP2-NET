using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCragos _cargo;
        private Curso _Curso;
        private Persona _Docente;


        
        public TiposCragos Cargo
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

        public enum TiposCragos
        {
            Auxiliar,
            Profesor
        }
    }
}
