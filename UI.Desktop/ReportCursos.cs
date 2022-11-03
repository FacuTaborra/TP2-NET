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
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReportCursos : Form
    {
        public int AñoInforme { get; set; }
        public ReportCursos(int año)
        {
            AñoInforme = año;
            InitializeComponent();
        }

        private void ReportCursos_Load(object sender, EventArgs e)
        {
            CursoLogic cursoLogic = new CursoLogic();
            ReportDataSource rds = new ReportDataSource("ReportCursos", cursoLogic.GetAll(AñoInforme));
            this.rvCursos.LocalReport.DataSources.Clear();
            this.rvCursos.LocalReport.DataSources.Add(rds);
            this.rvCursos.RefreshReport();
        }
    }
}
