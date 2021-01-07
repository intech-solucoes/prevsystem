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
	public abstract class CronogProcDAO : BaseDAO<CronogProcEntidade>
	{
		public CronogProcDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual CronogProcEntidade BuscarPorFundacaoTipoFolhaReferencia(string CD_FUNDACAO, string CD_TIPO_FOLHA, DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<CronogProcEntidade>("SELECT *  FROM GB_CRONOG_PROC  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA    AND DT_REFERENCIA = @DT_REFERENCIA", new { CD_FUNDACAO, CD_TIPO_FOLHA, DT_REFERENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<CronogProcEntidade>("SELECT * FROM GB_CRONOG_PROC WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_TIPO_FOLHA=:CD_TIPO_FOLHA AND DT_REFERENCIA=:DT_REFERENCIA", new { CD_FUNDACAO, CD_TIPO_FOLHA, DT_REFERENCIA });
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
