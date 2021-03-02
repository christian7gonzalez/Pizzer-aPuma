using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {
        public int id { get; set; }
        public string nombreMenu { get; set; }       
        public string tipo { get; set; }
        public string mDescripcion { get; set; }
        public decimal precio { get; set; }

    }
}
