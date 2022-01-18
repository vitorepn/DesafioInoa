using DesafioInoa.src.metodos;
using DesafioInoa.src.api;

namespace DesafioInoa.res {
    class Teste {
        public static void Executar() {
            //Console.WriteLine("Este programa foi chamado");
            EnviarEmail.Inferior((GetStock.Executar("PETR4")["open"]).ToString());

        }
    }
}
