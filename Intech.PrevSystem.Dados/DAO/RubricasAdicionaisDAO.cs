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
    public abstract class RubricasAdicionaisDAO : BaseDAO<RubricasAdicionaisEntidade>
    {
        
		public virtual IEnumerable<RubricasAdicionaisEntidade> BuscarPorFundacaoEmpresaMatriculaOrigemReferencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, decimal CD_ORIGEM, DateTime DATA_REF_ATUAL, DateTime DATA_REF_ANTERIOR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricasAdicionaisEntidade>("SELECT * FROM CE_RUBRICAS_ADCIONAIS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND NUM_MATRICULA = @NUM_MATRICULA   AND CD_ORIGEM = @CD_ORIGEM    AND DATA_REF = (SELECT MAX(DATA_REF) AS DATA_REF                     FROM CE_RUBRICAS_ADCIONAIS                     WHERE DATA_REF <= @DATA_REF_ATUAL                         AND DATA_REF >= @DATA_REF_ANTERIOR)", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_ORIGEM, DATA_REF_ATUAL, DATA_REF_ANTERIOR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricasAdicionaisEntidade>("SELECT * FROM CE_RUBRICAS_ADCIONAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND NUM_MATRICULA=:NUM_MATRICULA AND CD_ORIGEM=:CD_ORIGEM AND DATA_REF=(SELECT MAX(DATA_REF) AS DATA_REF FROM CE_RUBRICAS_ADCIONAIS WHERE DATA_REF<=:DATA_REF_ATUAL AND DATA_REF>=:DATA_REF_ANTERIOR)", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_ORIGEM, DATA_REF_ATUAL, DATA_REF_ANTERIOR });
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
