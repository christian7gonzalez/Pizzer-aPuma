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
    public class DetallePedidoDAL
    {
        public void CargarDetallePedido (string connectionString, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CargarDetallePedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);             
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void EliminarDetallePedido(string connectionString, int id, int idDetalle)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM DetallePedido WHERE id = "+id +" AND idDetalle = "+ idDetalle, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        ///GetDetallePedidoDato
        public List<DetallePedido> GetDetallePedidoDato(string connectionString,int id)
        {
            List<Entidades.DetallePedido> DetallePedido = new List<Entidades.DetallePedido>();
            string sqlSelect = "SELECT * FROM [dbo].[DetallePedido] WHERE id=" +id;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        Entidades.DetallePedido objDetallePedido = new Entidades.DetallePedido();//Creo una instancia de DetallePedidoTemporal
                        objDetallePedido.id = Convert.ToInt32(dr["id"]);
                        objDetallePedido.tipo = Convert.ToString(dr["tipo"]);
                        objDetallePedido.variedad = Convert.ToString(dr["variedad"]);
                        objDetallePedido.paraPizza = Convert.ToString(dr["paraPizza"]);
                        objDetallePedido.cantidad = Convert.ToInt32(dr["cantidad"]);
                        objDetallePedido.precio = Convert.ToDecimal(dr["precio"]);
                        objDetallePedido.idDetalle = Convert.ToInt32(dr["idDetalle"]);
                        DetallePedido.Add(objDetallePedido); // Agrega el DetallePedidoTemporal a la lista
                    }

                }
                con.Close();
            }
            return DetallePedido;
        }
        public DetallePedido GetDetallePedidoData(string connectionString, int idDetalle, int id)
        {
            DetallePedido DetallePedido = new DetallePedido();
            string sqlSelect = "SELECT * FROM [dbo].[DetallePedido] WHERE idDetalle=" + idDetalle +" AND id =" + id;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        DetallePedido.id = Convert.ToInt32(dr["id"]);
                        DetallePedido.tipo = Convert.ToString(dr["tipo"]);
                        DetallePedido.variedad = Convert.ToString(dr["variedad"]);
                        DetallePedido.paraPizza = Convert.ToString(dr["paraPizza"]);
                        DetallePedido.cantidad = Convert.ToInt32(dr["cantidad"]);
                        DetallePedido.precio = Convert.ToDecimal(dr["precio"]);
                        DetallePedido.idDetalle = Convert.ToInt32(dr["idDetalle"]);
                        DetallePedido.idPedido = Convert.ToInt32(dr["idPedido"]);
                    }
                }
                con.Close();
            }
            return DetallePedido;
        }
        public int AgregarDetallePedido(string connectionString, DetallePedido objDetallePedido)
        {
            int idDetallePedido = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AgregarDetallePedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objDetallePedido.id);
                cmd.Parameters.AddWithValue("@tipo", objDetallePedido.tipo);
                cmd.Parameters.AddWithValue("@variedad", objDetallePedido.variedad);
                cmd.Parameters.AddWithValue("@paraPizza", objDetallePedido.paraPizza);
                cmd.Parameters.AddWithValue("@cantidad", objDetallePedido.cantidad);
                cmd.Parameters.AddWithValue("@precio", objDetallePedido.precio);
                con.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    idDetallePedido = Convert.ToInt32(cmd.ExecuteScalar());
                }
                
                con.Close();

            }
            return idDetallePedido;
        }
        //EditarDetallePedido
        public void EditarDetallePedido(string connectionString, DetallePedido objDetallePedido)
        {
            //int idDetallePedidoTemporal;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditarDetallePedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objDetallePedido.id);
                cmd.Parameters.AddWithValue("@idDetalle", objDetallePedido.idDetalle);
                cmd.Parameters.AddWithValue("@tipo", objDetallePedido.tipo.ToUpper());
                cmd.Parameters.AddWithValue("@variedad", objDetallePedido.variedad.ToUpper());
                cmd.Parameters.AddWithValue("@paraPizza", objDetallePedido.paraPizza.ToUpper());
                cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(objDetallePedido.cantidad));
                cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(objDetallePedido.precio));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            //return idDetallePedidoTemporal;
        }
    }
}
