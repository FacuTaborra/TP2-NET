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
    public partial class MateriasPlan : System.Web.UI.Page
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



        private void LoadGrid()
        {
            Usuario usrActual = UI.WebForm.Site.UsrActual;
            this.gridView.DataSource = Logic.GetAllWhithUser(usrActual.ID);
            this.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack)
            {
                LoadGrid();
            }
        }
    }
}