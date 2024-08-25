namespace RedSecure.Domain.Templates
{
    public class HtmlTemplates
    {
        private const string HtmlBody = @"<!DOCTYPE html>
                                <html>

                                <head>
                                    <meta charset=""utf-8"">
                                    <title>Correo de validación</title>
                                </head>

                                <body>
                                    <p>Hola {0}, gracias por iniciar el registro en nuestra plataforma
                                        <br> Te enviamos el código de validación de ingreso para
                                        registrarte correctamente:
                                    </p>
                                    <ul>
                                        <li><strong>Código de validación de ingreso:</strong>{1}</li>
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
