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
    public partial class EligePlanCurso : UI.Desktop.ApplicationForm
    {
        public EligePlanCurso()
        {
            InitializeComponent();
        }

        private void EligePlanCurso_Load(object sender, EventArgs e)
        {
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            Plan p = new Plan();
            p.Descripcion = "Plan";
            p.ID = 0;
            Especialidad esp = new Especialidad();
            esp.Descripcion = " ";
            p.Especialidad = esp;
            planes.Insert(0, p);

            this.cbPlanes.DataSource = planes;
            this.cbPlanes.DisplayMember = "DescripcionYEspecialidad";
            this.cbPlanes.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CursosDesktop cd = new CursosDesktop(ApplicationForm.ModoForm.alta, int.Parse(this.cbPlanes.SelectedValue.ToString()));
            this.Close();
            cd.ShowDialog();
        }
    }
}
