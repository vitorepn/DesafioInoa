using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioInoa.src.api;
using System.Net.Mail;

namespace DesafioInoa.src.metodos
{
    internal class EnviarEmail
    {
        public static MailMessage mail = api.mail.GerarMail();
        public static SmtpClient smtp = api.mail.GerarSmtp();
        public static void Inferior(string ativo){
            mail.Subject = "Seu ativo " + ativo + " atingiu o alvo superior";
            mail.Body = "Seu ativo " + ativo + " atingiu o alvo superior";
            Enviar();
        }
        public static void Superior(string ativo){
             
            mail.Subject = "Seu ativo " + ativo + " atingiu o alvo superior";
            mail.Body = "Seu ativo " + ativo + " atingiu o alvo superior";
            Enviar();
        }

        static void Enviar(){
            try{
                smtp.Send(mail);
            }catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
