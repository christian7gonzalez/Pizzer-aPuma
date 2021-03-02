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
    public class CuentaTotalBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        CuentaTotalDAL cuentaTotal = new CuentaTotalDAL();
        public string CalcularTotal(string desde, string hasta)
        {
            return cuentaTotal.CalcularTotal(connectionString, desde, hasta);
        }
    }
}
