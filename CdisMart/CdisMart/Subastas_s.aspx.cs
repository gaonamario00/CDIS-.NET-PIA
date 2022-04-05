using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CdisMart.CdisMart
{
    public partial class Subastas_s : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["Usuario"];
                    lblNombreUsuario.Text = "Bienvenido " + dt.Rows[0]["Name"].ToString();
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

        #endregion
    }
}