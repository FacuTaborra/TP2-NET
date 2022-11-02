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
    public partial class Materias : MasterAdmin
    {
        public int _id_plan;
        public Tipo _tipo;
        public enum Tipo
        {
            filtrado,
            nofiltrado
        }

        public int idplan
        {
            get { return _id_plan; }
            set { _id_plan = value; }
        }

        public Tipo tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public Materias()
        {
            tipo = Tipo.nofiltrado;
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            Listar();
        }

        public Materias(int id_plan)
        {
            tipo = Tipo.filtrado;
            idplan = id_plan;
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            this.tlMaterias.Dock = DockStyle.Fill;
            this.cbPlanes.Visible = false;
            this.btnBuscar.Visible = false;
            this.TituloElegirPlan.Visible = false;
            this.tsMaterias.Visible = false;
            
            // falta ocultar el toolscript
            ListarRespectoPlan(idplan);
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            this.dgvMaterias.DataSource = materias;
        }

        public void ListarRespectoPlan(int id_plan)
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAllWhithPlan(id_plan);
        }

        private int CursosDeMateria(int id)
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> listaCursos = cl.GetAll();
            int cant = 0;
            foreach(var cur in listaCursos)
            {
                if (cur.Materia.ID == id)
                {
                    cant++;
                }
            }
            return cant;
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            Plan p = new Plan();
            p.Descripcion = "Plan";
            Especialidad es = new Especialidad();
            es.Descripcion = " ";
            p.Especialidad = es;
            p.ID = 0;
            planes.Insert(0, p);
            this.cbPlanes.DataSource = planes;
            this.cbPlanes.DisplayMember = "DescripcionYEspecialidad";
            this.cbPlanes.ValueMember = "ID";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (tipo == Tipo.filtrado)
            {
                ListarRespectoPlan(idplan);

            }else if(tipo == Tipo.nofiltrado)
            {
                Listar();
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (tipo == Tipo.filtrado)
            {
                this.Close();
            }
            else if (tipo == Tipo.nofiltrado)
            {
                MenuAdmin fm = new MenuAdmin();
                fm.Show();
                this.Close();
            }
            
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.alta);
            formMateria.ShowDialog();

            if (tipo == Tipo.filtrado)
            {
                ListarRespectoPlan(idplan);
            }
            else if (tipo == Tipo.nofiltrado)
            {
                Listar();
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.modificacion);
                formMateria.ShowDialog();
                if (tipo == Tipo.filtrado)
                {
                    ListarRespectoPlan(idplan);
                }
                else if (tipo == Tipo.nofiltrado)
                {
                    Listar();
                }
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                if (CursosDeMateria(ID) == 0)
                {
                    MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.baja);
                    formMateria.ShowDialog();
                    if (tipo == Tipo.filtrado)
                    {
                        ListarRespectoPlan(idplan);
                    }
                    else if (tipo == Tipo.nofiltrado)
                    {
                        Listar();
                    }
                }
                else
                {
                    ApplicationForm af = new ApplicationForm();
                    af.Notificar("No es posible eliminar la materia por tener cursos asociados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ApplicationForm af = new ApplicationForm();
                af.Notificar("Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(this.cbPlanes.SelectedValue != null)
            {
                this.ListarRespectoPlan(int.Parse(this.cbPlanes.SelectedValue.ToString()));
            }
            else
            {
                Notificar("Error", "Debe seleccionar un Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
