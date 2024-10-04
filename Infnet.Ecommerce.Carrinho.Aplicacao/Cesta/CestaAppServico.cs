using AutoMapper;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces;
using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Messagem;
using Infnet.Ecommerce.Carrinho.Dominio.Servicos.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta
{
    public class CestaAppServico : ICestaAppServico
    {
        private readonly ICestaServico cestaServico;
        private readonly IProdutoRepositorio produtoRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly ILogger<CestaAppServico> logger;
        private readonly IMapper mapper;

        public CestaAppServico(ICestaServico cestaServico, IProdutoRepositorio produtoRepositorio, IUsuarioRepositorio usuarioRepositorio, IPagamentoRepositorio pagamentoRepositorio, ILogger<CestaAppServico> logger, IMapper mapper)
        {
            this.cestaServico = cestaServico;
            this.produtoRepositorio = produtoRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
            PagamentoRepositorio = pagamentoRepositorio;
            this.logger = logger;
            this.mapper = mapper;
        }

        public IPagamentoRepositorio PagamentoRepositorio { get; }

        public void AdicionarItemCesta(ItemCestaRequest itemCestaRequest)
        {
            try
            {
                ItemCesta item = mapper.Map<ItemCesta>(itemCestaRequest);

                var produto = produtoRepositorio.RecuperarProduto(itemCestaRequest.ProdutoId);
                var usuario = usuarioRepositorio.RecuperaUsuario(itemCestaRequest.UsuarioId);

                if (usuario == null)
                    throw new Exception("Usuario informado é invalido");

                if (produto == null)
                    throw new Exception("Produto informado é invalido");

                item.PrecoUnitario = produto.Valor;
                item.Nome = produto.Nome;

                cestaServico.AdicionarItemCesta(itemCestaRequest.CestaId,item);
            }
            catch (Exception ex )
            {
                logger.LogError("Erro ao inserir produto {produtoId} a cesta {cestaId}",itemCestaRequest.ProdutoId, itemCestaRequest.CestaId);
                throw;
            }
        }
        public int AtualizarStatusCesta(int cestaId, string status)
        {
            int quantidadeResgistrosAtualizados = 0;
            try
            {
                StatusCesta statusCesta = mapper.Map<StatusCesta>(status);
                cestaServico.AtualizarStatusCesta(cestaId, statusCesta);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao atualizar status da venda");
                throw;
            }
            return quantidadeResgistrosAtualizados;
        }
        public CestaResponse RecuperarCestaAbertaPorUsuario(string usuarioId)
        {
            Dominio.Entidades.Cesta cesta = null;
            CestaResponse response = null;
            try
            {
                var usuario = usuarioRepositorio.RecuperaUsuario(usuarioId);
                if (usuario == null)
                    throw new Exception("Usuario informado é invalido");

                cesta = cestaServico.RecuperarCestaAbertaPorUsuario(usuarioId);

                if(cesta == null)
                {
                    cesta = new Dominio.Entidades.Cesta(usuarioId);
                    cestaServico.CriarCesta(cesta);
                    cesta = cestaServico.RecuperarCestaAbertaPorUsuario(usuarioId);
                }

                response = mapper.Map<CestaResponse>(cesta);

            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao recuperar cesta do usuario.");
                throw;
            }
            return response;
        }

        public void RegistrarPagamento(int cestaId, PagamentoRequest pagamentoRequest)
        {
            Dominio.Entidades.Cesta cesta = null;
            try
            {
                cesta = cestaServico.RecuperarCestaAbertaPorId(cestaId);
                if (cesta == null)
                    throw new Exception("Não foi possivel localizar a cesta informada.");

                PagamentoMensagem pagamento = new PagamentoMensagem();
                pagamento.CestaId = cesta.CestaId;
                pagamento.UsuarioId = cesta.UsuarioId;
                pagamento.MeioDePagamento = pagamentoRequest.MeioPagamento.ToString();
                pagamento.Parcelas = pagamentoRequest.Parcelas;
                pagamento.ValorTotal = cesta.ValorTotal;

                PagamentoRepositorio.RegistrarPagamento(pagamento);
            }
            catch (Exception ex)
            {
                logger.LogError("Erro ao registrar pagamento da cesta {cestaId}", cestaId);
                throw;
            }
        }

        public int RemoverItemCesta(int itemCestaId)
        {
            int quantidadeItensRemovidos = 0;
            try
            {
                cestaServico.RemoverItemCesta(itemCestaId);
            }
            catch (Exception)
            {
                logger.LogError("Erro ao remover item da cesta.");
                throw;
            }
            return quantidadeItensRemovidos;
        }
    }
}
