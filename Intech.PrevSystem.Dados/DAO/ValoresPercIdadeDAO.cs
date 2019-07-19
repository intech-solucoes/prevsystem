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
    public abstract class ValoresPercIdadeDAO : BaseDAO<ValoresPercIdadeEntidade>
    {
        
		public virtual decimal BuscarPercentual(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<decimal>("SELECT VI.PERCENTUAL     FROM DR_VALORES_PERC_IDADE VI,          DR_PERC_IDADE PI    WHERE VI.CD_FUNDACAO       = PI.CD_FUNDACAO      AND VI.CD_TIPO_RESGATE   = PI.CD_TIPO_RESGATE      AND VI.CD_PLANO          = PI.CD_PLANO      AND VI.CD_MANTENEDORA    = PI.CD_MANTENEDORA      AND VI.CD_FUNDACAO       = @CD_FUNDACAO     AND VI.CD_TIPO_RESGATE   = '01'     AND VI.CD_PLANO          = '0001'     AND VI.CD_MANTENEDORA    = '2'     AND VI.QTD_CONTRIB      >= (SELECT COUNT(DISTINCT CF.ANO_REF + CF.MES_REF)                                   FROM CC_FICHA_FINANCEIRA CF                                                                WHERE CF.CD_FUNDACAO   = @CD_FUNDACAO                                     AND CF.CD_PLANO      = @CD_PLANO                                       AND CF.NUM_INSCRICAO = @NUM_INSCRICAO                                    AND (CF.CONTRIB_PARTICIPANTE <> 0 OR CF.CONTRIB_EMPRESA <> 0) )                                    ORDER BY VI.CD_FUNDACAO, VI.CD_TIPO_RESGATE,  VI.CD_PLANO,  VI.CD_MANTENEDORA,            VI.ANOS_IDADE, VI.ANOS_CONTRIBUICAO, VI.ANOS_PATROC, VI.QTD_CONTRIB", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<decimal>("", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
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
