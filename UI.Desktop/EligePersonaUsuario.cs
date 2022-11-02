using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EligePersonaUsuario : UI.Desktop.ApplicationForm
    {
        public EligePersonaUsuario()
        {
            InitializeComponent();
        }

        private void EligePersonaUsuario_Load(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> personas = pl.GetAll();
            Persona p = new Persona();
            p.Nombre = "Persona";
            p.Apellido = " ";
            personas.Insert(0,p);
            this.cbPersonas.DataSource = personas;
            this.cbPersonas.DisplayMember = "NombreYApellidoYTipo";
            this.cbPersonas.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.alta, int.Parse(this.cbPersonas.SelectedValue.ToString()));
            formUsuario.ShowDialog();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
