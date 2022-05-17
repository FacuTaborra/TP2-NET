using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_01
{
    class Especialidad: BusinessEntity
    {
        private string _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
