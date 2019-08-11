namespace FredericoRibeiro.Produto.Domain.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public byte Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
