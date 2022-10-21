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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> listaCursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                string consulta = "select * from cursos";
                SqlCommand cmdCursos = new SqlCommand(consulta, sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursos["id_curso"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    c.Cupo = (int)drCursos["cupo"];
                    int idMat = (int)drCursos["id_materia"];
                    MateriaAdapter ma = new MateriaAdapter();
                    c.Materia = ma.GetOne(idMat);
                    int idComi = (int)drCursos["id_comision"];
                    ComisionAdapter ca = new ComisionAdapter();
                    c.Comision = ca.GetOne(idComi);

                    listaCursos.Add(c);
                }
            }
            catch (SqlException ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos");
                throw ExcepcionManejada;
            }
            catch (Exception ex2)
            {
                Exception ExcepcionManejada2 = new Exception("Error al recuperar la lista de cursos");
                throw ExcepcionManejada2;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaCursos;
        }

        public Curso GetOne(int id)
        {
            Curso c = new Curso();
            try
            {
                this.OpenConnection();
                string consulta = "select * from cursos where id_curso=@id";
                SqlCommand cmdCurso = new SqlCommand(consulta, sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                if (drCurso.Read())
                {
                    c.ID = (int)drCurso["id_curso"];
                    c.AnioCalendario = (int)drCurso["anio_calendario"];
                    c.Cupo = (int)drCurso["cupo"];
                    int idMateria = (int)drCurso["id_materia"];
                    MateriaAdapter ma = new MateriaAdapter();
                    c.Materia = ma.GetOne(idMateria);
                    int idComision = (int)drCurso["id_comision"];
                    ComisionAdapter ca = new ComisionAdapter();
                    c.Comision = ca.GetOne(idComision);
                }
                drCurso.Close();
            }
            catch (SqlException sqlEx)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", sqlEx);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el curso", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return c;
        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                string consulta = "delete from cursos where id_curso=@id";
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
                Exception ExcepcionManejada = new Exception("Error al borrar curso", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Insert(Curso c)
        {
            try
            {
                this.OpenConnection();
                string consulta = "Insert into cursos (anio_calendario, cupo, id_comision, id_materia) values (@anio, @cupo, @comision, @materia) select @@identity";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = c.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = c.Cupo;
                cmdInsert.Parameters.Add("@comision", SqlDbType.Int).Value = c.Comision.ID;
                cmdInsert.Parameters.Add("@materia", SqlDbType.Int).Value = c.Materia.ID;
                c.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (SqlException Ex)
            {
                Exception ExManejada = new Exception("Error con la base de datos", Ex);
                throw ExManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Error al insertar curso", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Update(Curso c)
        {
            try
            {
                this.OpenConnection();
                string consulta = "update cursos set anio_calendario=@anio, cupo=@cupo, id_comision=@comision, id_materia=@materia where id_curso=@id";
                SqlCommand cmdUpdate = new SqlCommand(consulta, sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = c.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = c.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = c.Cupo;
                cmdUpdate.Parameters.Add("@comision", SqlDbType.Int).Value = c.Comision.ID;
                cmdUpdate.Parameters.Add("@materia", SqlDbType.Int).Value = c.Materia.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExManejada = new Exception("Error con la base de datos", Ex1);
                throw ExManejada;
            }
            catch(Exception ex)
            {
                Exception exManejada = new Exception("Error al actualizar datos del curso", ex);
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso c)
        {
            if (c.State == BusinessEntity.States.New)
            {
                this.Insert(c);
            }
            else if (c.State == BusinessEntity.States.Modified)
            {
                this.Update(c);
            }
            else if (c.State == BusinessEntity.States.Deleted)
            {
                this.Delete(c.ID);
            }

            c.State = BusinessEntity.States.Unmodified;
        }

    }
}
