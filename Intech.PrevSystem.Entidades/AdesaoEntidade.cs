using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_ADESAO")]
	public class AdesaoEntidade
	{
		[Write(false)] public List<AdesaoDependenteEntidade> Dependentes { get; set; }
		[Write(false)] public AdesaoContribEntidade Contrib { get; set; }
		[Write(false)] public AdesaoPlanoEntidade Plano { get; set; }
		[Write(false)] public List<AdesaoDocumentoEntidade> Documentos { get; set; }
		[Write(false)] public string IPV4 { get; set; }
		[Write(false)] public string IPV6 { get; set; }
	}
}
