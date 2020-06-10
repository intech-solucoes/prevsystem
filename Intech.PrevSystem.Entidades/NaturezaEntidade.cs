using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_NATUREZA")]
	public class NaturezaEntidade
	{
		public decimal CD_NATUR { get; set; }
		public string DS_NATUR { get; set; }
		public decimal CD_GRUPO { get; set; }
		public string CD_FUNDO { get; set; }
		public decimal MES_CALC_PREST { get; set; }
		public decimal DIA_VENC_PREST { get; set; }
		public string DT_VENC_FSF { get; set; }
		public decimal? IDADE_MINIMA { get; set; }
		public decimal? TEMPO_MINIMO { get; set; }
		public decimal? CAR_QUIT_NORMAL { get; set; }
		public decimal? CAR_QUIT_ANTEC { get; set; }
		public decimal? CAR_RENOVACAO { get; set; }
		public decimal? CAR_SOLICITACAO { get; set; }
		public decimal? PRAZO_MIN { get; set; }
		public decimal? PRAZO_MAX { get; set; }
		public string CREDITO_UNICO { get; set; }
		public decimal? DIA_CREDITO { get; set; }
		public decimal? MES_CALC_CRED { get; set; }
		public string DT_CRED_FSF { get; set; }
		public decimal? LIMITE_DT_CREDITO { get; set; }
		public decimal? PREST_RESTANTES_RENOV { get; set; }
		public decimal? RENOVACAO_MIN_PERC { get; set; }
		public decimal? RENOVACAO_MAX_PERC { get; set; }
		public string SITUACAO { get; set; }
		public decimal? CD_CATEGORIA { get; set; }
		public string ID_CONVENIO { get; set; }
		public decimal? VL_FATOR_CALCULO { get; set; }
		public string CONSIDERAR_LIMITE_EMPRESTIMO { get; set; }
		public string CATEGORIA_ATIVO { get; set; }
		public string CATEGORIA_ASSISTIDO { get; set; }
		public string CATEGORIA_AUTOPATROCINADO { get; set; }
		public decimal? VL_INDICE_PROVISIONADO { get; set; }
		public string LIMITAR_SALARIO_MINIMO { get; set; }
		public string MES_CRED_CIVIL { get; set; }
		public decimal? MAX_CONTR_ATIVOS { get; set; }
		public decimal? TEMPO_TIPO_CONTRIBUICAO { get; set; }
		public decimal? LIMITE_TIPO_CONTRIBUICAO { get; set; }
		public decimal? MAX_CONTR_REFORMADOS { get; set; }
		public string CATEGORIA_DIFERIDO { get; set; }
		public decimal? CARENCIA_MIN { get; set; }
		public decimal? CARENCIA_MAX { get; set; }
		public string CONSIDERAR_CARENCIA_CONCESSAO { get; set; }
		public string SOMENTE_REFINANCIAMENTO { get; set; }
		public string AUTORIZACAO_ESPECIAL { get; set; }
		public string PERMITE_REFORMA { get; set; }
		public decimal? PERCENTUAL_DESCONTO { get; set; }
		public string ID_TEMP_VINC { get; set; }
		public string PERMITE_CONCESSAO_WEB { get; set; }
		[Write(false)] public List<DateTime> DatasCredito { get; set; }
		[Write(false)] public List<CarenciasDisponiveisEntidade> Carencias { get; set; }
		[Write(false)] public decimal MargemConsignavel { get; set; }
		[Write(false)] public decimal TaxaMargemConsignavel { get; set; }
		[Write(false)] public decimal TaxaJuros { get; set; }
		[Write(false)] public ConcessaoEntidade Concessao { get; set; }
	}
}
