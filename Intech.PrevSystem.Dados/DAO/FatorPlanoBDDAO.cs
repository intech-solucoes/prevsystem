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
	public abstract class FatorPlanoBDDAO : BaseDAO<FatorPlanoBDEntidade>
	{
		public FatorPlanoBDDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FatorPlanoBDEntidade> BuscarPorDtValidadeIdadeEntradaIdadeSaida(DateTime DT_VALIDADE, int IDADE_ENTRADA, int IDADE_SAIDA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FatorPlanoBDEntidade>("SELECT * FROM   GB_FATOR_PLANO_BD WHERE  ( DT_VALIDADE <= @DT_VALIDADE )        AND ( IDADE_ENTRADA = @IDADE_ENTRADA )        AND ( IDADE_SAIDA = @IDADE_SAIDA )        AND ( DT_VALIDADE = (SELECT MAX(DT_VALIDADE) AS DT_VALIDADE                             FROM   GB_FATOR_PLANO_BD                             WHERE  IDADE_ENTRADA = @IDADE_ENTRADA                                    AND IDADE_SAIDA = @IDADE_SAIDA) )", new { DT_VALIDADE, IDADE_ENTRADA, IDADE_SAIDA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FatorPlanoBDEntidade>("SELECT * FROM GB_FATOR_PLANO_BD WHERE (DT_VALIDADE<=:DT_VALIDADE) AND (IDADE_ENTRADA=:IDADE_ENTRADA) AND (IDADE_SAIDA=:IDADE_SAIDA) AND (DT_VALIDADE=(SELECT MAX(DT_VALIDADE) AS DT_VALIDADE FROM GB_FATOR_PLANO_BD WHERE IDADE_ENTRADA=:IDADE_ENTRADA AND IDADE_SAIDA=:IDADE_SAIDA))", new { DT_VALIDADE, IDADE_ENTRADA, IDADE_SAIDA }, Transaction).ToList();
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