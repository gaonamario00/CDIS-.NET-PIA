using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_BLL;

namespace CdisMart
{
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/CdisMart/User_Alta.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('El usuario y/o la contraseña son invalidos!')", true);
            }
        }

        #endregion

        #region Metodos


        public bool usuarioValido()
        {
            bool acceso = false;

            User_BLL usuarioBLL = new User_BLL();
            DataTable dtUsuario = new DataTable();

            dtUsuario = usuarioBLL.consultarUsuario(TextUsuario.Text, TextPassword.Text);

            if (dtUsuario.Rows.Count > 0)
            {
                Session["Usuario"] = dtUsuario;
                acceso = true;

            }

            return acceso;
        }

        #endregion
    }
}