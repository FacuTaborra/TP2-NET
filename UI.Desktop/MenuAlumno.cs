﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MenuAlumno : MasterAlumno
    {
        public MenuAlumno(Persona alumno)
        {
            Alumno = alumno;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
