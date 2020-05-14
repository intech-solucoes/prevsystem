using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PlanosContratoDAO : BaseDAO<PlanosContratoEntidade>
	{
		public virtual List<PlanosContratoEntidade> BuscarPorFundacaoAnoNumContrato(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanosContratoEntidade>("SELECT *  FROM CE_PLANOS_CONTRATO   WHERE CD_FUNDACAO = @CD_FUNDACAO     AND ANO_CONTRATO = @ANO_CONTRATO      AND NUM_CONTRATO = @NUM_CONTRATO  ORDER BY DATA_INSCRICAO DESC", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanosContratoEntidade>("SELECT * FROM CE_PLANOS_CONTRATO WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO ORDER BY DATA_INSCRICAO DESC", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }).ToList();
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
