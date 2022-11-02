using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic: BusinessLogic
    {
        public ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAllPlan(int idplan)
        {
            return ComisionData.GetAllPlan(idplan);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public Comision GetOne(int idComi)
        {
            return ComisionData.GetOne(idComi);
        }

        public void Delete(int idComi)
        {
            ComisionData.Delete(idComi);
        }

        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }

    }
}
