using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Consulta
{
    public class UsuarioConsulta
    {
        [JsonPropertyName("usuarioId")]
        public string UsuarioId { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
