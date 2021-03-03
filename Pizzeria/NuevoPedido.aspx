<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoPedido.aspx.cs" Inherits="Pizzeria.WebForm1" %>
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
        <h1>Nuevo Pedido</h1>
        <div class="jumbotron">
            <div style="Width:410px">
             
                    <asp:Label id="lblnombreCliente" Text="Nombre del Cliente: " runat="server" class="medidaBox text-align:left" />
                    <asp:TextBox id="txtnombreCliente" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>
                    <br />
                    <br />
                    <asp:Label id="lbldireccion" Text="Dirección: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtdireccion" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>
                    <br />
                    <br />
                    <asp:Label id="lblnota" Text="Nota: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtnota" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>   
                    <br />
                    <br />
                    <asp:Label id="lblAtencion" Text="Atención: " runat="server" class="medidaBox text-align:left"/>
                    <asp:TextBox id="txtAtencion" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>  
                    <br />
                    <br />
                    <asp:Label id="lblAvisar" Text="Avisar: " runat="server" class="medidaBox text-align:left"/>
                    
                    <asp:RadioButtonList ID="RadioButtonAvisar" runat="server">
                        <asp:ListItem Text="SI" />                   
                    </asp:RadioButtonList>
                    
            </div>           
        </div>
        <div class="jumbotron">
           
            <h3>Pedido:</h3>
            <br />
            <dv sityle="width: 561px;border-style: none; border-width: 4px;">
                <asp:DropDownList ID="DropDownProducto" runat="server" AutoPostBack="True" class="tamaño-dropDownlist" OnSelectedIndexChanged="DropDownProducto_SelectedIndexChanged" style="border-radius:4px"  >
                <asp:ListItem Selected="True" Value="Seleccione"> Seleccione </asp:ListItem>      
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownVariedad" runat="server" Visible="false"  class="tamaño-dropDownlist"  AutoPostBack="True" style="border-radius:4px"  >
                <asp:ListItem Selected="True" Value="Variedad"> Variedad </asp:ListItem>
               
            </asp:DropDownList>
              <asp:DropDownList ID="DropDownParaPizza" runat="server" Visible="false"  class="tamaño-dropDownlist" style="border-radius:4px" >
                <asp:ListItem Selected="True" Value="Seleccione"> Seleccione </asp:ListItem>
                <asp:ListItem Value="MOLDE"> MOLDE </asp:ListItem>
                <asp:ListItem Value="PIEDRA"> PIEDRA </asp:ListItem>
            </asp:DropDownList>
            </dv>
            <div style="Width:268px;  position: -webkit-sticky;" class="derechaBox" >
                <asp:Label Text="Cantidad: " runat="server"  style="float:left"/>
                <asp:TextBox text="" ID="txtCantidad" runat="server" Width="108px" class="form-control" style="float:left" Height="24px"/> 
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
            <div style="border-style:solid;border-width: 1px; height: 154px; border-color:Highlight">
                <br />
            <div style="float:left; padding-left:10px; height: 122px;">
                Empanadas:
                <asp:RadioButtonList ID="rbtnEmpanadas" runat="server">
                    <asp:ListItem Text="Media-Docena" />
                    <asp:ListItem Text="Docena" />
                </asp:RadioButtonList>
                Cantidad:
                <asp:TextBox ID="txtCantidadEmpanadas" runat="server" class="derechaBox form-control" Height="24px"/>
            </div> 
               
            <div style="Width:171px; height: 34px; padding:10px; padding-right:10px" class="derechaBox">
                   <asp:Label id="lblTotal" Text="Total: " runat="server" class="medidaBox text-align:left" position="static" />
                 <asp:TextBox id="txtTotal" runat="server" Width="115px" display="inline-block"  Enabled="false" CssClase="derechaBox form-control" Height="23px" Style="border-radius:4px"/>  
             
            </div>
            <br />
            <br />
            <br />
            <div style="Width:179px;padding-right:10px;" class="derechaBox">                 
                <asp:Button Text="Eliminar" Id="btnEliminarPedido" runat="server" OnClick="btnEliminarPedido_Click"  class="derechaBox btn btn-primary " />
                <asp:Button Text="Editar" ID="btnEditar" runat="server" OnClick="btnEditar_Click" class="izquierdaBox btn btn-primary "/>
            </div>
        </div>
            <br />
        <div>  
            <asp:Label Text="Modo de Pago: " runat="server" />
            <br />
            <asp:RadioButton Text="TARJETA" id="rbTarjeta" runat="server" AutoPostBack="True" OnCheckedChanged="rbTarjeta_CheckedChanged" />
            <br />
            <asp:RadioButton Text="MERCADOPAGO" id="rbMercadoPago" runat="server" AutoPostBack="True" OnCheckedChanged="rbMercadoPago_CheckedChanged" />
            <br />
            <asp:RadioButton Text="EFECTIVO" id="rbEfectivo" runat="server" AutoPostBack="True" OnCheckedChanged="rbEfectivo_CheckedChanged" />
            <br />
            <br />
        </div>
        
        <asp:Label Text="Estado: " runat="server" />
        <asp:TextBox text="ABIERTO" Id="txtEstado" runat="server" Enabled="False" />
        <br />
        <br />
        <p>
            <asp:Button id="btnAceptar" Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary"/>
            <asp:Button id="btnCancelar"  Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-primary"/>
        </p>
    </div>
    </div>
</asp:Content>
