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
    public class AlumnoInscripcionAdapter:Adapter
    {

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> lista = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                string consulta = "Select * from alunos_inscripciones";
                SqlCommand cmdGetAll = new SqlCommand(consulta, sqlConn);
                SqlDataReader drGetAll = cmdGetAll.ExecuteReader();
                while (drGetAll.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)drGetAll["id_inscripcion"];
                    int idAlu = (int)drGetAll["id_alumno"];
                    int idCurso = (int)drGetAll["id_curso"];
                    ai.Condicion = (string)drGetAll["condicion"];
                    ai.Nota = (int)drGetAll["nota"];
                    PersonaAdapter pa = new PersonaAdapter();
                    ai.Alumno = pa.GetOne(idAlu);
                    CursoAdapter ca = new CursoAdapter();
                    ai.Curso = ca.GetOne(idCurso);

                    lista.Add(ai);
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
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripciones", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return lista;
        }


        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                string consulta = "select * from alumnos_inscripciones where id_inscripcion=@id";
                SqlCommand cmdGetOne = new SqlCommand(consulta, sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drGetOne = cmdGetOne.ExecuteReader();
                if (drGetOne.Read())
                {
                    ai.ID = (int)drGetOne["id_inscripcion"];
                    int idAlu = (int)drGetOne["id_alumno"];
                    int idCurso = (int)drGetOne["id_curso"];
                    ai.Condicion = (string)drGetOne["condicion"];
                    ai.Nota = (int)drGetOne["nota"];
                    PersonaAdapter pa = new PersonaAdapter();
                    ai.Alumno = pa.GetOne(idAlu);
                    CursoAdapter ca = new CursoAdapter();
                    ai.Curso = ca.GetOne(idCurso);
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
                Exception ExcepcionManejada = new Exception("Error al recuperar la inscripcion", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ai;
        }


        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                string consulta = "select * from alumnos_inscripciones where id_inscripcion=@id";
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


        public void Insert(AlumnoInscripcion ai)
        {
            try
            {
                this.OpenConnection();
                string consulta = "insert into alumnos_inscripciones (id_alumno, id_curso, condicion, nota)" +
                    "values(@alu, @curso, @con, @nota)";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("alu", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdInsert.Parameters.Add("curso", SqlDbType.Int).Value = ai.Curso.ID;
                cmdInsert.Parameters.Add("con", SqlDbType.VarChar, 50).Value = ai.Condicion;
                cmdInsert.Parameters.Add("nota", SqlDbType.Int).Value = ai.Nota;
                ai.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al agregar inscripcion", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Update(AlumnoInscripcion ai)
        {
            try
            {
                this.OpenConnection();
                string consulta = "update alumnos_inscripciones set id_alumno=@alu, id_curso=@curso, condicion=@con,nota=@nota where id_inscripcion=@id)";
                SqlCommand cmdUpdate = new SqlCommand(consulta, sqlConn);
                cmdUpdate.Parameters.Add("id", SqlDbType.Int).Value = ai.ID;
                cmdUpdate.Parameters.Add("alu", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdUpdate.Parameters.Add("curso", SqlDbType.Int).Value = ai.Curso.ID;
                cmdUpdate.Parameters.Add("con", SqlDbType.VarChar, 50).Value = ai.Condicion;
                cmdUpdate.Parameters.Add("nota", SqlDbType.Int).Value = ai.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar los datos de la isncripcion", Ex2);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(AlumnoInscripcion ai)
        {
            if (ai.State == BusinessEntity.States.New)
            {
                this.Insert(ai);
            }
            else if (ai.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ai.ID);
            }
            else if (ai.State == BusinessEntity.States.Modified)
            {
                this.Update(ai);
            }
            ai.State = BusinessEntity.States.Unmodified;
        }


        


    }
}
