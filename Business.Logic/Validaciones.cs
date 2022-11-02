using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Data.Database;
using Business.Entities;


namespace Business.Logic
{
    public class Validaciones
    {
        public static bool ValidaNota(int nota)
        {
            if(nota<=10 && nota>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ValidaProfesores(int id_DocenteTitular, int id_DocenteAuxiliar)
        {
            if(id_DocenteTitular != id_DocenteAuxiliar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool emailValido(string strMailAddress)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }


        public static bool ValidarHorasSemanales(int cant_hs)
        {
            if (cant_hs>=0 && cant_hs <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ValidarHorasTotales(int cant_hs)
        {
            if (cant_hs >= 0 && cant_hs <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EstaInscripto()
        {
            return true; // falta codear
        }

        public static bool HayCupo()
        {
            return true; // falta codear
        }


    }
}
