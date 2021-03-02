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
    public class VariablesDAL
    {
        public string GetVariableData(string connectionString, string id)
        {

            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT * FROM Variables WHERE id= '" + id +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Variable variable = new Variable();
            if (dr != null)
            {
                while (dr.Read())
                {
                    variable.idVariable = Convert.ToInt32(dr["idVariable"]);
                    variable.id = Convert.ToString(dr["id"]); //toma el campo del datareader y se lo asigna a la propiedad IdMenu
                    variable.tipo = Convert.ToString(dr["tipo"]);
                    variable.valor = Convert.ToString(dr["valor"]);
                }
            }
            con.Close(); // Cierra la conexion
            return variable.valor; // retorna el objeto
        }

        public int InsertarVariableData(string connectionString, Variable objVariable)
        {

            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "INSERT INTO Variables VALUES(@tipo,@id,@valor) SELECT @@IDENTITY";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.Parameters.Add(new SqlParameter("@tipo", objVariable.tipo));
            cmd.Parameters.Add(new SqlParameter("@id", objVariable.id));
            cmd.Parameters.Add(new SqlParameter("@valor", objVariable.valor));
            int idVariable = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return idVariable;
           
        }
        public int EditarVariable(string connectionString, Variable objvariable)
        {
            int idvariable;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditarVariable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tipo", objvariable.tipo);
                cmd.Parameters.AddWithValue("@id", objvariable.id);
                cmd.Parameters.AddWithValue("@valor", objvariable.valor);
     
                con.Open();
                idvariable = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            return idvariable;
        }
    }
}
