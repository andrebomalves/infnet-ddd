using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infnet.Ecommerce.Produto.Dominio.Entidades;

namespace Infnet.Ecommerce.Produto.Dominio.Repositorios
{
    public interface IProdutoRepositorio
    {
        public void Salvar(Produto.Dominio.Entidades.Produto produto);

        public Produto.Dominio.Entidades.Produto ObterPorId(int produtoId);

        public IEnumerable<Produto.Dominio.Entidades.Produto> ObterTodos();
    }
}
