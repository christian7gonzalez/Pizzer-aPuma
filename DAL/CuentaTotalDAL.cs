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
    public class CuentaTotalDAL
    {
        public string CalcularTotal(string connectionString, string desde, string hasta)
        {
            decimal total = 0 ;
            string querySQL = "SELECT SUM(total) AS total FROM Pedido WHERE CONVERT(VARCHAR, fechaInicio, 121) BETWEEN '" + desde + "' AND '" + hasta + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(querySQL, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@fechaIngreso", desde);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //if (dr["total"] != DBNull.Value)
                //{
                //    total = Convert.ToDecimal(dr["total"]);
                //}
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        if (dr["total"] != DBNull.Value)
                        {
                            total = Convert.ToDecimal(dr["total"]);
                        }
                    }
                }
            
                con.Close();
               

            }
            return Convert.ToString(total);
        }
    }
}
