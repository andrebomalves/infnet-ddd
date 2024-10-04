using Infnet.Ecommerce.Pagamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Dominio.Repositorios
{
    public interface IPagamentoRepositorio
    {
        void Salvar(Dominio.Entidades.Pagamento pagamento);
        Dominio.Entidades.Pagamento recuperarPorCesta(int cestaId);
    }
}
