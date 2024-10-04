using System.Data;

namespace Infnet.Ecommerce.Produto.Infra.Contexto
{
    public interface IDataContext
    {
        void Init();
        IDbConnection GetDbConnection();
    }
}
