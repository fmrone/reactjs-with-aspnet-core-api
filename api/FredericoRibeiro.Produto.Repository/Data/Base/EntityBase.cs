using System.ComponentModel.DataAnnotations;

namespace FredericoRibeiro.Produto.Repository.Data.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
