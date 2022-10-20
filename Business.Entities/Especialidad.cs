using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private string _Descripcion;

        public Especialidad()
        {

        }
        public Especialidad(string desc)
        {
            Descripcion = desc;
        }

        public String Descripcion
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
