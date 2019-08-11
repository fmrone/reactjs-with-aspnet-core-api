using FredericoRibeiro.Produto.Repository.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FredericoRibeiro.Produto.Repository.Data.Entities
{
    public class Produto : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        public byte Quantidade { get; set; }
        
        public decimal Valor { get; set; }
    }
}
