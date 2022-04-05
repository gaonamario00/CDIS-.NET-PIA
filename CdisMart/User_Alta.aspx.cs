using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        #endregion

        #region Metodos

        public void agregarUsuario()
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