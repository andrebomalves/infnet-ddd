using Infnet.Ecommerce.Produto.Infra.Contexto;
using System.Data;

namespace Infnet.Ecommerce.Produto.Repositorios
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
