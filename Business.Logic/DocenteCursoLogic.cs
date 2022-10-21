using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _DCData;

        public DocenteCursoAdapter DCData
        {
            get { return _DCData; }
            set { _DCData = value; }
        }



        public DocenteCursoLogic()
        {
            DCData = new DocenteCursoAdapter();
        }


        public List<DocenteCurso> GetAll()
        {
            return DCData.GetAll();
        }

        public DocenteCurso GetOne(int id)
        {
            return DCData.GetOne(id);
        }

        public void Update(DocenteCurso dc)
        {
            DCData.Update(dc);
        }

        public void Delete(int id)
        {
            DCData.Delete(id);
        }

        public void Insert(DocenteCurso dc)
        {
            DCData.Insert(dc);
        }

        public void Save(DocenteCurso dc)
        {
            DCData.Save(dc);
        }


    }
}
