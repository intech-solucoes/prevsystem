﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DocumentoAtualizacaoCadastralDAO : BaseDAO<DocumentoAtualizacaoCadastralEntidade>
	{
		public virtual void IncluirDocumento(decimal OID_DOC_ATU_CADASTRAL, decimal OID_ARQUIVO_UPLOAD, string CD_FUNDACAO, string NUM_INSCRICAO, decimal SEQ_RECEBEDOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_DOC_ATU_CADASTRAL   ( OID_ARQUIVO_UPLOAD, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR )  VALUES  ( @OID_ARQUIVO_UPLOAD, @CD_FUNDACAO, @NUM_INSCRICAO, @SEQ_RECEBEDOR )", new { OID_DOC_ATU_CADASTRAL, OID_ARQUIVO_UPLOAD, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_DOC_ATU_CADASTRAL (OID_ARQUIVO_UPLOAD, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR) VALUES (:OID_ARQUIVO_UPLOAD, :CD_FUNDACAO, :NUM_INSCRICAO, :SEQ_RECEBEDOR)", new { OID_DOC_ATU_CADASTRAL, OID_ARQUIVO_UPLOAD, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DocumentoAtualizacaoCadastralEntidade> ObterPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoAtualizacaoCadastralEntidade>("SELECT EE.NOME_ENTID, AU.OID_ARQUIVO_UPLOAD, AU.NOM_ARQUIVO_ORIGINAL, AU.NOM_ARQUIVO_LOCAL, AU.DTA_UPLOAD  FROM WEB_DOC_ATU_CADASTRAL DC  INNER JOIN TBG_ARQUIVO_UPLOAD AU ON AU.OID_ARQUIVO_UPLOAD = DC.OID_ARQUIVO_UPLOAD  INNER JOIN CS_FUNCIONARIO FU ON FU.CD_FUNDACAO = DC.CD_FUNDACAO AND FU.NUM_INSCRICAO = DC.NUM_INSCRICAO  INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FU.COD_ENTID  WHERE DC.CD_FUNDACAO = @CD_FUNDACAO    AND DC.NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY AU.DTA_UPLOAD DESC", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoAtualizacaoCadastralEntidade>("SELECT EE.NOME_ENTID, AU.OID_ARQUIVO_UPLOAD, AU.NOM_ARQUIVO_ORIGINAL, AU.NOM_ARQUIVO_LOCAL, AU.DTA_UPLOAD FROM WEB_DOC_ATU_CADASTRAL  DC  INNER  JOIN TBG_ARQUIVO_UPLOAD   AU  ON AU.OID_ARQUIVO_UPLOAD=DC.OID_ARQUIVO_UPLOAD INNER  JOIN CS_FUNCIONARIO   FU  ON FU.CD_FUNDACAO=DC.CD_FUNDACAO AND FU.NUM_INSCRICAO=DC.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FU.COD_ENTID WHERE DC.CD_FUNDACAO=:CD_FUNDACAO AND DC.NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY AU.DTA_UPLOAD DESC", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
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
