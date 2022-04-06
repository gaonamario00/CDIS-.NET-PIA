using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_BLL;

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
                    grd_subastas.DataSource = cargarSubastas();
                    grd_subastas.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void grd_subastas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Name")
            {
                Response.Redirect("~/CdisMart/Subasta_detalle.aspx?pAuctionId="+e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/CdisMart/Subasta_historial.aspx?pAuctionId=" + e.CommandArgument);
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

        public List<Object> cargarSubastas()
        {
             Subastas_BLL subastas_BLL  = new Subastas_BLL();
            List<Object> subastas = new List<Object>();

            subastas = subastas_BLL.cargarSubastas();



            return subastas;
        }

        #endregion

        protected void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('El usuario y/o la contraseña son invalidos!')", true);
        }

        //public IEnumerable<object> filtrar(string text)
        //{
        //    try
        //    {

        //    }catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}