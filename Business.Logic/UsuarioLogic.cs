using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        public Data.Database.UsuarioAdapter _UsuarioData;

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int idUsuario)
        {
            return UsuarioData.GetOne(idUsuario);
        }

        public void Delete(int idUsuario)
        {
            UsuarioData.Delete(idUsuario);        
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
