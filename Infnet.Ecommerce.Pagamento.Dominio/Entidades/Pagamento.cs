using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Dominio.Entidades
{
    public class Pagamento
    {
        public Pagamento() {
            this.DataPagamento = DateTime.Now;
            this.Status = StatusPagamento.Aprovado;
        }
        public int PagamentoId { get; set; }
        public int CestaId { get; set; }
        public string UsuarioId { get; set; }
        public string MeioDePagamento { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusPagamento Status { get; set; }
  
    }

    public enum StatusPagamento
    {
        Pendente,
        Aprovado,
        Rejeitado
    }
}
