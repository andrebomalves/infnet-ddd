using AutoMapper;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Profiles
{
    public class ItemCestaProfile : Profile
    {
        public ItemCestaProfile()
        {
            CreateMap<ItemCestaRequest, ItemCesta>().ReverseMap();

        }
    }
}
