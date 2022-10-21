using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> lista = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                string consulta = "select * from docentes_cursos";
                SqlCommand cmdGetAll = new SqlCommand(consulta, sqlConn);
                SqlDataReader drGetAll = cmdGetAll.ExecuteReader();
                while (drGetAll.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drGetAll["id_dictado"];
                    dc.IDCurso = (int)drGetAll["id_curso"];
                    dc.IDDocente = (int)drGetAll["id_docente"];
                    dc.Cargo = (int)drGetAll["cargo"];

                    lista.Add(dc);
                }
                drGetAll.Close();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar docentes_cursos", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }


        public DocenteCurso GetOne(int id)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            { 
                this.OpenConnection();
                string consulta = "select * from docentes_cursos where id_dictado=@id";
                SqlCommand cmdGetOne = new SqlCommand(consulta, sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drGetOne = cmdGetOne.ExecuteReader();
                if (drGetOne.Read())
                {
                    dc.ID = (int)drGetOne["id_dictado"];
                    dc.IDCurso = (int)drGetOne["id_curso"];
                    dc.IDDocente = (int)drGetOne["id_docente"];
                    dc.Cargo = (int)drGetOne["cargo"];
                }
                drGetOne.Close();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar dictado", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }


        public void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                string consulta = "insert into docentes_cursos (id_docente, id_curso, cargo) values(@id_docente, @id_curso, @cargo)";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdInsert.Parameters.Add("id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdInsert.Parameters.Add("cargo", SqlDbType.Int).Value = dc.Cargo;
                dc.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar dictado", Ex2);
                throw ExcepcionManejada;
            }
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
                string consulta = "delete from docentes_cursos where id_dictado=@id";
                SqlCommand cmdDelete = new SqlCommand(consulta, sqlConn);
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
                Exception ExcepcionManejada = new Exception("Error al borrar dictado", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                string consulta = "update docentes_cursos set id_docente=@id_docente, id_curso=@id_curso, cargo=@cargo where id_dictado=@id";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("id", SqlDbType.Int).Value = dc.ID;
                cmdInsert.Parameters.Add("id_docente", SqlDbType.Int).Value = dc.IDDocente;
                cmdInsert.Parameters.Add("id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdInsert.Parameters.Add("cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdInsert.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar los datos del dictado", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}
