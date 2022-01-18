using System.Net.Mail;
using System.Configuration;

namespace DesafioInoa.src.api
{

    public class mail {
        static string from = ConfigurationManager.AppSettings["from"];
        static string password = ConfigurationManager.AppSettings["password"];
        static string to = ConfigurationManager.AppSettings["to"];
        static string smtpclient = ConfigurationManager.AppSettings["smtpclient"];
        static int smtpport = Int32.Parse(ConfigurationManager.AppSettings["smtpport"]);
        public static MailMessage GerarMail() {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            return mail;           
        }
        public static SmtpClient GerarSmtp() {
            SmtpClient smtp = new SmtpClient(smtpclient);
            smtp.Port = smtpport;
            smtp.Credentials = new System.Net.NetworkCredential(from, password);
            smtp.EnableSsl = true;
            return smtp;
        }
    }

}
