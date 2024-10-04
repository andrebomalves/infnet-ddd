using Infnet.Ecommerce.Usuario.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Dominio.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        public void Salvar(Dominio.Entidades.Usuario usuario);
        public Dominio.Entidades.Usuario ObterPorId(string usuarioId);
        public IEnumerable<Dominio.Entidades.Usuario> ObterTodos();

    }
}
