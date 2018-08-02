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
    public abstract class RecadastramentoSolicitacaoValorDAO : BaseDAO<RecadastramentoSolicitacaoValorEntidade>
    {
        
		public virtual RecadastramentoSolicitacaoValorEntidade DeletePorOidSolicitacao(decimal OID_SOLICITACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoValorEntidade>("DELETE FROM REC_SOLICITACAO_VALOR WHERE OID_SOLICITACAO = @OID_SOLICITACAO", new { OID_SOLICITACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoValorEntidade>("DELETE FROM REC_SOLICITACAO_VALOR WHERE OID_SOLICITACAO=:OID_SOLICITACAO", new { OID_SOLICITACAO });
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
