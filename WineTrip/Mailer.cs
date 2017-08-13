using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WineTrip
{
    public static class Mailer
    {
        public static void SendMail(string toAdress, string toName, string subject, string body, string attachementFileName = null)
        {
            SendMail(toAdress, ref toName, subject, body, attachementFileName);
        }

        public static void SendHtmlMail(string toAdress, string toName, string subject, string body, string attachementFileName = null)
        {
            SendMail(toAdress, ref toName, subject, body, attachementFileName, true);
        }

        private static void SendMail(string toAdress, ref string toName, string subject, string body, string attachementFileName, bool isBodyHtml = false)
        {
            MailAddress fromAddress = new MailAddress("winetripsolutions@gmail.com", "Wine trip solutions");
            if (toAdress == null)
            {
                MessageBox.Show("Mailadress is not filled in");
                return;
            }
            if (toName == null)
                toName = "";
            MailAddress toAddress = new MailAddress(toAdress, toName);
            string password = ConfigurationManager.AppSettings["GooglePassword"];

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            })
            {
                if (attachementFileName != null)
                {
                    FileInfo fileInfo = new FileInfo(attachementFileName);
                    Attachment attachment = new Attachment(attachementFileName, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = fileInfo.CreationTime;
                    disposition.ModificationDate = fileInfo.LastWriteTime;
                    disposition.ReadDate = fileInfo.LastAccessTime;
                    disposition.FileName = Path.GetFileName(attachementFileName);
                    disposition.Size = fileInfo.Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    message.Attachments.Add(attachment);
                }
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
