using Infnet.Ecommerce.Pagamento.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Infra.Repositorios
{
    public class CarrinhoRepositorio : ICarrinhoRepositorio
    {
        private readonly HttpClient client;
        public CarrinhoRepositorio(IHttpClientFactory factory )
        {
            this.client = factory.CreateClient("Carrinho"); 
        }
        public void AtualizaStatus(int cestaId, string status)
        {
            var request = new { status = status };
            var content = JsonSerializer.Serialize(request);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            client.PutAsync($"Cesta/{cestaId}", httpContent );
        }
    }
}
