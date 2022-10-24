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
    public class PersonaAdapter : Adapter
    {

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas ", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                    Plan p = new Plan((int)drPersonas["id_plan"]);
                    p.Descripcion = (string)drPersonas["desc_plan"];
                    Especialidad esp = new Especialidad((int)drPersonas["id_especialidad"]);
                    esp.Descripcion = (string)drPersonas["desc_especialidad"];
                    per.Plan = p;
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


        public List<Persona> GetAll(Persona.TiposPersonas tipo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * " +
                                                        " from personas as per " +
                                                        " inner join planes as pl " +
                                                        "   on per.id_plan = pl.id_plan " +
                                                        " where per.tipo_persona = @tipo ", sqlConn);
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)tipo ;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                    Plan p = new Plan((int)drPersonas["id_plan"]);
                    p.Descripcion = (string)drPersonas["desc_plan"];
                    Especialidad esp = new Especialidad((int)drPersonas["id_especialidad"]);
                    esp.Descripcion = (string)drPersonas["desc_especialidad"];
                    per.Plan = p;
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

        public Persona GetOne(int id)
        {
            Persona p = new Persona();
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas where id_persona = @idPer ", sqlConn);
                cmdPersona.Parameters.Add("@idPer", SqlDbType.Int).Value = id;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();
                if (drPersona.Read())
                {
                    p.ID = (int)drPersona["id_persona"];
                    p.Apellido = (string)drPersona["apellido"];
                    p.Nombre = (string)drPersona["nombre"];
                    p.Direccion = (string)drPersona["direccion"];
                    Plan plan = new Plan();
                    plan.ID = (int)drPersona["id_plan"];
                    p.Plan = plan;
                    p.Legajo = (int)drPersona["legajo"];
                    p.Telefono = (string)drPersona["telefono"];
                    p.Email = (string)drPersona["email"];
                    p.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    p.TipoPersona = (Persona.TiposPersonas)drPersona["tipo_persona"];

                }
            }
            /*catch (Exception Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }*/
            finally
            {
                CloseConnection();
            }
            return p;
        }

        protected void Insert(Persona per)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)" +
                    "values(@nom, @ape, @dire, @email, @tel, @fena, @leg, @tp, @idp)" + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdSave.Parameters.Add("@ape", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdSave.Parameters.Add("@dire", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdSave.Parameters.Add("@tel", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdSave.Parameters.Add("@fena", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdSave.Parameters.Add("@leg", SqlDbType.Int).Value = per.Legajo;
                cmdSave.Parameters.Add("@tp", SqlDbType.Int).Value = (int)per.TipoPersona;
                cmdSave.Parameters.Add("@idp", SqlDbType.Int).Value = per.Plan.ID; //corregir
                per.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            /*catch (SqlException Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar persona", Ex2);
                throw ExcepcionManejada;
            }*/
            finally
            {
                this.CloseConnection();
            }
           
        }

        protected void Update(Persona per)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("update personas set nombre = @nom, apellido = @ape, direccion = @dire, " +
                    " email = @em, telefono = @tel, fecha_nac = @fena, legajo = @leg, tipo_persona = @tp, id_plan = @plan " +
                    "where id_persona = @id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = per.ID;
                cmdUpdate.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdUpdate.Parameters.Add("@ape", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdUpdate.Parameters.Add("@dire", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdUpdate.Parameters.Add("@em", SqlDbType.VarChar, 50).Value = per.Email;
                cmdUpdate.Parameters.Add("@tel", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdUpdate.Parameters.Add("@fena", SqlDbType.DateTime, 50).Value = per.FechaNacimiento;
                cmdUpdate.Parameters.Add("@leg", SqlDbType.Int).Value = per.Legajo;
                cmdUpdate.Parameters.Add("@tp", SqlDbType.Int).Value = per.TipoPersona;
                cmdUpdate.Parameters.Add("@plan", SqlDbType.Int).Value = per.Plan.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            /*catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al editar persona", Ex2);
                throw ExcepcionManejada;
            }*/
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar persona", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        
        public void Save(Persona per)
        {
            if(per.State == BusinessEntity.States.New)
            {
                this.Insert(per);
            }
            else if(per.State == BusinessEntity.States.Modified)
            {
                this.Update(per);
            }
            else if (per.State == BusinessEntity.States.Deleted)
            {
                this.Delete(per.ID);
            }
            per.State = BusinessEntity.States.Unmodified;
        }

    }
}
