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
    public class DetallePedidoTemporalBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;

        DetallePedidoTemporalDAL detallePedidoTem = new DetallePedidoTemporalDAL();
        public List<DetallePedidoTemporal> GetDetallePedidoTemporal()
        {
            return detallePedidoTem.GetDetallePedidoTemporal(connectionString);
        }
        public DetallePedidoTemporal GetDetallePedidoTemporalData(int idDetallePedidoTemporal)
        {
            return detallePedidoTem.GetDetallePedidoTemporalData(connectionString, idDetallePedidoTemporal);
        }

        public void CrearDetallePedidoTemporal(DetallePedidoTemporal detallePedTem)
        {
            detallePedidoTem.CrearDetallePedidoTemporal(connectionString, detallePedTem);
        }
        public void TruncatePedidoTemporalData()
        {
            detallePedidoTem.TruncatePedidoTemporalData(connectionString);
        }
        public void ReindexarPedidoTemporalData()
        {
            detallePedidoTem.ReindexarPedidoTemporalData(connectionString);
        }
        public void EliminarDetallePedidoTemporal(int detallePedTem)
        {
            detallePedidoTem.EliminarDetallePedidoTemporal(connectionString, detallePedTem);
        }
        public void EditarDetallePedidoTemporal(DetallePedidoTemporal detallePedTem)
        {
            detallePedidoTem.EditarDetallePedidoTemporal(connectionString, detallePedTem);
        }
    }
}
