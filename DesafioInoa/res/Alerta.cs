using DesafioInoa.src.metodos;
using System.Diagnostics;
namespace DesafioInoa.res
{
    internal class Alerta
    {
        static HashSet<Ativo> set = new HashSet<Ativo>();
        static string[] RespostaDividida = new string[3];
        public static void Main()
        {

            string Resposta = ""; ;
            int Delay = 60000;
            do {
                Stopwatch Cronometro = new Stopwatch();
                Cronometro.Start();
                try
                {
                    Console.WriteLine("Insira o ativo que quer rastrear e os alvos na forma: TICKER XXX,XX XXX,XX");
                    Resposta = Reader.ReadLine(30000);

                }
                catch (TimeoutException)
                {
                    Resposta = "0 0 0";
                }
                RespostaDividida = Resposta.Split(" ");
                try
                {
                    if (RespostaDividida[0] != "0")
                    {
                        string Ticker = RespostaDividida[0];
                        float AlvoSuperior = float.Parse(RespostaDividida[1]);
                        float AlvoInferior = float.Parse(RespostaDividida[2]);
                        if (AlvoInferior > AlvoSuperior)
                        {
                            float Aux = AlvoSuperior;
                            AlvoSuperior = AlvoInferior;
                            AlvoInferior = Aux;
                        }

                        Ativo atual = new Ativo(Ticker, AlvoSuperior, AlvoInferior);
                        set.Add(atual);
                    }

                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Erro de escrita");
                    Console.ResetColor();
                    continue;
                }

                AssociarEmail();
                Cronometro.Stop();
                EnviarEmail.Executar(set);
                Console.WriteLine("\nRastreando:");
                ExibirSet();

                Thread.Sleep(Delay - Convert.ToInt32(Cronometro.ElapsedMilliseconds));


            } while (true);

        }
        public static void ExibirSet()
        {
            foreach (Ativo i in set)
            {               
                Console.WriteLine("Ativo: " + i.Ticker + " Alvo superior: " + i.AlvoSuperior + " Alvo inferior: " + i.AlvoInferior);
            }
        }
        public static void AssociarEmail()
        {
            foreach (Ativo ativo in set)
            {
                try
                {
                    int Email = PertenceAoIntervalo.Executar(ativo.Ticker, ativo.AlvoSuperior, ativo.AlvoInferior);
                    ativo.Email = Email;
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    set.Remove(ativo);
                }
            }
        }
        class Reader
        {
            private static Thread inputThread;
            private static AutoResetEvent getInput, gotInput;
            private static string input;

            static Reader()
            {
                getInput = new AutoResetEvent(false);
                gotInput = new AutoResetEvent(false);
                inputThread = new Thread(reader);
                inputThread.IsBackground = true;
                inputThread.Start();
            }

            private static void reader()
            {
                while (true)
                {
                    getInput.WaitOne();
                    input = Console.ReadLine();
                    gotInput.Set();
                }
            }

            public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
            {
                getInput.Set();
                bool success = gotInput.WaitOne(timeOutMillisecs);
                if (success)
                    return input;
                else
                    throw new TimeoutException("User did not provide input within the timelimit.");
            }
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
