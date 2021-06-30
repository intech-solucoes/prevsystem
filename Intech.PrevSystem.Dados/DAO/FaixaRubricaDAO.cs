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
	public abstract class FaixaRubricaDAO : BaseDAO<FaixaRubricaEntidade>
	{
		public FaixaRubricaDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FaixaRubricaEntidade> BuscarPorCdCalculoDtVigencia(decimal CD_CALCULO, DateTime DT_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixaRubricaEntidade>("SELECT *   FROM GB_FAIXA_RUBRICA  WHERE ( CD_CALCULO = @CD_CALCULO )    AND ( DT_VIGENCIA <= @DT_VIGENCIA )", new { CD_CALCULO, DT_VIGENCIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixaRubricaEntidade>("SELECT * FROM GB_FAIXA_RUBRICA WHERE (CD_CALCULO=:CD_CALCULO) AND (DT_VIGENCIA<=:DT_VIGENCIA)", new { CD_CALCULO, DT_VIGENCIA }, Transaction).ToList();
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