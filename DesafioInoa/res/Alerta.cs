using DesafioInoa.src.metodos;

namespace DesafioInoa.res
{
    internal class Alerta
    {
        public static void Executar()
        {
            Console.WriteLine("Insira o ativo que quer rastrear e os alvos na forma: TICKER XXX,XX XXX,XX");
            string Resposta = Console.ReadLine();
            string[] RespostaDividida = Resposta.Split(" ");

            string Stock = RespostaDividida[0];
            float AlvoSuperior = float.Parse(RespostaDividida[1]);
            float AlvoInferior = float.Parse(RespostaDividida[2]);

            int caso = PertenceAoIntervalo.Executar(Stock, AlvoSuperior, AlvoInferior);
            Console.WriteLine(caso);

            switch (caso)
            {
                case 0:
                    Console.WriteLine("Teste");
                    break;
                case 1:
                    EnviarEmail.Superior(Stock);
                    break;
                case 2:
                    EnviarEmail.Inferior(Stock);
                    break;
            }
            
        }
    }
}
