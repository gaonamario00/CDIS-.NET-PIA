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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('Usuario agregado exitosamente!')", true);
            Response.Redirect("Login.aspx");
        }
        #endregion

        #region Metodos

        public void agregarUsuario()
        {
            if (!TextPassword.Text.Equals(TextPassword2.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('Las contraseñas no coinciden')", true);
            }
            else
            {

                if (verificarCampos())
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
                    }
                    catch (Exception e)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('"+e.Message+"')", true);
                    }
                }
                else Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta Usuario", "alert('Campo(s) incorrectos')", true);

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

        public Boolean verificarCamposVacios()
        {
            if (TextNombre.Text.Equals("") || TextUsuario.Text.Equals("") || TextPassword.Text.Equals("") || TextPassword2.Text.Equals(""))
            {
                return false;
            }
            else return true;
        }

        public Boolean verificarCampos()
        {
            if(verificarEmail() && verificarCamposVacios())
            return true;
            else return false;
        }

        public Boolean verificarEmail()
        {
            string pattern = @"[a-z]+[0-9]*@[a-z]+[.]com";
            Match m = Regex.Match(TextEmail.Text, pattern);
            if (m.Success) return true;
            else return false;
        }

       

        #endregion
    }
}