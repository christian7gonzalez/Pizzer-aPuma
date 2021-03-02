<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Pizzeria.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <STYLE type=text/css>
        .box {

        position:relative;

        display:block;

        margin:21px 10px 10px 10px;

        float:left;

        min-height:80px;

        width:97%;

        /*background:#ccc;*/
            top: -14px;
            left: -1px;
            height: 100px;
        }
       .contenido{
          display: grid;
          grid-template-columns: 1fr 1fr;
       }
    </STYLE>
    <script> // 580
        function alertas() {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Imprimiendo...'
            })
        };
        function AlertaEliminar() {
            Swal.fire(
                'Error',
                'No hay pedido seleccionado!',
              'error'
            );
        };
    </script>
   

    <script type="text/javascript" src="Scripts/SweetAlert.js"></script>
    <script src="sweetalert2-master/src/SweetAlert.js"></script>
    <script src="sweetalert2-master/src/sweetalert2.js"></script>
    <link rel="stylesheet" type="text/css" href="sweetalert2-master/src/sweetalert2.scss">

    <h1>Pedidos</h1>
    
        <div>
       
        <asp:GridView runat="server" ID="gridPedidosList" OnRowDataBound="gridPedidosList_RowDataBound"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
            CssClass= "table table-striped table-bordered table-condensed">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
            <Columns>   
                <asp:BoundField DataField="IdPedido" HeaderText="Código" />   
                <asp:BoundField DataField="nombreCliente" HeaderText="Nombre_de_Cliente" />   
                <asp:BoundField DataField="direccion" HeaderText="direccion" />  
                <asp:BoundField DataField="nota" HeaderText="nota" />  
                 <asp:BoundField DataField="fechaInicio" HeaderText="Fecha/Hora" /> 
                <asp:BoundField DataField="Estado" HeaderText="Estado" /> 
                <asp:BoundField DataField="avisar" HeaderText="Avisar" /> 
                <asp:BoundField DataField="modoPago" HeaderText="modoPago" /> 
                <asp:BoundField DataField="total" HeaderText="Total" /> 
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
              <div class="box" style="float:left;position:static;width: 259px;">
                  <div>
                        <asp:Label Text="Cambio de estado (Rapido):" runat="server" id="lblCambio" Visible="False" Font-Size="Medium"/>
                  </div>
                  <asp:Label Text="En curso:" runat="server" style="float:left;padding:10px" ID="lblEnCurso" Visible="false"/>
                <asp:ImageButton ID="ibtnEnCurso" runat="server" Height="39px" ImageUrl="Imagenes/a-tiempo.png" Width="41px" style="float:left" Visible="false" OnClick="ibtnEnCurso_Click"/>
                  <br />
                  <br />
                  
                  <asp:Label Text="Cerrar:" runat="server" style="float:left;padding:10px" ID="lblCerrar" Visible="false"/>
                  <asp:ImageButton ID="ibtnCerrar" runat="server" Height="31px" ImageUrl="Imagenes/cheque.png" Width="34px" style="float:left" Visible="false" OnClick="ibtnCerrar_Click"/>
                  <br />
                  <br />
            </div>
          
        </div> 

            <div class="box" style="float:left;position:static;width: 666px;">
                <div>
                    <asp:Label Text="Cambiar Aviso:" runat="server" id="lblAvisar" Visible="false" Font-Size="Medium"/>
                </div>
                <asp:Label Text="Avisar: " runat="server" style="float:left;padding:10px" ID="lblAvisarSi" Visible="false"/>
                <asp:ImageButton ImageUrl="Imagenes/alarm_alert_bell_activado.png" ID="ibtnAvisarSi" runat="server" Height="31px"  Width="34px" style="float:left" Visible="false" OnClick="ibtnAvisarSi_Click"/>
                <br />
                <br />   
                <asp:Label Text="No Avisar:" runat="server" style="float:left;padding:10px" ID="lblAvisarNo" Visible="false"/> 
                <asp:ImageButton ImageUrl="Imagenes/alarm_alert_bell_desactivado.png" id="ibtnAvisarNo" runat="server"  Height="31px"  Width="34px" style="float:left" Visible="false" OnClick="ibtnAvisarNo_Click"/>
                <br />
             </div>
          
        <div class="box" >
            <br />
            <asp:Button id="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-primary" style="float:left" />
            <asp:Button id="btnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"  class="btn btn-primary"   style="float:left"/>
            <asp:Button id="btnEliminar" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" class="btn btn-primary" style="float:left" />
            <asp:Button id="btnImprimir" Text="Imprimir" runat="server" OnClick="btnImprimir_Click" class="btn btn-primary derechaBox" style="float:right" />
        </div>
    <br />       
</asp:Content>
