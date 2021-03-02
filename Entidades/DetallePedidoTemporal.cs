using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedidoTemporal
    {
        public int idDetalle { get; set; }
        public string tipo { get; set; }
        public string variedad { get; set; }
        public string paraPizza { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
