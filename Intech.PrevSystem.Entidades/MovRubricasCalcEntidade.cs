using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_MOV_RUBRICAS_CALC")]
	public class MovRubricasCalcEntidade
	{
		public string CD_TIPO_FOLHA { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public decimal NUM_PROCESSO { get; set; }
		public string ANO_PROCESSO { get; set; }
		public int SEQ_RECEBEDOR { get; set; }
		public DateTime DT_COMPETENCIA { get; set; }
		public string CD_RUBRICA { get; set; }
		public decimal SEQ_RECEBEDOR_PENSAO { get; set; }
		public decimal? VL_RUBRICA_MC { get; set; }
		public decimal? VL_RUBRICA_CT { get; set; }
		public string TP_PROV_DESC { get; set; }
		public decimal? PRAZO_DIAS { get; set; }
		public string CD_CONSIGNATARIO { get; set; }
		public string NUM_MATRICULA { get; set; }
		public decimal? NUM_PRESTACAO { get; set; }
		public decimal? TOT_PRESTACAO { get; set; }
		public string CAMPO_CALCULADO { get; set; }
		public decimal? VL_BASE_CALC { get; set; }
		public string COD_COBRANCA { get; set; }
		[Write(false)] public string DS_RUBRICA { get; set; }
		[Write(false)] public string RUBRICA_PROV_DESC { get; set; }
		[Write(false)] public string DS_TIPO_FOLHA { get; set; }
		[Write(false)] public string DS_ESPECIE { get; set; }
	}
}