using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class TipoMenuDAL
    {
        public List<TipoMenu> GetDatosTipo(string connectionString, int idTipo)
        {
            List<TipoMenu> ListTipoMenu = new List<TipoMenu>();
            string sqlSelect = "SELECT tipo FROM TipoMenu WHERE idTipo = " + idTipo;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr!=null)
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        TipoMenu tipoMenu = new TipoMenu();
                        //tipoMenu.idTipo = Convert.ToInt32(dr["idTipo"]);
                        tipoMenu.tipo = Convert.ToString(dr["tipo"]);
                        ListTipoMenu.Add(tipoMenu);
                    }
                }
            }
            return ListTipoMenu;
        }
        public List<TipoMenu> GetTipos(string connectionString)
        {
            List<TipoMenu> ListTipoMenu = new List<TipoMenu>();
            string sqlSelect = "SELECT tipo FROM TipoMenu";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        TipoMenu tipoMenu = new TipoMenu();
                        //tipoMenu.idTipo = Convert.ToInt32(dr["idTipo"]);
                        tipoMenu.tipo = Convert.ToString(dr["tipo"]);
                        ListTipoMenu.Add(tipoMenu);
                    }
                }
            }
            return ListTipoMenu;
        }
    }
}
