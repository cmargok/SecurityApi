using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Security.Infrastructure.Externals.Notifications
{
    public class NotificationsApi 
    {
        public EmailSettings emailSettings { get; }

        public NotificationsApi(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            var emailRequest = new EmailToSendDto()
            {
                //DisplayName = "CQRS managment",
                //EmailFrom = "cmargokk@hotmail.com",

                DisplayName = emailSettings.FromDisplayName,
                EmailFrom = emailSettings.FromAdress,
                Html = false,
                Subject = email.Subject,
                Message = email.Body,
                EmailsTo = new List<EmailToSendDto.To> {
                    new EmailToSendDto.To
                    {

                        Email = email.To,
                        DisplayName = email.DisplayName,


                    }
                }
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("https://localhost:7001/api/v1/Email/");

            var requestContent = new StringContent(JsonConvert.SerializeObject(emailRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("SendEmail", requestContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            var h = await response.Content.ReadAsStringAsync();

            return false;

        }

    }


    public class EmailToSendDto
    {
        [EmailAddress]
        public string EmailFrom { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public List<To> EmailsTo { get; set; } = new List<To>();
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool Html { get; set; } = false;
        public string HtmlBody { get; set; } = string.Empty;

        public class To
        {
            public string DisplayName { get; set; } = string.Empty;

            [EmailAddress]
            public string Email { get; set; } = string.Empty;
        }
    }
    public class EmailSettings
    {

        public string FromAdress { get; set; } = string.Empty;
        public string FromDisplayName { get; set; } = string.Empty;
    }

}
