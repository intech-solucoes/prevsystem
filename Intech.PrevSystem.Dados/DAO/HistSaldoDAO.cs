using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class HistSaldoDAO : BaseDAO<HistSaldoEntidade>
	{
		public virtual List<HistSaldoEntidade> BuscarPorFundacaoEmpresaPlanoEspecieNumAnoProcesso(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_ESPECIE, decimal NUM_PROCESSO, string ANO_PROCESSO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<HistSaldoEntidade>("SELECT *  FROM GB_HIST_SALDO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND CD_ESPECIE = @CD_ESPECIE    AND NUM_PROCESSO = @NUM_PROCESSO    AND ANO_PROCESSO = @ANO_PROCESSO  ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_ESPECIE, NUM_PROCESSO, ANO_PROCESSO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<HistSaldoEntidade>("SELECT * FROM GB_HIST_SALDO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND CD_ESPECIE=:CD_ESPECIE AND NUM_PROCESSO=:NUM_PROCESSO AND ANO_PROCESSO=:ANO_PROCESSO ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_ESPECIE, NUM_PROCESSO, ANO_PROCESSO }).ToList();
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
