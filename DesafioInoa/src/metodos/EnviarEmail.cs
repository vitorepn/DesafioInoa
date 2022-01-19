using System.Net.Mail;
using static DesafioInoa.res.Alerta;

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
        public static void Executar(HashSet<Ativo> set)
        {
            mail.Body = "";
            foreach(Ativo ativo in set)
            {
                switch (ativo.Email)
                {
                    case 0:
                        break;
                    case 1:
                        mail.Body += "O ativo " + ativo.Ticker +" atingiu o alvo de venda\n";
                        break;
                    case 2:
                        mail.Body += "O ativo " + ativo.Ticker + " atingiu o alvo de compra\n";
                        break;
                }
            }
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
