﻿using System;
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
            TextOferta.Text = "0";
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
            lblWinner.Text =  auction.Winner.ToString();
            lblMejorOferta.Text = auction.HighestBid.ToString();
            lblUserId.Text = auction.UserId.ToString();

            verificarOferta(int.Parse(auction.UserId.ToString()), auction.EndDate);

            TextOferta.Text = "0";

        }

        public void verificarOferta(int idUserAuction, DateTime endDate)
        {

            int offerIsAvailable = DateTime.Compare(endDate, DateTime.Now);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["Usuario"];

            int idUserCurrent = int.Parse(dt.Rows[0]["UserId"].ToString());
            if (offerIsAvailable < 0)
            {
                lblFechaExpirada.Visible = true;
                lblOfertaInfo.Visible = false;
                lblOferta.Visible = false;
                TextOferta.Visible = false;
                btnAgregarApuesta.Visible = false;
            }
            if (idUserCurrent == idUserAuction)
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

            DataTable dt = new DataTable();

            int idUserCurrent = 0;

            try
            {
                dt = (DataTable)Session["Usuario"];
                idUserCurrent = int.Parse(dt.Rows[0]["UserId"].ToString());
            }
            catch { Response.Redirect("~/Login.aspx"); }


            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            AuctionRecord auctionRecord = new AuctionRecord();

            auctionRecord.AuctionId = int.Parse(lblID.Text);
            auctionRecord.UserId = idUserCurrent;
            auctionRecord.Amount = decimal.Parse(TextOferta.Text);
            auctionRecord.BidDate = DateTime.Now;

            try
            {
                decimal parametro;

                if (lblMejorOferta.Text.Equals(null) || lblMejorOferta.Text.Equals("")) parametro = 0;
                else parametro = decimal.Parse(lblMejorOferta.Text);

                subastaHistorial_BLL.agregarApuestaAHistorial(auctionRecord, parametro);

                lblMejorOferta.Text = auctionRecord.Amount.ToString();
                lblWinner.Text = auctionRecord.UserId.ToString();
                lblFueraDeRango.Visible = false;
                lblOfertaDebeSerMejor.Visible = false;
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ofertar", "alert('Ha ofertado una cantidad de " + TextOferta.Text + " a " + lblName.Text + "')", true);
            }
            catch (Exception e)
            {
                // 1 - Cantidad fuera de rango (0-1,000,000)
                // 2 - Cantidad menor a la mejor oferta
                // 3 - La subasta ha finalizado
                // 4 - No se le permite ofertar en esta subasta (el usuario es el propiertario de la subasta)

                switch (e.Message)
                {
                    case "1":
                        lblFueraDeRango.Visible = true;
                        break;
                    case "2":
                        lblOfertaDebeSerMejor.Visible = true;
                        break;
                    default:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + e.Message + "')", true);
                        break;
                }

            }


        }
        

        #endregion


    }
}