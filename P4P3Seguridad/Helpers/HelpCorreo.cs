using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P4P3Seguridad.Helpers
{
    public class HelpCorreo
    {
        public void SendMail(string correo, string asunto, string contenido)
        {
            MailMessage mail = new()
            {
                From = new MailAddress("221G0299@rcarbonifera.tecnm.mx", "Sistema de control escolar"),
                Subject = asunto,
                IsBodyHtml = true,
                Body = GetEmailTemplate(contenido)
            };

            mail.To.Add(correo);

            SmtpClient cliente = new("smtp.outlook.office365.com")
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("221G0299@rcarbonifera.tecnm.mx", "Tormenta.12")
            };

            cliente.Send(mail);
        }

        private string GetEmailTemplate(string mensaje)
        {
            return $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
<title>Registro Exitoso</title>
<style>
                body {{
                    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                    line-height: 1.6;
                    color: #333333;
                    margin: 0;
                    padding: 0;
                    background-color: #f5f5f5;
                }}
                .main-table {{
                    width: 100%;
                    max-width: 600px;
                    margin: 20px auto;
                    background: #ffffff;
                    border-radius: 8px;
                    overflow: hidden;
                    box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
                    border-collapse: collapse;
                }}
                .header {{
                    background: #2c3e50;
                    padding: 20px;
                    text-align: center;
                    color: #ffffff;
                }}
                .header h1 {{
                    margin: 10px 0 0;
                    font-size: 24px;
                }}
                .content {{
                    padding: 30px;
                }}
                .content h2 {{
                    color: #2c3e50;
                    margin-top: 0;
                }}
                .content p {{
                    margin-bottom: 20px;
                }}
                .button {{
                    display: inline-block;
                    background: #3498db;
                    color: #ffffff !important;
                    text-decoration: none;
                    padding: 12px 25px;
                    border-radius: 5px;
                    margin: 20px 0;
                    font-weight: bold;
                }}
                .footer {{
                    background: #f5f5f5;
                    padding: 20px;
                    text-align: center;
                    font-size: 12px;
                    color: #777777;
                }}
                .logo {{
                    color: #ffffff;
                    font-size: 24px;
                    font-weight: bold;
                }}
</style>
</head>
<body>
<!-- Tabla principal -->
<table class='main-table' border='0' cellpadding='0' cellspacing='0' width='100%'>
<!-- Cabecera -->
<tr>
<td class='header'>
<span class='logo'>Sistema de Control Escolar</span>
<h1>¡Registro Exitoso!</h1>
</td>
</tr>
<!-- Contenido -->
<tr>
<td class='content'>
<h2>Bienvenido/a a nuestro sistema</h2>
<p>{mensaje}</p>
<p>Gracias por registrarte en nuestro sistema de control escolar. 
                        Ahora podrás acceder a todos los servicios disponibles.</p>
<p>Si no realizaste este registro, por favor ignora este mensaje 
                        o contacta con nuestro equipo de soporte.</p>
<p>Atentamente,</p>
<p><strong>Equipo de Control Escolar</strong><br>
                        Instituto Tecnológico de la Región Carbonífera</p>
</td>
</tr>
<!-- Pie de página -->
<tr>
<td class='footer'>
                        © {DateTime.Now.Year} Sistema de Control Escolar. Todos los derechos reservados.
</td>
</tr>
</table>
</body>
</html>";
        }
    }
}
