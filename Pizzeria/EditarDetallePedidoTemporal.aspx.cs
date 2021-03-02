using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness;
using Entidades;

namespace Pizzeria
{
    public partial class EditarDetallePedidoTemporal : System.Web.UI.Page
    {
        int idDetalle=0;
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idDetalle"] != "" && Request.QueryString["id"] != "")
            {
                idDetalle = Convert.ToInt32(Request.QueryString["idDetalle"]);
                id = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("NuevoPedido.aspx");
            }
            if (!IsPostBack)
            {
                FillDetallePedidoData();
            }
        }
        private void FillDetallePedidoData()
        {
            DetallePedidoTemporalBussiness temBiz = new DetallePedidoTemporalBussiness();
            DetallePedidoTemporal dePeTem = new DetallePedidoTemporal();
            dePeTem = temBiz.GetDetallePedidoTemporalData(idDetalle);
            this.txtIdDetalle.Text = Convert.ToString(dePeTem.idDetalle);
            this.txtTipo.Text = dePeTem.tipo;
            this.txtMenu.Text = dePeTem.variedad;
            this.txtParaPizza.Text = dePeTem.paraPizza;
            this.txtCantidad.Text = Convert.ToString(dePeTem.cantidad);
            this.txtPrecio.Text = Convert.ToString(dePeTem.precio);
            int cantidad = 0;
            cantidad = Convert.ToInt32(dePeTem.cantidad);
            Session["VariableSession"] = cantidad;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad=0;
            DetallePedidoTemporalBussiness detallePeTemBuss = new DetallePedidoTemporalBussiness();
            DetallePedidoTemporal pedidoTem = new DetallePedidoTemporal();
            pedidoTem.idDetalle = Convert.ToInt32(this.txtIdDetalle.Text);
            pedidoTem.tipo = this.txtTipo.Text;
            pedidoTem.variedad = this.txtMenu.Text;
            pedidoTem.paraPizza = this.txtParaPizza.Text;
            pedidoTem.cantidad = Convert.ToInt32(this.txtCantidad.Text);
            if (Session["VariableSession"] != null)
            {
                cantidad = (int)Session["VariableSession"];    
            }
            decimal variable = Convert.ToDecimal(this.txtPrecio.Text);
            pedidoTem.precio = (Convert.ToDecimal(this.txtPrecio.Text) / cantidad) * pedidoTem.cantidad;
            detallePeTemBuss.EditarDetallePedidoTemporal(pedidoTem);
            Response.Redirect("NuevoPedido.aspx");
            //FillDetallePedidoGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoPedido.aspx");
        }
    }
}