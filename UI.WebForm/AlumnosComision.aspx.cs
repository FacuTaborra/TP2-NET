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
        private void LoadGrid(int idCurso)
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            this.gridView.DataSource = ail.GetAlumnosCurso(idCurso);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idCurso = int.Parse(Request.QueryString["idCurso"]);
                LoadGrid(idCurso);
            }
        }

        protected void cargarNotaLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}