using Infnet.Ecommerce.Produto.Aplicacao.Produto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Aplicacao.Produto.Interfaces
{
    public interface IProdutoAppServico
    {
        public void CadastrarNovoProduto(ProdutoRequest produtoRequest);

        public IEnumerable<ProdutoResponse> ListarTodos();

        public ProdutoResponse ListarPorId(int produtoId);
    }
}
