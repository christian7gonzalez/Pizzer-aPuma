<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="Pizzeria.Menus1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <h1>Menus</h1>
        <asp:GridView runat="server" ID="gridMenusList" OnRowDataBound="gridMenusList_RowDataBound"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
            CssClass= "table table-striped table-bordered table-condensed">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
            <Columns>   
                <asp:BoundField DataField="id" HeaderText="Código" />   
                <asp:BoundField DataField="nombreMenu" HeaderText="Menu" />   
                <asp:BoundField DataField="tipo" HeaderText="Tipo" />  
                 <asp:BoundField DataField="mDescripcion" HeaderText="Descripción" />  
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
        <br />
                <asp:Button id="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-primary"  />
                <asp:Button id="btnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"  class="btn btn-primary"   />
                <asp:Button id="btnEliminar" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" class="btn btn-primary"  />
    </div>
</asp:Content>
