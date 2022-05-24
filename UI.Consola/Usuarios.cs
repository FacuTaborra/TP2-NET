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
            while (op >= 0 && op < 6)
            {
                try {
                    Console.Clear();
                    Console.WriteLine("1- Listado");
                    Console.WriteLine("2- Consulta");
                    Console.WriteLine("3- Agregar");
                    Console.WriteLine("4- Modificar");
                    Console.WriteLine("5- Eliminar");
                    Console.WriteLine("6- Salir");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            ListadoGeneral();
                            break;
                        case 2:
                            Consultar();
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
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un numero del 1 al 6");
                    Console.ReadKey();
                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            try
            {
                foreach (Usuario usr in UsuarioNegocio.GetAll())
                {
                    MostrarDatos(usr);
                }
            }
            catch(NullReferenceException e)//No lo toma
            {
                Console.WriteLine("No hay usuarios cargados");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public void Consultar()
        {
            try { 
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.Clear();
                Console.WriteLine("El ID Ingresada deber ser un numero entero");
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("No puede dejar el campo vacio");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habitacion de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habitacion de Usuario (1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("El ID Ingresada deber ser un numero entero");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("No puede dejar el campo vacio");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("El ID Ingresada deber ser un numero entero");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("No puede dejar el campo vacio");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: (0)", usr.ID);
            Console.WriteLine("\t\tNombre:{0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

    }


}