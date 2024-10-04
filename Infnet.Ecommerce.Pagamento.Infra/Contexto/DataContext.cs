using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Infnet.Ecommerce.Pagamento.Infra.Contexto
{
    public class DataContext : IDataContext
    {
        protected readonly IDbConnection connection;

        public DataContext(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
        }
        
        public IDbConnection GetDbConnection()
        {
            return this.connection;
        }

        public void Init()
        {
            var parametros = new DynamicParameters();

            var sql = @"
            CREATE TABLE IF NOT EXISTS 
            Pagamentos (
                PagamentoId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                CestaId INTEGER,
                UsuarioId INTEGER,
                MeioDePagamento TEXT,
                Parcelas INTEGER,
                ValorTotal REAL,
                DataPagamento TEXT,
                Status TEXT
                );
            ";
            connection.Execute(sql);
        }
    }
}
