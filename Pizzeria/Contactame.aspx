<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactame.aspx.cs" Inherits="Pizzeria.Contactame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
         function Alertas(valor, mensaje) {
             if (valor == 0) {
                 Swal.fire(
                     'Success!',
                     'Success - ' + mensaje,
                     'success'
                 )
             } else {
                 Swal.fire(
                     'Error!',
                     'Error - ' + mensaje,
                     'error'
                 )
             }
         }
       
     </script>
    
        <script src="Scripts/SweetAlert.js"></script>
    <div class="jumbotron">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
    <br />
    <p>
        Por favor, envienos su consulta por correo electronico:
    </p>
    <p>
        Tu Nombre:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"

            ControlToValidate="YourName" ValidationGroup="save" /><br />
        <asp:TextBox ID="YourName" runat="server" Width="250px" class="form-control"/><br />
        Tu Correo Electronico:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"

            ControlToValidate="YourEmail" ValidationGroup="save" /><br />
        <asp:TextBox ID="YourEmail" runat="server" Width="250px" class="form-control"/>
        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator23"

            SetFocusOnError="true" Text="Example: [pepe@gmail.com]" ControlToValidate="YourEmail"

            ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" Display="Dynamic"

            ValidationGroup="save" /><br />
        Asunto:
        <asp:TextBox ID="YourSubject" runat="server" Width="400px" class="form-control"/><br />
        Tu Consulta:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"

            ControlToValidate="YourSubject" ValidationGroup="save" /><br />
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"

            ControlToValidate="Comments" ValidationGroup="save" /><br />
        <asp:TextBox ID="Comments" runat="server" 

                TextMode="MultiLine" Rows="10" Width="400px"  class="form-control"/>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" 

                    Onclick="btnSubmit_Click" ValidationGroup="save" class="btn btn-primary"/>
    </p>
</asp:Panel>
    </div>

<p>
    <asp:Label ID="DisplayMessage" runat="server" Visible="false" />
</p>  
</asp:Content>
