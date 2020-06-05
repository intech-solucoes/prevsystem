using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CS_FUNCIONARIO")]
    public class FuncionarioEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public int COD_ENTID { get; set; }
		public string CD_EMPRESA { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string CD_CARGO { get; set; }
		public string CD_FUNCAO { get; set; }
		public string CD_LOTACAO { get; set; }
		public string CD_NIVEL_SALARIAL { get; set; }
		public string CD_MOTIVO_DEMISSAO { get; set; }
		public DateTime? DT_ADMISSAO { get; set; }
		public string CD_SIT_EMPRESA { get; set; }
		public DateTime? DT_SITUACAO_EMPRESA { get; set; }
		public DateTime? DT_DEMISSAO { get; set; }
		public string AUTO_MANTENEDOR { get; set; }
		public string FONE_TRAB { get; set; }
		public string FAX_TRAB { get; set; }
		public string RAMAL_TRAB { get; set; }
		public string AGENDA { get; set; }
		public string CD_LOCALIDADE { get; set; }
		public decimal? CD_OCUPACAO { get; set; }
		public string ORGAO_EXT { get; set; }
		public string SETOR_EXT { get; set; }
		public string CONTATO_EXT { get; set; }
		public string FONE_EXT { get; set; }
		public string RAMAL_EXT { get; set; }
		public string CD_EMP_NEW { get; set; }
		public string NUM_PROTOCOLO { get; set; }
		public DateTime? DT_RECADASTRO { get; set; }
		public string NUM_INSCRICAO_ORIGEM { get; set; }
		public string COD_VINC { get; set; }
		public string COD_CERTA { get; set; }
		public string COD_ORIGEM { get; set; }
		public string COD_PAG { get; set; }
		public decimal? VL_REND_BASE { get; set; }
		public DateTime? DT_INF_PPE { get; set; }
		public int? TEMP_SERV { get; set; }
		public decimal? VL_BASE { get; set; }
		public string CD_SEQ_CPF { get; set; }
		public string NUM_MATRICULA_SIAPE { get; set; }
		public DateTime? DT_APOSENT { get; set; }
		public string CD_APOSENT_SUJ { get; set; }
		public string EMAIL_FUNC { get; set; }
		public string EXTRATO_IMPRESSO { get; set; }
		public DateTime? DT_VINCULO_FUNDACAO { get; set; }
		public string IND_ELEGIBILIDADE { get; set; }
		public DateTime? DT_TERMO { get; set; }
		public string IND_PART_RATIFICADO { get; set; }
		public decimal? PERC_PECULIO { get; set; }
		public string AGENDA2 { get; set; }
		[Write(false)] public string NOME_ENTID { get; set; }
		[Write(false)] public string DS_LOTACAO { get; set; }
		[Write(false)] public string DS_CARGO { get; set; }
		[Write(false)] public string CPF_CGC { get; set; }
		[Write(false)] public string PENSIONISTA { get; set; }
		[Write(false)] public string CD_PLANO { get; set; }
		[Write(false)] public string CD_SIT_PLANO { get; set; }
        
    }
}
