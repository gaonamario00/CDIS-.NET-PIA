using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart
{
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            imgWarning.Visible = false;
            if (verificarCampos())
            {
            
                if (usuarioValido())
                {
                    Response.Redirect("~/CdisMart/Subastas_s.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('El usuario y/o la contraseña son invalidos!')", true);
                }
            }
        }


        #endregion

        #region Metodos


        public bool usuarioValido()
        {
            bool acceso = false;

            User_BLL usuarioBLL = new User_BLL();
            UserTable user = new UserTable();

            user = usuarioBLL.consultarUsuario(TextUsuario.Text, TextPassword.Text);

            if (user != null)
            {
                Session["Usuario"] = user;
                acceso = true;

            }

            return acceso;
        }

        public Boolean verificarCampos()
        {
            if (TextUsuario.Text.Equals("") || TextPassword.Text.Equals(""))
            {
                lblError.Text = "Debe de llenar todos los campos<br />";
                lblError.Visible = true;
                imgWarning.Visible = true;
                return false;
            }

            else return true;
        }

        #endregion

    }
}