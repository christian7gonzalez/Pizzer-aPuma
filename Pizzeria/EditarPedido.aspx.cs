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
    public partial class EditarPedido : System.Web.UI.Page
    {
        int id = 0;
        int idPedido = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["idpedido"] != "")
            {
                idPedido = Convert.ToInt32(Request.QueryString["idpedido"]);
                PedidoBussiness pbizz = new PedidoBussiness();
                Pedido pedido = new Pedido();
                pedido = pbizz.GetPedidoDato(idPedido);//pasar el idPedido a id para luego buscar el id en DetallePedido
                id = pedido.id;
            }
            else
            {
                Response.Redirect("Pedidos.aspx");
            }
            if (!IsPostBack)
            {
                FillDetallePedidoData();
            }
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("rblistModoPago", this.rbListModoPago.SelectedValue);
            varBuss.EditarVariableValor("rblistEstado", this.rbListEstado.SelectedValue);
            varBuss.EditarVariableValor("DropDownProducto", DropDownProducto.SelectedValue);
            varBuss.EditarVariableValor("DropDownVariedad", DropDownVariedad.SelectedValue);
            varBuss.EditarVariableValor("DropDownParaPizza", DropDownParaPizza.SelectedValue);

            if (DropDownProducto.SelectedValue == "Seleccione")
            {
                MostrarDropDownList(DropDownProducto);
            }
            else if (DropDownProducto.SelectedValue == "PIZZA")
            {
                MostrarDropDownList(DropDownVariedad);
                DropDownParaPizza.Visible = true;
            }
            else
            {
                MostrarDropDownList(DropDownVariedad);
                DropDownParaPizza.Visible = false;
            }
            DropDownListCargaTipoMenu(DropDownProducto);
            DropDownListCargaMenu(DropDownVariedad);
        }
        public void FillDetallePedidoData()
        {
            
            PedidoBussiness pbuss = new PedidoBussiness();
            Pedido pedido = new Pedido();
            pedido = pbuss.GetPedidoDato(idPedido);
            this.txtnombreCliente.Text = pedido.nombreCliente;
            this.txtdireccion.Text = pedido.direccion;
            this.txtnota.Text = pedido.nota;
            this.txtAtencion.Text = pedido.atencion;
            this.rbListModoPago.SelectedValue = pedido.modoPago;
            this.rbListEstado.SelectedValue = pedido.estado;
           
            FillDetallePedidoGrid();
            DetallePedidoBussiness dpbuss = new DetallePedidoBussiness();
            List<DetallePedido> listDetallePedido = new List<DetallePedido>();
            listDetallePedido = dpbuss.GetDetallePedidoDato(id);
            gridTipoProductoPedidosList.DataSource = listDetallePedido;
            gridTipoProductoPedidosList.DataBind();
            

        }
        private void FillTipoProductoPedidoGrid(ref int idTipo)
        {
            List<TipoMenu> TipoProductoList = new List<TipoMenu>();
            TipoMenuBussiness TipoProductoBuss = new TipoMenuBussiness();
            TipoProductoList = TipoProductoBuss.GetDatosTipo(idTipo);

            gridTipoProductoPedidosList.DataSource = TipoProductoList;
            gridTipoProductoPedidosList.DataBind();

        }
        private void FillDetallePedidoGrid()
        {
            DetallePedidoBussiness dpbuss = new DetallePedidoBussiness();
            List<DetallePedido> listDetallePedido = new List<DetallePedido>();
            listDetallePedido = dpbuss.GetDetallePedidoDato(id);
            PedidoBussiness peBuss = new PedidoBussiness();
            this.txtTotal.Text = Convert.ToString(peBuss.GetTotalPedidos(id));
            
            gridTipoProductoPedidosList.DataSource = listDetallePedido;
            gridTipoProductoPedidosList.DataBind();

        }
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gridTipoProductoPedidosList.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gridTipoProductoPedidosList, "Select$" + row.RowIndex.ToString(), true));
            }
            base.Render(writer);
        }
        protected void gridTipoProductoPedidosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='pointer';");
                e.Row.ToolTip = "Click en la fila para seleccionarla";
            }
        }

        private void DropDownListVisible(DropDownList DropDownList, string nombre)
        {
            DropDownList.SelectedIndex = DropDownList.Items.IndexOf(DropDownList.Items.FindByValue(nombre));
            if (DropDownList.SelectedIndex == 0)
            {
                DropDownVariedad.Visible = true;
            }
        }
        private void DropDownListCargaTipoMenu(DropDownList drowDownList)
        {

            List<TipoMenu> tipoMenuList = new List<TipoMenu>();
            TipoMenuBussiness tipoMenuBuss = new TipoMenuBussiness();
            tipoMenuList = tipoMenuBuss.GetTipos();
            drowDownList.Items.Clear();
            drowDownList.Items.Insert(0, new ListItem("--Seleccione--", "Seleccione"));
            int j = 1;
            for (int i = 0; i < tipoMenuList.Count; i++)
            {
                drowDownList.Items.Insert(j, new ListItem(tipoMenuList[i].tipo, tipoMenuList[i].tipo));
                j++;
            }
            VariablesBussiness varBuss = new VariablesBussiness();
            drowDownList.SelectedValue = varBuss.GetVariableData("DropDownProducto");
        }

        private void DropDownListCargaMenu(DropDownList drowDownList)
        {
            List<Entidades.Menu> tipoMenuList = new List<Entidades.Menu>();
            MenuBussiness MenuBuss = new MenuBussiness();
            tipoMenuList = MenuBuss.GetMenus();
            string ValorSeleccionado = DropDownProducto.SelectedValue;
            string SeleccionVariedad = DropDownVariedad.SelectedValue;
            drowDownList.Items.Clear();
            drowDownList.Items.Insert(0, new ListItem("Seleccione", "Seleccione"));
            int j = 1;
            for (int i = 0; i < tipoMenuList.Count; i++)
            {
                if (tipoMenuList[i].tipo == ValorSeleccionado)
                {
                    drowDownList.Items.Insert(j, new ListItem(tipoMenuList[i].nombreMenu, tipoMenuList[i].nombreMenu));
                    j++;
                }
            }
            if (DropDownVariedad.SelectedValue != "Seleccione" && DropDownVariedad.SelectedValue != "Variedad")
            {
                DropDownVariedad.SelectedValue = SeleccionVariedad;
            }
            if (DropDownVariedad.Items.FindByValue(SeleccionVariedad) != null)
            {
                DropDownVariedad.SelectedValue = SeleccionVariedad;
            }
        }
        private void MostrarDropDownList(DropDownList dropDownList)
        {

            List<DropDownList> listDrop = new List<DropDownList>();
            listDrop.Add(DropDownProducto);
            listDrop.Add(DropDownVariedad);
            listDrop.Add(DropDownParaPizza);

            foreach (DropDownList pl in listDrop)
            {
                pl.Visible = false;
                if (dropDownList.ID == pl.ID)
                {
                    pl.Visible = true;
                }
            }
            DropDownProducto.Visible = true;
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            DetallePedido detallePedido = new DetallePedido();
            DetallePedidoBussiness detallePedidoBuss = new DetallePedidoBussiness();
            MenuBussiness menuBuss = new MenuBussiness();
            Entidades.Menu menu = new Entidades.Menu();          

            if (this.DropDownProducto.SelectedValue != "Seleccione" &&
                this.DropDownVariedad.SelectedValue != "" &&
                this.txtCantidad.Text != "" )
            {
                detallePedido.id = id;
                detallePedido.tipo = this.DropDownProducto.SelectedValue;
                detallePedido.variedad = this.DropDownVariedad.SelectedValue;
                if (this.DropDownParaPizza.SelectedValue == "Seleccione")
                {
                    detallePedido.paraPizza = "";
                }
                else
                {
                    detallePedido.paraPizza = this.DropDownParaPizza.SelectedValue;
                }
                detallePedido.cantidad = Convert.ToInt32(this.txtCantidad.Text);
                menu = menuBuss.GetMenuDataTipo(detallePedido.variedad);
                detallePedido.precio = menu.precio * detallePedido.cantidad;
                detallePedidoBuss.AgregarDetallePedido(detallePedido);
                FillDetallePedidoGrid();
                this.DropDownProducto.SelectedValue = "Seleccione";
                this.DropDownVariedad.SelectedValue = "Seleccione";
                this.DropDownParaPizza.SelectedValue = "Seleccione";
                this.txtCantidad.Text = "";
            }
            else
            {
                string script = "Alerta();";
                ScriptManager.RegisterStartupScript(this,this.GetType(),"popup",script,true);
            }          
        }

        protected void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            int idDetalle;
            if (gridTipoProductoPedidosList.SelectedIndex != -1)
            {
                idDetalle = Convert.ToInt32(gridTipoProductoPedidosList.SelectedRow.Cells[0].Text);
                DetallePedidoBussiness menuBuss = new DetallePedidoBussiness();
                menuBuss.EliminarDetallePedido(id,idDetalle);
                FillDetallePedidoGrid();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string idDetalle = null;
            if (gridTipoProductoPedidosList.SelectedIndex != -1)
            {
                idDetalle = gridTipoProductoPedidosList.SelectedRow.Cells[0].Text;
                Response.Redirect("EditarDetallePedido.aspx?id="+ id + "&iddetalle=" + idDetalle);

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
 
            DetallePedidoBussiness detpedidoBuss = new DetallePedidoBussiness();
            VariablesBussiness varBuss = new VariablesBussiness();
            PedidoBussiness peBuss = new PedidoBussiness();
            DetallePedidoBussiness dpBuss = new DetallePedidoBussiness();

            Pedido pedido = new Pedido();
         
            pedido.id = id;
            pedido.nombreCliente = this.txtnombreCliente.Text;
            pedido.direccion = this.txtdireccion.Text;
            pedido.atencion = this.txtAtencion.Text;
            pedido.nota = this.txtnota.Text;
            pedido.modoPago = varBuss.GetVariableData("rbListModoPago");
            pedido.estado = varBuss.GetVariableData("rbListEstado");
            pedido.total = Convert.ToDecimal(txtTotal.Text);
            peBuss.EditarPedido(pedido);
            //dpBuss.CargarDetallePedido(id); // debo modificar a actualizar DetallePedido, tengo que ver que no este repetido en la base

            Response.Redirect("Pedidos.aspx");
          
           
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void DropDownProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownVariedad.SelectedValue = "Seleccione";
            DropDownParaPizza.SelectedValue = "Seleccione";
        }

        protected void rblistModoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("rbListModoPago", this.rbListModoPago.SelectedValue);
        }

        protected void rbListEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("rbListEstado", this.rbListEstado.SelectedValue);

        }
        //protected void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        //{
        //    rbMercadoPago.Checked = false;
        //    rbEfectivo.Checked = false;
        //    VariablesBussiness varBuss = new VariablesBussiness();
        //    varBuss.EditarVariableValor("RadioButtonSelected", rbTarjeta.Text);
        //}

        //protected void rbMercadoPago_CheckedChanged(object sender, EventArgs e)
        //{
        //    rbTarjeta.Checked = false;
        //    rbEfectivo.Checked = false;
        //    VariablesBussiness varBuss = new VariablesBussiness();
        //    varBuss.EditarVariableValor("RadioButtonSelected", rbMercadoPago.Text);
        //}

        //protected void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        //{
        //    rbMercadoPago.Checked = false;
        //    rbTarjeta.Checked = false;
        //    VariablesBussiness varBuss = new VariablesBussiness();
        //    varBuss.EditarVariableValor("RadioButtonSelected", rbEfectivo.Text);
        //}
    }
}