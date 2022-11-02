using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AsignarProfesoresCurso : ApplicationForm
    {
        public DocenteCurso _docenteCurso;
        public DocenteCursoLogic _DocenteCursoData;
        public Curso _CursoActual;

        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }

        public AsignarProfesoresCurso(Curso curso, ModoForm modoForm)
        {
            _Modo = modoForm;
            CursoActual = curso;
            InitializeComponent();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();

            List<Persona> profesoresTitulares = pl.GetProfesores(); // faltaria filtrar por plan
            Persona tituloCb = new Persona();
            tituloCb.ID = 0;
            tituloCb.Nombre = "Titular";

            profesoresTitulares.Insert(0, tituloCb);

            this.cbProfesoresTitulares.DataSource = profesoresTitulares;
            this.cbProfesoresTitulares.ValueMember = "ID";
            this.cbProfesoresTitulares.DisplayMember = "NombreYApellido";

            List<Persona> profesoresAuxiliares = pl.GetProfesores();
            tituloCb.Nombre = "Auxiliar";
            profesoresAuxiliares.Insert(0, tituloCb);

            this.cbProfesoresAuxiliar.DataSource = profesoresAuxiliares;
            this.cbProfesoresAuxiliar.ValueMember = "ID";
            this.cbProfesoresAuxiliar.DisplayMember = "NombreYApellido";

            if (_Modo == ModoForm.alta)
            {
                this.cbProfesoresTitulares.SelectedIndex = 0;
                this.cbProfesoresAuxiliar.SelectedIndex = 0;
            }
            else if (_Modo == ModoForm.modificacion)
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                DocenteCurso ProfesorTitular = dcl.GetProfesorCurso(CursoActual.ID, DocenteCurso.TiposCargos.Profesor);
                this.cbProfesoresTitulares.SelectedValue = ProfesorTitular.Docente.ID;

                DocenteCurso ProfesorAuxiliar = dcl.GetProfesorCurso(CursoActual.ID, DocenteCurso.TiposCargos.Auxiliar);
                this.cbProfesoresAuxiliar.SelectedValue = ProfesorAuxiliar.Docente.ID;
            }

        }

        private void AsignarProfesoresCurso_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void MapearAdatos()
        {
            _DocenteCursoData = new DocenteCursoLogic();

            //Titular
            _docenteCurso = new DocenteCurso();
            _docenteCurso.Cargo = DocenteCurso.TiposCargos.Profesor;
            Persona Titular = new Persona();
            Titular.ID = int.Parse(this.cbProfesoresTitulares.SelectedValue.ToString());
            _docenteCurso.Docente = Titular;
            _docenteCurso.Curso = CursoActual;
            _DocenteCursoData.Insert(_docenteCurso);

            _docenteCurso = null;

            //Axiliar
            _docenteCurso = new DocenteCurso();
            _docenteCurso.Cargo = DocenteCurso.TiposCargos.Auxiliar;
            Persona Auxiliar = new Persona();
            Auxiliar.ID = int.Parse(this.cbProfesoresAuxiliar.SelectedValue.ToString());
            _docenteCurso.Docente = Auxiliar;
            _docenteCurso.Curso = CursoActual;
            _DocenteCursoData.Insert(_docenteCurso);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idTitular = int.Parse(this.cbProfesoresTitulares.SelectedValue.ToString());
            int idAuxiliar = int.Parse(this.cbProfesoresAuxiliar.SelectedValue.ToString());

            if (Validaciones.ValidaProfesores(idTitular, idAuxiliar))
            {
                this.MapearAdatos();
            }
            else
            {
                Notificar("Error","El profesor titular y auxiliar no pueden ser iguales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
