using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ResultadoSimuladorSabesprevMaisEntidade
    {
        public SaldoEntidade Saldo { get; set; }
        public List<SaldoEntidade> HistoricoSaldo { get; set; }
        public decimal SomaDasContribuicoesBrutas { get; set; }
        public DateTime DataAposentadoria { get; set; }
        public decimal ParcelasMensais { get; set; }
        public decimal RendaMensalDeterminada { get; set; }
        public int IdadePrazoDeterminadoInicio { get; set; }
        public int IdadePrazoDeterminadoFim { get; set; }
        public List<SaldoRestanteEntidade> SaldosRestantes { get; set; }
        public int IdadeRendaDefinidaInicio { get; set; }
        public int IdadeRendaDefinidaFim { get; set; }
        public int IdadeRendaDefinidaFimMinimo { get; set; }
        public int IdadeRendaDefinidaFimMax { get; set; }
        public int ParcelasMensaisRendaDefinida { get; set; }
        public decimal ValorRendaDefinida { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorRentabilidade { get; set; }
        public List<dynamic> HistoricoRendaDefinida { get; set; }
        public List<dynamic> HistoricoPrazoDefinido { get; set; }
        public string MensagemPrazoDeterminado { get; set; }
        public string MensagemRendaDefinida { get; set; }
        public string MensagemRendaDefinidaLimiteParcelas { get; set; }
        public decimal RendaAtuarial { get; set; }
        public string MensagemSimuladorDefault { get; set; }
        public decimal ValorRendaDefinidaMinimo { get; set; }
        public decimal ValorRendaDefinidaMaximo { get; set; }
    }
}
