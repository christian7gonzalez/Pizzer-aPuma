using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
        public string nota { get; set; }
        public string modoPago { get; set; }
        public string estado { get; set; } 
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string atencion { get; set; }
        public decimal total { get; set; }
        public string avisar { get; set; }
    }
}
