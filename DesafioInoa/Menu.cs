using DesafioInoa.res;
using DesafioInoa.src.api;


namespace DesafioInoa
{
    class Menu {
        static void Main(string[] args) {
            var central = new CentralDeRecursos(new Dictionary<string, Action>() {
                {"Programa de Teste 1", Teste.Executar},
                {"Programa de Teste 2", Teste2.Executar},
                
            });

            central.SelecionarEExecutar();
        }
    }
}