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
    public abstract class MargensDAO : BaseDAO<MargensEntidade>
    {
        
		public virtual MargensEntidade BuscarPorFundacaoEmpresaModalidadeNaturezaEmVigencia(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR, DateTime DT_VIGENCIA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT TOP 1 * FROM CE_MARGENS WHERE (CD_FUNDACAO = @CD_FUNDACAO)   AND (CD_MODAL = @CD_MODAL)   AND (CD_NATUR = @CD_NATUR)   AND (CD_EMPRESA = @CD_EMPRESA)   AND (DT_VIGENCIA <= @DT_VIGENCIA) ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, DT_VIGENCIA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT * FROM CE_MARGENS WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_MODAL=:CD_MODAL) AND (CD_NATUR=:CD_NATUR) AND (CD_EMPRESA=:CD_EMPRESA) AND (DT_VIGENCIA<=:DT_VIGENCIA) AND ROWNUM <= 1  ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, DT_VIGENCIA });
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
