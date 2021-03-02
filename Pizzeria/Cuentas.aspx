<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuentas.aspx.cs" Inherits="Pizzeria.Cuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        function Alertas() {
            Swal.fire(
                'ERROR!',
                'Valores de Calendario desde y/o hasta son nulos!',
                'error'
            );
        };

        function Validar() {
            var campo = $('#pickerDesde').val();
            if (campo === '') {
                alert("El campo esta vacío");
                return false;
            } else {
                //Las validaciones que necesitas hacer
            }
        };
       


    </script>


    <script src="Scripts/jquery-3.4.1.min.js"> </script>

    <script type="text/javascript" src="pickadate.js-3.6.2/lib/picker.js"></script>
    <script type="text/javascript" src="pickadate.js-3.6.2/lib/picker.date.js"></script>
    <script type="text/javascript" src="pickadate.js-3.6.2/lib/picker.time.js"></script>
    <link rel="stylesheet" type="text/css" href="pickadate.js-3.6.2/lib/themes/classic.css">
    <link rel="stylesheet" type="text/css" href="pickadate.js-3.6.2/lib/themes/classic.date.css">

    <script type="text/javascript" src="Scripts/SweetAlert.js"></script>
    <script type="text/javascript" src="sweetalert2-master/src/SweetAlert.js"></script>
    <script type="text/javascript" src="sweetalert2-master/src/sweetalert2.js"></script>
     <link rel="stylesheet" type="text/css" href="sweetalert2-master/src/sweetalert2.scss">


    <div class="form-group">
         <h1>Cuentas</h1>     
        <div class="jumbotron form-group">
            <h5>Los campos con * son obligatorios para la busqueda.</h5>
         <h3>Total del dia:
         </h3>
         <br />
         <div style="width:504px">
             <div style="width: 80px" >
                  <h4>Desde:</h4>
             </div>             
   
              <br />
              <asp:Label Text="*" ID="lblpikerDesde" runat="server" ForeColor="Red" visible="True" Width="16px" Font-Bold="False" Font-Size="Larger" Height="22px"/>
             Fecha Desde: <input type="text" id="pickerDesde"  name="Desde" class="form-control" style="width: 187px; height: 24px; background-color:white">
                <script type="text/javascript">
                    $("#pickerDesde").pickadate({
                        format: 'yyyy-mm-dd',
                        monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
                        // Buttons
                        today: 'Hoy',
                        clear: 'Limpiar',
                        close: 'Cerrar',
                    });
                    function CambiarColor() {
                        Console.log("entre");
                        $("#pickerDesde" ).css('background-color', '#F00');
                    };
                </script>
              <asp:Label Text="*" ID="lbltimepickerDesde" runat="server" ForeColor="Red" visible="True" Width="16px" Font-Bold="False" Font-Size="Larger" Height="22px"/>
             Hora Desde: <input type="text" id="timepickerDesde" name="Desde" class="form-control" style="Width:187px; height:24px;background-color:white">

                <script type="text/javascript">
                    $("#timepickerDesde").pickatime({
                        format: 'HH:i',
                        clear: 'Limpiar',
                    });
                </script>
    
            
             <br />
             <br />  
         </div>
         <div style="width:503px">
             <div style="width: 80px" >
                  <h4>Hasta: </h4>
             </div>
             <asp:Label Text="*" ID="lblpikerHasta" runat="server" ForeColor="Red" visible="True" Width="16px" Font-Bold="False" Font-Size="Larger" Height="22px"/>
       
             
             Fecha Hasta: <input type="text" id="pickerHasta" name="Hasta" class="form-control" style="Width:187px; height:24px;background-color:white" required>
                     
                <script type="text/javascript">
                    $("#pickerHasta").pickadate({
                        format: 'yyyy-mm-dd',
                        monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
                        // Buttons
                        today: 'Hoy',
                        clear: 'Limpiar',
                        close: 'Cerrar',

                    });
                   
                </script>
                <asp:Label Text="*" ID="lbltimepickerHasta" runat="server" ForeColor="Red" visible="True" Width="16px" Font-Bold="False" Font-Size="Larger" Height="22px"/>
             Hora Hasta: <input type="text" id="timepickerHasta" name="Hasta" class="form-control" style="Width:187px; height:24px;background-color:white" required>

                <script type="text/javascript">
                    $("#timepickerHasta").pickatime({
                        format: 'HH:i',
                        clear: 'Limpiar',
                    });
                </script>
             <br />
             <br />  
             <h3>Calcular</h3>
             <asp:Label Text="$0" ID="lblTotal" runat="server" Font-Size="Large" />
             <br />
            <br />
            <asp:Button Text="BUSCAR" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click1"   CssClass="btn btn-primary" CausesValidation="True"/>
         </div>
    </div>
    </div>
     
    </asp:Content>
