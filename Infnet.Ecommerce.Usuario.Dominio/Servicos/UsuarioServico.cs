using Infnet.Ecommerce.Usuario.Dominio.Repositorios;
using Infnet.Ecommerce.Usuario.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRespositorio usuarioRespositorio;

        public UsuarioServico(IUsuarioRespositorio usuarioRespositorio)
        {
            this.usuarioRespositorio = usuarioRespositorio;
        }
        public Entidades.Usuario ObterPorId(string usuarioId)
        {
            Guid id;

            bool guidEhValido = Guid.TryParse(usuarioId, out id);
            if (!guidEhValido)
                throw new Exception("O formado do id do usuario é invalido.");

            return usuarioRespositorio.ObterPorId(id);
        }

        public IEnumerable<Entidades.Usuario> ObterTodos()
        {
            return usuarioRespositorio.ObterTodos();
        }

        public void Salvar(Entidades.Usuario usuario)
        {
            usuarioRespositorio.Salvar(usuario);
        }
    }
}
