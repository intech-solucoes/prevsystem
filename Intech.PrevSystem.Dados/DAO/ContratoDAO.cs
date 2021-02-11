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
	public abstract class ContratoDAO : BaseDAO<ContratoEntidade>
	{
		public ContratoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual ContratoEntidade BuscarDetalhePorFundacaoInscricaoAnoNumeroSeqFamilia(string CD_FUNDACAO, string NUM_INSCRICAO, string ANO_CONTRATO, string NUM_CONTRATO, string NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT EE.NOME_ENTID AS NOME_PARTICIPANTE,        EE.CPF_CGC AS CPF_PARTICIPANTE,        EE2.NOME_ENTID AS NOME_PENSIONISTA,        EE2.CPF_CGC AS CPF_PENSIONISTA,        ST.DS_SITUACAO,        PL.DS_PLANO,        NA.DS_NATUR,        MO.DS_MODAL,        CE.* FROM CE_CONTRATOS CE     INNER JOIN CE_MODALIDADE MO ON MO.CD_MODAL = CE.CD_MODAL     INNER JOIN CE_NATUREZA NA ON NA.CD_NATUR = CE.CD_NATUR     INNER JOIN CE_SITUACAO_CONTRATO ST ON ST.CD_SITUACAO = CE.CD_SITUACAO     INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = CE.CD_FUNDACAO         AND FN.NUM_INSCRICAO = CE.NUM_INSCRICAO     INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID     INNER JOIN TB_PLANOS PL ON PL.CD_FUNDACAO = CE.CD_FUNDACAO         AND PL.CD_PLANO = CE.CD_PLANO     LEFT OUTER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = CE.CD_FUNDACAO          AND RB.NUM_INSCRICAO = CE.NUM_INSCRICAO         AND RB.NUM_SEQ_GR_FAMIL = CE.NUM_SEQ_GR_FAMIL     LEFT OUTER JOIN EE_ENTIDADE EE2 ON EE2.COD_ENTID = RB.COD_ENTID WHERE CE.CD_FUNDACAO = @CD_FUNDACAO   AND CE.NUM_INSCRICAO = @NUM_INSCRICAO   AND CE.ANO_CONTRATO = @ANO_CONTRATO   AND CE.NUM_CONTRATO = @NUM_CONTRATO   AND CE.NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL", new { CD_FUNDACAO, NUM_INSCRICAO, ANO_CONTRATO, NUM_CONTRATO, NUM_SEQ_GR_FAMIL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT EE.NOME_ENTID AS NOME_PARTICIPANTE, EE.CPF_CGC AS CPF_PARTICIPANTE, EE2.NOME_ENTID AS NOME_PENSIONISTA, EE2.CPF_CGC AS CPF_PENSIONISTA, ST.DS_SITUACAO, PL.DS_PLANO, NA.DS_NATUR, MO.DS_MODAL, CE.* FROM CE_CONTRATOS  CE  INNER  JOIN CE_MODALIDADE   MO  ON MO.CD_MODAL=CE.CD_MODAL INNER  JOIN CE_NATUREZA   NA  ON NA.CD_NATUR=CE.CD_NATUR INNER  JOIN CE_SITUACAO_CONTRATO   ST  ON ST.CD_SITUACAO=CE.CD_SITUACAO INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=CE.CD_FUNDACAO AND FN.NUM_INSCRICAO=CE.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID INNER  JOIN TB_PLANOS   PL  ON PL.CD_FUNDACAO=CE.CD_FUNDACAO AND PL.CD_PLANO=CE.CD_PLANO LEFT OUTER JOIN GB_RECEBEDOR_BENEFICIO   RB  ON RB.CD_FUNDACAO=CE.CD_FUNDACAO AND RB.NUM_INSCRICAO=CE.NUM_INSCRICAO AND RB.NUM_SEQ_GR_FAMIL=CE.NUM_SEQ_GR_FAMIL LEFT OUTER JOIN EE_ENTIDADE   EE2  ON EE2.COD_ENTID=RB.COD_ENTID WHERE CE.CD_FUNDACAO=:CD_FUNDACAO AND CE.NUM_INSCRICAO=:NUM_INSCRICAO AND CE.ANO_CONTRATO=:ANO_CONTRATO AND CE.NUM_CONTRATO=:NUM_CONTRATO AND CE.NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL", new { CD_FUNDACAO, NUM_INSCRICAO, ANO_CONTRATO, NUM_CONTRATO, NUM_SEQ_GR_FAMIL });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ContratoEntidade BuscarPorFundacaoAnoNumContrato(string CD_FUNDACAO, string ANO_CONTRATO, string NUM_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO   AND NUM_CONTRATO = @NUM_CONTRATO", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoInscricaoGrupoFamiliaNotSituacao(string CD_FUNDACAO, string NUM_INSCRICAO, string NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT ST.DS_SITUACAO,        CE.* FROM CE_CONTRATOS CE     INNER JOIN CE_SITUACAO_CONTRATO ST ON ST.CD_SITUACAO = CE.CD_SITUACAO WHERE CE.CD_FUNDACAO = @CD_FUNDACAO   AND CE.NUM_INSCRICAO = @NUM_INSCRICAO   AND CE.CD_SITUACAO NOT IN ('0', '4', '6')   AND CE.NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL ORDER BY CE.DT_CREDITO DESC", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT ST.DS_SITUACAO, CE.* FROM CE_CONTRATOS  CE  INNER  JOIN CE_SITUACAO_CONTRATO   ST  ON ST.CD_SITUACAO=CE.CD_SITUACAO WHERE CE.CD_FUNDACAO=:CD_FUNDACAO AND CE.NUM_INSCRICAO=:NUM_INSCRICAO AND CE.CD_SITUACAO NOT  IN ('0', '4', '6') AND CE.NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL ORDER BY CE.DT_CREDITO DESC", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoInscricaoSituacao(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_SITUACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string NUM_SEQ_GR_FAMIL, string CD_SITUACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, CD_SITUACAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, CD_SITUACAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual int BuscarUltimoNumeroContrato(string CD_FUNDACAO, int ANO_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT TOP 1 NUM_CONTRATO FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT NUM_CONTRATO FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND ROWNUM <= 1  ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
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