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
	public abstract class ProtocoloDAO : BaseDAO<ProtocoloEntidade>
	{
		public ProtocoloDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual ProtocoloEntidade BuscarAbertasPorFundacaoEmpresaPlanoMatriculaFuncionalidade(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_MATRICULA, decimal NUM_FUNCIONALIDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.CD_EMPRESA,         WEB_PROTOCOLO.CD_FUNDACAO,         WEB_PROTOCOLO.CD_PLANO,         WEB_PROTOCOLO.COD_IDENTIFICADOR,         WEB_PROTOCOLO.DTA_EFETIVACAO,         WEB_PROTOCOLO.DTA_SOLICITACAO,         WEB_PROTOCOLO.NUM_MATRICULA,         WEB_PROTOCOLO.OID_FUNCIONALIDADE,         WEB_PROTOCOLO.OID_PROTOCOLO,         WEB_PROTOCOLO.SEQ_RECEBEDOR,         WEB_PROTOCOLO.TXT_DISPOSITIVO,         WEB_PROTOCOLO.TXT_IPV4,         WEB_PROTOCOLO.TXT_IPV4_EXTERNO,         WEB_PROTOCOLO.TXT_IPV6,         WEB_PROTOCOLO.TXT_MOTIVO_RECUSA,         WEB_PROTOCOLO.TXT_ORIGEM,         WEB_PROTOCOLO.TXT_TRANSACAO,         WEB_PROTOCOLO.TXT_TRANSACAO2,         WEB_PROTOCOLO.TXT_USUARIO_EFETIVACAO,         WEB_PROTOCOLO.TXT_USUARIO_SOLICITACAO  FROM   WEB_PROTOCOLO  INNER JOIN WEB_FUNCIONALIDADE      ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE = WEB_PROTOCOLO.OID_FUNCIONALIDADE  WHERE ( WEB_PROTOCOLO.CD_FUNDACAO = @CD_FUNDACAO )    AND ( WEB_PROTOCOLO.CD_EMPRESA = @CD_EMPRESA )    AND ( WEB_PROTOCOLO.CD_PLANO = @CD_PLANO )    AND ( WEB_PROTOCOLO.NUM_MATRICULA = @NUM_MATRICULA )    AND ( WEB_PROTOCOLO.DTA_EFETIVACAO IS NULL )    AND ( WEB_PROTOCOLO.TXT_MOTIVO_RECUSA IS NULL )    AND ( WEB_FUNCIONALIDADE.NUM_FUNCIONALIDADE = @NUM_FUNCIONALIDADE )  ORDER  BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, NUM_FUNCIONALIDADE }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.CD_EMPRESA, WEB_PROTOCOLO.CD_FUNDACAO, WEB_PROTOCOLO.CD_PLANO, WEB_PROTOCOLO.COD_IDENTIFICADOR, WEB_PROTOCOLO.DTA_EFETIVACAO, WEB_PROTOCOLO.DTA_SOLICITACAO, WEB_PROTOCOLO.NUM_MATRICULA, WEB_PROTOCOLO.OID_FUNCIONALIDADE, WEB_PROTOCOLO.OID_PROTOCOLO, WEB_PROTOCOLO.SEQ_RECEBEDOR, WEB_PROTOCOLO.TXT_DISPOSITIVO, WEB_PROTOCOLO.TXT_IPV4, WEB_PROTOCOLO.TXT_IPV4_EXTERNO, WEB_PROTOCOLO.TXT_IPV6, WEB_PROTOCOLO.TXT_MOTIVO_RECUSA, WEB_PROTOCOLO.TXT_ORIGEM, WEB_PROTOCOLO.TXT_TRANSACAO, WEB_PROTOCOLO.TXT_TRANSACAO2, WEB_PROTOCOLO.TXT_USUARIO_EFETIVACAO, WEB_PROTOCOLO.TXT_USUARIO_SOLICITACAO FROM WEB_PROTOCOLO INNER  JOIN WEB_FUNCIONALIDADE  ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE=WEB_PROTOCOLO.OID_FUNCIONALIDADE WHERE (WEB_PROTOCOLO.CD_FUNDACAO=:CD_FUNDACAO) AND (WEB_PROTOCOLO.CD_EMPRESA=:CD_EMPRESA) AND (WEB_PROTOCOLO.CD_PLANO=:CD_PLANO) AND (WEB_PROTOCOLO.NUM_MATRICULA=:NUM_MATRICULA) AND (WEB_PROTOCOLO.DTA_EFETIVACAO IS NULL ) AND (WEB_PROTOCOLO.TXT_MOTIVO_RECUSA IS NULL ) AND (WEB_FUNCIONALIDADE.NUM_FUNCIONALIDADE=:NUM_FUNCIONALIDADE) ORDER BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, NUM_FUNCIONALIDADE }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ProtocoloEntidade BuscarPorCodIdentificador(string COD_IDENTIFICADOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*,     WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE,     EE_ENTIDADE.NOME_ENTID,     TB_PLANOS.DS_PLANO FROM   WEB_PROTOCOLO  INNER JOIN WEB_FUNCIONALIDADE ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE = WEB_PROTOCOLO.OID_FUNCIONALIDADE  INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_MATRICULA = WEB_PROTOCOLO.NUM_MATRICULA INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = WEB_PROTOCOLO.CD_PLANO WHERE ( WEB_PROTOCOLO.COD_IDENTIFICADOR = @COD_IDENTIFICADOR) ORDER  BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { COD_IDENTIFICADOR }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*, WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE, EE_ENTIDADE.NOME_ENTID, TB_PLANOS.DS_PLANO FROM WEB_PROTOCOLO INNER  JOIN WEB_FUNCIONALIDADE  ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE=WEB_PROTOCOLO.OID_FUNCIONALIDADE INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_MATRICULA=WEB_PROTOCOLO.NUM_MATRICULA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=WEB_PROTOCOLO.CD_PLANO WHERE (WEB_PROTOCOLO.COD_IDENTIFICADOR=:COD_IDENTIFICADOR) ORDER BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { COD_IDENTIFICADOR }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ProtocoloEntidade BuscarPorFuncionalidade(decimal OID_FUNCIONALIDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT * FROM WEB_PROTOCOLO WHERE OID_FUNCIONALIDADE = @OID_FUNCIONALIDADE", new { OID_FUNCIONALIDADE }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT * FROM WEB_PROTOCOLO WHERE OID_FUNCIONALIDADE=:OID_FUNCIONALIDADE", new { OID_FUNCIONALIDADE }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ProtocoloEntidade> BuscarPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*,     WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE,     EE_ENTIDADE.NOME_ENTID,     TB_PLANOS.DS_PLANO FROM   WEB_PROTOCOLO  INNER JOIN WEB_FUNCIONALIDADE ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE = WEB_PROTOCOLO.OID_FUNCIONALIDADE  INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_MATRICULA = WEB_PROTOCOLO.NUM_MATRICULA INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = WEB_PROTOCOLO.CD_PLANO WHERE ( WEB_PROTOCOLO.CD_FUNDACAO = @CD_FUNDACAO )    AND ( WEB_PROTOCOLO.CD_EMPRESA = @CD_EMPRESA )    AND ( WEB_PROTOCOLO.NUM_MATRICULA = @NUM_MATRICULA )  ORDER  BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*, WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE, EE_ENTIDADE.NOME_ENTID, TB_PLANOS.DS_PLANO FROM WEB_PROTOCOLO INNER  JOIN WEB_FUNCIONALIDADE  ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE=WEB_PROTOCOLO.OID_FUNCIONALIDADE INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_MATRICULA=WEB_PROTOCOLO.NUM_MATRICULA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=WEB_PROTOCOLO.CD_PLANO WHERE (WEB_PROTOCOLO.CD_FUNDACAO=:CD_FUNDACAO) AND (WEB_PROTOCOLO.CD_EMPRESA=:CD_EMPRESA) AND (WEB_PROTOCOLO.NUM_MATRICULA=:NUM_MATRICULA) ORDER BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ProtocoloEntidade BuscarPorOid(decimal OID_PROTOCOLO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*,     WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE,     EE_ENTIDADE.NOME_ENTID,     TB_PLANOS.DS_PLANO FROM   WEB_PROTOCOLO  INNER JOIN WEB_FUNCIONALIDADE ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE = WEB_PROTOCOLO.OID_FUNCIONALIDADE  INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_MATRICULA = WEB_PROTOCOLO.NUM_MATRICULA INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = WEB_PROTOCOLO.CD_PLANO WHERE ( WEB_PROTOCOLO.OID_PROTOCOLO = @OID_PROTOCOLO) ORDER  BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { OID_PROTOCOLO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT WEB_PROTOCOLO.*, WEB_FUNCIONALIDADE.DES_FUNCIONALIDADE, EE_ENTIDADE.NOME_ENTID, TB_PLANOS.DS_PLANO FROM WEB_PROTOCOLO INNER  JOIN WEB_FUNCIONALIDADE  ON WEB_FUNCIONALIDADE.OID_FUNCIONALIDADE=WEB_PROTOCOLO.OID_FUNCIONALIDADE INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_MATRICULA=WEB_PROTOCOLO.NUM_MATRICULA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID LEFT OUTER JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=WEB_PROTOCOLO.CD_PLANO WHERE (WEB_PROTOCOLO.OID_PROTOCOLO=:OID_PROTOCOLO) ORDER BY WEB_PROTOCOLO.DTA_SOLICITACAO DESC", new { OID_PROTOCOLO }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void Insert(decimal OID_FUNCIONALIDADE, string COD_IDENTIFICADOR, string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_MATRICULA, decimal? SEQ_RECEBEDOR, DateTime DTA_SOLICITACAO, DateTime? DTA_EFETIVACAO, string TXT_MOTIVO_RECUSA, string TXT_TRANSACAO, string TXT_TRANSACAO2, string TXT_USUARIO_SOLICITACAO, string TXT_USUARIO_EFETIVACAO, string TXT_IPV4, string TXT_IPV6, string TXT_DISPOSITIVO, string TXT_ORIGEM)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_PROTOCOLO (     OID_FUNCIONALIDADE,     COD_IDENTIFICADOR,     CD_FUNDACAO,     CD_EMPRESA,     CD_PLANO,     NUM_MATRICULA,     SEQ_RECEBEDOR,     DTA_SOLICITACAO,     DTA_EFETIVACAO,     TXT_MOTIVO_RECUSA,     TXT_TRANSACAO,     TXT_TRANSACAO2,     TXT_USUARIO_SOLICITACAO,     TXT_USUARIO_EFETIVACAO,     TXT_IPV4,     TXT_IPV6,     TXT_DISPOSITIVO,     TXT_ORIGEM)  VALUES (     @OID_FUNCIONALIDADE,     @COD_IDENTIFICADOR,     @CD_FUNDACAO,     @CD_EMPRESA,     @CD_PLANO,     @NUM_MATRICULA,     @SEQ_RECEBEDOR,     @DTA_SOLICITACAO,     @DTA_EFETIVACAO,     @TXT_MOTIVO_RECUSA,     @TXT_TRANSACAO,     @TXT_TRANSACAO2,     @TXT_USUARIO_SOLICITACAO,     @TXT_USUARIO_EFETIVACAO,     @TXT_IPV4,     @TXT_IPV6,     @TXT_DISPOSITIVO,     @TXT_ORIGEM)", new { OID_FUNCIONALIDADE, COD_IDENTIFICADOR, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, SEQ_RECEBEDOR, DTA_SOLICITACAO, DTA_EFETIVACAO, TXT_MOTIVO_RECUSA, TXT_TRANSACAO, TXT_TRANSACAO2, TXT_USUARIO_SOLICITACAO, TXT_USUARIO_EFETIVACAO, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO, TXT_ORIGEM }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_PROTOCOLO (OID_PROTOCOLO,OID_FUNCIONALIDADE, COD_IDENTIFICADOR, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, SEQ_RECEBEDOR, DTA_SOLICITACAO, DTA_EFETIVACAO, TXT_MOTIVO_RECUSA, TXT_TRANSACAO, TXT_TRANSACAO2, TXT_USUARIO_SOLICITACAO, TXT_USUARIO_EFETIVACAO, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO, TXT_ORIGEM) VALUES (S_WEB_PROTOCOLO.NEXTVAL,:OID_FUNCIONALIDADE, :COD_IDENTIFICADOR, :CD_FUNDACAO, :CD_EMPRESA, :CD_PLANO, :NUM_MATRICULA, :SEQ_RECEBEDOR, :DTA_SOLICITACAO, :DTA_EFETIVACAO, :TXT_MOTIVO_RECUSA, :TXT_TRANSACAO, :TXT_TRANSACAO2, :TXT_USUARIO_SOLICITACAO, :TXT_USUARIO_EFETIVACAO, :TXT_IPV4, :TXT_IPV6, :TXT_DISPOSITIVO, :TXT_ORIGEM)", new { OID_FUNCIONALIDADE, COD_IDENTIFICADOR, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, SEQ_RECEBEDOR, DTA_SOLICITACAO, DTA_EFETIVACAO, TXT_MOTIVO_RECUSA, TXT_TRANSACAO, TXT_TRANSACAO2, TXT_USUARIO_SOLICITACAO, TXT_USUARIO_EFETIVACAO, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO, TXT_ORIGEM }, Transaction);
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