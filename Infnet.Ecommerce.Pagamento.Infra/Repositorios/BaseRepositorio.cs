using Infnet.Ecommerce.Pagamento.Infra.Contexto;
using System.Data;

namespace Infnet.Ecommerce.Pagamento.Repositorios
{
    public class BaseRepositorio
    {
        private readonly IDataContext dataContext;
        public IDbConnection connection;

        public BaseRepositorio(IDataContext dataContext) {
            this.connection = dataContext.GetDbConnection();
        }


    }
}
