using Infnet.Ecommerce.Carrinho.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO
{
    public class PagamentoRequest
    {
        public MeioPagamentoEnum MeioPagamento { get; set; }
        public int Parcelas {  get; set; }
    }


}
