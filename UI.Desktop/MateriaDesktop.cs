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
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia _MateriaActual;

        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {

        }

        public MateriaDesktop (int ID, ModoForm modo): this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                MateriaLogic ml = new MateriaLogic();
                _MateriaActual = ml.GetOne(ID);
                MapearDeDatos();
            }
            if(_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";

            }else if(_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtDescrip.ReadOnly = true;
                this.cbPlanes.DropDownStyle = ComboBoxStyle.Simple;
                this.cbPlanes.Enabled = false;
                this.nudHsSem.ReadOnly = true;
                this.nudHsTot.ReadOnly = true;
            }
            else if (_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtID.Text = this._MateriaActual.ID.ToString();
            this.txtDescrip.Text = this._MateriaActual.Descripcion;
            this.nudHsSem.Text = this._MateriaActual.HSSemanales.ToString();
            this.nudHsTot.Text = this._MateriaActual.HSTotales.ToString();
        }


        public override void MapearADatos()
        {
            base.MapearADatos();
            if (_Modo == ModoForm.alta)
            {
                _MateriaActual = new Materia();
            }
            if (_Modo == ModoForm.modificacion || _Modo == ModoForm.alta)
            {
                _MateriaActual.Descripcion = this.txtDescrip.Text;
                _MateriaActual.HSSemanales = int.Parse(this.nudHsSem.Text);
                _MateriaActual.HSTotales = int.Parse(this.nudHsTot.Text);
                Plan p = new Plan(int.Parse(this.cbPlanes.SelectedValue.ToString()));
                _MateriaActual.Plan = p;
                if (_Modo == ModoForm.alta)
                {
                    _MateriaActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _MateriaActual.State = BusinessEntity.States.Modified;
                }
            }
        }


        public override bool Validar()
        {
            if(this.txtDescrip.Text!="" && this.nudHsSem.Text !="" && this.nudHsTot.Text!="" && this.cbPlanes.SelectedIndex != 0)
            {
                PlanLogic pl = new PlanLogic();
                if (pl.ValidarIDPlan(int.Parse(this.cbPlanes.SelectedValue.ToString()))) 
                {
                    if (Validaciones.ValidarHorasSemanales(int.Parse(this.nudHsSem.Text)))
                    {
                        if (Validaciones.ValidarHorasTotales(int.Parse(this.nudHsTot.Text)))
                        {
                            return true;
                        }
                        else
                        {
                            Notificar("La cantidad de horas totales ingresada no está permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        Notificar("La cantidad de horas semanales ingresada no está permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    Notificar("El ID de Plan es inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            MateriaLogic ml = new MateriaLogic();
            ml.Save(_MateriaActual);
        }


        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            Plan p = new Plan("Seleccionar Plan");
            Especialidad esp = new Especialidad();
            esp.Descripcion = "";
            p.Especialidad = esp;
            planes.Insert(0, p);
            this.cbPlanes.DataSource = planes;
            this.cbPlanes.ValueMember = "ID";
            this.cbPlanes.DisplayMember = "DescripcionYEspecialidad";
            if(_MateriaActual != null)
            {
                this.cbPlanes.SelectedValue = _MateriaActual.Plan.ID;
            }
            else
            {
                this.cbPlanes.SelectedIndex = 0;
            }
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

        private void txtHsSem_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHsTot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
