using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Security.Domain.Templates
{
    public  class HtmlTemplates
    {
        private static string HtmlBody = @"<!DOCTYPE html>
                                <html>

                                <head>
                                    <meta charset=""utf-8"">
                                    <title>Correo de validación</title>
                                </head>

                                <body>
                                    <p>Gracias por iniciar el registro en nuestra plataforma
                                        <br> Te enviamos el código de validación de ingreso y el
                                        código IV para poder
                                        registrarte correctamente en la plataforma:
                                    </p>
                                    <ul>
                                        <li><strong>Código de validación de ingreso:</strong>{0}</li>
                                        <li><strong>Código IV:</strong>{1}</li>
                                    </ul>
                                    <p>Gracias por tu tiempo.</p>
                                    <p>Cmargok Security System.</p>
                                </body>

                                </html>";  

        public static string GetPreRegisterTemplate()
        {
            return HtmlBody;
        }
    }
}
