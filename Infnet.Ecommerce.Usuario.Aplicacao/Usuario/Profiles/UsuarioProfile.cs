using AutoMapper;
using Infnet.Ecommerce.Usuario.Aplicacao.Usuario.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Aplicacao.Usuario.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Dominio.Entidades.Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Dominio.Entidades.Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));
            CreateMap<Guid, string>().ConvertUsing(g => g.ToString());
            CreateMap<Guid?, string>().ConvertUsing(g => g.GetValueOrDefault().ToString());
            CreateMap<string, Guid?>().ConvertUsing(s => String.IsNullOrWhiteSpace(s) ? (Guid?)null : Guid.Parse(s));
        }
    }
}
