using System;
using System.Collections.Generic;
using DesafioInoa.Teste;


namespace DesafioInoa {
    class Menu {
        static void Main(string[] args) {
            var central = new CentralDeRecursos(new Dictionary<string, Action>() {
                {"Programa de Teste 1", Teste.Teste.Executar},
                {"Programa de Teste 2", Teste.Teste2.Executar},
            });

            central.SelecionarEExecutar();
        }
    }
}