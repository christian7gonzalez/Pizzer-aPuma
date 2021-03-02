<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPedido.aspx.cs" Inherits="Pizzeria.EditarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function Alerta() {
            Swal.fire(
                'ERROR!',
                'Faltan datos - Pedido incompleto!',
                'error'
            );
        };
    </script>  
        <script type="text/javascript" src="Scripts/SweetAlert.js"></script>
    <script src="sweetalert2-master/src/SweetAlert.js"></script>
    <script src="sweetalert2-master/src/sweetalert2.js"></script>
     <link rel="stylesheet" type="text/css" href="sweetalert2-master/src/sweetalert2.scss">
    <div>
        <h1>Editar Pedido</h1>
        <div class="jumbotron">
            <div style="Width:410px">
             
                    <asp:Label id="lblnombreCliente" Text="Nombre del Cliente: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtnombreCliente" runat="server" Width="300px" class="derechaBox"/>
                    <br />
                    <br />
                    <asp:Label id="lbldireccion" Text="Dirección: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtdireccion" runat="server" Width="300px" class="derechaBox"/>
                    <br />
                    <br />
                    <asp:Label id="lblnota" Text="Nota: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtnota" runat="server" Width="300px" class="derechaBox"/>   
                    <br />
                    <br />
                    <asp:Label id="lblAtencion" Text="Atención: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtAtencion" runat="server" Width="300px" class="derechaBox"/>  
            </div>           
        </div>
        <div class="jumbotron">
            <h3>Pedido:</h3>
            <br />
            <div style="width: 561px">
                <asp:DropDownList ID="DropDownProducto" runat="server" AutoPostBack="True" class="tamaño-dropDownlist" OnSelectedIndexChanged="DropDownProducto_SelectedIndexChanged"   >
                <asp:ListItem Selected="True" Value="Seleccione"> Seleccione </asp:ListItem>      
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownVariedad" runat="server" Visible="false"  class="tamaño-dropDownlist"  AutoPostBack="True"  >
                <asp:ListItem Selected="True" Value="Variedad"> Variedad </asp:ListItem>
               
            </asp:DropDownList>
              <asp:DropDownList ID="DropDownParaPizza" runat="server" Visible="false"  class="tamaño-dropDownlist" >
                <asp:ListItem Selected="True" Value="Seleccione"> Seleccione </asp:ListItem>
                <asp:ListItem Value="MOLDE"> MOLDE </asp:ListItem>
                <asp:ListItem Value="PIEDRA"> PIEDRA </asp:ListItem>
            </asp:DropDownList>
            </div>
            <div style="Width:254px" class="derechaBox">
                <asp:Label Text="Cantidad: " runat="server"  />
                <asp:TextBox text="" ID="txtCantidad" runat="server" Width="74px"  /> 
                 <asp:Button Text="Cargar" id="btnCargar" runat="server" OnClick="btnCargar_Click" class="derechaBox btn btn-primary " />
            </div>       
            <br />
            <br />
            <asp:GridView ID="gridTipoProductoPedidosList" OnRowDataBound="gridTipoProductoPedidosList_RowDataBound"
                CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
                CssClass= "table table-striped table-bordered table-condensed" runat="server">
                <Columns>   
                    <asp:BoundField DataField="idDetalle" HeaderText="ID" /> 
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" /> 
                    <asp:BoundField DataField="variedad" HeaderText="Menus" /> 
                    <asp:BoundField DataField="paraPizza" HeaderText="Para Pizzas" /> 
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" /> 
                     <asp:BoundField DataField="precio" HeaderText="Precio" /> 
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="false" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
                   
            <div style="Width:171px" class="derechaBox">
                   <asp:Label id="lblTotal" Text="Total: " runat="server" class="medidaBox text-align:left" position="static" />
                 <asp:TextBox id="txtTotal" runat="server" Width="115px" display="inline-block"  Enabled="false" CssClase="derechaBox"/>  
             
            </div>
            <br />
            <br />
            <br />
            <div style="Width:179px" class="derechaBox">                 
                <asp:Button Text="Eliminar" Id="btnEliminarPedido" runat="server" OnClick="btnEliminarPedido_Click"  class="derechaBox btn btn-primary "/>
                <asp:Button Text="Editar" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="izquierdaBox btn btn-primary "/>
            </div>
            
        </div>
        <div>  
            <h4>Modo de Pago: </h4> 
            <asp:RadioButtonList id="rbListModoPago" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="rblistModoPago_SelectedIndexChanged" >
                <asp:ListItem Text="TARJETA" />
                <asp:ListItem Text="MERCADOPAGO" />
                <asp:ListItem Text="EFECTIVO" />
            </asp:RadioButtonList>
            
            <br />
            <br />
        </div>
          <div>
              <h4>Estado:</h4> 
              <asp:RadioButtonList ID="rbListEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbListEstado_SelectedIndexChanged">
                <asp:ListItem Text="ABIERTO" />
                <asp:ListItem Text="EN CURSO" />
                <asp:ListItem Text="CERRADO" />
              </asp:RadioButtonList>
            <asp:Label Text="Estado: " runat="server" />
            <asp:TextBox text="ABIERTO" Id="txtEstado" runat="server" Enabled="False" />
            <br />
            <br />
          
          </div>       
            <asp:Button id="btnAceptar" Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary"/>
            <asp:Button id="btnCancelar"  Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-primary"/>  
    </div>
</asp:Content>
