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
	public abstract class RegraCalcFundacaoDAO : BaseDAO<RegraCalcFundacaoEntidade>
	{
		public RegraCalcFundacaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<RegraCalcFundacaoEntidade> BuscarPorPlanoEspecie(string CD_PLANO, string CD_ESPECIE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RegraCalcFundacaoEntidade>("SELECT *  FROM GB_REGRA_CALC_FUNDACAO  WHERE (CD_PLANO = @CD_PLANO)    AND (CD_ESPECIE = @CD_ESPECIE)", new { CD_PLANO, CD_ESPECIE }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RegraCalcFundacaoEntidade>("SELECT * FROM GB_REGRA_CALC_FUNDACAO WHERE (CD_PLANO=:CD_PLANO) AND (CD_ESPECIE=:CD_ESPECIE)", new { CD_PLANO, CD_ESPECIE }, Transaction).ToList();
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