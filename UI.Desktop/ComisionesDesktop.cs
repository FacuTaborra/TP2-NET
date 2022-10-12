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
    public partial class ComisionesDesktop : ApplicationForm
    {

        private Comision _ComisionActual;

        public ComisionesDesktop()
        {
            InitializeComponent();
        }

        public ComisionesDesktop(ModoForm modo): this()
        {
            _Modo = modo;
        }

        public ComisionesDesktop(int id, ModoForm modo) : this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                ComisionLogic cl = new ComisionLogic();
                _ComisionActual = cl.GetOne(id);
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


        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planesList = new List<Plan>();
            planesList = pl.GetAll();
            Plan extraPlan = new Plan();
            extraPlan.Descripcion = "Seleccionar Plan";
            planesList.Add(extraPlan);
            this.cbPlanes.DataSource = planesList;
            this.cbPlanes.DisplayMember = "Descripcion";
            this.cbPlanes.ValueMember = "ID";
            if (_ComisionActual == null)
            {
                this.cbPlanes.SelectedIndex = planesList.Count() -1;
            }
        }

        public override void MapearDeDatos()
        {

        }
        public override void MapearADatos()
        {

        }
        public override void GuardarCambios()
        {

        }
        public override bool Validar()
        {
            return false;
        }

    }
}
