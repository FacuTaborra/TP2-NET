using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        public Data.Database.PlanAdapter _PlanData;

        public PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Plan GetOne(int idPlan)
        {
            return PlanData.GetOne(idPlan);
        }

        public void Delete(int idPlan)
        {
            PlanData.Delete(idPlan);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }

    }
}
