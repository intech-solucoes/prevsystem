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
	public abstract class FaixaValorContribDAO : BaseDAO<FaixaValorContribEntidade>
	{
		public FaixaValorContribDAO (IDbTransaction tx = null) : base(tx) { }

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
				if(Transaction == null)
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
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FaixaValorContribEntidade> BuscarPorTipoContribMantenedora(string CD_TIPO_CONTRIBUICAO, string CD_MANTENEDORA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT tb_faixa_valor_contrib.cd_fundacao,          tb_faixa_valor_contrib.cd_plano,          tb_faixa_valor_contrib.cd_tipo_contribuicao,          tb_faixa_valor_contrib.cd_mantenedora,          tb_faixa_valor_contrib.ano_ref,          tb_faixa_valor_contrib.mes_ref,          tb_faixa_valor_contrib.seq_faixa,          tb_faixa_valor_contrib.perc_faixa,          tb_faixa_valor_contrib.limite_inf_faixa,          tb_faixa_valor_contrib.limite_sup_faixa,          tb_faixa_valor_contrib.deducao_faixa,          tb_faixa_valor_contrib.perc_fundador,          tb_faixa_valor_contrib.vl_perc_min,          tb_faixa_valor_contrib.vl_perc_max   FROM   tb_faixa_valor_contrib          INNER JOIN (SELECT Max(mes_ref) AS MES_REF,                             Max(ano_ref) AS ANO_REF                      FROM   tb_faixa_contrib AS TB_FAIXA_CONTRIB_UM                      WHERE  ( cd_tipo_contribuicao = @CD_TIPO_CONTRIBUICAO )                             AND ( cd_mantenedora = @CD_MANTENEDORA )                             AND ( ano_ref = (SELECT Max(ano_ref) AS ANO_REF                                              FROM   tb_faixa_contrib AS                                                     TB_FAIXA_CONTRIB_DOIS                                              WHERE  ( cd_tipo_contribuicao =                                                       @CD_TIPO_CONTRIBUICAO )                                                     AND ( cd_mantenedora =                                                           @CD_MANTENEDORA )) )) AS                     TB                  ON TB.ano_ref = tb_faixa_valor_contrib.ano_ref                     AND tb_faixa_valor_contrib.ano_ref = TB.ano_ref                     AND tb_faixa_valor_contrib.mes_ref = TB.mes_ref   WHERE  ( tb_faixa_valor_contrib.cd_tipo_contribuicao = @CD_TIPO_CONTRIBUICAO )          AND ( tb_faixa_valor_contrib.cd_mantenedora = @CD_MANTENEDORA )", new { CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT TB_FAIXA_VALOR_CONTRIB.CD_FUNDACAO, TB_FAIXA_VALOR_CONTRIB.CD_PLANO, TB_FAIXA_VALOR_CONTRIB.CD_TIPO_CONTRIBUICAO, TB_FAIXA_VALOR_CONTRIB.CD_MANTENEDORA, TB_FAIXA_VALOR_CONTRIB.ANO_REF, TB_FAIXA_VALOR_CONTRIB.MES_REF, TB_FAIXA_VALOR_CONTRIB.SEQ_FAIXA, TB_FAIXA_VALOR_CONTRIB.PERC_FAIXA, TB_FAIXA_VALOR_CONTRIB.LIMITE_INF_FAIXA, TB_FAIXA_VALOR_CONTRIB.LIMITE_SUP_FAIXA, TB_FAIXA_VALOR_CONTRIB.DEDUCAO_FAIXA, TB_FAIXA_VALOR_CONTRIB.PERC_FUNDADOR, TB_FAIXA_VALOR_CONTRIB.VL_PERC_MIN, TB_FAIXA_VALOR_CONTRIB.VL_PERC_MAX FROM TB_FAIXA_VALOR_CONTRIB INNER  JOIN (SELECT MAX(MES_REF) AS MES_REF, MAX(ANO_REF) AS ANO_REF FROM TB_FAIXA_CONTRIB TB_FAIXA_CONTRIB_UM WHERE (CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO) AND (CD_MANTENEDORA=:CD_MANTENEDORA) AND (ANO_REF=(SELECT MAX(ANO_REF) AS ANO_REF FROM TB_FAIXA_CONTRIB TB_FAIXA_CONTRIB_DOIS WHERE (CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO) AND (CD_MANTENEDORA=:CD_MANTENEDORA)))) TB  ON TB.ANO_REF=TB_FAIXA_VALOR_CONTRIB.ANO_REF AND TB_FAIXA_VALOR_CONTRIB.ANO_REF=TB.ANO_REF AND TB_FAIXA_VALOR_CONTRIB.MES_REF=TB.MES_REF WHERE (TB_FAIXA_VALOR_CONTRIB.CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO) AND (TB_FAIXA_VALOR_CONTRIB.CD_MANTENEDORA=:CD_MANTENEDORA)", new { CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA }).ToList();
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
