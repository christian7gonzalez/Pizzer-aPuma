using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Bussiness;

namespace Pizzeria
{
    public partial class NuevoMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MenuBussiness Menubiz = new MenuBussiness();
            Entidades.Menu objMenu = new Entidades.Menu();
            objMenu.nombreMenu = this.txtNombreMenu.Text.ToUpper();
            objMenu.tipo = this.txtTipo.Text.ToUpper();
            objMenu.mDescripcion = this.txtDescripcion.Text.ToUpper();
            objMenu.precio = Convert.ToDecimal(this.txtPrecio.Text);

            Menubiz.CrearMenu(objMenu);
            Response.Redirect("Menus.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menus.aspx");
        }
    }
}