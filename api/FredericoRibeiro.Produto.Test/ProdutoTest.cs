using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FredericoRibeiro.Produto.Test
{
    [TestClass]
    public class ProdutoTest
    {
        private readonly Domain.Models.Produto _mockProduto;
        private readonly Application.Services.ProdutoService _produtoService;

        public ProdutoTest()
        {
            _mockProduto = new Domain.Models.Produto();
            _produtoService = new Application.Services.ProdutoService();
        }

        [TestMethod]
        public void SucessoAoValidarRegraDeExclusao()
        {
            _mockProduto.Descricao = "MCBook Air";
            _mockProduto.Quantidade = 10;
            _mockProduto.Valor = 10000;

            var expected = _produtoService.PermiteExcluir(_mockProduto.Quantidade);
            var actual = false;

            Assert.AreEqual(expected, actual, "SucessoAoValidarRegraDeExclusao");
        }
    }
}
