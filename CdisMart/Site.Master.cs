using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_DAL;

namespace CdisMart
{
    public partial class SiteMaster : MasterPage
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    UserTable user = new UserTable();
                    user = (UserTable)Session["Usuario"];
                    lblNombreUsuario.Text = "Bienvenido " + user.Name;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        #endregion

        #region Metodos

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void cerrarSesion()
        {
            Response.Redirect("../Login.aspx");
        }

        #endregion
    }
}