using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Interfaces
{
    public interface IUsuarioAppServico
    {
        public void CadastrarNovoUsuario(UsuarioRequest usuarioRequest);

        public IEnumerable<UsuarioResponse> ListarTodos();

        public UsuarioResponse ListarPorId(string usuarioId);
    }
}
