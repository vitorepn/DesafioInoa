
namespace DesafioInoa.src.metodos
{
    internal class PertenceAoIntervalo
    {
        static Dictionary<string, float>? Dados;
        public static int Executar(string Stock, float AlvoSuperior, float AlvoInferior)
        {

            try
            {
                Dados = ReceberStock.Executar(Stock);
            }

            catch (Exception)
            {
                throw new ArgumentException("Ativo inválido");
            }

            if (AlvoSuperior <= Dados["high"] && AlvoSuperior >= Dados["low"]) return 1;

            else if (AlvoInferior <= Dados["high"] && AlvoInferior >= Dados["low"]) return 2;

            else return 0;
        }
    }
}
