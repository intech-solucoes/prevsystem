using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_USUARIO_GRUPO")]
    public class UsuarioGrupoEntidade
    {
		[Key]
		public decimal OID_USUARIO_GRUPO { get; set; }
		public decimal OID_GRUPO_USUARIO { get; set; }
		public decimal OID_USUARIO { get; set; }
		[Write(false)] public string CPF_CGC { get; set; }
		[Write(false)] public string NOME_ENTID { get; set; }
        
    }
}
