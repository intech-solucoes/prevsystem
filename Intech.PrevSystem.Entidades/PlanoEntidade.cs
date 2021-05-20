using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TB_PLANOS")]
	public class PlanoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string DS_PLANO { get; set; }
		public string TP_PLANO { get; set; }
		public string TP_CARENCIA { get; set; }
		public decimal? PRAZO_CARENCIA { get; set; }
		public decimal? CATEG_PLANO { get; set; }
		public string CD_TIPO_RESGATE { get; set; }
		public string COD_CNPB { get; set; }
		public string COD_CONVENIO { get; set; }
		public string NOME_ORIGEM { get; set; }
		public string UTILIZA_PERFIL { get; set; }
		public string CK_UTILIZA_CUSTODIANTE { get; set; }
		public int? NU_SEQ_CUSTODIANTE { get; set; }
		public string MES_REF_AUT { get; set; }
		public string CK_INSTITUIDO { get; set; }
		public string PL_CONTRIB_INDIV_OBR { get; set; }
		public string EFINANC_PP_TPPRODUTO { get; set; }
		public string COD_CARTEIRA { get; set; }
		[Write(false)] public string DS_ESPECIE { get; set; }
		[Write(false)] public string CD_ESPECIE { get; set; }
	}
}