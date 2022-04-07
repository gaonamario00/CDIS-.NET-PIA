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
                    cargarUsuarios(AuctionId);
                    cargarHistorialPorUsuario();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarHistorialPorUsuario();
        }
        #endregion

        #region Metodos
        public void cargarUsuarios(int AuctionId)
        {
            int userId = 0;

            UserTable user = new UserTable();
            try
            {
                user = (UserTable)Session["Usuario"];
                userId = int.Parse(user.UserId.ToString());
            }
            catch { Response.Redirect("~/Login.aspx"); }
            

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();

            var listUsers = subastaHistorial_BLL.cargarUsuariosPorSubasta(AuctionId, userId);

            ddlUsuarios.DataSource = listUsers;
            ddlUsuarios.DataTextField = "UserId";
            ddlUsuarios.DataValueField = "UserId";             
            ddlUsuarios.DataBind();

            

            ddlUsuarios.Items.Insert(0, new ListItem ("Yo", userId.ToString()));

        }

        public void cargarHistorialPorUsuario()
        {

            if (Session["Usuario"] == null) Response.Redirect("~/Login.aspx");

            int userId = int.Parse(ddlUsuarios.SelectedValue);

            SubastaHistorial_BLL subastaHistorial_BLL = new SubastaHistorial_BLL();
            var listHistorialPorUsuario = subastaHistorial_BLL.cargarHistorialPorUsuario(userId);
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

        #endregion

    }
}