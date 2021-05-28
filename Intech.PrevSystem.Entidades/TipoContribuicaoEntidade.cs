using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TB_TIPO_CONTRIBUICAO")]
	public class TipoContribuicaoEntidade
	{
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string DS_TIPO_CONTRIBUICAO { get; set; }
		public string CALC_CONTRIB_EMPRESA { get; set; }
		public string CALC_CONTRIB_PARTICIPANTE { get; set; }
		public string CALC_MARGEM_CONSIG { get; set; }
		public string COMPOE_SALDO_BENEFICIO { get; set; }
		public string PERCENTUAL_FATOR { get; set; }
		public string CD_OPERACAO { get; set; }
		public string INCIDE_TMP_CTR_EM { get; set; }
		public string RECURSO_PORTADO { get; set; }
		public string CONTRIB_FUNDO { get; set; }
		public string CONTRIB_FUNDO_FICHA { get; set; }
		public decimal? CD_PERFIL_INVEST { get; set; }
		public string CK_COMPOE_IR_AM { get; set; }
		public decimal? NU_CONTA { get; set; }
		public string CK_SEM_ENCARGO_AM { get; set; }
		public string CD_GRUPO_CONTRIBUICAO { get; set; }
		public string CK_COMPOE_ARQUIVO { get; set; }
		public string MUDA_PERFIL_MOV_FINANC { get; set; }
		public string IND_PORTABILIDADE { get; set; }
		public string VALOR_FIXO { get; set; }
		public string IND_PORTAB_IRRF { get; set; }
		public string IND_CALC_ELEGE_EMP { get; set; }
		public string IND_CALCULO_IN1343 { get; set; }
		public string CONTRIB_DECIMO_TERCEIRO { get; set; }
		public string FUNDO_PATRONAL { get; set; }
		public string IND_TIPO { get; set; }
		public string CK_CONTABILIZA { get; set; }
		public string CD_GRUPO_CONTABIL { get; set; }
		public string CONTRIB_PART_PATROC { get; set; }
		public string CONTRIB_INDV_OBR { get; set; }
		public string COD_AGRUPADOR_WEB { get; set; }
	}
}