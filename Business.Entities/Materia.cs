using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
	public class Materia: BusinessEntity
	{

		private string _Descripcion;
		private int _HSSemanales;
		private int _HSTotales;
		private Plan _Plan;

		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public int HSSemanales
		{
			get { return _HSSemanales; }
			set { _HSSemanales = value; }
		}

		public int HSTotales
		{
			get { return _HSTotales; }
			set { _HSTotales = value; }
		}

		public Plan Plan
		{
			get { return _Plan; }
			set { _Plan = value; }
		}

		public override string ToString()
		{
			return Descripcion;
		}
	}
}
