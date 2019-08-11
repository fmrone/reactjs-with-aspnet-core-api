using System.Collections.Generic;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.Domain.Repositories
{
    public interface IProdutoReadOnlyRepository
    {
        Task<Models.Produto> ObtemProdutoAsync(long id);
        Task<IEnumerable<Models.Produto>> ObtemProdutosAsync();
    }
}
