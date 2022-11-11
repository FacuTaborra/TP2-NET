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
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid(int idCurso)
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            this.GridView.DataSource = ail.GetAlumnosCurso(idCurso);
            this.GridView.DataBind();
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idCurso = Convert.ToInt32(Request.QueryString["idCurso"]);
                LoadGrid(idCurso);
            }
        }

        protected void cargarNotaLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.labelNotasValidas.Visible = false;
                this.labelNotaInvalida.Visible = false;
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                AlumnoInscripcion ai = ail.GetOne(this.SelectedID);
                this.AlumnoTextBox.Text = ai.Alumno.NombreYApellido;
                this.legajoTextBox.Text = ai.Alumno.Legajo.ToString();

            }
            else
            {
                SeleccionarLabel.Visible = true;
            }
        }

        protected new void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }


        private bool ValidaNota(int nota)
        {
            if (nota <= 10 && nota >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string Condicion(int nota)
        {
            if(nota>=1 && nota <= 5)
            {
                return "Desaprobado";
            }
            else if(nota>=6 && nota <= 10)
            {
                return "Aprobado";
            }
            else if (nota == 0)
            {
                return "Cursando";
            }
            else
            {
                return "";
            }
        }



        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.labelNotasValidas.Visible = false;
            this.labelNotaInvalida.Visible = false;
            this.NotaTextBox.Text = string.Empty;
            try
            {
                if (this.ValidaNota(int.Parse(this.NotaTextBox.Text)))
                {
                    AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
                    alumnoInscripcionLogic.CargaNota(this.SelectedID, int.Parse(this.NotaTextBox.Text));
                    this.formPanel.Visible = false;
                }
                else
                {
                    this.labelNotaInvalida.Visible = true;
                }
            }
            catch(FormatException Ex)
            {
                this.labelNotaInvalida.Visible = true;
            }
            finally
            {
                this.LoadGrid(Convert.ToInt32(Request.QueryString["idCurso"]));
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}