using Dapper;
using Infnet.Ecommerce.Pagamento.Dominio.Repositorios;
using Infnet.Ecommerce.Pagamento.Infra.Contexto;
using Infnet.Ecommerce.Pagamento.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Infra.Repositorios
{
    public class PagamentoRepositorio : BaseRepositorio, IPagamentoRepositorio
    {
        public PagamentoRepositorio(IDataContext dataContext) : base(dataContext)
        {
        }

        public Dominio.Entidades.Pagamento recuperarPorCesta(int cestaId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select cestaid, usuarioid, meiodepagamento, ");
            sql.Append("parcelas, valortotal, datapagamento, status from pagamentos ");
            sql.Append("where cestaid = @cestaid ");

            return connection.QueryFirstOrDefault<Dominio.Entidades.Pagamento>(sql.ToString(),new { cestaid = cestaId });
        }

        public void Salvar(Dominio.Entidades.Pagamento pagamento)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into pagamentos ");
            sql.Append("( cestaid, usuarioid, meiodepagamento, parcelas, valortotal, datapagamento, status) ");
            sql.Append("values ( @cestaid, @usuarioid, @meiodepagamento, @parcelas, @valortotal, @datapagamento, @status); ");

            var parametros = new DynamicParameters();

            parametros.Add("@cestaid", pagamento.CestaId);
            parametros.Add("@usuarioid", pagamento.UsuarioId);
            parametros.Add("@meiodepagamento", pagamento.MeioDePagamento);
            parametros.Add("@parcelas", pagamento.Parcelas);
            parametros.Add("@valortotal", pagamento.ValorTotal);
            parametros.Add("@datapagamento", pagamento.DataPagamento);
            parametros.Add("@status", pagamento.Status.ToString());

            connection.Execute(sql.ToString(), parametros);
        }
    }
}
