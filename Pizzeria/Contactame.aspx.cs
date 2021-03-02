using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;

namespace Pizzeria
{
    public partial class Contactame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            string fromAddress = ConfigurationManager.AppSettings["EmailAddress"].ToString();
            string fromPassword = ConfigurationManager.AppSettings["Password"].ToString();
            //var fromAddress = "christian718gonzalez@gmail.com";
            // any address where the email will be sending
            var toAddress = YourEmail.Text.ToString();
            //Password of your gmail address
            //const string fromPassword = "sofiamadelaine718179";
            // Passing the values and make a email formate to display
            string subject = YourSubject.Text.ToString();
            string body = "De: " + YourName.Text + "\n";
            body += "Email: " + YourEmail.Text + "\n";
            body += "Asunto: " + YourSubject.Text + "\n";
            body += "Consulta: " + Comments.Text + "\n"; //n
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587; //587
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //here on button click what will done 
                SendMail();
                string funtion = string.Format("Alertas('{0}','{1}');", 0, "Correo enviado con exito!"); //"Alerta();" 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", funtion, true);
               // DisplayMessage.Text = "Your Comments after sending the mail";
               // DisplayMessage.Visible = true;
                YourSubject.Text = "";
                YourEmail.Text = "";
                YourName.Text = "";
                Comments.Text = "";
            }
            catch (Exception ex) 
            {
                string funtion = string.Format("Alertas('{0}','{1}');", 1, ex.Message + "!"); 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", funtion, true);
                //this.DisplayMessage.Text = ex.Message;
               // this.DisplayMessage.Visible = true;
            }
        }
    }
}