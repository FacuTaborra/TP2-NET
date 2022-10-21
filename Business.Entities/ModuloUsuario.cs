using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class ModuloUsuario: BusinessEntity
    {
        private Usuario _Usuario;
        private Modulo _Modulo;
        private bool _PermiteAlta;
        private bool _PermiteBaja;
        private bool _PermiteModificacion;
        private bool _PermiteConsulta;

        public Usuario Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public Modulo Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }
        public bool PermiteAlta
        {
            get { return _PermiteAlta; }
            set { _PermiteAlta = value; }
        }
        public bool PermiteBaja
        {
            get { return _PermiteBaja; }
            set { _PermiteBaja = value; }
        }
        public bool PermiteModificacion
        {
            get { return _PermiteModificacion; }
            set { _PermiteModificacion = value; }
        }
        public bool PermiteConsulta
        {
            get { return _PermiteConsulta; }
            set { _PermiteConsulta = value; }
        }
    }
}
