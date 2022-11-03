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
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReportPlanes : Form
    {
        public ReportPlanes()
        {
            InitializeComponent();
        }

        private void ReportPlanes_Load(object sender, EventArgs e)
        {
            PlanLogic planLogic = new PlanLogic();
            ReportDataSource rds = new ReportDataSource("ReportPlanes", planLogic.GetAll());
            this.rvPlanes.LocalReport.DataSources.Clear();
            this.rvPlanes.LocalReport.DataSources.Add(rds);
            this.rvPlanes.RefreshReport();
        }
    }
}
