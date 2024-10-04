using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.DTO;
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infnet.Ecommerce.Usuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServico usuarioAppServico;

        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;
        }

        [HttpPost]
        public ActionResult CadastrarNovoUsuario([FromBody] UsuarioRequest request)
        {
            if (request == null)
                return BadRequest();

            usuarioAppServico.CadastrarNovoUsuario(request);

            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioResponse>> RecuperarTodos()
        {
            var usuarios = usuarioAppServico.ListarTodos();

            return Ok(usuarios);
        }

        [HttpGet("{usuarioId}")]
        public ActionResult<UsuarioResponse> RecuperarPorId([FromRoute] string usuarioId)
        {
            if (string.IsNullOrEmpty(usuarioId))
                return BadRequest();

            var usuario = usuarioAppServico.ListarPorId(usuarioId);

            return Ok(usuario);
        }
         
    }
}
