using System;

namespace Business.Entities
{
	public class Plan: BusinessEntity
	{
		private string _Descripcion;
		private Especialidad _Especialidad;

		public Plan()
        {

        }

		public Plan(string desc)
		{
			Descripcion = desc;
		}

		public Plan(int idPlan)
		{
			ID = idPlan;
		}

		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public Especialidad Especialidad
		{
			get { return _Especialidad; }
			set { _Especialidad = value; }
		}

		public String DescripcionYEspecialidad
        {
			
            get {
				var especialidad = Especialidad;
				return Descripcion + " " + especialidad.Descripcion; 
			}
        }

		public override string ToString()
		{
			return DescripcionYEspecialidad;
		}
	}
}
