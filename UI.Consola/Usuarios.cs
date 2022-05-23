using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        public Business.Logic.UsuarioLogic _UsuarioNegocio;
        
        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public void Menu()
        {
            int op = 0;
            Console.WriteLine("1-Listado");
            Console.WriteLine("2- Consulta");
            Console.WriteLine("3- Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar");
            Console.WriteLine("6- Salir");
            while (op <= 0 && op > 6)
            {
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 1:
                    ListadoGeneral();
                    break;
                case 2:
                    Consulta();
                    break;
                case 3:
                    Agregar();
                    break;
                case 4:
                    Modificar();
                    break;
                case 5:
                    Eliminar();
                    break;
                case 6:
                    Salir();
                    break;
            }
        }

        public void ListadoGeneral()
        {
            List<Usuario> lista;
            lista= Business.Logic.UsuarioLogic GetAll();    
        }

        public void Consulta()
        {

        }

        public void Agregar()
        {

        }

        public void Modificar()
        {

        }

        public void Eliminar()
        {

        }
        
        public void Salir()
        {

        }

    }


}