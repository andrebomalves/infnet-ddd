using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO
{
    public class CestaAtualizaStatusRequest
    {
        public StatusCesta Status { get; set; }
    }
}
