using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Infnet.Ecommerce.Produto.Infra.Contexto
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
            Produtos (
                ProdutoId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                Nome TEXT,
                Descricao TEXT,
                Valor REAL
                );
            ";
            connection.Execute(sql);
        }
    }
}
