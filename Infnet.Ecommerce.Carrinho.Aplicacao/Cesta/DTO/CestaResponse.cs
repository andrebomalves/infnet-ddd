using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO
{
    public class CestaResponse
    {
        public int CestaId { get; set; }
        public string UsuarioId { get; set; }
        public string Status { get; set; }
        public List<ItemCestaResponse> Itens { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
