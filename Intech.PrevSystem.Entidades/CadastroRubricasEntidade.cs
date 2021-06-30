using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CC_CADASTRO_RUBRICAS")]
	public class CadastroRubricasEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string ANO_COMPETENCIA { get; set; }
		public string MES_COMPETENCIA { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_RUBRICA { get; set; }
		public decimal? VALOR_RUBRICA { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		[Write(false)] public string COD_IND_CONC { get; set; }
		[Write(false)] public string DS_RUBRICA { get; set; }
		[Write(false)] public decimal VariacaoAcumuladaIndice { get; set; }
		[Write(false)] public decimal ValorIndiceMes { get; set; }
		[Write(false)] public decimal ValorCorrigido { get; set; }
	}
}