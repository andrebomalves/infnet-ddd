using Dapper;
using Infnet.Ecommerce.Produto.Dominio.Repositorios;
using Infnet.Ecommerce.Produto.Infra.Contexto;
using Infnet.Ecommerce.Produto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Infra.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
    {
        public ProdutoRepositorio(IDataContext dataContext) : base(dataContext)
        {
        }

        public Dominio.Entidades.Produto ObterPorId(int produtoId)
        {
            var parans = new DynamicParameters();
            parans.Add("@produtoId", produtoId);

            string sql = @"select produtoid, nome, descricao, valor from produtos where produtoId = @produtoId;";

            return connection.QueryFirstOrDefault<Dominio.Entidades.Produto>(sql, parans);
        }

        public IEnumerable<Dominio.Entidades.Produto> ObterTodos()
        {
            string sql = @"select produtoid, nome, descricao, valor from produtos;";

            return connection.Query<Dominio.Entidades.Produto>(sql);
        }

        public void Salvar(Dominio.Entidades.Produto produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into produtos ");
            sql.Append("( nome, descricao, valor) ");
            sql.Append("values ( @nome, @descricao, @valor); ");

            var parametros = new DynamicParameters();

            parametros.Add("@nome", produto.Nome);
            parametros.Add("@descricao", produto.Descricao);
            parametros.Add("@valor", produto.Valor);

            connection.Execute(sql.ToString(), parametros);
        }
    }
}
