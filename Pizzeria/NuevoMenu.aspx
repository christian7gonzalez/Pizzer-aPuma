<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoMenu.aspx.cs" Inherits="Pizzeria.NuevoMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .auto-style1{
            width: 76px;
            height: 72px;
        }
    </style>
     <script src="Scripts/MisFuncionesFront.js"></script>
    <div>
        <h1>Nuevo Menú</h1>

        <div class="jumbotron">
            <div style="Width:410px">
             
                <asp:Label id="lblNombreMenu" Text="Nombre de Menu: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtNombreMenu" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>
                <br />
                <br />
                <asp:Label id="lblTipo" Text="Tipo: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtTipo" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>
                <br />
                <br />
                <asp:Label id="lblDescripcion" Text="Descripción: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtDescripcion" runat="server" Width="300px" class="derechaBox form-control" Style="text-transform: uppercase"/>
                <br />
                <br />
                <asp:Label id="lblPrecio" Text="Precio: " runat="server" class="medidaBox text-align:left"/>
                <asp:TextBox id="txtPrecio" runat="server" Width="300px" class="derechaBox form-control" onkeypress="javascript:return soloDecimales(event)" />          
            </div>           
        </div>
        
        
        <br />
        <p>
            <asp:Button id="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <asp:Button id="btnCancelar"  Text="Cancelar" runat="server" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
        </p>
    </div>
</asp:Content>
