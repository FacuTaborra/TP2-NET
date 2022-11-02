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
    public partial class ComisionesProfesor : UI.Desktop.ApplicationForm
    {
        public Persona _profesor;
        public DocenteCursoLogic _DataCurso;
        
        public Persona Profesor
        {
            get { return _profesor; }
            set { _profesor = value; }
        }

        public ComisionesProfesor()
        {
            InitializeComponent();
            this.dgvComisionesProfesor.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            _DataCurso = new DocenteCursoLogic();
            this.dgvComisionesProfesor.DataSource = _DataCurso.GetCursosProfesor(Profesor.ID);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvComisionesProfesor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                AlumnosComision alumnosComision = new AlumnosComision(int.Parse(this.dgvComisionesProfesor.CurrentRow.Cells[0].Value.ToString()));
                alumnosComision.ShowDialog();
            }
        }

        private void ComisionesProfesor_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
