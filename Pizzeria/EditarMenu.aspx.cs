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
    public partial class EditarMenu : System.Web.UI.Page
    {
        int idMenu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idMenu"] != "")
            {
                idMenu = Convert.ToInt32(Request.QueryString["idMenu"]);
            }
            else
            {
                Response.Redirect("Menus.aspx");
            }
            if (!IsPostBack)
            {
                FillMenuData();
            }
        }

        private void FillMenuData()
        {
            MenuBussiness MenuBiz = new MenuBussiness();
            Entidades.Menu menu = new Entidades.Menu();
            menu = MenuBiz.GetMenuData(idMenu);
            this.txtID.Text = Convert.ToString(menu.id);
            this.txtNombreMenu.Text = menu.nombreMenu;
            this.txtTipo.Text = menu.tipo;
            this.txtDescripcion.Text = menu.mDescripcion;
            this.txtPrecio.Text = Convert.ToString(menu.precio);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MenuBussiness menuBuss = new MenuBussiness();
            Entidades.Menu menu = new Entidades.Menu();
            menu.id = Convert.ToInt32(this.txtID.Text);
            menu.nombreMenu = this.txtNombreMenu.Text.ToUpper();
            menu.tipo = this.txtTipo.Text.ToUpper();
            menu.mDescripcion = this.txtDescripcion.Text.ToUpper();
            menu.precio = Convert.ToDecimal(this.txtPrecio.Text);

            menuBuss.EditarMenu(menu);
            Response.Redirect("Menus.aspx");
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menus.aspx");
        }
    }
}