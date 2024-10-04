using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Servicos.Interfaces
{
    public interface ICestaServico
    {
        void CriarCesta(Cesta cesta);
        void AdicionarItemCesta(int cestaId, ItemCesta itemCesta);

        int RemoverItemCesta(int itemCestaId);

        Cesta RecuperarCestaAbertaPorUsuario(string usuarioId);

        Cesta RecuperarCestaAbertaPorId(int cestaId);

        int AtualizarStatusCesta(int cestaId, StatusCesta status);
    }
}
