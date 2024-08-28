namespace RedSecure.Domain.Templates
{
    public class HtmlTemplates
    {
        private const string HtmlBody =
            "<!DOCTYPE html>" +
            "<html>" +
            "<head>" +
            "<meta charset=\"utf-8\"><title>Validation Email</title>" +
            "</head>" +
            "<body" +
            "><p>Hello <strong>{0}</strong>, thank you for starting the registration process on our platform" +
            "<br> We are sending you the validation code needed to register correctly:</p>" +
            "<ul><li>Validation code: <strong>{1}</strong></li></ul>" +
            "<p>Thank you for wanting to be part of our change.</p>" +
            "<p>Cmargok Security System.</p>" +
            "</body>" +
            "</html>";

        public static string GetPreRegisterTemplate()
        {
            return HtmlBody;
        }
    }
}
