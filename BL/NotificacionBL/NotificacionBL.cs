using ET;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL.NotificacionBL
{
    public class NotificacionBL : INotificacionBL
    {
        public async Task<RSV_Global<bool>> EnviarEmailCliente(string pNombreCliente, string pMail)
        {
            RSV_Global<bool> infoResultado = new RSV_Global<bool>();
            string pBody = string.Empty;

            try
            {

                if (!(ValidMail(pMail)))
                {
                    throw new System.ArgumentException($"El Mail {pMail} no es valido", new Exception($"El Mail {pMail} no es valido"));
                }

                pBody = "<link href='//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css' rel='stylesheet' id='bootstrap-css'><script src='//axcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js'></script><script src='//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script><link href='//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css' rel='stylesheet' id='bootstrap-css'>-<script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js'></script>-<script src='//code.jquery.com/jquery-1.11.1.min.js'></script><div style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial, sans-serif;'><table style='width: 100%;'><tr><td></td><td bgcolor='#FFFFFF'><div style='padding: 15px; max-width: 600px;margin: 0 auto;display: block; border-radius: 0px;padding: 0px; border: 1px solid lightseagreen;'><table style='width: 100%;background: #ff9000 ;'><tr><td></td> <td><div><table width='100%'><tr><td rowspan='2' style='text-align:center;padding:10px;'><img style='float:left; ' width='200'  src='https://ms-f7-sites-01-cdn.azureedge.net/docs/stories/774590-siigo-professional-services-office365-azure-spa-colombia/resources/7e4ff59a-d2d5-4dce-bc7d-7a0e4efda393/1186398634972771890_1186398634972771890' /></span></span></td></tr></table></div></td><td></td></tr></table><table style='padding: 10px;font-size:14px; width:100%;'><tr><td style='padding:10px;font-size:14px; width:100%;'><p>Hola [NOMBRE],</p><p><br /> Le escribimos para informarle que su pedido ya se encuentra disponible.</p><p>Gracias por su atención<br><br><strong>Cordialmente, </strong><br>Area de Ventas,<br></td></tr></table></div>";

                pBody = pBody.Replace("[NOMBRE]", pNombreCliente);

                await SendEmailRestPass($"Su pedido se encuentra disponible - Siigo", pBody, pMail);
                infoResultado.Exitoso = true;


            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");

            }

            infoResultado.Datos = true;
            return infoResultado;
        }

        public async Task<RSV_Global<bool>> EnviarEmailProveedor(string pNombreProveedor, string pNombreProducto, string pMail)
        {
            RSV_Global<bool> infoResultado = new RSV_Global<bool>();
            string pBody = string.Empty;

            try
            {

                if (!(ValidMail(pMail)))
                {
                    throw new System.ArgumentException($"El Mail {pMail} no es valido", new Exception($"El Mail {pMail} no es valido"));
                }

                pBody = "<link href='//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css' rel='stylesheet' id='bootstrap-css'><script src='//axcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js'></script><script src='//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script><link href='//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css' rel='stylesheet' id='bootstrap-css'>-<script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js'></script>-<script src='//code.jquery.com/jquery-1.11.1.min.js'></script><div style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial, sans-serif;'><table style='width: 100%;'><tr><td></td><td bgcolor='#FFFFFF'><div style='padding: 15px; max-width: 600px;margin: 0 auto;display: block; border-radius: 0px;padding: 0px; border: 1px solid lightseagreen;'><table style='width: 100%;background: #ff9000 ;'><tr><td></td> <td><div><table width='100%'><tr><td rowspan='2' style='text-align:center;padding:10px;'><img style='float:left; ' width='200'  src='https://ms-f7-sites-01-cdn.azureedge.net/docs/stories/774590-siigo-professional-services-office365-azure-spa-colombia/resources/7e4ff59a-d2d5-4dce-bc7d-7a0e4efda393/1186398634972771890_1186398634972771890' /></span></span></td></tr></table></div></td><td></td></tr></table><table style='padding: 10px;font-size:14px; width:100%;'><tr><td style='padding:10px;font-size:14px; width:100%;'><p>Hola [NOMBRE],</p><p><br /> Le escribimos para informarle que actualmente requerimos el producto <strong>[PRODUCTO]</strong>.</p><p>Gracias por su atención<br><br><strong>Cordialmente, </strong><br>Area de Ventas,<br></td></tr></table></div>";

                pBody = pBody.Replace("[NOMBRE]", pNombreProveedor);
                pBody = pBody.Replace("[PRODUCTO]", pNombreProducto);

                await SendEmailRestPass($"Solicitud de producto <{pNombreProducto}> - Siigo", pBody, pMail);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");

            }

            infoResultado.Datos = true;
            return infoResultado;
        }

        private Boolean ValidMail(String mail)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(mail, expresion))
            {
                if (Regex.Replace(mail, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private async Task SendEmailRestPass(string pAsunto, string pBody, string pEmailDestino)
        {
            MailAddress fromAddress = null;
            MailAddress toAddress = null;
            MailMessage message = null;
            SmtpClient smtpClient = null;
            string passMail = "Colombia2020*";
            string fechaVencimiento = string.Empty;

            try
            {
                fromAddress = new MailAddress("siiigo.info@gmail.com", "Siigo");
                smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, passMail),
                    EnableSsl = true
                };

                toAddress = new MailAddress(pEmailDestino);
                message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = pAsunto,
                    Body = pBody,
                    IsBodyHtml = true
                };

                await smtpClient.SendMailAsync(message);

                message.Dispose();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException($"Error al enviar el mensaje de recuperación de contraseña. Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}, {ex.Message.ToString()}", ex);
            }

        }
    }
}
