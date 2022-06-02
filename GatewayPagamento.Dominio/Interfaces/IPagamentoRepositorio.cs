using GatewayPagamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GatewayPagamento.Dominio.Interfaces
{
    public interface IPagamentoRepositorio
    {
        void Inserir(Pagamento pagamento);
        List<Pagamento> Selecionar(string numeroCartao);
        List<Pagamento> Selecionar(Expression<Func<Pagamento, bool>> condicao);
    }
}
