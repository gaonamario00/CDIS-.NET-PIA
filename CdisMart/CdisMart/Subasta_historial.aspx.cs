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
    public partial class Subasta_historial : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int AuctionId = int.Parse(Request.QueryString["pAuctionId"]);
                    cargarInfoProducto(AuctionId);
                    cargarTodoElHistorial(AuctionId);
                    cargarUsuarios(AuctionId);
                    cargarMisOfertas(AuctionId);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) Response.Redirect("~/Login.aspx");

            if (int.Parse(ddlUsuarios.SelectedValue) == 0)
            {
                cargarTodoElHistorial(int.Parse(Request.QueryString["pAuctionId"]));
            }
            else cargarHistorialPorUsuario(int.Parse(Request.QueryString["pAuctionId"]));
        }
        #endregion

        #region Metodos
        public void cargarUsuarios(int AuctionId)
        {
            int userId = 0;

            UserTable user = new UserTable();
            user = (UserTable)Session["Usuario"];
            userId = int.Parse(user.UserId.ToString());

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            User_DAL user_DAL = new User_DAL();

            var listUsers = subastaHistorial_BLL.cargarUsuariosPorSubasta(AuctionId, userId);

                ddlUsuarios.DataSource = listUsers;
                ddlUsuarios.DataTextField = "UserName";
                ddlUsuarios.DataValueField = "UserId";
                ddlUsuarios.DataBind();

                ddlUsuarios.Items.Insert(0, new ListItem("Todos", "0"));

        }

        public void cargarTodoElHistorial(int AuctionId)
        {
            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL ();
            var listHistorialCompleto = subastaHistorial_BLL.cargarHistorialPorSubasta(AuctionId);
            grd_historial.DataSource = listHistorialCompleto;
            grd_historial.DataBind();

            if (listHistorialCompleto.Count == 0)
            {
                lblUser.Visible = false;
                ddlUsuarios.Visible = false;
                lblListIsEmpty.Visible = true;
                lblListIsEmpty.Text = "No hay ofertas para este produto";
            }
        }

        public void cargarHistorialPorUsuario(int auctionId)
        {

            int userId = int.Parse(ddlUsuarios.SelectedValue);

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            var listHistorialPorUsuario = subastaHistorial_BLL.cargarHistorialPorUsuario(userId, auctionId);
            grd_historial.DataSource = listHistorialPorUsuario;
            grd_historial.DataBind();
        }

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

        public void cargarInfoProducto(int AuctionId)
        {
            Subastas_BLL subastas_BLL = new Subastas_BLL();

            Auction auction = new Auction();

            auction = subastas_BLL.cargarSubastaPorID(AuctionId);

            lblProductoName.Text = auction.ProductoName;
            lblDescription.Text = auction.Description;

        }

        public void cargarMisOfertas(int auctionId)
        {

            UserTable user = new UserTable();
            user = (UserTable)Session["Usuario"];

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            var listMisOfertas = subastaHistorial_BLL.cargarMiHistorialPorSubasta(int.Parse(user.UserId.ToString()), auctionId);
            if (listMisOfertas.Count > 0)
            {
                lblMisOfertas.Visible = true;
                grd_misOfertas.DataSource = listMisOfertas;
                grd_misOfertas.DataBind();
            }

        }

        #endregion

    }
}