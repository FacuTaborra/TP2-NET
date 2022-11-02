using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic:BusinessLogic
    {
        private AlumnoInscripcionAdapter _AIData;

        public AlumnoInscripcionAdapter AIData
        {
            get { return _AIData; }
            set { _AIData = value; }
        }

        public AlumnoInscripcionLogic()
        {
            _AIData = new AlumnoInscripcionAdapter();
        }

        public void CargaNota(int id_inscripcion, int nota)
        {
            AlumnoInscripcion alumnoInscripcion = this.GetOne(id_inscripcion);
            alumnoInscripcion.Nota = nota;
            if (nota <= 3)
            {
                alumnoInscripcion.Condicion = "Desaprobado";
            } else if (nota <= 5 && nota >= 4)
            {
                alumnoInscripcion.Condicion = "Regular";
            } else if (nota >= 6)
            {
                alumnoInscripcion.Condicion = "Aprobado";
            }
            this.Update(alumnoInscripcion);
        }

        public List<AlumnoInscripcion> GetAlumnosCurso( int IdCurso)
        {
            return AIData.GetAlumnosCurso(IdCurso);
        }

        public List<AlumnoInscripcion> GetEstadoAcademico(int legajo)
        {
            return _AIData.GetEstadoAcademico(legajo);
        }


        public AlumnoInscripcion GetOne(int id)
        {
            return AIData.GetOne(id);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AIData.GetAll();
        }

        public void Insert(AlumnoInscripcion ai)
        {
            AIData.Insert(ai);
        }

        public void Update(AlumnoInscripcion ai)
        {
            AIData.Update(ai);
        }

        public void Delete(int id)
        {
            AIData.Delete(id);
        }

        public void Save(AlumnoInscripcion ai)
        {
            AIData.Save(ai);
        }

    }
}
