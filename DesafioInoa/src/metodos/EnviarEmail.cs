using System.Net.Mail;
using static DesafioInoa.res.Alerta;

namespace DesafioInoa.src.metodos
{
    internal class EnviarEmail
    {
        public static MailMessage mail = api.mail.GerarMail();
        public static SmtpClient smtp = api.mail.GerarSmtp();

        public static void Executar(HashSet<Ativo> set)
        {
            mail.Subject = "Alerta de ativos";
            mail.Body = "";
            foreach (Ativo ativo in set)
            {
                switch (ativo.Email)
                {
                    case 0:
                        break;
                    case 1:
                        mail.Body += "O ativo " + ativo.Ticker + " atingiu o alvo de venda:" + ativo.AlvoSuperior + "\n";
                        break;
                    case 2:
                        mail.Body += "O ativo " + ativo.Ticker + " atingiu o alvo de compra:" + ativo.AlvoInferior + "\n";
                        break;
                }
            }
            if (mail.Body != "")
            {
                Enviar();
            }

        }
        static void Enviar()
        {
            try
            {
                smtp.Send(mail);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
