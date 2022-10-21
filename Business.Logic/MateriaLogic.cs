using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public Data.Database.MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public List<Materia> GetAllWhithPlan(int id_plan)
        {
            return MateriaData.GetAllWhithPlan(id_plan);
        }


        public Materia GetOne(int idMateria)
        {
            return MateriaData.GetOne(idMateria);
        }


        public void Delete(int idMateria)
        {
            MateriaData.Delete(idMateria);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
    }
}
