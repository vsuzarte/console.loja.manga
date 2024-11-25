namespace loja.manga.dominio
{
    public class Manga
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public int QuantidadeEstoque { get; set; }

        public double ValorUnitario { get; set; }

        public bool Desativado { get; set; }

        public string ImprimirEmLinha()
        {
            return $"Id: {Id}, Nome: {Nome}, Autor: {Autor}, Quantidade em Estoque: {QuantidadeEstoque}, Valor Unitário: {ValorUnitario:C}";
        }

        public string ImprimirVariasLinhas()
        {
            return $"Id: {Id}\n" +
                   $"Nome: {Nome}\n" +
                   $"Autor: {Autor}\n" +
                   $"Quantidade em Estoque: {QuantidadeEstoque}\n" +
                   $"Valor Unitário: {ValorUnitario:C}";
        }
    }
}
