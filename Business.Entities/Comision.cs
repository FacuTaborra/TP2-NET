using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Comision: BusinessEntity
    {
        private int _AnioEspecialidad;
        private Plan _Plan;
        private string _Descripcion;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
