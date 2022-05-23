using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    class Comision: BusinessEntity
    {
        private int _AnioEspecialidad;
        private int _IDPlan;
        private string _Descripcion;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
