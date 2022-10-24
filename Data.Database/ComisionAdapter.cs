using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class ComisionAdapter: Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                string consulta = " Select * " +
                                  " from comisiones c" +
                                  " inner join planes pl" +
                                  "   on pl.id_plan = c.id_plan" +
                                  " inner join especialidades esp" +
                                  "   on esp.id_especialidad = pl.id_especialidad" ; 
                SqlCommand cmdComisiones = new SqlCommand(consulta, sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    Plan p = new Plan((int)drComisiones["id_plan"]);
                    p.Descripcion = (string)drComisiones["desc_plan"];

                    Especialidad esp = new Especialidad((int)drComisiones["id_especialidad"]);
                    esp.Descripcion = (string)drComisiones["desc_especialidad"];
                    p.Especialidad = esp;

                    com.Plan = p;
                    comisiones.Add(com);
                }
            }
            catch (SqlException sqlEx)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", sqlEx);
                throw ExcepcionManejada;
            }
            catch(Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        
        public Comision GetOne(int id)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                string consulta = "select * from comisiones where id_comision=@id";
                SqlCommand cmdComision = new SqlCommand(consulta, sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drComision = cmdComision.ExecuteReader();
                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    PlanAdapter pa = new PlanAdapter();
                    int idPlan = (int)drComision["id_plan"];
                    com.Plan = pa.GetOne(idPlan);
                }
                drComision.Close();
            }
            catch (SqlException sqlEx)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", sqlEx);
                throw ExcepcionManejada;
            }
            catch(Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la comision", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                string consulta = "delete comisiones where id_comision=@id";
                SqlCommand cmdDelete = new SqlCommand(consulta, sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar comision", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }



        public void Insert(Comision com)
        {
            try
            {
                this.OpenConnection();
                String consulta = "Insert into comisiones (desc_comision, anio_especialidad, id_plan)" + "values (@desc, @anio_esp, @plan)" + "select @@identity";
                SqlCommand cmdSave = new SqlCommand(consulta, sqlConn);
                cmdSave.Parameters.Add("desc", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("anio_esp", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("plan", SqlDbType.Int).Value = com.Plan.ID;
                com.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar comision", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Comision com)
        {
            try
            {
                this.OpenConnection();
                string consulta = " update comisiones set desc_comision=@desc, anio_especialidad=@anio, id_plan=@plan where id_comision=@id";
                SqlCommand cmdUpdate = new SqlCommand(consulta, sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdUpdate.Parameters.Add("@plan", SqlDbType.Int).Value = com.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar los datos de la comision", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision com)
        {
            if(com.State== BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }

    }
}
