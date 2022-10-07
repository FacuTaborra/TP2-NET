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
    public class PersonaAdapter: Adapter
    {
        public List<Personas> GetAll()
        {
            List<Personas> personas = new List<Personas>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while(drPersonas.Read())
                {
                    Personas per = new Personas();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Nombre = (string)drPersonas["nombre"];
                    Plan p = new Plan((int)drPersonas["id_plan"]);
                    per.Plan = p;
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Personas.TiposPersonas)drPersonas["tipo_persona"];
                    personas.Add(per);
                }


            }
            catch (Exception Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return personas;
        }

        public Personas GetOne(int id)
        {
            Personas p = new Personas();
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * " +
                                                       "from personas per" +
                                                       "inner join planes pl on pl.id_plan = per.id_plan" +
                                                       "where per.id_persona = @idPer ", sqlConn);
                cmdPersona.Parameters.Add("@idPer", SqlDbType.Int).Value = id;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();
                if(drPersona.Read())
                {
                    p.ID = (int)drPersona["id_persona"];
                    p.Apellido = (string)drPersona["apellido"];
                    p.Nombre = (string)drPersona["nombre"];
                    Plan plan = new Plan();
                    plan.ID = (int)drPersona["id_plan"];
                    plan.Descripcion = (string)drPersona["desc_plan"];
                    p.Plan = plan;
                    p.Legajo = (int)drPersona["legajo"];
                    p.Telefono = (string)drPersona["telefono"];
                    p.Email = (string)drPersona["email"];
                    p.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    p.TipoPersona = (Personas.TiposPersonas)drPersona["tipo_personas"];
                }
            }
            catch (Exception Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return p;
        }


    }
}
