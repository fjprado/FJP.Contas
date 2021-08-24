using System;
using System.Collections.Generic;

namespace FJP.Contas
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Paga(int id, DateTime dataPagamento, decimal valorPagamento);
        int ProximoId();
    }
}