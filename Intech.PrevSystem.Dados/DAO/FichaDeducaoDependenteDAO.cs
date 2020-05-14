using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FichaDeducaoDependenteDAO : BaseDAO<FichaDeducaoDependenteEntidade>
	{
		public virtual FichaDeducaoDependenteEntidade BuscarPorFundacaoRecebedorReferencia(string CD_FUNDACAO, decimal SEQ_RECEBEDOR, DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaDeducaoDependenteEntidade>("SELECT *   FROM GB_FICHA_DEDUCAO_DEPENDENTE  WHERE CD_FUNDACAO = @CD_FUNDACAO      AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR    AND DT_REFERENCIA = @DT_REFERENCIA", new { CD_FUNDACAO, SEQ_RECEBEDOR, DT_REFERENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaDeducaoDependenteEntidade>("SELECT * FROM GB_FICHA_DEDUCAO_DEPENDENTE WHERE CD_FUNDACAO=:CD_FUNDACAO AND SEQ_RECEBEDOR=:SEQ_RECEBEDOR AND DT_REFERENCIA=:DT_REFERENCIA", new { CD_FUNDACAO, SEQ_RECEBEDOR, DT_REFERENCIA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

	}
}
