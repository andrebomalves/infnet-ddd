using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Servicos
{
    public class CestaServico : ICestaServico
    {
        private readonly ICestaRepositorio cestaRepositorio;

        public CestaServico(ICestaRepositorio cestaRepositorio)
        {
            this.cestaRepositorio = cestaRepositorio;
        }
        public void AdicionarItemCesta(int cestaId, ItemCesta itemCesta)
        {
            cestaRepositorio.AdicionarItemCesta(cestaId, itemCesta);
        }

        public int AtualizarStatusCesta(int cestaId, StatusCesta status)
        {
            return cestaRepositorio.AtualizarStatusCesta(cestaId, status);
        }

        public void CriarCesta(Cesta cesta)
        {
            cestaRepositorio.CriarCesta(cesta);
        }

        public Cesta RecuperarCestaAbertaPorUsuario(string usuarioId)
        {
            return cestaRepositorio.RecuperarCestaAbertaPorUsuario(usuarioId); 
        }

        public Cesta RecuperarCestaAbertaPorId(int cestaId)
        {
            return cestaRepositorio.RecuperarCestaAbertaPorId(cestaId);
        }

        public int RemoverItemCesta(int itemCestaId)
        {
            return cestaRepositorio.RemoverItemCesta(itemCestaId);
        }
    }
}
