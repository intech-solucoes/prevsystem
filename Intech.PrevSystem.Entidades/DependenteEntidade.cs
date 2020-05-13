using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_DEPENDENTE")]
	public class DependenteEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal NUM_SEQ_DEP { get; set; }
		public string NOME_DEP { get; set; }
		public string CD_GRAU_PARENTESCO { get; set; }
		public string SEXO_DEP { get; set; }
		public DateTime DT_NASC_DEP { get; set; }
		public string ABATIMENTO_IRRF { get; set; }
		public DateTime DT_VALIDADE_DEP { get; set; }
		public string CD_MOT_PERDA_VALIDADE { get; set; }
		public DateTime DT_INCLUSAO_DEP { get; set; }
		public string PLANO_ASSISTENCIAL { get; set; }
		public string PLANO_PREVIDENCIAL { get; set; }
		public DateTime? DT_INIC_IRRF { get; set; }
		public DateTime? DT_TERM_IRRF { get; set; }
		public string PECULIO { get; set; }
		public decimal? PERC_PECULIO { get; set; }
		public string NUM_PROTOCOLO { get; set; }
		public DateTime? DT_INC_MOV { get; set; }
		public DateTime? DT_EXC_MOV { get; set; }
		public string CD_SIT_PLANO_MOV { get; set; }
		public string POLIT_EXP { get; set; }
		public string CPF { get; set; }
		public string IDENTIDADE { get; set; }
		public string ORGAO_EXP { get; set; }
		public DateTime? DT_EXPEDICAO { get; set; }
		public decimal? CD_OCUPACAO { get; set; }
		public string BENEF_IND { get; set; }
		public string CD_PLANO { get; set; }
		public string UF_IDENT_DEP { get; set; }
		public string CD_NACIONALIDADE { get; set; }
		public string CD_ESTADO_CIVIL { get; set; }
		public string NATURALIDADE { get; set; }
		public string UF_NATURALIDADE { get; set; }
		public string EMAIL_DEP { get; set; }
		public string FONE_CELULAR { get; set; }
		public string NOME_PAI { get; set; }
		public string NOME_MAE { get; set; }
		public string ISS { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public string END_DEP { get; set; }
		public string NR_END_DEP { get; set; }
		public string COMP_END_DEP { get; set; }
		public string BAIRRO_DEP { get; set; }
		public string CID_DEP { get; set; }
		public string UF_DEP { get; set; }
		public string CD_PAIS { get; set; }
		public string FONE_DEP { get; set; }
		public string FONE_COM_DEP { get; set; }
		public string CEP_DEP { get; set; }
		public string PLANO_SAUDE { get; set; }
		public DateTime? DT_RECONHECIMENTO { get; set; }
		public string CD_TIPO_CORRESP { get; set; }
		public string CX_POSTAL { get; set; }
		[Write(false)] public string DS_GRAU_PARENTESCO { get; set; }
	}
}
