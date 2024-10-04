using System.Data;

namespace Infnet.Ecommerce.Pagamento.Infra.Contexto
{
    public interface IDataContext
    {
        void Init();
        IDbConnection GetDbConnection();
    }
}
