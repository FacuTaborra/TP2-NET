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

        public List<Curso> GetCursosDisponibles(int anio, Persona Alumno)
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(" select cur.*, com.*, pl.*, esp.*, mat.* " +
                                                      " from cursos cur" +
                                                      " inner join comisiones com" +
                                                      "  on com.id_comision = cur.id_comision" +
                                                      " inner join planes pl" +
                                                      "     on pl.id_plan = com.id_plan" +
                                                      " inner join especialidades esp" +
                                                      "     on esp.id_especialidad = pl.id_especialidad" +
                                                      " inner join materias mat" +
                                                      "     on mat.id_materia = cur.id_materia" +
                                                      " left join alumnos_inscripciones ai" +
                                                      "     on ai.id_curso = cur.id_curso " +
                                                      "     and ai.id_alumno != @id_alumno" +
                                                      " where pl.id_plan = @idplan and cur.anio_calendario = @anio" +
                                                      "         and cur.id_curso not in (select ai.id_curso" +
                                                      "                                  from alumnos_inscripciones ai" +
                                                      "                                  where ai.id_alumno = @id_alumno) ", sqlConn);

                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmdCursos.Parameters.Add("@idplan", SqlDbType.Int).Value = Alumno.Plan.ID;
                cmdCursos.Parameters.Add("@id_alumno", SqlDbType.Int).Value = Alumno.ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursos["id_curso"];
                    c.Cupo = (int)drCursos["cupo"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drCursos["id_especialidad"];
                    esp.Descripcion = (string)drCursos["desc_especialidad"];
                 
                    Plan p = new Plan();
                    p.Descripcion = (string)drCursos["desc_plan"];
                    p.ID= (int)drCursos["id_plan"];
                    p.Especialidad = esp;

                    Comision com = new Comision();
                    com.ID = (int)drCursos["id_comision"];
                    com.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    com.Descripcion = (string)drCursos["desc_comision"];
                    com.Plan = p;

                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    mat.HSTotales = (int)drCursos["hs_totales"];
                    mat.HSSemanales = (int)drCursos["hs_semanales"];
                    mat.Plan = p;

                    c.Comision = com;
                    c.Materia = mat;

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


        public List<Curso> GetAll(int año)
        {
            List<Curso> listaCursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                string consulta = " select * " +
                                  " from cursos cur" +
                                  " inner join materias mat" +
                                  "     on mat.id_materia = cur.id_materia" +
                                  " inner join comisiones com" +
                                  "     on com.id_comision = cur.id_comision" +
                                  " inner join planes pl" +
                                  "     on pl.id_plan = com.id_plan" +
                                  " inner join especialidades esp" +
                                  "     on esp.id_especialidad = pl.id_especialidad" +
                                  " where anio_calendario = @anio";
                SqlCommand cmdCursos = new SqlCommand(consulta, sqlConn);
                cmdCursos.Parameters.Add("@anio",SqlDbType.Int ).Value = año;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursos["id_curso"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    c.Cupo = (int)drCursos["cupo"];
                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    c.Materia = mat;
                    Comision com = new Comision();
                    com.ID = (int)drCursos["id_comision"];
                    com.Descripcion = (string)drCursos["desc_comision"];
                    Especialidad esp = new Especialidad();
                    esp.Descripcion = (string)drCursos["desc_especialidad"];

                    Plan p = new Plan((string)drCursos["desc_plan"]);
                    p.Especialidad = esp;
                    com.Plan = p;

                    c.Comision = com;

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
                string consulta = " select * " +
                                  " from cursos c " +
                                  " inner join comisiones com " +
                                  "     on com.id_comision = c.id_comision " +
                                  "inner join planes pl " +
                                  "     on pl.id_plan = com.id_plan " +
                                  "inner join especialidades esp " +
                                  "     on esp.id_especialidad=pl.id_especialidad " +
                                  "inner join materias mat " +
                                  "     on c.id_materia = mat.id_materia "+
                                  " where id_curso=@id";
                SqlCommand cmdCurso = new SqlCommand(consulta, sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                if (drCurso.Read())
                {
                    c.ID = (int)drCurso["id_curso"];
                    c.AnioCalendario = (int)drCurso["anio_calendario"];
                    c.Cupo = (int)drCurso["cupo"];
                    Materia mat = new Materia();
                    mat.ID = (int)drCurso["id_materia"];
                    mat.Descripcion = (string)drCurso["desc_materia"];
                    c.Materia = mat;
                    Comision com = new Comision();
                    com.ID = (int)drCurso["id_comision"];
                    com.Descripcion = (string)drCurso["desc_comision"];
                    com.AnioEspecialidad = (int)drCurso["anio_especialidad"];
                    Especialidad esp = new Especialidad();
                    esp.Descripcion = (string)drCurso["desc_especialidad"];
                    Plan p = new Plan((string)drCurso["desc_plan"]);
                    p.Especialidad = esp;
                    com.Plan = p;
                    c.Comision = com;
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


        public Curso Insert(Curso c)
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
            return c;
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

        public Curso Save(Curso c)
        {
            if (c.State == BusinessEntity.States.New)
            {
                c = this.Insert(c);
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
            return c;
        }

        public List<int> GetAños()
        {
            List<int> años = new List<int>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdanio = new SqlCommand(" select distinct anio_calendario from cursos c ", sqlConn);
                SqlDataReader reader = cmdanio.ExecuteReader();
                while(reader.Read())
                {
                    años.Add((int)reader["anio_calendario"]);
                }
            }
            catch (SqlException Ex1)
            {
                Exception ExManejada = new Exception("Error con la base de datos", Ex1);
                throw ExManejada;
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al actualizar datos del curso", ex);
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return años;
        }

    }
}
