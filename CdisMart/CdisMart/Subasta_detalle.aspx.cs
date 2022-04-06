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
        protected void btnAgregarApuesta_Click(object sender, EventArgs e)
        {
            agregarApuestaAHistorial();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ofertar", "alert('Ha ofertado una cantidad de " +TextOferta.Text+" a "+lblName.Text+"')", true);
            //TextOferta.Text = "0";
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

            TextOferta.Text = "0";

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
                btnAgregarApuesta.Visible=false;
            }
        }

        public void agregarApuestaAHistorial()
        {
            //if (lblWinner)
            //{

            //}
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Usuario"];

            int idUserCurrent = int.Parse(dt.Rows[0]["UserId"].ToString());

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            AuctionRecord auctionRecord = new AuctionRecord();

            auctionRecord.AuctionId = int.Parse(lblID.Text);
            auctionRecord.UserId = idUserCurrent;
            auctionRecord.Amount = decimal.Parse(TextOferta.Text);
            auctionRecord.BidDate = DateTime.Now;

            subastaHistorial_BLL.agregarApuestaAHistorial(auctionRecord);

        }

        #endregion


    }
}