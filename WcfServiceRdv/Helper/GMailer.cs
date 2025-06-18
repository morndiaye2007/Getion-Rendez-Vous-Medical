using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WcfServiceRdv.Models;

namespace WcfServiceRdv.App_Start
{
    /// <summary>
    /// Classe permettant l'envoi d'e-mails via Gmail.
    /// </summary>
    public class GMailer
    {
        

        public static string GmailUsername { get; set; } = "diabdullah113@gmail.com";
        public static string GmailPassword { get; set; } = "ocxxfmnrmjyxvghg";
        public static string GmailHost { get; set; } = "smtp.gmail.com";
        public static int GmailPort { get; set; } = 587;
        public static bool GmailSSL { get; set; } = true;

      
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        /// <summary>
        /// Envoie un e-mail en utilisant les informations définies.
        /// </summary>
        public void Send()
        {
            using (SmtpClient smtp = new SmtpClient(GmailHost, GmailPort))
            {
                smtp.EnableSsl = GmailSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                try
                {
                    using (var message = new MailMessage(GmailUsername, ToEmail))
                    {
                        message.Subject = Subject;
                        message.Body = Body;
                        message.IsBodyHtml = IsHtml;
                        smtp.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    WriteLogSystem(ex.ToString(), "Send Email Error");
                   // SaveFailedEmail(ToEmail, Subject, Body);
                }
            }
        }

        /// <summary>
        /// Envoie un e-mail avec les paramètres spécifiés.
        /// </summary>
        /// <param name="address">Adresse e-mail du destinataire.</param>
        /// <param name="subject">Sujet de l'e-mail.</param>
        /// <param name="body">Contenu de l'e-mail.</param>
        public static void senMail(string address, string subject, string body)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(GmailUsername);
                message.Subject = subject;
                message.Body = "<pre>" + body + "</pre>";
                message.To.Add(address);
                message.Priority = MailPriority.High;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient(GmailHost, GmailPort))
                {
                    client.EnableSsl = GmailSSL;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception e)
                    {
                        WriteLogSystem(e.ToString(), "Send Email Error");
                        //SaveFailedEmail(address, subject, body);
                    }
                }
            }
        }

      

        /// <summary>
        /// Enregistre un message dans les logs du système.
        /// </summary>
        /// <param name="message">Le message d'erreur.</param>
        /// <param name="libelle">Libellé décrivant l'erreur.</param>
        private static void WriteLogSystem(string message, string libelle)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {libelle} - {message}");
        }
    }
}
