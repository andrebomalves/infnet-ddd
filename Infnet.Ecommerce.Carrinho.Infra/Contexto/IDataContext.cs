using System.Data;

namespace Infnet.Ecommerce.Carrinho.Infra.Contexto
{
    public interface IDataContext
    {
        void Init();
        IDbConnection GetDbConnection();
    }
}
