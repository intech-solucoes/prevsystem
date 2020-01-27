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
    public abstract class CronogProcDAO : BaseDAO<CronogProcEntidade>
    {
        
		public virtual CronogProcEntidade BuscarPorFundacaoTipoFolhaReferencia(string CD_FUNDACAO, string CD_TIPO_FOLHA, DateTime DT_REFERENCIA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<CronogProcEntidade>("SELECT *  FROM GB_CRONOG_PROC  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA    AND DT_REFERENCIA = @DT_REFERENCIA", new { CD_FUNDACAO, CD_TIPO_FOLHA, DT_REFERENCIA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<CronogProcEntidade>("SELECT * FROM GB_CRONOG_PROC WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_TIPO_FOLHA=:CD_TIPO_FOLHA AND DT_REFERENCIA=:DT_REFERENCIA", new { CD_FUNDACAO, CD_TIPO_FOLHA, DT_REFERENCIA });
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
