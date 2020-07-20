using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class ContribuicaoIndividualDAO : BaseDAO<ContribuicaoIndividualEntidade>
	{
		public virtual List<ContribuicaoIndividualEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT *   FROM CS_CONTRIB_INDIVIDUAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<ContribuicaoIndividualEntidade> BuscarPorFundacaoInscricaoDataAtualTipoFixo(string CD_FUNDACAO, string NUM_INSCRICAO, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT *   FROM CS_CONTRIB_INDIVIDUAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_TIPO_CONTRIBUICAO IN ('09','15')    AND (DT_FIM IS NULL OR DT_FIM >= @DATA_ATUAL)", new { CD_FUNDACAO, NUM_INSCRICAO, DATA_ATUAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_TIPO_CONTRIBUICAO IN ('09', '15') AND (DT_FIM IS NULL  OR DT_FIM>=:DATA_ATUAL)", new { CD_FUNDACAO, NUM_INSCRICAO, DATA_ATUAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<ContribuicaoIndividualEntidade> BuscarPorFundacaoInscricaoTipo(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_TIPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT *   FROM CS_CONTRIB_INDIVIDUAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_TIPO_CONTRIBUICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_TIPO_CONTRIBUICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual ContribuicaoIndividualEntidade BuscarPorFundacaoInscricaoTipoFixo(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_TIPO_CONTRIBUICAO in ('07','11') --fixo", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_TIPO_CONTRIBUICAO IN ('07', '11')", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual ContribuicaoIndividualEntidade BuscarPorFundacaoPlanoInscricaoTipo(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string CD_TIPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContribuicaoIndividualEntidade>("SELECT *   FROM CS_CONTRIB_INDIVIDUAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_PLANO = @CD_PLANO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_TIPO_CONTRIBUICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ContribuicaoIndividualEntidade>("SELECT * FROM CS_CONTRIB_INDIVIDUAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_TIPO_CONTRIBUICAO });
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
