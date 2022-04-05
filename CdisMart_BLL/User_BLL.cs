using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class User_BLL
    {

        //public UserTable consultarUsuario(string userName, string password)
        //{
        //    User_DAL user = new User_DAL();

        //    return user.consultarUsuario(userName, password);
        //}

        public DataTable consultarUsuario(string userName, string password)
        {
            User_DAL user = new User_DAL();
            return user.consultarUsuario(userName, password);
        }

        public void agreagarUsuario(UserTable newUser)
        {
            User_DAL user = new User_DAL();
            user.agregarUsuario(newUser);
        }

    }
}
