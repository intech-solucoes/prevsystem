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
	public abstract class WebDocExigidoDAO : BaseDAO<WebDocExigidoEntidade>
	{
		public WebDocExigidoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<WebDocExigidoEntidade> BuscarPorFuncionalidadePlanoIndAtivo(int NUM_FUNCIONALIDADE, string CD_PLANO, string IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebDocExigidoEntidade>("SELECT DE.*   FROM WEB_DOC_EXIGIDO DE      INNER JOIN WEB_FUNCIONALIDADE FU ON FU.OID_FUNCIONALIDADE = DE.OID_FUNCIONALIDADE  WHERE FU.NUM_FUNCIONALIDADE = @NUM_FUNCIONALIDADE    AND (DE.CD_PLANO IS NULL OR DE.CD_PLANO = @CD_PLANO)    AND DE.IND_ATIVO = @IND_ATIVO", new { NUM_FUNCIONALIDADE, CD_PLANO, IND_ATIVO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebDocExigidoEntidade>("SELECT DE.* FROM WEB_DOC_EXIGIDO  DE  INNER  JOIN WEB_FUNCIONALIDADE   FU  ON FU.OID_FUNCIONALIDADE=DE.OID_FUNCIONALIDADE WHERE FU.NUM_FUNCIONALIDADE=:NUM_FUNCIONALIDADE AND (DE.CD_PLANO IS NULL  OR DE.CD_PLANO=:CD_PLANO) AND DE.IND_ATIVO=:IND_ATIVO", new { NUM_FUNCIONALIDADE, CD_PLANO, IND_ATIVO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}
