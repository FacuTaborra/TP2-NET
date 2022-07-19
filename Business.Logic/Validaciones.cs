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

    }
}
