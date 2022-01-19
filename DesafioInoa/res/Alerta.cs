using DesafioInoa.src.metodos;
using System.Diagnostics;
namespace DesafioInoa.res
{
    internal class Alerta
    {
        public static void Executar()
        {
           
            HashSet<Ativo> set = new HashSet<Ativo>();
            string Resposta = "";
            do{
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine("Insira o ativo que quer rastrear e os alvos na forma: TICKER XXX,XX XXX,XX");
                try
                {
                    Console.WriteLine("Please enter your name within the next 5 seconds.");
                    Resposta = Reader.ReadLine(30000);
                    Console.WriteLine("Hello, {0}!", Resposta);
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Sorry, you waited too long.");
                }
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
                }
                stopwatch.Stop();
                EnviarEmail.Executar(set);
                Thread.Sleep(60000- Convert.ToInt32(stopwatch.ElapsedMilliseconds));
                Console.WriteLine("Executando novamente");
            } while (true);
            
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

            // omit the parameter to read a line without a timeout
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
