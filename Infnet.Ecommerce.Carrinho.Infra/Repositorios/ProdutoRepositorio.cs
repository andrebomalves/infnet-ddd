using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly HttpClient produtoClient;

        public ProdutoRepositorio(IHttpClientFactory httpClientFactory)
        {
            this.produtoClient = httpClientFactory.CreateClient("Produto");
        }
        public ProdutoConsulta RecuperarProduto(int produtoId)
        {
            ProdutoConsulta produto = null;

            var response = produtoClient.GetAsync($"produto/{produtoId}").Result;

            if (response.IsSuccessStatusCode)
            {
                produto = JsonSerializer.Deserialize<ProdutoConsulta>(response.Content.ReadAsStringAsync().Result);
            }

            return produto;
        }
    }
}
