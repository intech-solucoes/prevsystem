﻿using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("SEG_USUARIO")]
	public class SegUsuarioEntidade
	{
		[Key]
		public decimal OID_USUARIO { get; set; }
		public string NOM_LOGIN { get; set; }
		public string NOM_USUARIO { get; set; }
		public string NOM_EMAIL { get; set; }
		public string PWD_USUARIO { get; set; }
		public string IND_BLOQUEADO { get; set; }
		public DateTime? DTA_EXPIRACAO { get; set; }
		public decimal NUM_TENTATIVA { get; set; }
		public string DES_LOTACAO { get; set; }
		public string IND_ADMINISTRADOR { get; set; }
		public string IND_ATIVO { get; set; }
		public string NOM_USUARIO_CRIACAO { get; set; }
		public DateTime? DTA_CRIACAO { get; set; }
		public string NOM_USUARIO_ATUALIZACAO { get; set; }
		public DateTime? DTA_ATUALIZACAO { get; set; }
	}
}
