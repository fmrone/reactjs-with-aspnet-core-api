using AutoMapper;
using FredericoRibeiro.Produto.Domain.Models;
using FredericoRibeiro.Produto.Domain.Repositories;
using FredericoRibeiro.Produto.Repository.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FredericoRibeiro.Produto.Repository
{
    public class ProdutoRepository : IProdutoReadOnlyRepository, IProdutoWriteOnlyRepository
    {
        private readonly ProdutoContext _produtoContext;
        private readonly DbSet<Data.Entities.Produto> _dataSet;

        public ProdutoRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext ?? 
                throw new ArgumentNullException(nameof(produtoContext));

            _dataSet = _produtoContext.Set<Data.Entities.Produto>();
        }

        public async Task<Domain.Models.Produto> ObtemProdutoAsync(long id)
        {
            var produto = await _dataSet.SingleOrDefaultAsync(q => q.Id == id);
            return ConvertToModel(produto);
        }

        public async Task<IEnumerable<Domain.Models.Produto>> ObtemProdutosAsync()
        {
            var produtos = await _dataSet.ToListAsync();
            return ConvertToModelList(produtos);
        }

        public async Task<Domain.Models.Produto> CriaProdutoAsync(Domain.Models.Produto produto)
        {
            Data.Entities.Produto produtoEntity = ConvertToEntity(produto);

            await _dataSet.AddAsync(produtoEntity);
            await _produtoContext.SaveChangesAsync();

            produto = ConvertToModel(produtoEntity);

            return produto;
        }

        public async Task<Domain.Models.Produto> AlteraProdutoAsync(Domain.Models.Produto produto)
        {
            var produtoEntity = await _dataSet
                .SingleOrDefaultAsync(q => q.Id == produto.Id);

            if (produtoEntity == null)
                return null;

            Data.Entities.Produto produtoEntityToUpdate = ConvertToEntity(produto);

            _produtoContext
                .Entry(produtoEntity)
                .CurrentValues
                .SetValues(produtoEntityToUpdate);

            await _produtoContext.SaveChangesAsync();

            return ConvertToModel(produtoEntityToUpdate);
        }

        public async Task<bool> ExcluiProdutoAsync(long id)
        {
            try
            {
                var produtoEntity = await _dataSet
                .SingleOrDefaultAsync(q => q.Id == id);

                if (produtoEntity != null)
                    _dataSet.Remove(produtoEntity);

                await _produtoContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static Data.Entities.Produto ConvertToEntity(Domain.Models.Produto produto)
        {
            return Mapper.Map<Domain.Models.Produto,
                Data.Entities.Produto>(produto);
        }

        private static Domain.Models.Produto ConvertToModel(Data.Entities.Produto produtoEntity)
        {
            return Mapper.Map<Data.Entities.Produto,
                Domain.Models.Produto>(produtoEntity);
        }

        private static IEnumerable<Domain.Models.Produto> ConvertToModelList(IEnumerable<Data.Entities.Produto> produtosEntity)
        {
            return Mapper.Map<IEnumerable<Data.Entities.Produto>,
                IEnumerable<Domain.Models.Produto>>(produtosEntity);
        }
    }
}
