using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Dominio.Repositorios
{
    public interface ICarrinhoRepositorio
    {
        void AtualizaStatus(int cestaId, string status);
    }
}
