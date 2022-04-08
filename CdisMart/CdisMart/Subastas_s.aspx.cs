using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.CdisMart
{
    public partial class Subastas_s : TemaCdisMart, IAcceso
    {

        int i = 0;

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            //buscar.Focus();

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
            if (e.CommandName == "Name")
            {
                Response.Redirect("~/CdisMart/Subasta_detalle.aspx?pAuctionId=" + e.CommandArgument);
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

        public List<Auction> cargarSubastas()
        {
            Subastas_BLL subastas_BLL = new Subastas_BLL();
            List<Auction> subastas = new List<Auction>();

            subastas = subastas_BLL.cargarSubastas();



            return subastas;
        }

        #endregion

        protected void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('El usuario y/o la contraseña son invalidos!')", true);
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Write("i: "+i);
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