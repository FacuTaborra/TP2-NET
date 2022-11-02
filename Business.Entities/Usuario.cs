using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Usuario: BusinessEntity
    {
        private string _NombreUsuario;
        private string _Clave;
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private bool _Habilitado;
        private Persona _Persona;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        public Persona.TiposPersonas TipoPersona
        {
            get { return Persona.TipoPersona; }
        }
    }
}
