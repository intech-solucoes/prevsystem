using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_FICHA_FINANC_ASSISTIDO")]
    public class FichaFinanceiraAssistidoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public decimal NUM_PROCESSO { get; set; }
		public string ANO_PROCESSO { get; set; }
		public int SEQ_RECEBEDOR { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public DateTime DT_COMPETENCIA { get; set; }
		public string CD_RUBRICA { get; set; }
		public decimal SEQ_RECEBEDOR_PENSAO { get; set; }
		public decimal? VALOR_MC { get; set; }
		public decimal? VALOR_CT { get; set; }
		public decimal? PRAZO { get; set; }
		public string CD_TIPO_FOLHA { get; set; }
		public string GB__CD_FUNDACAO { get; set; }
		public decimal? NUM_PRESTACAO { get; set; }
		public decimal? TOT_PRESTACAO { get; set; }
		public decimal? VL_BASE_CALC { get; set; }
		public string CAMPO_CALCULADO { get; set; }
		public string COD_COBRANCA { get; set; }
		[Write(false)] public string DS_RUBRICA { get; set; }
		[Write(false)] public string DS_ESPECIE { get; set; }
		[Write(false)] public string RUBRICA_PROV_DESC { get; set; }
		[Write(false)] public string ID_RUB_SUPLEMENTACAO { get; set; }
		[Write(false)] public bool IsAbonoAnual { get; set; }
		[Write(false)] public decimal? VAL_BRUTO { get; set; }
		[Write(false)] public decimal? VAL_DESCONTOS { get; set; }
		[Write(false)] public decimal? VAL_LIQUIDO { get; set; }
        
    }
}
