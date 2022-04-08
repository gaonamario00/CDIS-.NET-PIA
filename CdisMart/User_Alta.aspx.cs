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
            lblError.Visible = false;
            imgWarning.Visible = false;

            if (ValidarCampos())
            {



            if (!TextPassword.Text.Equals(TextPassword2.Text))
            {
                    imgWarning.Visible = true;
                    lblError.Text = "Las contraseñas no coinciden";
                    lblError.Visible = true;
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
                                imgWarning.Visible = true;
                                lblError.Text = "Nombre usuario ya existe";
                                lblError.Visible = true;
                                break;
                            default:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('" + e.Message + "')", true);
                                break;
                        }
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

        public Boolean ValidarCampos()
        {
            if (TextEmail.Text.Equals("") ||
                TextNombre.Text.Equals("") ||
                TextPassword.Text.Equals("") ||
                TextPassword2.Text.Equals("") ||
                TextUsuario.Text.Equals("") )
            {
                imgWarning.Visible = true;
                lblError.Text = "Todos los campos son obligatorios<br/>";
                lblError.Visible = true;
                return false;
            }

            if(TextNombre.Text.Length > 50)
            {
                imgWarning.Visible = true;
                lblError.Text = "Nombre no debe superar los 50 caracteres<br/>";
                lblError.Visible = true;
                return false;
            }

            string pattern = @"[a-z]+[0-9]*@[a-z]+[.][a-z]+";
            Match m = Regex.Match(TextEmail.Text, pattern);
            if (!m.Success)
            {
                imgWarning.Visible = true;
                lblError.Text = "Formato de email incorrecto<br/>";
                lblError.Visible = true;
                return false;
            }

            

             string patternUserName = @"^[a-zA-Z0-9]{4,10}";
             Match u = Regex.Match(TextUsuario.Text, patternUserName);
            if (!u.Success || TextUsuario.Text.Length < 4)
            {
                imgWarning.Visible = true;
                lblError.Text = "Formato de Nombre de usuario incorrecto<br/>";
                lblError.Visible = true;
                return false;
            }

            string patternPass = @"^[a-zA-Z0-9]{6,10}";
            Match p = Regex.Match(TextPassword.Text, patternPass);
            if (!p.Success || TextPassword.Text.Length < 6)
            {
                imgWarning.Visible = true;
                lblError.Text = "Formato de contraseña incorrecto<br/>";
                lblError.Visible = true;
                return false;
            }

            return true;
        }

        #endregion
    }
}