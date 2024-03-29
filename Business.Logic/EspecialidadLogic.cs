﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public Data.Database.EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }
        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int idEspecialidad)
        {
            return EspecialidadData.GetOne(idEspecialidad);
        }

        public void Delete(int idEspecialidad)
        {
            EspecialidadData.Delete(idEspecialidad);
        }
     

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }

        public bool ValidarIDEspecialidad(int id)
        {
            Especialidad esp = new Especialidad();
            esp = EspecialidadData.GetOne(id);
            if (esp.ID == id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
