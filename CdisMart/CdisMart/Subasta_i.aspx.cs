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
    public partial class Subasta_i : TemaCdisMart, IAcceso
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
            lblError.Visible = false;
            imgWarning.Visible = false;

            if (!verificarCampos()) return;

            Auction subasta = new Auction();
            UserTable user = new UserTable();

            


            Subastas_BLL subastas_BLL = new Subastas_BLL();

 
            subasta.ProductoName = TextName.Text;
            subasta.Description = TextDescription.Text;
            subasta.StartDate = Convert.ToDateTime(TextFechaInicio.Text);
            subasta.EndDate = Convert.ToDateTime(TextFechaFin.Text);

            try
            {
                user = (UserTable)Session["Usuario"];
                subasta.UserId = int.Parse(user.UserId.ToString());
            }
            catch { Response.Redirect("~/Login.aspx"); }

            try
            {
                subastas_BLL.agregarSubasta(subasta);
                limpiarCampos();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ofertar", "alert('Subasta realizada con exito!')", true);
            }
            catch (Exception e)
            {
                imgWarning.Visible = true;
                lblError.Text = e.Message+"<br />";
                lblError.Visible = true;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ofertar", "alert('"+e.Message+"')", true);
            }
        }

        public void limpiarCampos()
        {
            TextName.Text = "";
            TextDescription.Text = "";
            TextFechaInicio.Text = "";
            TextFechaFin.Text = "";
        }

        public Boolean verificarCampos()
        {

            if(TextName.Text.Equals("") ||
                TextDescription.Text.Equals("") ||
                TextFechaFin.Text.Equals("") ||
                TextFechaInicio.Text.Equals(""))
            {
                imgWarning.Visible = true;
                lblError.Text = "Debe de llenar todos los campos<br />";
                lblError.Visible = true;
                return false;
            }

            return true;
        }

        #endregion
    }
}