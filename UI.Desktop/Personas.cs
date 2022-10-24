using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Personas : MasterAdmin
    {
        public Persona.TiposPersonas _tipoForm;

        public Persona.TiposPersonas TipoForm
        {
            get { return _tipoForm; }
            set { _tipoForm = value; }
        }

        public Personas(Persona.TiposPersonas tipop)
        {
            TipoForm = tipop;
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            if (TipoForm == Persona.TiposPersonas.Profesor)
            {
                this.Text = "Profesores";
                List<Persona> profesores = pl.GetProfesores();
                this.dgvPersonas.DataSource = profesores;
            }
            else if(TipoForm == Persona.TiposPersonas.Alumno)
            {
                this.Text = "Alumnos";
                List<Persona> alumnos = pl.GetAlumnos();
                this.dgvPersonas.DataSource = alumnos;
            }
            else if (TipoForm == Persona.TiposPersonas.Administrador)
            {
                this.Text = "Administrativos";
                List<Persona> administratuvos = pl.GetAdministrativos();
                this.dgvPersonas.DataSource = administratuvos;
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuAdmin mn = new MenuAdmin();
            mn.Show();
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonasDesktop fromPersona = new PersonasDesktop(ApplicationForm.ModoForm.alta);
            fromPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                PersonasDesktop formPersona = new PersonasDesktop(ID, ApplicationForm.ModoForm.modificacion);
                formPersona.ShowDialog();
                this.Listar();
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe Seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvPersonas.SelectedRows.Count == 1)
            {
                PersonasDesktop formPersona = new PersonasDesktop(ID, ApplicationForm.ModoForm.baja);
                formPersona.ShowDialog();
                this.Listar();
            }
        }
    }
}
