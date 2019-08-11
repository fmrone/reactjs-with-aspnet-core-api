using Microsoft.EntityFrameworkCore;

namespace FredericoRibeiro.Produto.Repository.Data.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext() { }

        public ProdutoContext(DbContextOptions<ProdutoContext> options) 
            : base(options) { }

        public DbSet<Entities.Produto> Produto { get; set; }
    }
}
