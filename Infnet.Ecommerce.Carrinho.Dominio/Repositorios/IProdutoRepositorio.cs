using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios
{
    public interface IProdutoRepositorio
    {
        ProdutoConsulta RecuperarProduto(int produtoId);
    }
}
