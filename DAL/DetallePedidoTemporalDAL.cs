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
    public class DetallePedidoTemporalDAL
    {
        public List<DetallePedidoTemporal> GetDetallePedidoTemporal(string connectionString)
        {
            List<Entidades.DetallePedidoTemporal> DetallePedidoTemporalList = new List<Entidades.DetallePedidoTemporal>();
            string sqlSelect = "SELECT * FROM [dbo].[DetallePedidoTemporal]";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        Entidades.DetallePedidoTemporal objDetallePedidoTemporal = new Entidades.DetallePedidoTemporal();//Creo una instancia de DetallePedidoTemporal
                        objDetallePedidoTemporal.idDetalle = Convert.ToInt32(dr["idDetalle"]);
                        objDetallePedidoTemporal.tipo = Convert.ToString(dr["tipo"]);                       
                        objDetallePedidoTemporal.variedad = Convert.ToString(dr["variedad"]);
                        objDetallePedidoTemporal.paraPizza = Convert.ToString(dr["paraPizza"]);
                        objDetallePedidoTemporal.cantidad = Convert.ToInt32(dr["cantidad"]);
                        objDetallePedidoTemporal.precio = Convert.ToDecimal(dr["precio"]);
                        DetallePedidoTemporalList.Add(objDetallePedidoTemporal); // Agrega el DetallePedidoTemporal a la lista
                    }

                }
                con.Close();
            }
            return DetallePedidoTemporalList;
        }

        public DetallePedidoTemporal GetDetallePedidoTemporalData(string connectionString, int idDetallePedidoTemporal)
        {

            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "  SELECT idDetalle, tipo, variedad, paraPizza, cantidad, precio FROM DetallePedidoTemporal WHERE idDetalle = " + idDetallePedidoTemporal;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DetallePedidoTemporal DetallePedidoTemporal = new DetallePedidoTemporal();
            if (dr != null)
            {
                while (dr.Read())
                {
                    DetallePedidoTemporal.idDetalle = Convert.ToInt32(dr["idDetalle"]);
                    DetallePedidoTemporal.tipo = Convert.ToString(dr["tipo"]);
                    DetallePedidoTemporal.variedad = Convert.ToString(dr["variedad"]);
                    DetallePedidoTemporal.paraPizza = Convert.ToString(dr["paraPizza"]);
                    DetallePedidoTemporal.cantidad = Convert.ToInt32(dr["cantidad"]);
                    DetallePedidoTemporal.precio = Convert.ToDecimal(dr["precio"]);
                }
            }
            con.Close(); // Cierra la conexion
            return DetallePedidoTemporal; // retorna el objeto


        }
        public int CrearDetallePedidoTemporal(string connectionString, DetallePedidoTemporal objDetallePedidoTemporal)
        {
            int idDetallePedidoTemporal;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CrearDetallePedidoTemporal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo", objDetallePedidoTemporal.tipo);
                cmd.Parameters.AddWithValue("@variedad", objDetallePedidoTemporal.variedad);
                cmd.Parameters.AddWithValue("@paraPizza", objDetallePedidoTemporal.paraPizza);
                cmd.Parameters.AddWithValue("@cantidad", objDetallePedidoTemporal.cantidad);
                cmd.Parameters.AddWithValue("@precio", objDetallePedidoTemporal.precio);
                con.Open();
                idDetallePedidoTemporal = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            return idDetallePedidoTemporal;
        }
        public void TruncatePedidoTemporalData(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "  TRUNCATE TABLE [DetallePedidoTemporal]";
            //string reindexar = "DBCC CHECKIDENT ('dbo.DetallePedidoTemporal', RESEED, 0);"
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.ExecuteReader();
            con.Close(); // Cierra la conexion
            //return DetallePedidoTemporal; // retorna el objeto
        }

        public void ReindexarPedidoTemporalData(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "DBCC CHECKIDENT('dbo.DetallePedidoTemporal', RESEED, 1)";          
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.ExecuteReader();
            con.Close(); // Cierra la conexion
            //return DetallePedidoTemporal; // retorna el objeto
        }
        public void EditarDetallePedidoTemporal(string connectionString, DetallePedidoTemporal objDetallePedidoTemporal)
        {
            //int idDetallePedidoTemporal;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditarDetallePedidoTemporal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalle", objDetallePedidoTemporal.idDetalle);
                cmd.Parameters.AddWithValue("@tipo", objDetallePedidoTemporal.tipo.ToUpper());
                cmd.Parameters.AddWithValue("@variedad", objDetallePedidoTemporal.variedad.ToUpper());
                cmd.Parameters.AddWithValue("@paraPizza", objDetallePedidoTemporal.paraPizza.ToUpper());
                cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(objDetallePedidoTemporal.cantidad));
                cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(objDetallePedidoTemporal.precio));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            //return idDetallePedidoTemporal;
        }

        public void EliminarDetallePedidoTemporal(string connectionString, int idDetallePedidoTemporal)
        {
            //int retorno;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarDetallePedidoTemporal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("idDetalle", idDetallePedidoTemporal));
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
    }
}
