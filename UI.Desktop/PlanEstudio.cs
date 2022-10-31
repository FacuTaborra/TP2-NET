using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PlanEstudio : UI.Desktop.MasterAlumno
    {
        public PlanEstudio(Persona alumno)
        {
            Alumno = alumno;
            InitializeComponent();
            this.dgvMateriasPlan.AutoGenerateColumns = false;
        }

        public void Listar(int id_plan)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAllWhithPlan(id_plan);
            this.dgvMateriasPlan.DataSource = materias;
        }

        private void PlanEstudio_Load(object sender, EventArgs e)
        {
            Listar(Alumno.Plan.ID);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuAlumno menuAlumno = new MenuAlumno(Alumno);
            menuAlumno.Show();
            this.Close();
        }
    }
}
