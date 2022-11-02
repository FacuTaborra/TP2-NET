using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MasterProfesor : UI.Desktop.ApplicationForm
    {
        public Persona _profesor;

        public Persona Profesor
        {
            get { return _profesor; }
            set { _profesor = value; }
        }

        public MasterProfesor()
        {
            InitializeComponent();
        }

        private void tsbComisiones_Click(object sender, EventArgs e)
        {
            ComisionesProfesor comisionesProfesor = new ComisionesProfesor(Profesor);
            comisionesProfesor.ShowDialog();
        }
    }
}
