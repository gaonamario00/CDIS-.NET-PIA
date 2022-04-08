using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using CdisMart_DAL;

namespace CdisMart
{
    public class TemaCdisMart: System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                UserTable user = new UserTable();
                user = (UserTable)Session["Usuario"];

                string nombre = user.UserName;

                if (nombre.Equals("Mario"))
                {
                    Page.Theme = "Tema2";
                }
                else
                {
                    Page.Theme = "Tema1";
                }
            }
        }

    }
}