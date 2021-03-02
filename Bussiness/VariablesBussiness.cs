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
    public class VariablesBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        VariablesDAL varDAL = new VariablesDAL();

        public string GetVariableData(string id)
        {
            return varDAL.GetVariableData(connectionString, id);
        }

        public void EditarVariable(Variable var)
        {
            varDAL.EditarVariable(connectionString, var);
        }

        public void EditarVariableValor(string id, string valor )
        {
            Variable var = new Variable();
            var.id = id;
            var.valor = valor;

            varDAL.EditarVariable(connectionString, var);
        }
    }
}
