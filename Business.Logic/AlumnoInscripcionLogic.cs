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
