using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using vexpenses.library.Config;
using vexpenses.library.Entities;
using vexpenses.library.Helpers;

namespace vexpenses.business.Components
{
    public class EmailComponent
    {
        public readonly EmailConfig _config;

        public EmailComponent(EmailConfig config)
        {
            _config = config;
        }

        private string TemplateEmailPadrao(Contato contato)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<br />");
            builder.AppendLine($"<b>Um novo contato foi registrado em sua agenda.");
            builder.AppendLine("<br /><br />");
            builder.AppendLine("Dados do contato: ");
            builder.AppendLine("<br /><br />");
            builder.AppendLine($"Nome: {contato.Nome}");
            builder.AppendLine("<br /><br />");
            builder.AppendLine($"Email: {contato.Email}");
            builder.AppendLine("<br /><br />");
            if (contato.Telefone.Count > 0)
            {
                builder.AppendLine($"Telefone: ({contato.Telefone.FirstOrDefault().DDD}){contato.Telefone.FirstOrDefault().Numero}");
                builder.AppendLine("<br /><br />");
            }
            builder.AppendLine("Para mais detalhes acesse o contato diretamente no aplicativo.");
            builder.AppendLine("<br /><br />");
            builder.AppendLine("Atenciosamente equipe VExpenses.");
            builder.AppendLine("<br />");

            return builder.ToString();
        }
        public async Task EnviarEmailContato(Contato contato, string destinatario)
        {
            if (_config == null)
            {
                throw new ArgumentNullException("EmailConfig");
            }

            _config.Validate();

            var mail = new MailMessage()
            {
                From = new MailAddress(_config.Username, "(no-reply) VExpenses - Controle de ações"),
            };

            mail.To.Add(destinatario);

            mail.Subject = $"VExpenses - Cadastro de contato na sua agenda";

            mail.Body = TemplateEmailPadrao(contato);

            mail.IsBodyHtml = true;

            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(_config.Domain, _config.Port))
            {
                smtp.Credentials = new NetworkCredential(_config.Username, _config.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
