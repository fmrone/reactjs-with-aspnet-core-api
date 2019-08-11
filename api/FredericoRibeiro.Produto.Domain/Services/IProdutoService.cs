using System.Collections.Generic;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.Domain.Services
{
    public interface IProdutoService
    {
        Task<Models.Produto> ObtemProdutoAsync(long id);
        Task<IEnumerable<Models.Produto>> ObtemProdutosAsync();
        Task<Models.Produto> CriaProdutoAsync(Models.Produto produto);
        Task<Models.Produto> AlteraProdutoAsync(Models.Produto produto);
        Task<bool> ExcluiProdutoAsync(long id);
    }
}
