using Dapper;
using Infnet.Ecommerce.Carrinho.Dominio.Entidades;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Infra.Contexto;
using Infnet.Ecommerce.Carrinho.Repositorios;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infnet.Ecommerce.Carrinho.Infra.Repositorios
{
    public class CestaRepositorio : BaseRepositorio, ICestaRepositorio
    {
        public CestaRepositorio(IDataContext dataContext) : base(dataContext)
        {
        }

        public void AdicionarItemCesta(int cestaId, ItemCesta itemCesta)
        {
            StringBuilder sqlItem = new StringBuilder();

            sqlItem.Append("insert into ItensCesta ");
            sqlItem.Append("(CestaId, ProdutoId, Nome, PrecoUnitario, Quantidade) ");
            sqlItem.Append("values (@cestaId, @produtoId, @nome, @precoUnitario, @quantidade);");

            connection.Execute(sqlItem.ToString(),
                                new { cestaId = cestaId, produtoId = itemCesta.ProdutoId, nome = itemCesta.Nome, precoUnitario = itemCesta.PrecoUnitario, quantidade = itemCesta.Quantidade });

        }

        public void CriarCesta(Cesta cesta)
        {
            int cestaId;
            string sql = @"
                        insert into Cestas (UsuarioId, Status) values (@usuarioId, @status);  
                        select last_insert_rowid();";

            cestaId = connection.ExecuteScalar<int>(sql, new { usuarioId = cesta.UsuarioId, status = cesta.Status.ToString() });

            if (cestaId != 0 && cesta.Itens.Any())
            {
                StringBuilder sqlItem = new StringBuilder();

                sqlItem.Append("insert into ItensCesta ");
                sqlItem.Append("(CestaId, ProdutoId, Nome, PrecoUnitario, Quantidade) ");
                sqlItem.Append("values (@cestaId, @produtoId, @nome, @precoUnitario, @quantidade);");

                cesta.Itens.ForEach(i =>
                {
                    connection.Execute(sqlItem.ToString(),
                                        new { cestaId = cestaId, produtoId = i.ProdutoId, nome = i.Nome, precoUnitario = i.PrecoUnitario, quantidade = i.Quantidade });
                });
            }
        }

        public Cesta RecuperarCestaAbertaPorUsuario(string usuarioId)
        {
            Cesta cesta;
            StringBuilder sqlCesta = new StringBuilder();
            sqlCesta.Append("select CestaId, UsuarioId, Status ");
            sqlCesta.Append("from Cestas ");
            sqlCesta.Append("where Status = 'Aberta' and UsuarioId = @usuarioId ");

            cesta = connection.QueryFirstOrDefault<Cesta>(sqlCesta.ToString(), new { usuarioId = usuarioId });

            if (cesta != null)
            {
                StringBuilder sqlItens = new StringBuilder();
                sqlItens.Append("select ItemCestaId, CestaId, ProdutoId, Nome, PrecoUnitario, Quantidade ");
                sqlItens.Append("from ItensCesta ");
                sqlItens.Append("where CestaId = @cestaId ");

                var itens = connection.Query<ItemCesta>(sqlItens.ToString(), new {cestaId = cesta.CestaId});

                cesta.Itens.AddRange(itens);
            }

            return cesta;
        }

        public Cesta RecuperarCestaAbertaPorId(int cestaId)
        {
            Cesta cesta;
            StringBuilder sqlCesta = new StringBuilder();
            sqlCesta.Append("select CestaId, UsuarioId, Status ");
            sqlCesta.Append("from Cestas ");
            sqlCesta.Append("where Status = 'Aberta' and CestaId = @cestaId ");

            cesta = connection.QueryFirstOrDefault<Cesta>(sqlCesta.ToString(), new { cestaId = cestaId });

            if (cesta != null)
            {
                StringBuilder sqlItens = new StringBuilder();
                sqlItens.Append("select ItemCestaId, CestaId, ProdutoId, Nome, PrecoUnitario, Quantidade ");
                sqlItens.Append("from ItensCesta ");
                sqlItens.Append("where CestaId = @cestaId ");

                var itens = connection.Query<ItemCesta>(sqlItens.ToString(), new { cestaId = cestaId });

                cesta.Itens.AddRange(itens);
            }

            return cesta;
        }

        public int RemoverItemCesta(int itemCestaId)
        {
            string sql = @"delete from ItensCesta where itemCestaId = @itemCestaId";
            var quantidaDeLinhasDeletadas = connection.Execute(sql, new { itemCestaId = itemCestaId });
            return quantidaDeLinhasDeletadas;
        }

        public int AtualizarStatusCesta(int cestaId, StatusCesta status)
        {

            string sql = @"update Cestas set Status = @status where CestaId = @cestaId";
            var quantidaDeLinhasAtualizadas = connection.Execute(sql, new { status = status.ToString() ,cestaId = cestaId });
            return quantidaDeLinhasAtualizadas;
        }
    }
}
