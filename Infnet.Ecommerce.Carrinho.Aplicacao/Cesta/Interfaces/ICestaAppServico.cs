using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces
{
    public interface ICestaAppServico
    {
        void AdicionarItemCesta(DTO.ItemCestaRequest itemCestaRequest);

        int RemoverItemCesta(int itemCestaId);

        CestaResponse RecuperarCestaAbertaPorUsuario(string usuarioId);

        int AtualizarStatusCesta(int cestaId, string status);

        void RegistrarPagamento(int cestaId, PagamentoRequest pagamentoRequest);
    }
}
