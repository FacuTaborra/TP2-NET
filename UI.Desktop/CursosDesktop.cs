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
    public partial class CursosDesktop : ApplicationForm
    {

        private Curso _CursoActual;

        public CursosDesktop()
        {
            InitializeComponent();
        }


        public CursosDesktop(ModoForm modo) : this()
        {
            _Modo = modo;
        }

        public CursosDesktop(int id, ModoForm modo) : this()
        {
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                CursoLogic cl = new CursoLogic();
                _CursoActual = cl.GetOne(id);
                MapearDeDatos();
            }

            if(_Modo==ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (_Modo == ModoForm.baja)
            {
                btnAceptar.Text = "Eliminar";
                this.cbComision.DropDownStyle = ComboBoxStyle.Simple;
                this.cbMateria.DropDownStyle = ComboBoxStyle.Simple;
                this.cbComision.Enabled = false;
                this.cbMateria.Enabled = false;
                this.nudAnio.Enabled = false;
                this.nudCupo.Enabled = false;
            }
            else if (_Modo == ModoForm.consulta)
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> listaMaterias = new List<Materia>();
            listaMaterias = ml.GetAll();
            Materia materiaExtra = new Materia();
            materiaExtra.ID = 0;
            materiaExtra.Descripcion = "Seleccionar Materia";
            listaMaterias.Add(materiaExtra);
            this.cbMateria.DataSource = listaMaterias;
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.ValueMember = "ID";

            ComisionLogic cl = new ComisionLogic();
            List<Comision> listaComisiones = new List<Comision>();
            listaComisiones = cl.GetAll();
            Comision comisionExtra = new Comision();
            comisionExtra.ID = 0;
            comisionExtra.Descripcion = "Elegir comision";
            listaComisiones.Add(comisionExtra);
            this.cbComision.DataSource = listaComisiones;
            this.cbComision.ValueMember = "ID";
            this.cbComision.DisplayMember = "Descripcion";

            if (_CursoActual == null)
            {
                this.cbMateria.SelectedIndex = listaMaterias.Count() - 1;
                this.cbComision.SelectedIndex = listaComisiones.Count() - 1;
                this.nudAnio.Value = 2022;
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


        public override void MapearADatos()
        {
            base.MapearADatos();
            if (_Modo == ModoForm.alta)
            {
                _CursoActual = new Curso();
            }

            if(_Modo==ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                _CursoActual.AnioCalendario = int.Parse(this.nudAnio.Value.ToString());
                _CursoActual.Cupo = int.Parse(this.nudCupo.Value.ToString());
                int matID = int.Parse(cbMateria.SelectedValue.ToString());
                MateriaLogic ml = new MateriaLogic();
                _CursoActual.Materia = ml.GetOne(matID);
                int comID = int.Parse(cbComision.SelectedValue.ToString());
                ComisionLogic cl = new ComisionLogic();
                _CursoActual.Comision = cl.GetOne(comID);
                string show = "Nueva Mat: " + _CursoActual.Materia.ID + "  ComisionActual: " + _CursoActual.Comision.ID;
                MessageBox.Show(show);
                if (_Modo == ModoForm.alta)
                {
                    _CursoActual.State = BusinessEntity.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _CursoActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtID.Text = this._CursoActual.ID.ToString();
            this.nudAnio.Text = this._CursoActual.AnioCalendario.ToString();
            this.nudCupo.Text = this._CursoActual.Cupo.ToString();
            this.cbComision.SelectedValue = _CursoActual.Comision.ID;
            this.cbMateria.SelectedValue = _CursoActual.Materia.ID;
        }


        public override bool Validar()
        {
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic cl = new ComisionLogic();

            if(this.cbMateria.SelectedIndex != ml.GetAll().Count())
            {
                if(this.cbComision.SelectedIndex != cl.GetAll().Count())
                {
                    if(nudAnio.Value>=1990 && nudAnio.Value <= 2030)
                    {
                        if(nudCupo.Value >= 10 && nudCupo.Value <= 50)
                        {
                            return true;
                        }
                        else
                        {
                            Notificar("Los cursos deben admitir entre 10 y 50 alumnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        Notificar("El Año de calendario es válido desde 1990 hasta 2030", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    Notificar("Seleccione una comision de la lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                Notificar("Seleccione una Materia de la lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            base.GuardarCambios();
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(_CursoActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
