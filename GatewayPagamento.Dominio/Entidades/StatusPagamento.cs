using System.ComponentModel;

namespace GatewayPagamento.Dominio.Entidades
{
    public enum StatusPagamento
    {
        [Description("Saldo insuficiente")]
        SaldoIndisponivel = 1,

        [Description("Pedido já Pago")]
        PedidoJaPago = 2,

        [Description("Cartão Inexistente")]
        CartaoInexistente = 3,

        [Description("Pagamento OK")]
        PagamentoOK = 4
    }
}