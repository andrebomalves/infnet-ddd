using AutoMapper;
using Infnet.Ecommerce.Produto.Aplicacao.Produto.DTO;
using Infnet.Ecommerce.Produto.Aplicacao.Produto.Interfaces;
using Infnet.Ecommerce.Produto.Dominio.Servicos.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Aplicacao.Produto
{
    public class ProdutoAppServico : IProdutoAppServico
    {
        private readonly IProdutoServico produtoServico;
        private readonly ILogger<ProdutoAppServico> logger;
        private readonly IMapper mapper;

        public ProdutoAppServico(IProdutoServico produtoServico, ILogger<ProdutoAppServico> logger, IMapper mapper)
        {
            this.produtoServico = produtoServico;
            this.logger = logger;
            this.mapper = mapper;
        }

        public void CadastrarNovoProduto(ProdutoRequest produtoRequest)
        {
            try
            {
                var produto = mapper.Map<Dominio.Entidades.Produto>(produtoRequest);
                produtoServico.Salvar(produto);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao criar novo produto. Produto: {@produtoRequest}", produtoRequest);
                throw;
            }
        }

        public ProdutoResponse ListarPorId(int produtoId)
        {
            ProdutoResponse produtoResponse;

            try
            {
                var usuario = produtoServico.ObterPorId(produtoId);
                produtoResponse = mapper.Map<ProdutoResponse>(usuario);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao listar produto. Id: {produtoId}", produtoId);
                throw;
            }

            return produtoResponse;
        }

        public IEnumerable<ProdutoResponse> ListarTodos()
        {
            IEnumerable<ProdutoResponse> produtosResponse = Enumerable.Empty<ProdutoResponse>();

            try
            {
                var produtos = produtoServico.ObterTodos();
                produtosResponse = mapper.Map<List<ProdutoResponse>>(produtos);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao listar todos os produtos.");
                throw;
            }

            return produtosResponse;
        }
    }
}
