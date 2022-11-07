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
    public partial class EstadoAcademico : Default
    {
        private new Usuario UsuarioActual
        {
            get
            {
                Default d = new Default();
                return d.UsuarioActual;
            }
        }
        private AlumnoInscripcionLogic _aiLogic;
        private AlumnoInscripcionLogic AILogic
        {
            get
            {
                if (_aiLogic == null)
                {
                    _aiLogic = new AlumnoInscripcionLogic();
                }
                return _aiLogic;
            }
        }
        private PersonaLogic _pLogic;
        private PersonaLogic PLogic
        {
            get
            {
                if (_pLogic == null)
                {
                    _pLogic = new PersonaLogic();
                }
                return _pLogic;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Persona alumno = this.PLogic.GetOne(UsuarioActual.Persona.ID);

            this.GridView.DataSource = AILogic.GetEstadoAcademico(alumno.Legajo);
            this.GridView.DataBind();

        }
    }
}