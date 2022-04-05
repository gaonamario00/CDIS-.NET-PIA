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

        //public UserTable consultarUsuario(string userName, string pass)
        //{
        //    var user = (from mUser in model.UserTable
        //               where mUser.UserName == userName && mUser.Password == pass
        //               select mUser).FirstOrDefault();
        //    return user;
        //}

        public void agregarUsuario(UserTable newUser)
        {
            model.UserTable.Add(newUser);
            model.SaveChanges();
        }

        public DataTable consultarUsuario(string UserName, string pass)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=MARIOGAONA\SQLEXPRESS;Database=CdisMart;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = con;

            command.Parameters.AddWithValue("pUserName", UserName);
            command.Parameters.AddWithValue("pContrasena", pass);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            con.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            con.Close();

            return dtUsuario;
        }

    }
}
