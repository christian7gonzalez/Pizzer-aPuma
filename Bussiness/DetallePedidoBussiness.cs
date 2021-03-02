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
    public class DetallePedidoBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        DetallePedidoDAL detallePedidoDAL = new DetallePedidoDAL();
        public void CargarDetallePedido(int id)
        {
            detallePedidoDAL.CargarDetallePedido(connectionString, id);
        }
        public void EliminarDetallePedido(int id, int idDetalle)
        {
            detallePedidoDAL.EliminarDetallePedido(connectionString, id, idDetalle);
        }
        public List<DetallePedido> GetDetallePedidoDato(int id)
        {
            return detallePedidoDAL.GetDetallePedidoDato(connectionString, id);
        }
      
        public int AgregarDetallePedido(DetallePedido detallePedido)
        {
            return detallePedidoDAL.AgregarDetallePedido(connectionString, detallePedido);
        }
        //
        public DetallePedido GetDetallePedidoData(int idDetalle, int id)
        {
            return detallePedidoDAL.GetDetallePedidoData(connectionString, idDetalle, id);
        }
        //EditarDetallePedido
        public void EditarDetallePedido(DetallePedido detallePedido)
        {
            detallePedidoDAL.EditarDetallePedido(connectionString, detallePedido);
        }
    }
}
