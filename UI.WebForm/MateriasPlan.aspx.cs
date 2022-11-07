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
    public partial class MateriasPlan : Default
    {
        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        PersonaLogic _plogic;
        private PersonaLogic PLogic
        {
            get
            {
                if (_plogic == null)
                {
                    _plogic = new PersonaLogic();
                }
                return _plogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Persona alumno = this.PLogic.GetOne(UsuarioActual.Persona.ID);
            PlanLogic pl = new PlanLogic();
            Plan p = pl.GetOne(alumno.Plan.ID);
            this.descPlan.Text = p.Descripcion +" "+ p.Especialidad.Descripcion;
            this.gridView.DataSource = Logic.GetAll();
            this.gridView.DataBind();
        }



        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}