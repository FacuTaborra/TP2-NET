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
        public DocenteCurso GetProfesorCurso(int idCurso, DocenteCurso.TiposCargos cargo)
        {
            DocenteCurso CursoProfesor = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdGetOne = new SqlCommand(" select dc.id_dictado, dc.cargo, " +
                                                      "        dc.id_curso," +
                                                      "        per.nombre, per.apellido, per.id_persona" +
                                                      " from docentes_cursos dc" +
                                                      " inner join personas per" +
                                                      "     on per.id_persona = dc.id_docente  " +
                                                      " where dc.id_curso = @id and dc.cargo = @cargo", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;
                cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = cargo;
                SqlDataReader drGetProfesorCurso = cmdGetOne.ExecuteReader();
                if (drGetProfesorCurso.Read())
                {
                    CursoProfesor.ID = (int)drGetProfesorCurso["id_dictado"];

                    Curso c = new Curso();
                    c.ID = (int)drGetProfesorCurso["id_curso"];
                    CursoProfesor.Curso = c;

                    Persona docente = new Persona();
                    docente.ID = (int)drGetProfesorCurso["id_persona"];
                    docente.Nombre = (string)drGetProfesorCurso["nombre"];
                    docente.Apellido = (string)drGetProfesorCurso["apellido"];
                    CursoProfesor.Docente = docente;

                    CursoProfesor.Cargo = (DocenteCurso.TiposCargos)drGetProfesorCurso["cargo"];

                }
                drGetProfesorCurso.Close();
            }
            /*catch (SqlException Ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos", Ex1);
                throw ExcepcionManejada;
            }
            catch (Exception Ex2)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar dictado", Ex2);
                throw ExcepcionManejada;
            }*/
            finally
            {
                this.CloseConnection();
            }
            return CursoProfesor;
        }
        public List<DocenteCurso> GetCursosProfesor(int idProfesor)
        {
            List<DocenteCurso> listaCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursosProfesor = new SqlCommand(" select dc.cargo, " +
                                                              " cur.anio_calendario, cur.id_curso, " +
                                                              " com.desc_comision, com.anio_especialidad," +
                                                              " pl.desc_plan, " +
                                                              " esp.desc_especialidad, " +
                                                              " mat.desc_materia" +
                                                              " from docentes_cursos dc" +
                                                              " inner join cursos cur" +
                                                              "     on cur.id_curso = dc.id_curso" +
                                                              " inner join comisiones com" +
                                                              "     on com.id_comision = cur.id_comision" +
                                                              " inner join planes pl " +
                                                              "     on pl.id_plan = com.id_plan" +
                                                              " inner join especialidades esp " +
                                                              "     on esp.id_especialidad = pl.id_especialidad" +
                                                              " inner join materias mat " +
                                                              "     on mat.id_materia = cur.id_materia" +
                                                              " where id_docente = @id_profesor" +
                                                              " order by cur.anio_calendario desc , dc.cargo asc", sqlConn);

                cmdCursosProfesor.Parameters.Add("@id_profesor", SqlDbType.Int).Value = idProfesor;
                SqlDataReader drCursosProfesor = cmdCursosProfesor.ExecuteReader();

                while (drCursosProfesor.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursosProfesor["id_curso"];
                    c.AnioCalendario = (int)drCursosProfesor["anio_calendario"];

                    Especialidad esp = new Especialidad();
                    esp.Descripcion = (string)drCursosProfesor["desc_especialidad"];

                    Plan p = new Plan((string)drCursosProfesor["desc_plan"]);
                    p.Especialidad = esp;

                    Comision com = new Comision();
                    com.AnioEspecialidad = (int)drCursosProfesor["anio_especialidad"];
                    com.Descripcion = (string)drCursosProfesor["desc_comision"];
                    com.Plan = p;

                    Materia mat = new Materia();
                    mat.Descripcion = (string)drCursosProfesor["desc_materia"];

                    c.Comision = com;
                    c.Materia = mat;

                    DocenteCurso dc = new DocenteCurso();
                    dc.Curso = c;
                    dc.Cargo = (DocenteCurso.TiposCargos)drCursosProfesor["cargo"];

                    listaCursos.Add(dc);
                }
            }
            /*catch (SqlException ex1)
            {
                Exception ExcepcionManejada = new Exception("Error con la base de datos");
                throw ExcepcionManejada;
            }*/
            /*catch (Exception ex2)
            {
                Exception ExcepcionManejada2 = new Exception("Error al recuperar la lista de cursos");
                throw ExcepcionManejada2;
            }*/
            finally
            {
                this.CloseConnection();
            }
            return listaCursos;
        }
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
                    int IDCurso = (int)drGetAll["id_curso"];
                    CursoAdapter ca = new CursoAdapter();
                    dc.Curso = ca.GetOne(IDCurso);
                    int IDDocente = (int)drGetAll["id_docente"];
                    PersonaAdapter pa = new PersonaAdapter();
                    dc.Docente = pa.GetOne(IDDocente);
                    dc.Cargo = (DocenteCurso.TiposCargos)drGetAll["cargo"];

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
                    int IDCurso = (int)drGetOne["id_curso"];
                    CursoAdapter ca = new CursoAdapter();
                    dc.Curso = ca.GetOne(IDCurso);
                    int IDDocente = (int)drGetOne["id_docente"];
                    PersonaAdapter pa = new PersonaAdapter();
                    dc.Docente = pa.GetOne(IDDocente);
                    dc.Cargo = (DocenteCurso.TiposCargos)drGetOne["cargo"];
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
                string consulta = " INSERT INTO docentes_cursos (id_curso, id_docente, cargo) " +
                                  " VALUES (@id_curso, @id_docente, @cargo) " +
                                  " SELECT @@identity";
                SqlCommand cmdInsert = new SqlCommand(consulta, sqlConn);
                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)dc.Cargo;
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
                cmdInsert.Parameters.Add("id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdInsert.Parameters.Add("id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                cmdInsert.Parameters.Add("cargo", SqlDbType.Int).Value =(int)dc.Cargo;
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
