using System;
using System.Collections.Generic;

namespace FJP.Contas
{
    public class ContaRepositorio : IRepositorio<Conta>
    {
        private List<Conta> listaConta = new List<Conta>();
        public void Paga(int id, DateTime dataPagamento, decimal valorPagamento)
        {
            var contaPaga = listaConta[id];
            contaPaga.DataPagamento = dataPagamento;
            contaPaga.StatusPagamento = dataPagamento > DateTime.Now ? StatusPagamentoEnum.Futuro : StatusPagamentoEnum.Pago;
            contaPaga.Valor = valorPagamento;
        }

        public void Exclui(int id)
        {
            listaConta[id].Excluir();
        }

        public void Insere(Conta objeto)
        {
            listaConta.Add(objeto);
        }

        public List<Conta> Lista()
        {
            return listaConta;
        }

        public int ProximoId()
        {
            return listaConta.Count;
        }

        public Conta RetornaPorId(int id)
        {
            return listaConta[id];
        }
    }
}