using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO
{
    public class ItemCestaRequest
    {
        public string UsuarioId { get; set; }
        public int CestaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
