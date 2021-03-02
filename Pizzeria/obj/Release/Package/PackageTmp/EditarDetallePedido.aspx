<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDetallePedido.aspx.cs" Inherits="Pizzeria.EditarDetallePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style type="text/css">
        .auto-style1{
            width: 76px;
            height: 72px;
        }
    </style>
    <div>
        <h1>Editar Detalle Pedido</h1>

        <div class="jumbotron">
            <div style="Width:410px">
             
                <asp:Label id="lblIdDetalle" Text="ID: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtIdDetalle" runat="server" Width="300px" class="derechaBox" Enabled="false"/>
                <br />
                <br />
                <asp:Label id="lblTipo" Text="Tipo: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtTipo" runat="server" Width="300px" class="derechaBox"/>
                <br />
                <br />
                <asp:Label id="lblMenu" Text="Menu: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtMenu" runat="server" Width="300px" class="derechaBox"/>
                <br />
                <br />
                <asp:Label id="lblParaPizza" Text="Para Pizza: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtParaPizza" runat="server" Width="300px" class="derechaBox"/>
                <br />
                <br />
                <asp:Label id="lblCantidad" Text="Cantidad: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtCantidad" runat="server" Width="300px" class="derechaBox"/>    
                <br />
                <br />
              
                <asp:Label id="lblPrecio" Text="Precio: " runat="server" class="medidaBox text-align:left" />
                <asp:TextBox id="txtPrecio" runat="server" Width="300px" class="derechaBox" Enabled="false"/>          
            
            </div>           
        </div>
        
        
        <br />
        <p>
            <asp:Button id="btnAceptar" Text="Aceptar" runat="server" OnClick="btnAceptar_Click" />
            <asp:Button id="btnCancelar"  Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
        </p>
    </div>
</asp:Content>
