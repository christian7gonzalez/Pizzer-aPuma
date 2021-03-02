using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using DAL;

namespace Bussiness
{
    public class PedidoBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        PedidoDAL PedidoDAL = new PedidoDAL();
        //
        public List<Pedido> GetPedidos()
        {
            return PedidoDAL.GetPedidos(connectionString);
        }
        public int CrearPedido(Pedido pedido)
        {
            return PedidoDAL.CrearPedido(connectionString, pedido);
        }
        public decimal GetTotalPedidos(int id) 
        {
            return PedidoDAL.GetTotalPedidos(connectionString, id);
        }
        public decimal GetTotalPedidosTemporal() 
        {
            return PedidoDAL.GetTotalPedidosTemporal(connectionString);
        }
        public Pedido GetPedidoDato(int idPedido)
        {
            return PedidoDAL.GetPedidoDato(connectionString, idPedido);
        }
        public Pedido GetPedidoDatoId(int id)
        {
            return PedidoDAL.GetPedidoDatoId(connectionString, id);
        }
        //EditarPedido
        public int EditarPedido(Pedido pedido)
        {
            return PedidoDAL.EditarPedido(connectionString, pedido);
        }
        
        public void DeletePedido(int idpedido)
        {
             PedidoDAL.DeletePedido(connectionString, idpedido);
        }

        public void CambiarEstado( int idPedido, int idEstado)
        {
            PedidoDAL.CambiarEstado(connectionString, idPedido, idEstado);
        }
        public void CambiarAviso(int idPedido, string avisar)
        {
            PedidoDAL.CambiarAviso(connectionString, idPedido, avisar);
        }
        public List<Pedido> FiltrarGridPedido(string codigo, string nombreCliente, string direccion, string fechaHora, string estado, string avisar, string modoPago)
        {
            return PedidoDAL.FiltrarGridPedido(connectionString, codigo, nombreCliente, direccion, fechaHora, estado, avisar, modoPago);
        }
    }
}
