using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infnet.Ecommerce.Carrinho.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CestaController : ControllerBase
    {
        private readonly ICestaAppServico cestaAppServico;

        public CestaController(ICestaAppServico cestaAppServico)
        {
            this.cestaAppServico = cestaAppServico;
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult RecuperarCesta([FromRoute] string usuarioId)
        {
            if (String.IsNullOrEmpty(usuarioId))
                return BadRequest();

            var cesta = cestaAppServico.RecuperarCestaAbertaPorUsuario(usuarioId);
            return Ok(cesta);
        }

        [HttpPost("item")]
        public ActionResult AdicionarItemNaCesta([FromBody] ItemCestaRequest itemCestaRequest)
        {
            cestaAppServico.AdicionarItemCesta(itemCestaRequest);
            return Ok();
        }

        [HttpDelete("item/{itemCestaId}")]
        public ActionResult RemoverItemDaCesta([FromRoute] int itemCestaId)
        {
            if (itemCestaId == 0)
                return BadRequest();

            cestaAppServico.RemoverItemCesta(itemCestaId);
            return Ok();
        }

        [HttpPut("{cestaId}")]
        public ActionResult AtualizarEstatus([FromRoute] int cestaId, [FromBody] CestaAtualizaStatusRequest statusRequest)
        {
            if(statusRequest == null || cestaId == 0)
                return BadRequest();

            cestaAppServico.AtualizarStatusCesta(cestaId, statusRequest.Status.ToString());

            return Ok();
        }

        [HttpPost("{cestaId}/pagamento")]
        public ActionResult RegistrarPagamento([FromRoute] int cestaId, [FromBody] PagamentoRequest pagamentoRequest) {

            cestaAppServico.RegistrarPagamento(cestaId, pagamentoRequest);

            return Ok();
        }
    }
}
