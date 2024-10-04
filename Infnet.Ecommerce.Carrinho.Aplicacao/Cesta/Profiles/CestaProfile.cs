using AutoMapper;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Aplicacao.Utils;
using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Profiles
{
    public class CestaProfile : Profile
    {
        public CestaProfile()
        {
            CreateMap<Dominio.Entidades.Cesta,CestaResponse>().ReverseMap();
            CreateMap<ItemCesta, ItemCestaResponse>().ReverseMap();
            CreateMap<StatusCesta,string>().ConvertUsing( status => status.ToString() );
            CreateMap<string, StatusCesta>().ConvertUsing(status => status.ToEnum<StatusCesta>());
        }             
    }
}
