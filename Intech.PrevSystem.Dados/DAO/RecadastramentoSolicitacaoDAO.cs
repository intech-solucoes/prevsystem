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
    public abstract class RecadastramentoSolicitacaoDAO : BaseDAO<RecadastramentoSolicitacaoEntidade>
    {
        
		public virtual RecadastramentoSolicitacaoEntidade BuscarFechada(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_MATRICULA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoEntidade>("SELECT TOP 1 * FROM  REC_SOLICITACAO WHERE NUM_MATRICULA = @NUM_MATRICULA   AND CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_PLANO = @CD_PLANO   AND IND_FECHADA = 'SIM' ORDER BY DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoEntidade>("SELECT * FROM REC_SOLICITACAO WHERE NUM_MATRICULA=:NUM_MATRICULA AND CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND IND_FECHADA='SIM' AND ROWNUM <= 1  ORDER BY DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual RecadastramentoSolicitacaoEntidade BuscarPorCodIdentificador(string COD_IDENTIFICADOR)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoEntidade>("SELECT * FROM  REC_SOLICITACAO WHERE COD_IDENTIFICADOR = @COD_IDENTIFICADOR", new { COD_IDENTIFICADOR });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoEntidade>("SELECT * FROM REC_SOLICITACAO WHERE COD_IDENTIFICADOR=:COD_IDENTIFICADOR", new { COD_IDENTIFICADOR });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual RecadastramentoSolicitacaoValorEntidade DeletePorOidSolicitacao(decimal OID_SOLICITACAO)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoValorEntidade>("DELETE FROM REC_SOLICITACAO WHERE OID_SOLICITACAO = @OID_SOLICITACAO", new { OID_SOLICITACAO });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<RecadastramentoSolicitacaoValorEntidade>("DELETE FROM REC_SOLICITACAO WHERE OID_SOLICITACAO=:OID_SOLICITACAO", new { OID_SOLICITACAO });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
