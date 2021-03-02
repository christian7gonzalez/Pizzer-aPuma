<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="Pizzeria.Menus1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
         function LimpiarTexto(txt) {
            
             if (txt.value == "*Tipo" || txt.value == "*Menu") {
                 txt.value = "";
             }
             else if (txt.value == "" || txt.value == "") {
                 if (txt.id == "txtSearch") {
                     txtBox.value = "*Manu";
                 }
                 else {
                     txtBox.value = "*Tipo";
                 }
             }
         }

    </script> 
    <div>
        <h1>Menus</h1>
         <asp:Label Text="BUSCAR:" runat="server" style="padding:12px" />
        <asp:TextBox ID="txtSearch" runat="server" Text="*Menu" onblur="LimpiarTexto()" />
        <asp:TextBox ID="TxtSearchTipo" runat="server" Text="*Tipo"/>
        <asp:ImageButton ID="btnSearch" ImageUrl="Imagenes/searchbutton.png" runat="server" OnClick="btnSearch_Click" Height="33px" Width="36px"/>
        <asp:ImageButton ID="btnClear" ImageUrl="Imagenes/clearbutton.png" runat="server" Height="33px" Width="36px" OnClick="btnClear_Click" />
         <br />
         <br />
        <h5>Para copiar debe seleccionar una fila y elegir el boton con información:</h5>
          <asp:TextBox runat="server" id="txtParaCopiar" Text="" Height="89px" Width="916px" ReadOnly="True" TextMode="MultiLine"/>
        <br />
        
            <asp:Button Text="Menu" runat="server" ID="btnNombreMenu" OnClick="btnNombreMenu_Click" CssClass="btn btn-primary"/>
            <asp:Button Text="Tipo" runat="server" ID="btnTipo" Onclick="btnTipo_Click" CssClass="btn btn-primary"/>
            <asp:Button Text="Descripción" runat="server" ID="btnDescripcion" Onclick="btnDescripcion_Click" CssClass="btn btn-primary"/>

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
         <br />
                <asp:Button id="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-primary"  />
                <asp:Button id="btnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"  class="btn btn-primary"   />
                <asp:Button id="btnEliminar" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" class="btn btn-primary"  />
    </div>
</asp:Content>
