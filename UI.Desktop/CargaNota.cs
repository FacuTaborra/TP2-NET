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
    public partial class CargaNota : UI.Desktop.ApplicationForm
    {
        public int IDInscripcion { get; set; }

        public CargaNota(int id_inscripcion)
        {
            IDInscripcion = id_inscripcion;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Validaciones.ValidaNota(int.Parse(txNota.Value.ToString())))
            {
                AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
                alumnoInscripcionLogic.CargaNota(IDInscripcion, int.Parse(txNota.Value.ToString()));
                this.Close();
            }
            else
            {
                Notificar("Error", "La nota ingresada no es correcta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
