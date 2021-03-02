using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrearTicketVenta;
using System.Configuration;
using Entidades;

namespace Bussiness
{
    public class TicketBussiness
    {
        
        public void ImprimirTicket( string nombreNegocio, string direccion, string telefono,ref int numeroTickt,ref int numeroDetalle, ref List<DetallePedido> lista, string atencion, string nombreCliente)
        {
            //Creamos una instancia d ela clase CrearTicket
            CrearTicket ticket = new CrearTicket();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro(nombreNegocio);
            ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoIzquierda("DIREC: " + direccion);
            ticket.TextoIzquierda("TELEF: " + telefono);
            //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
            //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("Caja # 1", "Ticket # " + numeroTickt.ToString("D3") + "-" + numeroDetalle.ToString("D7"));
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIÓ: " + atencion); // + nombreEmpleado meter variable 
            ticket.TextoIzquierda("CLIENTE: " + nombreCliente); // + nombreCliente meter variable
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            //{
            //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            //}
            foreach (DetallePedido item in lista)
            {
                ticket.AgregaArticulo(item.variedad, item.cantidad, item.precio, item.precio / item.cantidad);
            }          
            //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            //ticket.AgregarTotales("         SUBTOTAL......$", 100);
            //ticket.AgregarTotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
            ticket.AgregarTotales("         TOTAL.........$", lista.AsEnumerable().Sum(o => o.precio));
            ticket.TextoIzquierda("");
            // ticket.AgregarTotales("         EFECTIVO......$", 200);
            // ticket.AgregarTotales("         CAMBIO........$", 0);

            //Texto final del Ticket.
            //ticket.TextoIzquierda("");
            //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.CortaTicket();
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

            if (numeroDetalle <= 9999999)
            {
                numeroDetalle++;
            }
            else if (numeroTickt<= 999)
            {
                numeroTickt++;
                numeroDetalle = 1;
            }
            else
            {
                numeroTickt = 1;
                numeroDetalle = 1;
            }

        }
    }
}
