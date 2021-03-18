using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PrestacaoDAO : BaseDAO<PrestacaoEntidade>
	{
		public PrestacaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual void AtualizarPrestacoesAVencerParaNaoCobrar(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO, DateTime DT_VENC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE CE_PRESTACOES SET    CD_ORIGEM_REC = 51,        ORIGEM_LANC = 'REC. REFORMA' WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( ANO_CONTRATO = @ANO_CONTRATO )        AND ( NUM_CONTRATO = @NUM_CONTRATO )        AND ( DT_VENC > @DT_VENC )        AND ( DT_PAGTO IS NULL )        AND ( CD_ORIGEM_REC IS NULL               OR CD_ORIGEM_REC = 0               OR CD_ORIGEM_REC = 50               OR CD_ORIGEM_REC = 5 )        AND ( TIPO IN ( 'P', 'I' ) )", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, DT_VENC }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE CE_PRESTACOES SET CD_ORIGEM_REC=51, ORIGEM_LANC='REC. REFORMA' WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (ANO_CONTRATO=:ANO_CONTRATO) AND (NUM_CONTRATO=:NUM_CONTRATO) AND (DT_VENC>:DT_VENC) AND (DT_PAGTO IS NULL ) AND (CD_ORIGEM_REC IS NULL  OR CD_ORIGEM_REC=0 OR CD_ORIGEM_REC=50 OR CD_ORIGEM_REC=5) AND (TIPO IN ('P', 'I'))", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, DT_VENC }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void AtualizarPrestacoesInadimplentesParaRecebidas(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO, DateTime DT_VENC, DateTime DT_PAGTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE CE_PRESTACOES SET    CD_ORIGEM_REC = 6,        DT_PAGTO = @DT_PAGTO,        ORIGEM_LANC = 'REC. REFORMA' WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( ANO_CONTRATO = @ANO_CONTRATO )        AND ( NUM_CONTRATO = @NUM_CONTRATO )        AND ( DT_VENC <= @DT_VENC )        AND ( DT_PAGTO IS NULL )        AND ( CD_ORIGEM_REC IS NULL               OR CD_ORIGEM_REC = 50               OR CD_ORIGEM_REC = 0               OR CD_ORIGEM_REC = 5 )        AND ( TIPO IN ( 'P', 'I' ) )", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, DT_VENC, DT_PAGTO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE CE_PRESTACOES SET CD_ORIGEM_REC=6, DT_PAGTO=:DT_PAGTO, ORIGEM_LANC='REC. REFORMA' WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (ANO_CONTRATO=:ANO_CONTRATO) AND (NUM_CONTRATO=:NUM_CONTRATO) AND (DT_VENC<=:DT_VENC) AND (DT_PAGTO IS NULL ) AND (CD_ORIGEM_REC IS NULL  OR CD_ORIGEM_REC=50 OR CD_ORIGEM_REC=0 OR CD_ORIGEM_REC=5) AND (TIPO IN ('P', 'I'))", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, DT_VENC, DT_PAGTO }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PrestacaoEntidade> BuscarPagasPorFundacaoInscricaoPeriodo(string CD_FUNDACAO, string NUM_INSCRICAO, DateTime DT_INCIAL, DateTime DT_FINAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT CE_PRESTACOES.* FROM CE_PRESTACOES INNER JOIN CE_CONTRATOS ON CE_CONTRATOS.NUM_CONTRATO = CE_PRESTACOES.NUM_CONTRATO AND CE_CONTRATOS.ANO_CONTRATO = CE_PRESTACOES.ANO_CONTRATO WHERE (CE_CONTRATOS.NUM_INSCRICAO = @NUM_INSCRICAO)   AND (CE_PRESTACOES.DT_VENC >= @DT_INCIAL)   AND (CE_PRESTACOES.DT_VENC <= @DT_FINAL)   AND (CE_CONTRATOS.CD_FUNDACAO = @CD_FUNDACAO)   AND (CE_PRESTACOES.DT_PAGTO IS NOT NULL)", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INCIAL, DT_FINAL }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT CE_PRESTACOES.* FROM CE_PRESTACOES INNER  JOIN CE_CONTRATOS  ON CE_CONTRATOS.NUM_CONTRATO=CE_PRESTACOES.NUM_CONTRATO AND CE_CONTRATOS.ANO_CONTRATO=CE_PRESTACOES.ANO_CONTRATO WHERE (CE_CONTRATOS.NUM_INSCRICAO=:NUM_INSCRICAO) AND (CE_PRESTACOES.DT_VENC>=:DT_INCIAL) AND (CE_PRESTACOES.DT_VENC<=:DT_FINAL) AND (CE_CONTRATOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CE_PRESTACOES.DT_PAGTO IS  NOT NULL )", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INCIAL, DT_FINAL }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PrestacaoEntidade> BuscarPorFundacaoAnoNumero(string CD_FUNDACAO, string ANO_CONTRATO, string NUM_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT *  FROM CE_PRESTACOES PR WHERE PR.CD_FUNDACAO = @CD_FUNDACAO   AND PR.ANO_CONTRATO = @ANO_CONTRATO   AND PR.NUM_CONTRATO = @NUM_CONTRATO ORDER BY PR.SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES  PR  WHERE PR.CD_FUNDACAO=:CD_FUNDACAO AND PR.ANO_CONTRATO=:ANO_CONTRATO AND PR.NUM_CONTRATO=:NUM_CONTRATO ORDER BY PR.SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PrestacaoEntidade> BuscarPorFundacaoContrato(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO   AND NUM_CONTRATO = @NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}