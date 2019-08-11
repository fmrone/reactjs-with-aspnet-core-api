using FredericoRibeiro.Produto.Domain.Models;
using FredericoRibeiro.Produto.Domain.Repositories;
using FredericoRibeiro.Produto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoReadOnlyRepository _produtoReadOnlyRepository;
        private readonly IProdutoWriteOnlyRepository _produtoWriteOnlyRepository;

        public ProdutoService() { }
        public ProdutoService(
            IProdutoReadOnlyRepository produtoReadOnlyRepository,
            IProdutoWriteOnlyRepository produtoWriteOnlyRepository)
        {
            _produtoReadOnlyRepository = produtoReadOnlyRepository ??
                throw new ArgumentNullException(nameof(produtoReadOnlyRepository));

            _produtoWriteOnlyRepository = produtoWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(produtoWriteOnlyRepository));
        }

        public async Task<Domain.Models.Produto> ObtemProdutoAsync(long id)
        {
            return await _produtoReadOnlyRepository.ObtemProdutoAsync(id);
        }

        public async Task<IEnumerable<Domain.Models.Produto>> ObtemProdutosAsync()
        {
            return await _produtoReadOnlyRepository.ObtemProdutosAsync();
        }

        public async Task<Domain.Models.Produto> CriaProdutoAsync(Domain.Models.Produto produto)
        {
            return await _produtoWriteOnlyRepository.CriaProdutoAsync(produto);
        }

        public async Task<Domain.Models.Produto> AlteraProdutoAsync(Domain.Models.Produto produto)
        {
            return await _produtoWriteOnlyRepository.AlteraProdutoAsync(produto);
        }

        public async Task<bool> ExcluiProdutoAsync(long id)
        {
            // velidação de negócio, antes da exclusão PermiteExcluir
            // exemplo: só pode ser excluído produto que o estoque estiver zerado.
            // a exclusão deveria ser lógica, mas foi implementado o método de exclusão para entendimento didático.
            return await _produtoWriteOnlyRepository.ExcluiProdutoAsync(id);
        }

        public bool PermiteExcluir(int quantidadeEmEstoque)
        {
            // uso conceitual para ser utilizado nos testes unitários
            if (quantidadeEmEstoque == 0)
                return true;
            return false;
        }
    }
}
