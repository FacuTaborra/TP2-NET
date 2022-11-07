using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.WebForm
{
    public partial class AlumnosComision : ComisionesProfesor
    {

        private Curso _CursoActual;
        public new Curso CursoActual
        {
            get 
            {
                ComisionesProfesor cp = new ComisionesProfesor();
                return cp.CursoActual;
            }
        }

        private void LoadGrid()
        {

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void cargarNotaLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}