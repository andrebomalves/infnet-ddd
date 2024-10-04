using Infnet.Ecommerce.Usuario.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infnet.Ecommerce.Usuario.Infra.Repositorios
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
