using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_01
{
    class Curso: BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;
        private int _IDComision;
        private int _IDMateria;

        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }
    }
}
