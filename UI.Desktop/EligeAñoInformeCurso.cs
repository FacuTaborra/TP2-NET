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
    public partial class EligeAñoInformeCurso : UI.Desktop.ApplicationForm
    {
        public EligeAñoInformeCurso()
        {
            InitializeComponent();
        }

        private void EligeAño_Load(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            this.cbConsultaAño.DataSource = cl.GetAños();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReportCursos reportCursos = new ReportCursos(int.Parse(this.cbConsultaAño.SelectedValue.ToString()));
            reportCursos.ShowDialog();
        }
    }
}
