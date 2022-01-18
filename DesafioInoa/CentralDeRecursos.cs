namespace DesafioInoa
{
    public class CentralDeRecursos {
        Dictionary<string, Action> Recursos;

        public CentralDeRecursos(Dictionary<string, Action> recursos) {
            Recursos = recursos;    
        }

        public void SelecionarEExecutar() {
            int i = 1;
            Console.WriteLine("Escolha um dos recursos na lista");
            foreach (var programa in Recursos) {
                Console.WriteLine("{0}) {1}", i, programa.Key);
                i++;
            }
            bool numValido = false;
            int num;
            do {
                Console.Write("Digite o número: ");

                int.TryParse(Console.ReadLine(), out num);
                numValido = num > 0 && num <= Recursos.Count;
                if (numValido) {
                    num--;
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Opção Inválida");
                    Console.ResetColor();
                }

            } while (!numValido) ;
            
            string nomeDoRecurso = Recursos.ElementAt(num).Key;

            Console.Write("\nExecutando ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(nomeDoRecurso);
            Console.ResetColor();

            Console.WriteLine(String.Concat(
                Enumerable.Repeat("=", nomeDoRecurso.Length + 21)) + "\n");

            Action executar = Recursos.ElementAt(num).Value;
            try {
                executar();
            } catch(Exception e) {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ocorreu um erro: {0}", e.Message);
                Console.ResetColor();

                Console.WriteLine(e.StackTrace);
            }
        }
    }
}