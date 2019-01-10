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
    public abstract class ContratoDAO : BaseDAO<ContratoEntidade>
    {
        
		public virtual ContratoEntidade BuscarPorFundacaoAnoNumContrato(string CD_FUNDACAO, string ANO_CONTRATO, string NUM_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO   AND NUM_CONTRATO = @NUM_CONTRATO", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<ContratoEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<ContratoEntidade> BuscarPorFundacaoInscricaoSituacao(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_SITUACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<ContratoEntidade> BuscarPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string NUM_SEQ_GR_FAMIL, string CD_SITUACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, CD_SITUACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, CD_SITUACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT *  FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND CD_SITUACAO = @CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContratoEntidade>("SELECT * FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_SITUACAO=:CD_SITUACAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual int BuscarUltimoNumeroContrato(string CD_FUNDACAO, int ANO_CONTRATO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT TOP 1 NUM_CONTRATO FROM CE_CONTRATOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT NUM_CONTRATO FROM CE_CONTRATOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND ROWNUM <= 1  ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
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
