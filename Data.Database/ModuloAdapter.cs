using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    class ModuloAdapter: Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Modulo m = new Modulo();
                    m.ID = (int)reader["id_modulo"];
                    m.Descripcion = (string)reader["desc_modulo"];
                    modulos.Add(m);
                }

            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                CloseConnection();
            }
            return modulos;
        }

        public Modulo GetOne()
        {
            Modulo m = new Modulo();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("select * from modulos", sqlConn );
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    m.ID = (int)reader["id_modulo"];
                    m.Descripcion = (string)reader["desc_modulo"];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }
            return m;
        }

        public void insert(Modulo m)
        {

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("insert into modulos (desc_modulo) values(@desc)", sqlConn);
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = m.Descripcion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }

        public void update(Modulo m)
        {

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("update modulo set desc_modulo = desc where id_modulo = @id", sqlConn);
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = m.Descripcion;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = m.Descripcion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }
        }





    }
}
