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
    public partial class PlanDesktop : ApplicationForm
    {

        public Plan _PlanActual;
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this()
        {

        }



        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                PlanLogic pl = new PlanLogic();
                _PlanActual = pl.GetOne(ID);
                MapearDeDatos();
            }
            if (_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";

            }
            else if (_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtDesc.ReadOnly = true;
                this.txtEspecialidad.ReadOnly = true;

            }
            else if (_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtID.Text = this._PlanActual.ID.ToString();
            this.txtDesc.Text = this._PlanActual.Descripcion;
            this.txtEspecialidad.Text = this._PlanActual.IDEspecialidad.ToString();
        }


        public override void MapearADatos()
        {
            if (_Modo == ModoForm.alta)
            {
                _PlanActual = new Plan();
            }
            if(_Modo==ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                _PlanActual.Descripcion = this.txtDesc.Text;
                _PlanActual.IDEspecialidad= Convert.ToInt32(this.txtEspecialidad.Text);
                if (_Modo == ModoForm.alta)
                {
                    _PlanActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _PlanActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        public override bool Validar()
        {
            if (this.txtDesc.Text != "" && this.txtEspecialidad.Text != "")
            {
                EspecialidadLogic el = new EspecialidadLogic();
                if (!el.ValidarIDEspecialidad(Convert.ToInt32(this.txtEspecialidad.Text)))
                {
                    Notificar("El ID de especialidad ingresado no corresponde a una especialidad registrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;

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
            PlanLogic pl = new PlanLogic();
            pl.Save(_PlanActual);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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

    }
}
