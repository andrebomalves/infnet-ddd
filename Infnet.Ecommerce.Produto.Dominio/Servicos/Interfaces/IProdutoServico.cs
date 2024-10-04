using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Dominio.Servicos.Interfaces
{
    public interface IProdutoServico
    {
        public void Salvar(Dominio.Entidades.Produto produtoId);
        public Dominio.Entidades.Produto ObterPorId(int produto);
        public IEnumerable<Dominio.Entidades.Produto> ObterTodos();
    }
}
