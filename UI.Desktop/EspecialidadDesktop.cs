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


namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad _EspecialidadActual;
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo): this()
        {

        }   

        public EspecialidadDesktop(int ID, ModoForm modo): this()
        {
            _Modo = modo;

        }
    }
}
