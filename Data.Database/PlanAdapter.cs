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
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    Especialidad e = new Especialidad();
                    e.ID = (int)drPlanes["id_especialidad"];
                    plan.Especialidad = e;
                    planes.Add(plan);
                }
            }catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch(Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de planes", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }


        public Plan GetOne(int id)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drPlan = cmdPlanes.ExecuteReader();
                if (drPlan.Read())
                {
                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    Especialidad e = new Especialidad();
                    e.ID = (int)drPlan["id_especialidad"];
                    plan.Especialidad = e;
                }

                drPlan.Close();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return plan;
        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar plan", Ex2);
                throw ExcepcionManejada; // falta cartel de cascada
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan, id_especialidad) " 
                    + "values(@descrip, @id_esp) ", sqlConn);
                cmdSave.Parameters.Add("@descrip", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("id_esp", SqlDbType.Int).Value = plan.Especialidad.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar plan", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Update planes set desc_plan=@desc, id_especialidad=@id_esp where id_plan=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("id_esp", SqlDbType.Int).Value = plan.Especialidad.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar los datos del plan", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }

    }
}
