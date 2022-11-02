using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class AlumnosComision : UI.Desktop.ApplicationForm
    {
        public int IdCurso{ get; set; }

        public AlumnosComision(int idCurso)
        {
            IdCurso = idCurso;
            InitializeComponent();
            this.dgvAlumnosCurso.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            this.dgvAlumnosCurso.DataSource = alumnoInscripcionLogic.GetAlumnosCurso(IdCurso);
        }

        private void AlumnosComision_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvAlumnosCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                CargaNota cargaNota = new CargaNota(int.Parse(this.dgvAlumnosCurso.CurrentRow.Cells[0].Value.ToString()));
                cargaNota.ShowDialog();
                Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
