using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Bussiness;
using System.Web.Configuration;
using System.Configuration;
using System.Windows;
using System.Threading;


//using System.Web.UI;


namespace Pizzeria
{

    public partial class Pedidos : System.Web.UI.Page
    {
        private string nombreNegocio = WebConfigurationManager.AppSettings["NombreNegocio"].ToString();
        private string direccion = WebConfigurationManager.AppSettings["Direccion"].ToString();
        private string telefono = WebConfigurationManager.AppSettings["Telefono"].ToString();
        private int numeroTickt = Convert.ToInt32(WebConfigurationManager.AppSettings["NumeroDeTicket"].ToString());
        private int numeroDetalle = Convert.ToInt32(WebConfigurationManager.AppSettings["NumeroDeDetalle"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPedidoGrid();
            if (this.gridPedidosList.Rows.Count != 0)
            {
                lblCambio.Visible = true;
                lblEnCurso.Visible = true;
                ibtnEnCurso.Visible = true;
                lblCerrar.Visible = true;
                ibtnCerrar.Visible = true;
                lblAvisar.Visible = true;
                lblAvisarSi.Visible = true;
                ibtnAvisarSi.Visible = true;
                lblAvisarNo.Visible = true;
                ibtnAvisarNo.Visible = true;
               
            }
            this.txtSearchCodigo.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.txtSearchNombreCliente.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.TxtSearchDireccion.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.txtSearchFecha.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.txtSearchEstado.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.txtSearchAvisar.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
            this.txtSearchModoPago.Attributes.Add("OnFocus", "LimpiarTextoClear(this);");
        }

        private void FillPedidoGrid()
        {
            List<Pedido> PedidoList = new List<Pedido>();
            PedidoBussiness PedidoBuss = new PedidoBussiness();
            PedidoList = PedidoBuss.GetPedidos();
            //PedidoList = PedidoList;
            gridPedidosList.DataSource = from p in PedidoList
                                         orderby p.idPedido ascending
                                         select p; 
            gridPedidosList.DataBind();

        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gridPedidosList.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gridPedidosList, "Select$" + row.RowIndex.ToString(), true));
            }
            base.Render(writer);
        }
        protected void gridPedidosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='pointer';");
                e.Row.ToolTip = "Click en la fila para seleccionarla";
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            DetallePedidoTemporalBussiness temBuss = new DetallePedidoTemporalBussiness();
            temBuss.TruncatePedidoTemporalData();
            temBuss.ReindexarPedidoTemporalData();
            Response.Redirect("NuevoPedido.aspx");
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string idPedido = null;
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = gridPedidosList.SelectedRow.Cells[0].Text;
                Response.Redirect("EditarPedido.aspx?idpedido=" + idPedido);
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPedido = 0;
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt32(gridPedidosList.SelectedRow.Cells[0].Text);
                PedidoBussiness PedidoBiz = new PedidoBussiness();
                PedidoBiz.DeletePedido(idPedido);
                FillPedidoGrid();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this,this.GetType(),"popupEliminar",script,true);
            }
            if (gridPedidosList.Rows.Count == 0)
            {
                Response.Redirect("Pedidos.aspx");
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            //uso funcion javascript
            PedidoBussiness pbuss = new PedidoBussiness();
            Pedido pedido = new Pedido();
         
            DetallePedidoBussiness dpbuss = new DetallePedidoBussiness();
            List<DetallePedido> listaDetallePedido = new List<DetallePedido>();
            List<string> listaMenus = new List<string>();
            int idPedido = 0;
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt16(gridPedidosList.SelectedRow.Cells[0].Text);
                pedido = pbuss.GetPedidoDato(idPedido);
                listaDetallePedido = dpbuss.GetDetallePedidoDato(pedido.id);
                //listaMenus = listaDetallePedido.Select(x => x.variedad).ToList();
                string javaScript = "alertas();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                TicketBussiness ticktBuss = new TicketBussiness();
                ticktBuss.ImprimirTicket(nombreNegocio, direccion, telefono, ref numeroTickt, ref numeroDetalle, ref listaDetallePedido, pedido.atencion, pedido.nombreCliente);

                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
                webConfigApp.AppSettings.Settings["NumeroDeTicket"].Value = numeroTickt.ToString("D3");
                webConfigApp.Save();
                Configuration webConfigAppNumeroDetalle = WebConfigurationManager.OpenWebConfiguration("~");
                webConfigAppNumeroDetalle.AppSettings.Settings["NumeroDeDetalle"].Value = numeroDetalle.ToString("D7");
                webConfigAppNumeroDetalle.Save();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }




        }

        protected void ibtnEnCurso_Click(object sender, ImageClickEventArgs e)
        {
            int idPedido = 0;
            PedidoBussiness pbuss = new PedidoBussiness();
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt16(gridPedidosList.SelectedRow.Cells[0].Text);
                pbuss.CambiarEstado(idPedido, 4);
                FillPedidoGrid();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }
        }

        protected void ibtnCerrar_Click(object sender, ImageClickEventArgs e)
        {
            int idPedido = 0;
            PedidoBussiness pbuss = new PedidoBussiness();
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt16(gridPedidosList.SelectedRow.Cells[0].Text);
                pbuss.CambiarEstado(idPedido, 2);
                FillPedidoGrid();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }
        }

        protected void ibtnAvisarSi_Click(object sender, ImageClickEventArgs e)
        {
            int idPedido = 0;
            PedidoBussiness pbuss = new PedidoBussiness();
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt16(gridPedidosList.SelectedRow.Cells[0].Text);
                pbuss.CambiarAviso(idPedido, "SI");
                FillPedidoGrid();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }
        }

        protected void ibtnAvisarNo_Click(object sender, ImageClickEventArgs e)
        {
            int idPedido = 0;
            PedidoBussiness pbuss = new PedidoBussiness();
            if (gridPedidosList.SelectedIndex != -1)
            {
                idPedido = Convert.ToInt16(gridPedidosList.SelectedRow.Cells[0].Text);
                pbuss.CambiarAviso(idPedido, "NO");
                FillPedidoGrid();
            }
            else
            {
                string script = "AlertaSeleccion();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupEliminar", script, true);
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            PedidoBussiness pbuss = new PedidoBussiness();
            if (this.txtSearchCodigo.Text == "*Codigo")
            {
                this.txtSearchCodigo.Text = "";
            }
            if (this.txtSearchNombreCliente.Text == "*Nombre de cliente")
            {
                this.txtSearchNombreCliente.Text = "";
            }
            if (this.TxtSearchDireccion.Text == "*Dirección")
            {
                this.TxtSearchDireccion.Text = "";
            }
            if (this.txtSearchFecha.Text == "*Fecha/Hora")
            {
                this.txtSearchFecha.Text = "";
            }
            if (this.txtSearchEstado.Text == "*Estado")
            {
                this.txtSearchEstado.Text = "";
            }
            if (this.txtSearchAvisar.Text == "*Avisar")
            {
                this.txtSearchAvisar.Text = "";
            }
            if (this.txtSearchModoPago.Text == "*ModoPago")
            {
                this.txtSearchModoPago.Text = "";
            }
            if (this.txtSearchCodigo.Text != "*Codigo" && this.txtSearchNombreCliente.Text != "*Nombre de cliente" 
                && this.TxtSearchDireccion.Text != "*Dirección"
                && this.txtSearchFecha.Text != "*Fecha/Hora"
                && this.txtSearchEstado.Text != "*Estado"
                && this.txtSearchAvisar.Text != "*Avisar"
                && this.txtSearchModoPago.Text != "*ModoPago")
            {
                gridPedidosList.DataSource = pbuss.FiltrarGridPedido(this.txtSearchCodigo.Text, this.txtSearchNombreCliente.Text.ToUpper(), this.TxtSearchDireccion.Text.ToUpper(), this.txtSearchFecha.Text, this.txtSearchEstado.Text.ToUpper(), this.txtSearchAvisar.Text.ToUpper(), this.txtSearchModoPago.Text.ToUpper());
                gridPedidosList.DataBind();
                this.txtSearchCodigo.Text = "*Codigo";
                this.txtSearchNombreCliente.Text = "*Nombre de cliente";
                this.TxtSearchDireccion.Text = "*Dirección";
                this.txtSearchFecha.Text = "*Fecha/Hora";
                this.txtSearchEstado.Text = "*Estado";
                this.txtSearchAvisar.Text = "*Avisar";
                this.txtSearchModoPago.Text = "*ModoPago";
            }

        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            FillPedidoGrid();
            this.txtSearchCodigo.Text = "*Codigo";
            this.txtSearchNombreCliente.Text = "*Nombre de cliente";
            this.TxtSearchDireccion.Text = "*Dirección";
            this.txtSearchFecha.Text = "*Fecha/Hora";
            this.txtSearchEstado.Text = "*Estado";
            this.txtSearchAvisar.Text = "*Avisar";
            this.txtSearchModoPago.Text = "*ModoPago";
        }
    } 
}