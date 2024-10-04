using Infnet.Ecommerce.Carrinho.Infra.Contexto;
using System.Data;

namespace Infnet.Ecommerce.Carrinho.Repositorios
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
