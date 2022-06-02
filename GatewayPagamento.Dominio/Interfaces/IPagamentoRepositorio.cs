using GatewayPagamento.Dominio.Entidades;
using System.Collections.Generic;

namespace GatewayPagamento.Dominio.Interfaces
{
    public interface IPagamentoRepositorio
    {
        void Inserir(Pagamento pagamento);
        List<Pagamento> Selecionar(string numeroCartao);
    }
}
