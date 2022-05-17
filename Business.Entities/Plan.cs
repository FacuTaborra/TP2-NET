using System;

namespace TP2_01
{
	public class Plan: BusinessEntity
	{
		private string _Descripcion;
		private int _IDEspecialidad;

		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public int IDPlan
		{
			get { return _IDPlan; }
			set { _IDPlan = value; }
		}
	}
}
