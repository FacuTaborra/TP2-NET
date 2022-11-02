using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {

        public CursoAdapter _CursoData;

        public CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public void RestoCupo(Curso curso)
        {
            curso = GetOne(curso.ID);
            curso.Cupo = curso.Cupo - 1;
            _CursoData.Update(curso);
        }

        public List<Curso> GetCursosDisponibles(int año, int idPlan)
        {
            return _CursoData.GetCursosDisponibles(año, idPlan);
        }

        public List<Curso> GetAll(int año)
        {
            return CursoData.GetAll(año);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public Curso Save(Curso curso)
        {
            return CursoData.Save(curso);
        }

        public List<int> GetAños()
        {
            return CursoData.GetAños();
        }

    }
}
