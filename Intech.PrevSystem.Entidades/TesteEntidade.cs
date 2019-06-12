using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TBG_TESTE")]
    public class TesteEntidade
    {
		[Write(false)] public string DES_TESTE { get; set; }
        
    }
}
