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
    public abstract class DadosPessoaisDAO : BaseDAO<DadosPessoaisEntidade>
    {
        
		public virtual DadosPessoaisEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT     CS_DADOS_PESSOAIS.*,     EE_ENTIDADE.CPF_CGC FROM CS_DADOS_PESSOAIS INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_DADOS_PESSOAIS.COD_ENTID WHERE CS_DADOS_PESSOAIS.COD_ENTID = @COD_ENTID", new { COD_ENTID });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT CS_DADOS_PESSOAIS.*, EE_ENTIDADE.CPF_CGC FROM CS_DADOS_PESSOAIS INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_DADOS_PESSOAIS.COD_ENTID WHERE CS_DADOS_PESSOAIS.COD_ENTID=:COD_ENTID", new { COD_ENTID });
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
