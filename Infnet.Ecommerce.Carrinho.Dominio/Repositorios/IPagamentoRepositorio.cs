using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Messagem;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios
{
    public interface IPagamentoRepositorio
    {
        void RegistrarPagamento(PagamentoMensagem pagamentoFiltro);
    }
}
