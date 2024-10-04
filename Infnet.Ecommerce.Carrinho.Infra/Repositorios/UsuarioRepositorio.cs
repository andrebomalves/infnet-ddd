using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly HttpClient usuarioClient;

        public UsuarioRepositorio(IHttpClientFactory httpClientFactory)
        {
            usuarioClient = httpClientFactory.CreateClient("Usuario");
        }
        public UsuarioConsulta RecuperaUsuario(string usuarioId)
        {
            UsuarioConsulta usuario = null;

            var response = usuarioClient.GetAsync($"usuario/{usuarioId}").Result;

            if (response.IsSuccessStatusCode)
            {
                usuario = JsonSerializer.Deserialize<UsuarioConsulta>(response.Content.ReadAsStringAsync().Result);
            }

            return usuario;
        }
    }
}
