#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class HistRendasDAO : BaseDAO<HistRendasEntidade>
    {
        
		public virtual HistRendasEntidade BuscarPorFundacaoEmpresaPlanoAnoNumEspecie(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string ANO_PROCESSO, decimal NUM_PROCESSO, string CD_ESPECIE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<HistRendasEntidade>("SELECT *   FROM GB_HIST_RENDAS HR1  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND ANO_PROCESSO = @ANO_PROCESSO    AND NUM_PROCESSO = @NUM_PROCESSO    AND CD_ESPECIE = @CD_ESPECIE    AND DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE)  						  FROM GB_HIST_RENDAS  						    WHERE CD_FUNDACAO = HR1.CD_FUNDACAO  						  	  AND CD_EMPRESA = HR1.CD_EMPRESA  						  	  AND CD_PLANO = HR1.CD_PLANO  						  	  AND ANO_PROCESSO = HR1.ANO_PROCESSO  						  	  AND NUM_PROCESSO = HR1.NUM_PROCESSO  						  	  AND CD_ESPECIE = HR1.CD_ESPECIE)", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO_PROCESSO, NUM_PROCESSO, CD_ESPECIE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<HistRendasEntidade>("SELECT * FROM GB_HIST_RENDAS  HR1  WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND ANO_PROCESSO=:ANO_PROCESSO AND NUM_PROCESSO=:NUM_PROCESSO AND CD_ESPECIE=:CD_ESPECIE AND DT_INIC_VALIDADE=(SELECT MAX(DT_INIC_VALIDADE) FROM GB_HIST_RENDAS WHERE CD_FUNDACAO=HR1.CD_FUNDACAO AND CD_EMPRESA=HR1.CD_EMPRESA AND CD_PLANO=HR1.CD_PLANO AND ANO_PROCESSO=HR1.ANO_PROCESSO AND NUM_PROCESSO=HR1.NUM_PROCESSO AND CD_ESPECIE=HR1.CD_ESPECIE)", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO_PROCESSO, NUM_PROCESSO, CD_ESPECIE });
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
