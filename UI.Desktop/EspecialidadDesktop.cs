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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad _EspecialidadActual;
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {

        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                EspecialidadLogic el = new EspecialidadLogic();
                _EspecialidadActual = el.GetOne(ID);
                MapearDeDatos();
            }
            else if (_Modo != ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (_Modo != ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.textID.Text = this._EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this._EspecialidadActual.Descripcion;
        }

        public override void MapearADatos()
        {
            base.MapearADatos();
            if (_Modo == ModoForm.alta)
            {
                _EspecialidadActual = new Especialidad();
                if (_Modo == ModoForm.modificacion || _Modo == ModoForm.alta)
                {
                    _EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                }
                if (_Modo == ModoForm.alta)
                {
                    _EspecialidadActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _EspecialidadActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        public override bool Validar()
        {
            if(this.txtDescripcion.Text != "")
            {
                return true;
            }
            else
            {
                Notificar("El Campo Descripcion no puede estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(_EspecialidadActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
