using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        public PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Persona GetOne(int idPersona)
        {
            return PersonaData.GetOne(idPersona);
        }

        public void Delete(int id)
        {
            Persona per = new Persona(id, BusinessEntity.States.Deleted);
            Save(per);
        }

        public void Save(Persona per)
        {
            PersonaData.Save(per);
        }
    }
}
