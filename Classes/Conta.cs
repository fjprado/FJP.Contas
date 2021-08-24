using System;

namespace FJP.Contas
{
    public class Conta : EntidadeBase
    {
        // Atributos
		private TipoContaEnum TipoConta { get; set; }
		private string Titulo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
		public DateTime? DataPagamento { get; set; }
		public StatusPagamentoEnum StatusPagamento { get; set; }

        // Métodos
        public Conta(int id, TipoContaEnum tipoConta, string titulo, decimal valor, DateTime dataVencimento, DateTime? dataPagamento = null)
		{
			this.Id = id;
			this.TipoConta = tipoConta;
			this.Titulo = titulo;
			this.Valor = valor;
			this.DataVencimento = dataVencimento;
			this.DataPagamento = dataPagamento;
			this.StatusPagamento = DateTime.Now.AddDays(-1) > dataVencimento ? StatusPagamentoEnum.Atraso : StatusPagamentoEnum.Aberto;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Tipo Conta: " + this.TipoConta + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
			retorno += "Valor: " + this.Valor + Environment.NewLine;
            retorno += "Data de Vencimento: " + this.DataVencimento + Environment.NewLine;
			if(this.DataPagamento != null)
				retorno += "Data de Pagamento: " + this.DataPagamento + Environment.NewLine;
			retorno += "Status Pagamento: " + this.StatusPagamento;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}

		public string retornaValor()
		{
			return string.Format("{0:C}", this.Valor);
		}

        public string retornaTipoConta()
		{
			return this.TipoConta.ToString();
		}
		
		public string retornaStatus()
		{
			return this.StatusPagamento.ToString();
		}

        public void Excluir() {
            this.StatusPagamento = StatusPagamentoEnum.Removido;
        }
    }
}