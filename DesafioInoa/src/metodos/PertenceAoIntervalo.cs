using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioInoa.src.metodos
{
    internal class PertenceAoIntervalo
    {
        public static int Executar(string Stock,float AlvoSuperior, float AlvoInferior)
        {
            Dictionary<string, float> Dados = GetStock.Executar(Stock);
            if (AlvoSuperior <= Dados["high"] && AlvoSuperior >= Dados["low"]) { 
                return 1; 
            }else if(AlvoInferior <= Dados["high"] && AlvoInferior >= Dados["low"])
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
