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
    public abstract class SalarioBaseDAO : BaseDAO<SalarioBaseEntidade>
    {
        
		public virtual SalarioBaseEntidade BuscarUltimoPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SalarioBaseEntidade>("SELECT TOP 1 *  FROM CS_SALARIO_BASE WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND NUM_MATRICULA = @NUM_MATRICULA ORDER BY DT_BASE DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SalarioBaseEntidade>("SELECT * FROM CS_SALARIO_BASE WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND NUM_MATRICULA=:NUM_MATRICULA AND ROWNUM <= 1  ORDER BY DT_BASE DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
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
