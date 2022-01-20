using DesafioInoa.src.api;

namespace DesafioInoa.src.metodos
{
    internal class ReceberStock
    {
        public static Dictionary<string, float> Executar(string InputStock)
        {
            Dictionary<string, float> DadosStock = new Dictionary<string, float>();
            finance.RetornoApi Stock;
            try
            {
                Stock = finance.ObjetoStock(InputStock);
            }
            catch (Exception)
            {
                throw new ArgumentException("Ativo inválido");
            }
            DadosStock.Add("open", Stock.values[0].open);
            DadosStock.Add("close", Stock.values[0].close);
            DadosStock.Add("high", Stock.values[0].high);
            DadosStock.Add("low", Stock.values[0].low);

            return DadosStock;
        }
    }
}