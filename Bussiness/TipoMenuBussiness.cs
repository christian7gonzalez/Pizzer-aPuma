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
    public class TipoMenuBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        TipoMenuDAL tipoMenuDAL = new TipoMenuDAL();
        public List<TipoMenu> GetDatosTipo( int idTipo)
        {
            return tipoMenuDAL.GetDatosTipo(connectionString, idTipo);
        }

        public List<TipoMenu> GetTipos()
        {
            return tipoMenuDAL.GetTipos(connectionString);
        }
    }
}
