using DesafioInoa.src.api;

namespace DesafioInoa.src.metodos
{
    internal class GetStock
    {
        public static Dictionary<string, float> Executar(string InputStock)
        {
            Dictionary<string, float> DadosStock = new Dictionary<string, float>();
            finance.RetornoApi Stock = finance.ObjetoStock(InputStock);

            DadosStock.Add("open", Stock.values[0].open);
            DadosStock.Add("close", Stock.values[0].close);
            DadosStock.Add("high", Stock.values[0].high);
            DadosStock.Add("low", Stock.values[0].low);

            return DadosStock;
        }
    }
}
