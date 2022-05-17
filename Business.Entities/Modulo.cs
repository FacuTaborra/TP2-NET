using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_01
{
    public class Modulo:BusinessEntity
    {
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
