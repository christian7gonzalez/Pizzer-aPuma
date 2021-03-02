using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using Entidades;
using System.Drawing;

namespace Pizzeria
{
    public partial class Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               
            }
           
        }

        private string FechaEstructuradoSQL(string fecha)
        {
            string dia = null;
            string mes = null;
            string año = null;
            string hora = null;
            int longitud = fecha.Length;
            dia = fecha.Substring(0, 2);
            mes = fecha.Substring(3, 2);
            año = fecha.Substring(6, 4);
            hora = " 00:00:00";
            fecha = año + '-' + mes + '-' + dia + hora;
            return fecha;
        }


        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            string fechaDesde = null;
            string fechaHasta = null;

            string[] Desde = Request["Desde"].Split(',');
            string dateDesde = Desde[0];
            string horaDesde = Desde[1];
            string[] hasta = Request["Hasta"].Split(',');
            string diaHasta = hasta[0];
            string horaHasta = hasta[1];
            if (dateDesde != "" && horaDesde != "" && diaHasta != "" && horaHasta != "")
            {
                fechaDesde = dateDesde + " " + horaDesde + ":00";
                fechaHasta = diaHasta + " " + horaHasta + ":00";
                CuentaTotalBussiness ctotal = new CuentaTotalBussiness();
                this.lblTotal.Text = "$" + ctotal.CalcularTotal(fechaDesde, fechaHasta);
                this.lblTotal.ForeColor = Color.Red;
                this.lblTotal.Font.Bold = true;


            }
            else
            {
                string vtn = "Alertas();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupAleta", vtn, true);
            }
        }
    }
}