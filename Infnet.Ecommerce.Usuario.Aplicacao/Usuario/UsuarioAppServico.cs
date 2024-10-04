using AutoMapper;
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.DTO;
using UsuarioObj = Infnet.Ecommerce.Usuario.Dominio.Entidades.Usuario;
using Infnet.Ecommerce.Usuario.Dominio.Servicos.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Interfaces;

namespace Infnet.Ecommerce.Usuario.Aplicacao.Usuario
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly IUsuarioServico usuarioServico;
        private readonly ILogger<UsuarioAppServico> logger;
        private readonly IMapper mapper;

        public UsuarioAppServico(IUsuarioServico usuarioServico, ILogger<UsuarioAppServico> logger, IMapper mapper)
        {
            this.usuarioServico = usuarioServico;
            this.logger = logger;
            this.mapper = mapper;
        }

        public void CadastrarNovoUsuario(UsuarioRequest usuarioRequest)
        {

            try
            {
                var usuario = mapper.Map<UsuarioObj>(usuarioRequest);
                usuarioServico.Salvar(usuario);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao criar novo usuario. Usuario: {@usuarioRequest}", usuarioRequest);
                throw;
            }
        }

        public IEnumerable<UsuarioResponse> ListarTodos()
        {
            IEnumerable<UsuarioResponse> usuariosResponse = Enumerable.Empty<UsuarioResponse>();

            try
            {
                var usuarios = usuarioServico.ObterTodos();
                usuariosResponse = mapper.Map<List<UsuarioResponse>>(usuarios);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao listar todos os usuarios.");
                throw;
            }

            return usuariosResponse;
        }

        public UsuarioResponse ListarPorId(string usuarioId)
        {
            UsuarioResponse usuarioResponse;

            try
            {             
                var usuario = usuarioServico.ObterPorId(usuarioId);
                usuarioResponse = mapper.Map<UsuarioResponse>(usuario);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "erro ao listar usuario. Guid: {usuarioId}",usuarioId);
                throw;
            }

            return usuarioResponse;

        }
    }
}
