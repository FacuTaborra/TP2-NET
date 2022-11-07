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

        public List<AlumnoInscripcion> GetAlumnosCurso(int IdCurso)
        {
            List<AlumnoInscripcion> AlumnosCurso = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosCurso = new SqlCommand(" select ai.id_inscripcion, ai.condicion, ai.nota, ai.id_curso, " +
                                                            "        alu.nombre, alu.apellido, alu.legajo, alu.id_persona " +
                                                            " from alumnos_inscripciones ai" +
                                                            " inner join personas alu" +
                                                            "   on alu.id_persona = ai.id_alumno" +
                                                            " where ai.id_curso = @idCurso" +
                                                            " order by apellido desc, nombre desc", sqlConn);


                cmdAlumnosCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = IdCurso;

                SqlDataReader drAlumnosCurso = cmdAlumnosCurso.ExecuteReader();
                while (drAlumnosCurso.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();

                    Persona alu = new Persona((int)drAlumnosCurso["id_persona"]);
                    alu.Legajo = (int)drAlumnosCurso["legajo"];
                    alu.Nombre = (string)drAlumnosCurso["nombre"];
                    alu.Apellido = (string)drAlumnosCurso["apellido"];

                    Curso c = new Curso();
                    c.ID = (int)drAlumnosCurso["id_curso"];

                    ai.ID = (int)drAlumnosCurso["id_inscripcion"];
                    ai.Condicion = (string)drAlumnosCurso["condicion"];
                    ai.Nota = (int)drAlumnosCurso["nota"];

                    ai.Curso = c;
                    ai.Alumno = alu;

                    AlumnosCurso.Add(ai);
                }
                drAlumnosCurso.Close();
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
            return AlumnosCurso;
        }


        public List<AlumnoInscripcion> GetEstadoAcademico(int legajo)
        {
            List<AlumnoInscripcion> EstadoAcademico = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEstadoAcademico = new SqlCommand(" Select ai.id_inscripcion, ai.condicion, ai.nota," +
                                                               "        alu.id_persona, alu.legajo," +
                                                               "        c.anio_calendario," +
                                                               "        m.id_materia, m.desc_materia," +
                                                               "        pl.desc_plan, pl.id_plan, " +
                                                               "        esp.id_especialidad, esp.desc_especialidad" +
                                                               " from personas alu" +
                                                               " inner join alumnos_inscripciones ai" +
                                                               "     on ai.id_alumno = alu.id_persona" +
                                                               " inner join cursos c" +
                                                               "     on c.id_curso = ai.id_curso" +
                                                               " inner join materias m" +
                                                               "     on m.id_materia = c.id_materia" +
                                                               " inner join comisiones com" +
                                                               "     on c.id_comision = com.id_comision" +
                                                               " inner join planes pl" +
                                                               "     on pl.id_plan = com.id_plan" +
                                                               " inner join especialidades esp " +
                                                               "    on esp.id_especialidad = pl.id_especialidad" +
                                                               " where alu.legajo = @legajo", sqlConn);
                cmdEstadoAcademico.Parameters.Add("@legajo", SqlDbType.Int).Value = legajo;
                SqlDataReader drEstadoAcademico = cmdEstadoAcademico.ExecuteReader();
                while (drEstadoAcademico.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    
                    Persona alu = new Persona((int)drEstadoAcademico["id_persona"]);
                    alu.Legajo = (int)drEstadoAcademico["legajo"];
                    
                    ai.ID = (int)drEstadoAcademico["id_inscripcion"];
                    ai.Condicion = (string)drEstadoAcademico["condicion"];
                    var nota = drEstadoAcademico["nota"];
                        ai.Nota = (int)drEstadoAcademico["nota"];



                    Curso c = new Curso();
                    c.AnioCalendario = (int)drEstadoAcademico["anio_calendario"];

                    Materia m = new Materia();
                    m.ID = (int)drEstadoAcademico["id_materia"];
                    m.Descripcion = (string)drEstadoAcademico["desc_materia"];
                    c.Materia = m;

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEstadoAcademico["id_especialidad"];
                    esp.Descripcion = (string)drEstadoAcademico["desc_especialidad"];

                    Plan p = new Plan((string)drEstadoAcademico["desc_plan"]);
                    p.ID = (int)drEstadoAcademico["id_plan"];
                    p.Especialidad = esp;

                    Comision com = new Comision();
                    com.Plan = p;
                    c.Comision = com;

                    ai.Alumno = alu;
                    ai.Curso = c;

                    EstadoAcademico.Add(ai);
                }
                drEstadoAcademico.Close();
            }
            catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            /*catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripciones", Ex2);
                throw ExcepcionManejada;
            }*/
            finally
            {
                this.CloseConnection();
            }
            return EstadoAcademico;
        }



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
                string consulta = "insert into alumnos_inscripciones (id_alumno, id_curso, condicion)" +
                    "values(@alu, @curso, @condicion) select @@identity";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("@alu", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdInsert.Parameters.Add("@curso", SqlDbType.Int).Value = ai.Curso.ID;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = "Cursando";
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
                string consulta = "update alumnos_inscripciones set id_alumno=@alu, id_curso=@curso, condicion=@con,nota=@nota where id_inscripcion=@id";
                SqlCommand cmdUpdate = new SqlCommand(consulta, sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = ai.ID;
                cmdUpdate.Parameters.Add("@alu", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdUpdate.Parameters.Add("@curso", SqlDbType.Int).Value = ai.Curso.ID;
                cmdUpdate.Parameters.Add("@con", SqlDbType.VarChar, 50).Value = ai.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = ai.Nota;
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
