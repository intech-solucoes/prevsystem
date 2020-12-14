﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ResultadoSimuladorSabesprevReforcoEntidade
    {
        public DateTime DataAposentadoria { get; set; }
        public decimal FundoIndividual { get; set; }
        public SaldoEntidade Saldo { get; set; }
        public List<SaldoEntidade> HistoricoSaldo { get; set; }
        public decimal SomaDasContribuicoesBrutas { get; set; }
        public int ParcelasMensais { get; set; }
        public decimal RendaMensalDeterminada { get; set; }
        public int IdadePrazoDeterminadoInicio { get; set; }
        public int IdadePrazoDeterminadoFim { get; set; }
        public decimal ValorRentabilidade { get; set; }
    }
}
