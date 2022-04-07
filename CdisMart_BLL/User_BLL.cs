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

        public UserTable consultarUsuario(string userName, string password)
        {
            User_DAL user = new User_DAL();
            return user.consultarUsuario(userName, password);
        }

        public void agreagarUsuario(UserTable newUser)
        {
            User_DAL user_DAL = new User_DAL();

            List<UserTable> usuarios = new List<UserTable>();
            usuarios = user_DAL.obtenerUsuarios();

            bool userNameExist = false;

            foreach (UserTable usuar in usuarios)
            {
                if (usuar.UserName.Equals(newUser.UserName))
                {
                    userNameExist = true;
                }
            }

            if (!userNameExist)
            {
                User_DAL user = new User_DAL();
                user.agregarUsuario(newUser);
            }
            else throw new Exception("USERNAME_EXIST");

        }

    }
}
