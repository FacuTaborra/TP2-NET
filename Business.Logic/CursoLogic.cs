﻿using System;
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

        public List<Curso> GetAll(int año)
        {
            return CursoData.GetAll(año);
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

        public List<int> GetAños()
        {
            return CursoData.GetAños();
        }

    }
}