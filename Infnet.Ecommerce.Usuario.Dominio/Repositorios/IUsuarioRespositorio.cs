using Infnet.Ecommerce.Usuario.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Dominio.Repositorios
{
    public interface IUsuarioRespositorio
    {
        Entidades.Usuario ObterPorId(Guid usuarioId);
        void Salvar(Entidades.Usuario usuario);
        IEnumerable<Entidades.Usuario> ObterTodos();

    }
}
