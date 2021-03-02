using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MenuDAL
    {
        public List<Menu> GetMenus(string connectionString)
        {
            List<Menu> MenusList = new List<Menu>();
            string sqlSelect = "SELECT id,nombreMenu , tm.tipo , mDescripcion, precio FROM Menu me, TipoMenu tm WHERE me.idTipo = tm.idTipo";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        Menu objMenu = new Menu();//Creo una instancia de Menu
                        objMenu.id = Convert.ToInt32(dr["id"]);
                        objMenu.nombreMenu = Convert.ToString(dr["nombreMenu"]);
                        objMenu.tipo = Convert.ToString(dr["tipo"]);
                        objMenu.mDescripcion = Convert.ToString(dr["mDescripcion"]);
                        objMenu.precio = Convert.ToDecimal(dr["precio"]);
                        MenusList.Add(objMenu); // Agrega el Menu a la lista
                    }

                }
                con.Close();
            }
            return MenusList;
        }

        public Menu GetMenuData(string connectionString, int idMenu)
        {
           
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "  SELECT id, nombreMenu, tm.tipo, mDescripcion, precio FROM Menu me, TipoMenu tm WHERE id = " + idMenu;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Menu Menu = new Menu();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Menu.id = Convert.ToInt32(dr["id"]);
                    Menu.nombreMenu = Convert.ToString(dr["nombreMenu"]); //toma el campo del datareader y se lo asigna a la propiedad IdMenu
                    Menu.tipo = Convert.ToString(dr["tipo"]);
                    Menu.mDescripcion = Convert.ToString(dr["mDescripcion"]);
                    Menu.precio = Convert.ToDecimal(dr["precio"]);
                }
            }
            con.Close(); // Cierra la conexion
            return Menu; // retorna el objeto
        }
        public Menu GetMenuDataTipo(string connectionString, string nombreMenu)
        {

            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT id, nombreMenu, tm.tipo, mDescripcion, precio FROM Menu AS me, TipoMenu AS tm WHERE me.idTipo = tm.idTipo AND nombreMenu = '" + nombreMenu + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Menu Menu = new Menu();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Menu.id = Convert.ToInt32(dr["id"]);
                    Menu.nombreMenu = Convert.ToString(dr["nombreMenu"]); //toma el campo del datareader y se lo asigna a la propiedad IdMenu
                    Menu.tipo = Convert.ToString(dr["tipo"]);
                    Menu.mDescripcion = Convert.ToString(dr["mDescripcion"]);
                    Menu.precio = Convert.ToDecimal(dr["precio"]);
                }
            }
            con.Close(); // Cierra la conexion
            return Menu; // retorna el objeto
        }
        public int CrearMenu(string connectionString, Menu objMenu)
        {
            int idMenu;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CrearMenu",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreMenu", objMenu.nombreMenu);
                cmd.Parameters.AddWithValue("@mDescripcion", objMenu.mDescripcion);
                cmd.Parameters.AddWithValue("@tipo", objMenu.tipo.ToUpper());
                cmd.Parameters.AddWithValue("@precio", objMenu.precio);
                con.Open();
                idMenu = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            return idMenu;
        }

        public int EditarMenu(string connectionString, Menu objMenu)
        {
            int idMenu;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditarMenu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objMenu.id);
                cmd.Parameters.AddWithValue("@nombreMenu", objMenu.nombreMenu);
                cmd.Parameters.AddWithValue("@mDescripcion", objMenu.mDescripcion);
                cmd.Parameters.AddWithValue("@tipo", objMenu.tipo.ToUpper());
                cmd.Parameters.AddWithValue("@precio", objMenu.precio);
                con.Open();
                idMenu = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            return idMenu;
        }

        public void EliminarMenu(string connectionString, int idMenu)
        {
            //int retorno;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarMenu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", idMenu));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //retorno = cmd.ExecuteNonQuery();
                    con.Close();
                }
                //return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> FiltrarMenu(string connectionString, string nombreMenu, string tipo)
        {
            List<Menu> listaMenu = new List<Menu>();
           SqlConnection con = new SqlConnection(connectionString);
            string spSQL = "FiltrarGridMenu";
            con.Open();
            SqlCommand cmd = new SqlCommand(spSQL, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nombreMenu", nombreMenu);
            cmd.Parameters.AddWithValue("tipo", tipo);
            SqlDataReader dr = cmd.ExecuteReader();
            Menu Menu = new Menu();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Menu objMenu = new Menu();//Creo una instancia de Menu
                    objMenu.id = Convert.ToInt32(dr["id"]);
                    objMenu.nombreMenu = Convert.ToString(dr["nombreMenu"]);
                    objMenu.tipo = Convert.ToString(dr["tipo"]);
                    objMenu.mDescripcion = Convert.ToString(dr["mDescripcion"]);
                    objMenu.precio = Convert.ToDecimal(dr["precio"]);
                    listaMenu.Add(objMenu); // Agrega el Menu a la lista
                }
            }
            con.Close(); // Cierra la conexion
            return listaMenu; // retorna el objeto
        }
    }
}
