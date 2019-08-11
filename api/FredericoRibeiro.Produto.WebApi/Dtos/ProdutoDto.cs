using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.WebApi.Dtos
{
    public class ProdutoDto
    {
        public long? Id { get; set; }
        public string Descricao { get; set; }
        public byte Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
