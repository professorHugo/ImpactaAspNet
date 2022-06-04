using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Interfaces;
using System.Linq;

namespace GatewayPagamento.Dominio.Sevicos
{
    public class PagamentoServico
    {
        //injeção das dependências das interfaces
        IPagamentoRepositorio pagamentoRepositorio;
        ICartaoRepositorio cartaoRepositorio;

        //Construtor da classe de serviços para usar as classes do repositório
        public PagamentoServico(IPagamentoRepositorio pagamentoRepositorio, ICartaoRepositorio cartaoRepositorio)
        {
            this.pagamentoRepositorio = pagamentoRepositorio;
            this.cartaoRepositorio = cartaoRepositorio;
        }
                
        //iniciar a utilização da classe para inserir o pagamento após a injeção das dependências
        public StatusPagamento Inserir(Pagamento pagamento)
        {
            var cartao = cartaoRepositorio.Selecionar(pagamento.Cartao.Numero);
            //verificar se o cartão existe dentro do cadastro do banco
            if (cartao == null)
            {
                return StatusPagamento.CartaoInexistente;
            }
            var pagamentoExistente = pagamentoRepositorio.Selecionar(p => p.NumeroPedido == pagamento.NumeroPedido);
            //verificar se existe o pagamento já efetuado
            if (pagamentoExistente.Any())
            {
                return StatusPagamento.PedidoJaPago;
            }
            //Verificar se o valor do pedido é maior que o limite do cartão
            if (pagamento.Valor > cartao.Limite)
            {
                return StatusPagamento.SaldoIndisponivel;
            }
            //Se todas as validações passarem inserir o pagamento e colocar o status do pagamento como ok
            pagamento.Status = StatusPagamento.PagamentoOK;
            pagamentoRepositorio.Inserir(pagamento);
            return StatusPagamento.PagamentoOK;

        }
    }
}
