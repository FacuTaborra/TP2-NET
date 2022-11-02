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
    public partial class tcUsuarios : MasterAdmin
    {
        public tcUsuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
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

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvUsuarios.SelectedRows.Count == 1)
            {
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.baja);
                formUsuario.ShowDialog();
                this.Listar();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EligePersonaUsuario elige = new EligePersonaUsuario();
            elige.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            if (this.dgvUsuarios.SelectedRows.Count == 1)
            {
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
