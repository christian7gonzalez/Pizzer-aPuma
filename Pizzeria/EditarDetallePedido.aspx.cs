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
    public partial class EditarDetallePedido : System.Web.UI.Page
    {
        int id = 0;
        int idDetalle = 0;
        int idPedido = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idDetalle"] != "" && Request.QueryString["id"] !="")
            {
                idDetalle = Convert.ToInt32(Request.QueryString["idDetalle"]);
                id = Convert.ToInt32(Request.QueryString["id"]);
                PedidoBussiness pbuss = new PedidoBussiness();
                Pedido pedi = new Pedido();
                pedi = pbuss.GetPedidoDatoId(id);
                idPedido = pedi.idPedido;
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
            DetallePedidoBussiness detalleBiz = new DetallePedidoBussiness();
            DetallePedido dePe = new DetallePedido();
            dePe = detalleBiz.GetDetallePedidoData(idDetalle, id);
            this.txtIdDetalle.Text = Convert.ToString(dePe.idDetalle);
            this.txtTipo.Text = dePe.tipo;
            this.txtMenu.Text = dePe.variedad;
            this.txtParaPizza.Text = dePe.paraPizza;
            this.txtCantidad.Text = Convert.ToString(dePe.cantidad);
            this.txtPrecio.Text = Convert.ToString(dePe.precio);
            int cantidad = 0;
            cantidad = Convert.ToInt32(dePe.cantidad);
            Session["VariableSession"] = cantidad;
            
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            DetallePedidoBussiness detallePeBuss = new DetallePedidoBussiness();
            DetallePedido pedido = new DetallePedido();
            pedido.id = id;
            pedido.idDetalle = Convert.ToInt32(this.txtIdDetalle.Text);
            pedido.tipo = this.txtTipo.Text;
            pedido.variedad = this.txtMenu.Text;
            pedido.paraPizza = this.txtParaPizza.Text;
            pedido.cantidad = Convert.ToInt32(this.txtCantidad.Text);
            if (Session["VariableSession"] != null)
            {
                cantidad = (int)Session["VariableSession"];
            }
           
            decimal variable = Convert.ToDecimal(this.txtPrecio.Text);
            pedido.precio = (Convert.ToDecimal(this.txtPrecio.Text) / cantidad) * pedido.cantidad;
            detallePeBuss.EditarDetallePedido(pedido);
            Response.Redirect("EditarPedido.aspx?idpedido=" + idPedido);
            //FillDetallePedidoGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPedido.aspx?idpedido=" + idPedido);
        }
    }
}