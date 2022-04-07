using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class User_DAL
    {
        CdisMartEntities model;

        public User_DAL()
        {
            model = new CdisMartEntities();
        }

        public void agregarUsuario(UserTable newUser)
        {
            model.UserTable.Add(newUser);
            model.SaveChanges();
        }

        public UserTable consultarUsuario(string UserName, string pass)
        {

            var user  = (from usuario in model.UserTable
                        where usuario.UserName.Equals(UserName)
                        where usuario.Password.Equals(pass)
                        select usuario).FirstOrDefault();

            return user;

        }

        public List<UserTable> obtenerUsuarios()
        {
            return model.UserTable.ToList();
        }

    }
}
