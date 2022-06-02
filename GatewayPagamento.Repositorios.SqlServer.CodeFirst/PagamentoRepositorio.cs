using GatewayPagamento.Dominio.Entidades;
using GatewayPagamento.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        public void Inserir(Pagamento pagamento)
        {
            using (var contexto= new GatewayPagamentoDbContext())
            {
                pagamento.Cartao = contexto.Cartoes.SingleOrDefault( c => c.Numero == pagamento.Cartao.Numero);

                contexto.Pagamentos.Add(pagamento);
                contexto.SaveChanges();
            }
        }

        public List<Pagamento> Selecionar(string numeroCartao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    .Where(p => p.Cartao.Numero == numeroCartao)
                    .ToList();
            }
        }

        //Buscar a condição pelo parâmetro do método
        public List<Pagamento> Selecionar(Expression<Func<Pagamento, bool>> condicao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    .Where(condicao)
                    .ToList();
            }
        }
    }
}
