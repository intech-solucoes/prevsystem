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
    public abstract class PrestacaoDAO : BaseDAO<PrestacaoEntidade>
    {
        
		public virtual IEnumerable<PrestacaoEntidade> BuscarPagasPorFundacaoInscricaoPeriodo(string CD_FUNDACAO, string NUM_INSCRICAO, DateTime DT_INCIAL, DateTime DT_FINAL)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES INNER JOIN CE_CONTRATOS ON CE_CONTRATOS.NUM_CONTRATO = CE_PRESTACOES.NUM_CONTRATO AND CE_CONTRATOS.ANO_CONTRATO = CE_PRESTACOES.ANO_CONTRATO WHERE (CE_CONTRATOS.NUM_INSCRICAO = @NUM_INSCRICAO)   AND (CE_PRESTACOES.DT_VENC >= @DT_INCIAL)   AND (CE_PRESTACOES.DT_VENC <= @DT_FINAL)   AND (CE_CONTRATOS.CD_FUNDACAO = @CD_FUNDACAO)   AND (CE_PRESTACOES.DT_PAGTO IS NOT NULL)", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INCIAL, DT_FINAL });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES INNER  JOIN CE_CONTRATOS  ON CE_CONTRATOS.NUM_CONTRATO=CE_PRESTACOES.NUM_CONTRATO AND CE_CONTRATOS.ANO_CONTRATO=CE_PRESTACOES.ANO_CONTRATO WHERE (CE_CONTRATOS.NUM_INSCRICAO=:NUM_INSCRICAO) AND (CE_PRESTACOES.DT_VENC>=:DT_INCIAL) AND (CE_PRESTACOES.DT_VENC<=:DT_FINAL) AND (CE_CONTRATOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CE_PRESTACOES.DT_PAGTO IS  NOT NULL )", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INCIAL, DT_FINAL });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PrestacaoEntidade> BuscarPorFundacaoContrato(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO   AND NUM_CONTRATO = @NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
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
