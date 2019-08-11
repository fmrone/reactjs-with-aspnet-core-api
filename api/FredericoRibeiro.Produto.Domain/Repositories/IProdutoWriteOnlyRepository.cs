using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.Domain.Repositories
{
    public interface IProdutoWriteOnlyRepository
    {
        Task<Models.Produto> CriaProdutoAsync(Models.Produto produto);
        Task<Models.Produto> AlteraProdutoAsync(Models.Produto produto);
        Task<bool> ExcluiProdutoAsync(long id);
    }
}
