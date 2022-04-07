using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart
{
    public partial class User_Alta : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistrarse_Click(object sender, EventArgs e)
        {
            agregarUsuario();
        }
        #endregion

        #region Metodos

        public void agregarUsuario()
        {
            lblUserNameExist.Visible = false;
            lblPass.Visible = false;

            if (!TextPassword.Text.Equals(TextPassword2.Text))
            {
                lblPass.Text = "Las contraseñas no coinciden";
                lblPass.Visible = true;
            }
            else
            {
                    User_BLL userBLL = new User_BLL();

                    UserTable user = new UserTable();

                    user.Email = TextEmail.Text;
                    user.Name = TextNombre.Text;
                    user.UserName = TextUsuario.Text;
                    user.Password = TextPassword.Text;
                    try
                    {
                        userBLL.agreagarUsuario(user);
                        limpiarCampos();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('Usuario agregado exitosamente!')", true);
                        Response.Redirect("Login.aspx");
                    }
                    catch (Exception e)
                    {
                        switch (e.Message)
                        {
                            case "USERNAME_EXIST":
                                lblUserNameExist.Text = "Nombre usuario ya existe, por favor ingrese otro";
                                lblUserNameExist.Visible = true;
                                break;
                            default:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('" + e.Message + "')", true);
                                break;
                        }
                    }
            }

        }

        public void limpiarCampos()
        {
            TextEmail.Text = "";
            TextNombre.Text = "";
            TextPassword.Text = "";
            TextPassword2.Text = "";
            TextUsuario.Text = "";
        }

        #endregion
    }
}