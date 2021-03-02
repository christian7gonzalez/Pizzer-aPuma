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
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                FillDetallePedidoGrid();
            }

            VariablesBussiness varBuss = new VariablesBussiness();         
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
            List<DetallePedidoTemporal> TipoProductoList = new List<DetallePedidoTemporal>();
            DetallePedidoTemporalBussiness TipoProductoBuss = new DetallePedidoTemporalBussiness();
            TipoProductoList = TipoProductoBuss.GetDetallePedidoTemporal();
            PedidoBussiness peBuss = new PedidoBussiness();
            txtTotal.Text = Convert.ToString(peBuss.GetTotalPedidosTemporal());

            gridTipoProductoPedidosList.DataSource = TipoProductoList;
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
            for (int i = 0; i < tipoMenuList.Count ; i++)
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
            int j =1;
            for (int i = 0; i < tipoMenuList.Count; i++)
            {
                if (tipoMenuList[i].tipo == ValorSeleccionado)
                {
                    drowDownList.Items.Insert(j, new ListItem(tipoMenuList[i].nombreMenu, tipoMenuList[i].nombreMenu));
                    j++;
                }
            }
            if ( DropDownVariedad.SelectedValue != "Seleccione" && DropDownVariedad.SelectedValue != "Variedad")
            {
                DropDownVariedad.SelectedValue = SeleccionVariedad;
            }
            if (DropDownVariedad.Items.FindByValue(SeleccionVariedad)!= null)
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

        public void RadioChecked(RadioButton rbutton)
        {
            List<RadioButton> listarb = new List<RadioButton>();
            listarb.Add(rbTarjeta);
            listarb.Add(rbMercadoPago);
            listarb.Add(rbEfectivo);
            bool isChecked = rbutton.Checked;
            foreach (RadioButton item in listarb)
            {
                item.Checked = false;
                if (item.ID == rbutton.ID)
                {
                    rbutton.Checked = true;
                }
               
            }

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            DetallePedidoTemporalBussiness detpedidoTemBuss = new DetallePedidoTemporalBussiness();
            VariablesBussiness varBuss = new VariablesBussiness();
            PedidoBussiness peBuss = new PedidoBussiness();
            DetallePedidoBussiness dpBuss = new DetallePedidoBussiness();
            if (this.DropDownProducto.SelectedValue != "Seleccione" &&
               this.DropDownVariedad.SelectedValue != "Seleccion" &&
               this.txtCantidad.Text != "")
            { 
            
            }

                Pedido pedido = new Pedido();
            pedido.nombreCliente = this.txtnombreCliente.Text.ToUpper();
            pedido.direccion = this.txtdireccion.Text.ToUpper();
            pedido.atencion = this.txtAtencion.Text.ToUpper();
            pedido.nota = this.txtnota.Text.ToUpper();
            pedido.avisar = this.RadioButtonAvisar.SelectedValue.ToUpper();
            string valorchecked = varBuss.GetVariableData("RadioButtonSelected");
            pedido.modoPago = valorchecked;
            pedido.total = Convert.ToDecimal(txtTotal.Text);
            id = peBuss.CrearPedido(pedido);
            dpBuss.CargarDetallePedido(id);
            detpedidoTemBuss.TruncatePedidoTemporalData();
            detpedidoTemBuss.ReindexarPedidoTemporalData();
            FillDetallePedidoGrid();
            Response.Redirect("Pedidos.aspx");
            //this.txtnombreCliente.Text = "";
            //this.txtdireccion.Text = "";
            //this.txtnota.Text = "";
            //this.txtAtencion.Text = "";
            //rbTarjeta.Checked = false;
            //rbEfectivo.Checked = false;
            //rbMercadoPago.Checked = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pedidos.aspx");
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            DetallePedidoTemporal detallePedidoTem = new DetallePedidoTemporal();
            DetallePedidoTemporalBussiness detallePedidoTemBuss = new DetallePedidoTemporalBussiness();
            MenuBussiness menuBuss = new MenuBussiness();
            Entidades.Menu menu = new Entidades.Menu();
            if (this.DropDownProducto.SelectedValue != "Seleccione" &&
               this.DropDownVariedad.SelectedValue != "Seleccione" &&
                this.DropDownVariedad.SelectedValue != "" &&
               this.txtCantidad.Text != "")
            {
                detallePedidoTem.tipo = this.DropDownProducto.SelectedValue;
                detallePedidoTem.variedad = this.DropDownVariedad.SelectedValue;
                if (this.DropDownParaPizza.SelectedValue == "Seleccione")
                {
                    detallePedidoTem.paraPizza = "";
                }
                else
                {
                    detallePedidoTem.paraPizza = this.DropDownParaPizza.SelectedValue;
                }
                detallePedidoTem.cantidad = Convert.ToInt32(this.txtCantidad.Text);
                menu = menuBuss.GetMenuDataTipo(detallePedidoTem.variedad);
                detallePedidoTem.precio = menu.precio * detallePedidoTem.cantidad;
                detallePedidoTemBuss.CrearDetallePedidoTemporal(detallePedidoTem);
                FillDetallePedidoGrid();
                this.DropDownProducto.SelectedValue = "Seleccione";
                this.DropDownVariedad.SelectedValue = "Seleccione";
                this.DropDownParaPizza.SelectedValue = "Seleccione";
                this.txtCantidad.Text = "";
            }
            else
            {
                string script = "Alerta();";
                ScriptManager.RegisterStartupScript(this,this.GetType(),"popupPedidos",script,true);
            }

              
        }

        protected void DropDownProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownVariedad.SelectedValue = "Seleccione";
            DropDownParaPizza.SelectedValue = "Seleccione";
        }

        protected void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            int idPedidoTem;
            if (gridTipoProductoPedidosList.SelectedIndex != -1)
            {
                idPedidoTem = Convert.ToInt32(gridTipoProductoPedidosList.SelectedRow.Cells[0].Text);
                DetallePedidoTemporalBussiness menuBuss = new DetallePedidoTemporalBussiness();
                menuBuss.EliminarDetallePedidoTemporal(idPedidoTem);
                FillDetallePedidoGrid();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string idPedidoTem = null;
            if (gridTipoProductoPedidosList.SelectedIndex != -1)
            {
                idPedidoTem = gridTipoProductoPedidosList.SelectedRow.Cells[0].Text;
                Response.Redirect("EditarDetallePedidoTemporal.aspx?iddetalle= " + idPedidoTem);
                
            }
        }

        protected void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            rbMercadoPago.Checked = false;
            rbEfectivo.Checked = false;
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("RadioButtonSelected", rbTarjeta.Text);
        }

        protected void rbMercadoPago_CheckedChanged(object sender, EventArgs e)
        {
            rbTarjeta.Checked = false;
            rbEfectivo.Checked = false;
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("RadioButtonSelected", rbMercadoPago.Text);
        }

        protected void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            rbMercadoPago.Checked = false;
            rbTarjeta.Checked = false;
            VariablesBussiness varBuss = new VariablesBussiness();
            varBuss.EditarVariableValor("RadioButtonSelected", rbEfectivo.Text);
        }
    }
}