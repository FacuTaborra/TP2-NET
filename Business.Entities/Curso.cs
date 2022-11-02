using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Curso: BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private Comision _Comision;
        private Materia _Materia;

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

        public Comision Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }
        public Materia Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        public string PlanComision
        {
            get { return Comision.Plan.Descripcion + " " + Comision.Plan.Especialidad.Descripcion;}
        }

    }
}
