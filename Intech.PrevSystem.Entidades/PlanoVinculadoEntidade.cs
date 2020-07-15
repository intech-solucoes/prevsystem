using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_PLANOS_VINC")]
	public class PlanoVinculadoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime DT_INSC_PLANO { get; set; }
		public string CD_SIT_PLANO { get; set; }
		public DateTime DT_SITUACAO_ATUAL { get; set; }
		public string CD_MOTIVO_DESLIG { get; set; }
		public DateTime? DT_DESLIG_PLANO { get; set; }
		public string FUNDADOR { get; set; }
		public decimal? PERC_TAXA_MAXIMA { get; set; }
		public string GRUPO { get; set; }
		public DateTime? DT_PRIMEIRA_CONTRIB { get; set; }
		public DateTime? DT_VENC_CARENCIA { get; set; }
		public string CD_SIT_INSCRICAO { get; set; }
		public string TIPO_IRRF { get; set; }
		public int? IDADE_RECEB_BENEF { get; set; }
		public string CD_TIPO_COBRANCA { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public decimal? DIA_VENC { get; set; }
		public string CD_GRUPO { get; set; }
		public decimal? CD_PERFIL_INVEST { get; set; }
		public string NUM_PROTOCOLO { get; set; }
		public string VITALICIO { get; set; }
		public decimal? VL_PERC_VITALICIO { get; set; }
		public string LEI_108 { get; set; }
		public decimal? SALDO_PROJ { get; set; }
		public decimal? PECULIO_INV { get; set; }
		public decimal? PECULIO_MORTE { get; set; }
		public string INTEGRALIZA_SALDO { get; set; }
		public string CK_EXTRATO_CST { get; set; }
		public DateTime? DT_EMISSAO_CERTIFICADO { get; set; }
		public string TIPO_IRRF_CANC { get; set; }
		public string IND_OPTANTE_MAXIMA_BASICA { get; set; }
		public string IND_AFA_JUDICIAL { get; set; }
		[Write(false)] public string DS_PERFIL_INVEST { get; set; }
		[Write(false)] public string CD_CATEGORIA { get; set; }
		[Write(false)] public string DS_CATEGORIA { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
		[Write(false)] public string DS_SIT_PLANO { get; set; }
		[Write(false)] public string COD_CNPB { get; set; }
		[Write(false)] public decimal SalarioContribuicao { get; set; }
		[Write(false)] public decimal PercentualContribuicao { get; set; }
		[Write(false)] public ProcessoBeneficioEntidade ProcessoBeneficio { get; set; }
		[Write(false)] public List<ModalidadeEntidade> Modalidades { get; set; }
		[Write(false)] public decimal UltimoSalario { get; set; }
		[Write(false)] public string CD_EMPRESA { get; set; }
		[Write(false)] public DateTime? DT_INIC_VALIDADE { get; set; }
		[Write(false)] public decimal VL_BENEF_SALDADO_ATUAL { get; set; }
		[Write(false)] public decimal VL_BENEF_SALDADO_INICIAL { get; set; }
		[Write(false)] public string GRUPO_RECADASTRAMENTO { get; set; }
	}
}
