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
            CompletarCBEspecialidad(this.cbEspecialidad);
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
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad esp = new Especialidad();
            this.txtID.Text = this._PlanActual.ID.ToString();
            this.txtDesc.Text = this._PlanActual.Descripcion;
            var idEsp = this._PlanActual.IDEspecialidad;
            esp = el.GetOne(idEsp);


        }



        private DataTable getEspecialidades()
        {
            DataTable dtEsp = new DataTable();
            dtEsp.Columns.Add("id_esp", typeof(int));
            dtEsp.Columns.Add("desc_esp", typeof(string));
            List<Especialidad> listaEsp = new List<Especialidad>();
            EspecialidadLogic el = new EspecialidadLogic();
            listaEsp = el.GetAll();
            foreach (Especialidad esp in listaEsp)
            {
                dtEsp.Rows.Add(new Object[] { esp.ID.ToString(), esp.Descripcion.ToString() });
            }
            return dtEsp;
        }
        
        
        public void CompletarCBEspecialidad(ComboBox cbEsp)
        {
            List<Especialidad> listaEsp = new List<Especialidad>();
            EspecialidadLogic el = new EspecialidadLogic();
            listaEsp = el.GetAll();
            foreach(Especialidad esp in listaEsp)
            {
                cbEsp.Items.Add(esp.Descripcion.ToString());
                cbEsp.ValueMember = esp.ID.ToString();
            }
        }
        
        
        /*
        public void CompletarCBEspecialidad(ComboBox cbEsp)
        {
            DataTable listaEsp = new DataTable();
            //EspecialidadLogic el = new EspecialidadLogic();
            listaEsp = getEspecialidades();
            foreach (DataRow esp in listaEsp.Rows)
            {
                cbEsp.Items.Add(esp.DataColum.data());
                cbEsp.ValueMember = "id_esp";
                cbEsp.DisplayMember = "desc_esp";
            }
            
        }*/

        /*
        public void CompletarCBEspecialidad(ComboBox cbEsp)
        {
            cbEsp.DataSource = getEspecialidades();
            foreach (DataRow esp in cbEsp.DataSource)
            {
                cbEsp.Items.Add(esp);
                cbEsp.ValueMember = "id_esp";
                cbEsp.DisplayMember = "desc_esp";
            }
        }
        */


        public override void MapearADatos()
        {
            if (_Modo == ModoForm.alta)
            {
                _PlanActual = new Plan();
            }
            if(_Modo==ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                _PlanActual.Descripcion = this.txtDesc.Text;
                _PlanActual.IDEspecialidad= Convert.ToInt32(this.cbEspecialidad.SelectedValue);
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

            return true;
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
