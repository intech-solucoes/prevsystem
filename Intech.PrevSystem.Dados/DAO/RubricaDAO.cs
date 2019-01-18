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
    public abstract class RubricaDAO : BaseDAO<RubricaEntidade>
    {
        
		public virtual IEnumerable<RubricaEntidade> BuscarPorFundacaoEmpresaMargemConsig(string CD_FUNDACAO, string CD_EMPRESA, string MARGEM_CONSIG)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricaEntidade>("SELECT * FROM TB_RUBRICA WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND MARGEM_CONSIG = @MARGEM_CONSIG", new { CD_FUNDACAO, CD_EMPRESA, MARGEM_CONSIG });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricaEntidade>("SELECT * FROM TB_RUBRICA WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND MARGEM_CONSIG=:MARGEM_CONSIG", new { CD_FUNDACAO, CD_EMPRESA, MARGEM_CONSIG });
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
