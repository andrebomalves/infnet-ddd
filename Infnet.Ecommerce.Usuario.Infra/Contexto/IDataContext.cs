using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Infra.Contexto
{
    public interface IDataContext
    {
        void Init();
        IDbConnection GetDbConnection();
    }
}
