using DesafioInoa.src.metodos;

namespace DesafioInoa.res
{
    internal class Alerta
    {
        public static void Executar()
        {
            Console.WriteLine("Insira o ativo que quer rastrear e os alvos na forma: TICKER XXX,XX XXX,XX");
            HashSet<Ativo> set = new HashSet<Ativo>();
            string Resposta = "";
            do{
                
               Resposta = Console.ReadLine();
                string[] RespostaDividida = Resposta.Split(" ");

                string Ticker = RespostaDividida[0];
                float AlvoSuperior = float.Parse(RespostaDividida[1]);
                float AlvoInferior = float.Parse(RespostaDividida[2]);

                Ativo atual = new Ativo(Ticker, AlvoSuperior, AlvoInferior);
                set.Add(atual);
                foreach (Ativo i in set)
                {
                    int Email = PertenceAoIntervalo.Executar(i.Ticker, i.AlvoSuperior, i.AlvoInferior);
                    i.Email = Email;
                }
                EnviarEmail.Executar(set);
                Console.WriteLine("Você pode pode adicionar mais de um ativo: ");
                Console.WriteLine("Escreva TICKER 0 0 para remover");
            } while (true);
            
        }
        public class Ativo {
            public string Ticker;
            public float AlvoSuperior;
            public float AlvoInferior;
            public int Email=0;

            public Ativo(string Ticker, float AlvoSuperior, float AlvoInferior)
            {
                this.Ticker = Ticker;
                this.AlvoSuperior = AlvoSuperior;
                this.AlvoInferior=AlvoInferior;
                
            }
        }
    }
}
