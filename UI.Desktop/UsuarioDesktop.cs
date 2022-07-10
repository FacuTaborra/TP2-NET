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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario _UsuarioActual;


        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {

        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            if(_Modo != ModoForm.alta)
            {
                UsuarioLogic ul = new UsuarioLogic();
                _UsuarioActual = ul.GetOne(ID);
                MapearDeDatos();
            }
            if(_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                
            }else if(_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }else if(_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtID.Text = this._UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this._UsuarioActual.Habilitado;
            this.txtNombre.Text = this._UsuarioActual.Nombre;
            this.txtApellido.Text = this._UsuarioActual.Apellido;
            this.txtUsuario.Text = this._UsuarioActual.NombreUsuario;
            this.txtEmail.Text = this._UsuarioActual.Email;
            this.txtClave.Text = this._UsuarioActual.Clave;
        }

        public override void MapearADatos()
        {
            base.MapearADatos();
            if (_Modo == ModoForm.alta)
            {
                _UsuarioActual = new Usuario();
            }
            
            if (_Modo == ModoForm.modificacion || _Modo == ModoForm.alta)
            {
                _UsuarioActual.Nombre = this.txtNombre.Text;
                _UsuarioActual.Apellido = this.txtApellido.Text;
                _UsuarioActual.Email = this.txtEmail.Text;
                _UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                _UsuarioActual.Clave = this.txtClave.Text;
                _UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                if(_Modo == ModoForm.alta)
                {
                    _UsuarioActual.State = BusinessEntity.States.New;
                }
                else if(_Modo == ModoForm.modificacion)
                {
                    _UsuarioActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        public override bool Validar()
        {
            //falta validad bien el mail
            if (this.txtNombre.Text != null && this.txtApellido.Text != null && this.txtEmail.Text != null && this.txtClave.Text != null && this.txtUsuario.Text != null && this.chkHabilitado.Text != null)
            {
                if(this.txtClave.Text == this.txtConfirmarClave.Text)
                {
                    if (this.txtClave.Text.Length >= 8)
                    {
                        if (this.txtEmail.Text.Contains("@gmail.com"))
                        {
                            return true;
                        }
                        else
                        {
                            Notificar("El email es invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        Notificar("La clave debe contener al menos 8 digitos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    Notificar("Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else
            {
                Notificar("Ninguno de los campos no puede estar vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(_UsuarioActual);
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmarClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
