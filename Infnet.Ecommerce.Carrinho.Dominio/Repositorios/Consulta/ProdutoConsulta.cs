using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Consulta
{
    public class ProdutoConsulta
    {
        [JsonPropertyName("produtoId")]
        public int ProdutoId { get; set; }
        
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

    }
}
