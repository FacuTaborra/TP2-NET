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
    public partial class PersonasDesktop : ApplicationForm
    {
        public Persona _PersonaActual; 
        public PersonasDesktop()
        {
            InitializeComponent();
        }

        public PersonasDesktop(ModoForm modo): this()
        {

        }

        public PersonasDesktop(int ID, ModoForm modo): this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                PersonaLogic pl = new PersonaLogic();
                _PersonaActual = pl.GetOne(ID);
                MapearDeDatos();
            }

            if (_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            } else if (_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtNombre.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtLegajo.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.cbPlan.DropDownStyle = ComboBoxStyle.Simple;
                this.cbPlan.Enabled = false;
                this.cbTipo.DropDownStyle = ComboBoxStyle.Simple;
                this.cbTipo.Enabled = false;
                this.dtpFechaNac.Enabled = false;
            } else if(_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        private void PersonasDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();

            //agregamos manualmente "plan"
            Plan p = new Plan();
            p.Descripcion = "Selecccionar Plan";
            Especialidad esp = new Especialidad();
            p.Especialidad = esp;
            planes.Insert(0, p);

            cbPlan.DataSource = planes;
            cbPlan.DisplayMember = "DescripcionYEspecialidad";
            cbPlan.ValueMember = "ID";

            if (_PersonaActual == null)
            {
                cbTipo.DataSource = Enum.GetValues(typeof(Persona.TiposPersonas));
                cbPlan.SelectedIndex = 0;
            }
            else
            {
                cbPlan.SelectedValue = _PersonaActual.Plan.ID;
            } 
            

        }

        public override void MapearADatos()
        {
            base.MapearADatos();
            if(_Modo == ModoForm.alta)
            {
                _PersonaActual = new Persona();

            }
            if (_Modo == ModoForm.modificacion || _Modo == ModoForm.alta)
            {
                _PersonaActual.Nombre = this.txtNombre.Text;
                _PersonaActual.Apellido = this.txtApellido.Text;
                _PersonaActual.Email = this.txtEmail.Text;
                _PersonaActual.Direccion = this.txtDireccion.Text;
                _PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                _PersonaActual.Telefono = this.txtTelefono.Text;
                Plan p = new Plan(int.Parse(this.cbPlan.SelectedValue.ToString()));
                _PersonaActual.Plan = p; //verificar
                _PersonaActual.TipoPersona = (Persona.TiposPersonas)this.cbTipo.SelectedIndex; //verificar
                _PersonaActual.FechaNacimiento = this.dtpFechaNac.Value.Date; //verificar
                if (_Modo == ModoForm.alta)
                {
                    _PersonaActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _PersonaActual.State = BusinessEntity.States.Modified;
                }
                Console.WriteLine(_PersonaActual);
            }
        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtId.Text = _PersonaActual.ID.ToString();
            this.txtNombre.Text = _PersonaActual.Nombre;
            this.txtApellido.Text = _PersonaActual.Apellido;
            this.txtEmail.Text = _PersonaActual.Email;
            this.txtDireccion.Text = _PersonaActual.Direccion;
            this.txtTelefono.Text = _PersonaActual.Telefono;
            this.txtLegajo.Text = _PersonaActual.Legajo.ToString();
            this.cbTipo.DataSource = Enum.GetValues(typeof(Persona.TiposPersonas));
            this.cbTipo.SelectedIndex = (int)_PersonaActual.TipoPersona;
            this.cbPlan.SelectedValue = _PersonaActual.Plan.ID;
            this.dtpFechaNac.Text = _PersonaActual.FechaNacimiento.ToShortDateString();
        }

        public override bool Validar()
        {
            if (this.txtNombre.Text != "" && this.txtApellido.Text != "" && this.txtEmail.Text != "" && this.txtDireccion.Text != "" && this.txtLegajo.Text != "" && this.txtTelefono.Text != "")
            {
                return true;
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
            PersonaLogic pl = new PersonaLogic();
            pl.Save(_PersonaActual);
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

        
    }
}
