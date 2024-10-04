using AutoMapper;
using Infnet.Ecommerce.Produto.Aplicacao.Produto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Aplicacao.Produto.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Dominio.Entidades.Produto, ProdutoRequest>().ReverseMap();
            CreateMap<Dominio.Entidades.Produto, ProdutoResponse>().ReverseMap();
        }
    }
}
