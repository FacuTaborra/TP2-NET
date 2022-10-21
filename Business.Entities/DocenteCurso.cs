using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        /*private TiposCragos _cargo;*/
        private int _IDCurso;
        private int _IDDocente;
        private int _cargo;

        /*
        public TiposCragos Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        } 
        */

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }


        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }


        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }
        public enum TiposCragos
        {
            Auxiliar,
            Profesor
        }
    }
}
