using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Especialidad: BusinessEntity
    {
        private string _Descripcion;

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
