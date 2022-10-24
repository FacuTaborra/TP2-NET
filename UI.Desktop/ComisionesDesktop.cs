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
                MapearDeDatos();
            }
            if (_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtDescrip.Enabled=false;
                this.nudAñioEspecialidad.Enabled = false;
                this.cbPlanes.DropDownStyle = ComboBoxStyle.Simple;
                this.cbPlanes.Enabled = false;
            }
            else if (_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }


        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planesList = pl.GetAll();

            //Titulo comboBox
            Plan extraPlan = new Plan();
            extraPlan.ID = 0;
            extraPlan.Descripcion = "Seleccionar Plan";
            Especialidad extraEspecialidad = new Especialidad();
            extraEspecialidad.Descripcion = "";
            extraPlan.Especialidad = extraEspecialidad;

            planesList.Insert(0, extraPlan);
            this.cbPlanes.DataSource = planesList;
            this.cbPlanes.DisplayMember = "DescripcionYEspecialidad";
            this.cbPlanes.ValueMember = "ID";
            if (_ComisionActual == null)
            {
                this.cbPlanes.SelectedIndex = 0;
            }
            else
            {
                this.cbPlanes.SelectedValue = _ComisionActual.Plan.ID;
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

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtIDComision.Text = this._ComisionActual.ID.ToString();
            this.txtDescrip.Text = this._ComisionActual.Descripcion;
            this.cbPlanes.SelectedValue = _ComisionActual.Plan.ID;
            this.nudAñioEspecialidad.Text = this._ComisionActual.AnioEspecialidad.ToString();
        }

        public override void MapearADatos()
        {
            base.MapearADatos();
            if(_Modo == ModoForm.alta)
            {
                _ComisionActual = new Comision();
            }

            if (_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this._ComisionActual.Descripcion = this.txtDescrip.Text;
                this._ComisionActual.AnioEspecialidad = int.Parse(this.nudAñioEspecialidad.Text);

                PlanLogic pl = new PlanLogic();
                int idPlan = int.Parse(cbPlanes.SelectedValue.ToString());
                this._ComisionActual.Plan = pl.GetOne(idPlan);
                if (_Modo == ModoForm.alta)
                {
                    _ComisionActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _ComisionActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(_ComisionActual);
        }

        public override bool Validar()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planesList = new List<Plan>();
            planesList = pl.GetAll();
            int planesLenght = planesList.Count();

            if (this.txtDescrip.Text != "")
            {
                if (this.nudAñioEspecialidad.Value <= 2030 && this.nudAñioEspecialidad.Value >= 1990)
                {
                    if (this.cbPlanes.SelectedIndex != planesLenght)
                    {
                        return true;
                    }
                    else
                    {
                        Notificar("Seleccione un plan de la lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    Notificar("Año de especialidad ingresado Inválido. El año de especialidad es válido desde 1990 hasta 2030", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                Notificar("La descripción no puede estar vacía.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
