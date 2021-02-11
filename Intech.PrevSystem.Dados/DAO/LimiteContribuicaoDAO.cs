using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class LimiteContribuicaoDAO : BaseDAO<LimiteContribuicaoEntidade>
	{
		public LimiteContribuicaoDAO (IDbTransaction tx = null) : base(tx) { }

	}
}
