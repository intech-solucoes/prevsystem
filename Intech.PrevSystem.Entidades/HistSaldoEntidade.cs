using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_HIST_SALDO")]
    public class HistSaldoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public int NUM_PROCESSO { get; set; }
		public string ANO_PROCESSO { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public string CD_OPCAO_RECEB { get; set; }
		public string CD_PERFIL_INVESTIM { get; set; }
		public decimal? QTD { get; set; }
		public decimal? VALOR_COTAS { get; set; }
		public decimal? VALOR_REAIS { get; set; }
		public decimal? SALDO_ANTERIOR { get; set; }
		public decimal? SALDO_ATUAL { get; set; }
		public decimal? VERSAO { get; set; }
		public decimal? VALOR_COTAS_RISCO { get; set; }
		public decimal? SALDO_ANT_RISCO { get; set; }
		public decimal? SALDO_ATUAL_RISCO { get; set; }
        
    }
}
