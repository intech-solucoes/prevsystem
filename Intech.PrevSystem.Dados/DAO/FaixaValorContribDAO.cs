using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FaixaValorContribDAO : BaseDAO<FaixaValorContribEntidade>
	{
		public virtual List<FaixaValorContribEntidade> BuscarPorFundacaoPlanoTipoContribMantenedora(string CD_FUNDACAO, string CD_PLANO, string CD_TIPO_CONTRIBUICAO, string CD_MANTENEDORA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT *  FROM  TB_FAIXA_VALOR_CONTRIB  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_PLANO = @CD_PLANO    AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO    AND CD_MANTENEDORA = @CD_MANTENEDORA", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT * FROM TB_FAIXA_VALOR_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO AND CD_MANTENEDORA=:CD_MANTENEDORA", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<FaixaValorContribEntidade> BuscarPorFundacaoPlanoTipoContribuicao(string CD_FUNDACAO, string CD_PLANO, string CD_TIPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT * FROM TB_FAIXA_VALOR_CONTRIB FVC  WHERE FVC.CD_FUNDACAO = @CD_FUNDACAO    AND FVC.CD_PLANO = @CD_PLANO    AND FVC.CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO    AND (FVC.ANO_REF * 12 + FVC.MES_REF) = (SELECT MAX(FVC2.ANO_REF * 12 + FVC2.MES_REF)                                            FROM TB_FAIXA_VALOR_CONTRIB FVC2                                            WHERE FVC2.CD_FUNDACAO = FVC.CD_FUNDACAO                                             AND FVC2.CD_PLANO = FVC.CD_PLANO                                             AND FVC2.CD_TIPO_CONTRIBUICAO = FVC.CD_TIPO_CONTRIBUICAO                                             AND FVC.CD_MANTENEDORA = '2')", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO }).ToList();
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
