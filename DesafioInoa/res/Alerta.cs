using DesafioInoa.src.metodos;

namespace DesafioInoa.res
{
    internal class Alerta
    {
        public static void Executar()
        {
            
            HashSet<Ativo> set = new HashSet<Ativo>();
            string Resposta = "";
            do{
                Console.WriteLine("Insira o ativo que quer rastrear e os alvos na forma: TICKER XXX,XX XXX,XX");
                Resposta = Console.ReadLine();
                string[] RespostaDividida = Resposta.Split(" ");
                try
                {
                    string Ticker = RespostaDividida[0];
                    float AlvoSuperior = float.Parse(RespostaDividida[1]);
                    float AlvoInferior = float.Parse(RespostaDividida[2]);

                    Ativo atual = new Ativo(Ticker, AlvoSuperior, AlvoInferior);
                    set.Add(atual);
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Erro de escrita");
                    Console.ResetColor();
                    continue;
                }
             
                foreach (Ativo i in set)
                {
                    try
                    {
                        int Email = PertenceAoIntervalo.Executar(i.Ticker, i.AlvoSuperior, i.AlvoInferior);
                        i.Email = Email;
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        set.Remove(i);
                    }
                    Console.WriteLine(i.Ticker);
                }
                
                EnviarEmail.Executar(set);
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
