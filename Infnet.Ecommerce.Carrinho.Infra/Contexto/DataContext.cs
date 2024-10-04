using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Infnet.Ecommerce.Carrinho.Infra.Contexto
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
            Cestas (
                CestaId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                UsuarioId TEXT,
                Status TEXT
                );

            CREATE TABLE IF NOT EXISTS 
            ItensCesta (
                ItemCestaId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                CestaId INTEGER, 
                ProdutoId INTEGER,
                Nome TEXT,
                PrecoUnitario REAL,
                Quantidade INTEGER
                );
            ";
            connection.Execute(sql);
        }
    }
}
