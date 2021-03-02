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
    public class PedidoDAL
    {

        public List<Pedido> GetPedidos(string connectionString)
        {
            List<Pedido> PedidosList = new List<Pedido>();
            string sqlSelect = "SELECT idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio, avisar, total FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND CONVERT(VARCHAR,pe.fechaInicio,127) >= (CONVERT(VARCHAR(10),GETDATE(),121) + ' 01:00:00')";
            //string sqlSelect = "SELECT idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND pe.fechaInicio > CONVERT(smalldatetime,CONVERT(VARCHAR(10),GETDATE(),127),127)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        Pedido Pedido = new Pedido();//Creo una instancia de Pedido
                        Pedido.idPedido = Convert.ToInt32(dr["idPedido"]);
                        //toma el campo del datareader y se lo asigna a la propiedad IdPedido
                        Pedido.nombreCliente = Convert.ToString(dr["Nombre_de_Cliente"]);
                        Pedido.direccion = Convert.ToString(dr["direccion"]);
                        Pedido.nota = Convert.ToString(dr["nota"]);
                        Pedido.modoPago = Convert.ToString(dr["modoPago"]);
                        Pedido.estado = Convert.ToString(dr["Estado"]);
                        Pedido.fechaInicio = Convert.ToString(dr["fechaInicio"]);
                        Pedido.avisar = Convert.ToString(dr["avisar"]);
                        Pedido.total = Convert.ToDecimal(dr["total"]);
                        PedidosList.Add(Pedido); // Agrega el Pedido a la lista
                    }
                }
                con.Close();
            }
            return PedidosList;
        }
        public int CrearPedido(string connectionString, Pedido objPedido)
        {
            int idPedido = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CargarPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCliente", objPedido.nombreCliente);
                cmd.Parameters.AddWithValue("@direccion", objPedido.direccion);
                cmd.Parameters.AddWithValue("@modoPago", objPedido.modoPago);
                cmd.Parameters.AddWithValue("@nota", objPedido.nota);
                cmd.Parameters.AddWithValue("@atencion", objPedido.atencion);
                cmd.Parameters.AddWithValue("@total", objPedido.total);
                cmd.Parameters.AddWithValue("@avisar", objPedido.avisar);
                con.Open();
                idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            return idPedido;
        }
        public decimal GetTotalPedidos(string connectionString, int id)
        {
            decimal total = 0;
            string sqlSelect = "SELECT SUM(precio) AS total FROM DetallePedido WHERE id =" + id;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
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
            return total;
        }
        public decimal GetTotalPedidosTemporal(string connectionString)
        {
            decimal total = 0;
            string sqlSelect = "SELECT SUM(precio) AS total FROM DetallePedidoTemporal";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
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
            return total;
        } //GetPedidoDato
        public Pedido GetPedidoDato(string connectionString, int idpedido)
        {
            Pedido pedido = new Pedido();//Creo una instancia de Pedido
            string sqlSelect = "SELECT id,idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio, atencion,total FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND CONVERT(varchar,pe.fechaInicio,127) > '2021-01-04 01:00:00' AND idPedido = " + idpedido + "AND CONVERT(VARCHAR,fechaInicio,121) > (CONVERT(VARCHAR(10),GETDATE(),121) + ' 00:00:00')";
            //string sqlSelect = "SELECT idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND pe.fechaInicio > CONVERT(smalldatetime,CONVERT(VARCHAR(10),GETDATE(),127),127)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {

                        pedido.idPedido = Convert.ToInt32(dr["idPedido"]);//toma el campo del datareader y se lo asigna a la propiedad IdPedido
                        pedido.id = Convert.ToInt32(dr["id"]);
                        pedido.nombreCliente = Convert.ToString(dr["Nombre_de_Cliente"]);
                        pedido.direccion = Convert.ToString(dr["direccion"]);
                        pedido.nota = Convert.ToString(dr["nota"]);
                        pedido.modoPago = Convert.ToString(dr["modoPago"]);
                        pedido.estado = Convert.ToString(dr["Estado"]);
                        pedido.fechaInicio = Convert.ToString(dr["fechaInicio"]);
                        pedido.atencion = Convert.ToString(dr["atencion"]);
                        pedido.total = Convert.ToDecimal(dr["total"]);
                        // PedidosList.Add(Pedido); // Agrega el Pedido a la lista
                    }
                }
                con.Close();
            }
            return pedido;
        }

        public Pedido GetPedidoDatoId(string connectionString, int id)
        {
            Pedido pedido = new Pedido();//Creo una instancia de Pedido
            string sqlSelect = "SELECT id,idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio, atencion,total FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND CONVERT(varchar,pe.fechaInicio,127) > '2021-01-04 01:00:00' AND id = " + id + "AND CONVERT(VARCHAR,fechaInicio,121) > (CONVERT(VARCHAR(10),GETDATE(),121) + ' 00:00:00')";
            //string sqlSelect = "SELECT idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND pe.fechaInicio > CONVERT(smalldatetime,CONVERT(VARCHAR(10),GETDATE(),127),127)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {

                        pedido.idPedido = Convert.ToInt32(dr["idPedido"]);//toma el campo del datareader y se lo asigna a la propiedad IdPedido
                        pedido.id = Convert.ToInt32(dr["id"]);
                        pedido.nombreCliente = Convert.ToString(dr["Nombre_de_Cliente"]);
                        pedido.direccion = Convert.ToString(dr["direccion"]);
                        pedido.nota = Convert.ToString(dr["nota"]);
                        pedido.modoPago = Convert.ToString(dr["modoPago"]);
                        pedido.estado = Convert.ToString(dr["Estado"]);
                        pedido.fechaInicio = Convert.ToString(dr["fechaInicio"]);
                        pedido.atencion = Convert.ToString(dr["atencion"]);
                        pedido.total = Convert.ToDecimal(dr["total"]);
                        // PedidosList.Add(Pedido); // Agrega el Pedido a la lista
                    }
                }
                con.Close();
            }
            return pedido;
        }
        public int EditarPedido(string connectionString, Pedido objPedido)
        {
            int idPedido = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdatePedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objPedido.id);
                cmd.Parameters.AddWithValue("@nombreCliente", objPedido.nombreCliente);
                cmd.Parameters.AddWithValue("@direccion", objPedido.direccion);
                cmd.Parameters.AddWithValue("@modoPago", objPedido.modoPago);
                cmd.Parameters.AddWithValue("@estado", objPedido.estado);
                cmd.Parameters.AddWithValue("@nota", objPedido.nota);
                cmd.Parameters.AddWithValue("@atencion", objPedido.atencion);
                cmd.Parameters.AddWithValue("@total", objPedido.total);
                con.Open();
                idPedido = cmd.ExecuteNonQuery();
                con.Close();

            }
            return idPedido;
        }

        public void DeletePedido(string connectionString, int idpedido)
        {
            //int idPedido = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EliminaPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPedido", idpedido);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            // return idPedido;

        }

        //CambiarEstadoPedido
        public void CambiarEstado(string connectionString, int idpedido, int idEstado)
        {
            //int idPedido = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CambiarEstadoPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPedido", idpedido);
                cmd.Parameters.AddWithValue("@idEstado", idEstado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }///CambiarAviso
        public void CambiarAviso(string connectionString, int idpedido, string aviso)
        {
            //int idPedido = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CambiarAviso", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPedido", idpedido);
                cmd.Parameters.AddWithValue("@avisar", aviso);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<Pedido> FiltrarGridPedido(string connectionString, string codigo, string nombreCliente, string direccion, string fechaHora, string estado, string avisar, string modoPago)
        {
            List<Pedido> PedidosList = new List<Pedido>();
            string spSelect = "FiltrarGridPedido";
            //string sqlSelect = "SELECT idPedido,nombreCliente AS Nombre_de_Cliente,direccion,nota,modoPago, peE.descripcion AS Estado, fechaInicio FROM Pedido pe, PedidoEstado peE WHERE pe.idEstado = peE.idEstado AND pe.fechaInicio > CONVERT(smalldatetime,CONVERT(VARCHAR(10),GETDATE(),127),127)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spSelect, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@fechHora", fechaHora);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@avisar", avisar);
                cmd.Parameters.AddWithValue("@modoPago", modoPago);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) // reader no esta vacio
                {
                    while (dr.Read()) // lee mientras se pueda leer el reader(dr)
                    {
                        Pedido Pedido = new Pedido();//Creo una instancia de Pedido
                        Pedido.idPedido = Convert.ToInt32(dr["idPedido"]);
                        //toma el campo del datareader y se lo asigna a la propiedad IdPedido
                        Pedido.nombreCliente = Convert.ToString(dr["nombreCliente"]);
                        Pedido.direccion = Convert.ToString(dr["direccion"]);
                        Pedido.nota = Convert.ToString(dr["nota"]);
                        Pedido.modoPago = Convert.ToString(dr["modoPago"]);
                        Pedido.estado = Convert.ToString(dr["Estado"]);
                        Pedido.fechaInicio = Convert.ToString(dr["fechaInicio"]);
                        Pedido.avisar = Convert.ToString(dr["avisar"]);
                        Pedido.total = Convert.ToDecimal(dr["total"]);
                        PedidosList.Add(Pedido); // Agrega el Pedido a la lista
                    }
                }
                con.Close();
            }
            return PedidosList;
        }
    }
}

