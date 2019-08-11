using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FredericoRibeiro.Produto.Domain.Services;
using FredericoRibeiro.Produto.WebApi.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FredericoRibeiro.Produto.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService ??
                throw new ArgumentNullException(nameof(produtoService));
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _produtoService.ObtemProdutosAsync();

            var produtosDto = Mapper.Map<IEnumerable<Domain.Models.Produto>,
                IEnumerable<ProdutoDto>>(produtos);

            return Ok(produtosDto);
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var produto = await _produtoService.ObtemProdutoAsync(id);
            if (produto == null)
                return NotFound();

            var produtoDto = Mapper.Map<Domain.Models.Produto,
                ProdutoDto>(produto);

            return Ok(produtoDto);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProdutoDto produtoDto)
        {
            if (produtoDto == null)
                return BadRequest();

            var produto = Mapper.Map<ProdutoDto,
                Domain.Models.Produto>(produtoDto);

            var produtoInserido = await _produtoService
                .CriaProdutoAsync(produto);

            var produtoInseridoDto = Mapper.Map<Domain.Models.Produto,
                ProdutoDto>(produtoInserido);
            
            return new OkObjectResult(produtoInseridoDto);
        }

        // PUT: api/Produto
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProdutoDto produtoDto)
        {
            if (produtoDto == null)
                return BadRequest();

            var produto = Mapper.Map<ProdutoDto,
                Domain.Models.Produto>(produtoDto);

            var produtoAlterado = await _produtoService
                .AlteraProdutoAsync(produto);

            var produtoAlteradoDto = Mapper.Map<Domain.Models.Produto,
                ProdutoDto>(produtoAlterado);

            return new OkObjectResult(produtoAlteradoDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var sucesso = await _produtoService.ExcluiProdutoAsync(id);

            if (sucesso)
                return Ok();

            return BadRequest();
        }
    }
}
