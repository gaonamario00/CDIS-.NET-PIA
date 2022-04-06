using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart.CdisMart
{
    public partial class Subasta_detalle : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int AutionId = int.Parse(Request.QueryString["pAuctionId"]);
                    cargarSubastaPorID(AutionId);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        //protected void btnPrueba_Click(object sender, EventArgs e)
        //{
        //    //lblInfo.Visible = false;
        //}

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

        public void cargarSubastaPorID(int AuctionId)
        {
            Subastas_BLL subastas_BLL = new Subastas_BLL();
            Auction auction = new Auction();
           auction = subastas_BLL.cargarSubastaPorID(AuctionId);

            lblID.Text = auction.AuctionId.ToString();
            lblName.Text = auction.ProductoName;
            lblDescription.Text = auction.Description;
            lblFechaInicio.Text = auction.StartDate.ToString();
            lblFechaFin.Text = auction.EndDate.ToString();
            lblWinner.Text = auction.Winner.ToString();
            lblUserId.Text = auction.UserId.ToString();

            verificarUsuario(int.Parse(auction.UserId.ToString()));

        }

        public void verificarUsuario(int idUserAuction)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Usuario"];

            int idUserCurrent = int.Parse(dt.Rows[0]["UserId"].ToString());

            if(idUserCurrent == idUserAuction)
            {
                lblOfertaInfo.Visible=false;
                lblOferta.Visible = false;
                TextOferta.Visible=false;
                lblUserOferta.Visible=true;
            }
        }

        #endregion

    }
}