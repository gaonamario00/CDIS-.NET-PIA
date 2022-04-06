using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_DAL;
using CdisMart_BLL;
using System.Data;

namespace CdisMart.CdisMart
{
    public partial class Subasta_i : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                   
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarSubasta();
            limpiarCampos();
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

        public void agregarSubasta()
        {
            Auction subasta = new Auction();
            DataTable dt = new DataTable();


            Subastas_BLL subastas_BLL = new Subastas_BLL();

 
            subasta.ProductoName = TextName.Text;
            subasta.Description = TextDescription.Text;
            subasta.StartDate = Convert.ToDateTime(TextFechaInicio.Text);
            subasta.EndDate = Convert.ToDateTime(TextFechaFin.Text);

            try
            {
                dt = (DataTable)Session["Usuario"];
                subasta.UserId = int.Parse(dt.Rows[0]["UserId"].ToString());
            }
            catch { Response.Redirect("~/Login.aspx"); }


            subastas_BLL.agregarSubasta(subasta);
        }

        public void limpiarCampos()
        {
            TextName.Text = "";
            TextDescription.Text = "";
            TextFechaInicio.Text = "";
            TextFechaFin.Text = "";
        }

        #endregion
    }
}