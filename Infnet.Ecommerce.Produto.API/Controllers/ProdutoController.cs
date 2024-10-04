using Infnet.Ecommerce.Produto.Aplicacao.Produto.DTO;
using Infnet.Ecommerce.Produto.Aplicacao.Produto.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infnet.Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppServico produtoAppServico;

        public ProdutoController(IProdutoAppServico produtoAppServico)
        {
            this.produtoAppServico = produtoAppServico;
        }

        [HttpPost]
        public ActionResult CadastrarNovoProduto([FromBody] ProdutoRequest request)
        {
            if (request == null)
                return BadRequest();

            produtoAppServico.CadastrarNovoProduto(request);

            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoResponse>> RecuperarTodos()
        {
            var produtos = produtoAppServico.ListarTodos();

            return Ok(produtos);
        }

        [HttpGet("{produtoId}")]
        public ActionResult<ProdutoResponse> RecuperarPorId([FromRoute] int produtoId)
        {
            if (produtoId <= 0)
                return BadRequest();

            var produto = produtoAppServico.ListarPorId(produtoId);

            return Ok(produto);
        }
    }
}
