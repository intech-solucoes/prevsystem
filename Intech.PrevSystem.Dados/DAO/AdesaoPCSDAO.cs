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
	public abstract class AdesaoPCSDAO : BaseDAO<AdesaoPCSEntidade>
	{
		public AdesaoPCSDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<AdesaoPCSEntidade> BuscarPorInscricao(string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<AdesaoPCSEntidade>("SELECT *  FROM CS_ADESAO_PCS  WHERE NUM_INSCRICAO = @NUM_INSCRICAO ORDER BY DT_INICIO DESC", new { NUM_INSCRICAO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<AdesaoPCSEntidade>("SELECT * FROM CS_ADESAO_PCS WHERE NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY DT_INICIO DESC", new { NUM_INSCRICAO }, Transaction).ToList();
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