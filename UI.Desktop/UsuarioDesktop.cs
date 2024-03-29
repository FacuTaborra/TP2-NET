﻿using System;
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
        public Persona _PersonaAtual { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo, int id_persona) : this()
        {
            _Modo = modo;
            _PersonaAtual = new Persona();
            _PersonaAtual.ID = id_persona;
            PersonaLogic pr = new PersonaLogic();
            _PersonaAtual = pr.GetOne(_PersonaAtual.ID);
            this.txtNombre.Text = this._PersonaAtual.Nombre;
            this.txtApellido.Text = this._PersonaAtual.Apellido;
            this.txtEmail.Text = this._PersonaAtual.Email;

            this.txtApellido.ReadOnly = true;
            this.txtEmail.ReadOnly = true;
            this.txtNombre.ReadOnly = true;

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
                this.txtApellido.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtNombre.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;

            }
            else if(_Modo == ModoForm.consulta)
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
                _UsuarioActual.Persona = _PersonaAtual; //seteo los datos de la persona elegida
                //datos nuevos del usuario
                _UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                _UsuarioActual.Clave = this.txtClave.Text;
                _UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                if (_Modo == ModoForm.alta)
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
          
            if (this.txtNombre.Text != "" && this.txtApellido.Text != "" && this.txtEmail.Text != "" && this.txtClave.Text != "" && this.txtUsuario.Text != "")
            {
                if(this.txtClave.Text == this.txtConfirmarClave.Text)
                {
                    if (this.txtClave.Text.Length >= 8)
                    {
                        if (Validaciones.emailValido(this.txtEmail.Text))
                        {
                            return true;
                        }
                        else
                        {
                            Notificar("El email es inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Notificar("Ninguno de los campos puede estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(_UsuarioActual);
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

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
