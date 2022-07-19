using System;

namespace Business.Entities
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

		public int IDEspecialidad
		{
			get { return _IDEspecialidad; }
			set { _IDEspecialidad = value; }
		}
	}
}
