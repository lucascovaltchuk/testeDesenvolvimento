
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;

namespace WebAppTestFull.Services
{
    public class EmailService
    {
        public void SendEmail(string filePath, string recipient, string projectLink)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema", "no-reply@webapp.com"));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = "WebAppTestFull - Dados Gerados";

            var body = new TextPart("plain") {
                Text = "Olá, segue o arquivo Excel gerado em anexo. " +
           "Este projeto foi realizado como parte do teste para o desenvolvimento. " +
           "Você pode acessar o repositório do projeto no GitHub pelo seguinte link: " + projectLink + "\n\n" +
           "Atenciosamente,\nLucas Augusto Covaltchuk Calixto."
            };


            var attachment = new MimePart("application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                Content = new MimeContent(File.OpenRead(filePath)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(filePath)
            };

            var multipart = new Multipart("mixed")
            {
                body,
                attachment
            };

            message.Body = multipart;

            using (var client = new SmtpClient())
            {         
                client.Connect("smtp.server.com", 587, false); 
                client.Authenticate("lucasatakteste@gmail.com", "testeatak123"); 
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
