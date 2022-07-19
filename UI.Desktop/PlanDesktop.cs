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
            CompletarCBEspecialidad(this.cbEspecialidad);
            
        }

        public void CompletarCBEspecialidad(ComboBox cbEsp)
        {
            List<Especialidad> listaEsp = new List<Especialidad>();
            EspecialidadLogic el = new EspecialidadLogic();
            listaEsp = el.GetAll();
            foreach(Especialidad esp in listaEsp)
            {
                cbEsp.Items.Add(esp.Descripcion);
            }
        }


        public override void MapearADatos()
        {

        }

        public override bool Validar()
        {

            return true;
        }

        public override void GuardarCambios()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
