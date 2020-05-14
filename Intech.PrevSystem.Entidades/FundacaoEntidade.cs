using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_FUNDACAO")]
	public class FundacaoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public int COD_ENTID { get; set; }
		public string AVAL_ATUARIAL { get; set; }
		public string OPERADORA { get; set; }
		public int? SEQ_EVENTO_EFINANC { get; set; }
		public string CD_MUNICIPIO_EFINANC { get; set; }
		[Write(false)] public string NOME_ENTID { get; set; }
		[Write(false)] public string END_ENTID { get; set; }
		[Write(false)] public string BAIRRO_ENTID { get; set; }
		[Write(false)] public string CEP_ENTID { get; set; }
		[Write(false)] public string UF_ENTID { get; set; }
		[Write(false)] public string FONE_ENTID { get; set; }
		[Write(false)] public string FAX_ENTID { get; set; }
		[Write(false)] public string CPF_CGC { get; set; }
		[Write(false)] public List<EmpresaEntidade> Empresas { get; set; }
	}
}
