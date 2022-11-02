using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Persona: BusinessEntity
    {
        private string _Apellido;
        private string _Nombre;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private Plan _Plan;
        private int _Legajo;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public enum TiposPersonas
        {
            Administrador,
            Alumno,
            Profesor
        }

        public Persona()
        {

        }
        public Persona(int id)
        {
            ID = id;
        }

        public Persona(int id, BusinessEntity.States state )
        {
            ID = id;
            State = state;
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        } 
        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public TiposPersonas TipoPersona
        {
             get { return _TipoPersona; }
             set { _TipoPersona = value; }
        }

        public String NombreYApellido
        {
            get { return Nombre + " " + Apellido;}
        }

    }
}
