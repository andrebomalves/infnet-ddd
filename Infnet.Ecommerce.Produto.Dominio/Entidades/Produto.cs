using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Dominio.Entidades
{
    public class Produto
    {
		private int produtoId;

		public int ProdutoId
		{
			get { return produtoId; }
			set { produtoId = value; }
		}

		private string nome;

		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}
		private string descricao;

		public string Descricao
		{
			get { return descricao; }
			set { descricao = value; }
		}

		private decimal valor;

		public decimal Valor
		{
			get { return valor; }
			set { valor = value; }
		}


	}
}
