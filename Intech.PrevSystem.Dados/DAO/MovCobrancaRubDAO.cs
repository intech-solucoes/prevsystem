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
	public abstract class MovCobrancaRubDAO : BaseDAO<MovCobrancaRubEntidade>
	{
		public MovCobrancaRubDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<MovCobrancaRubEntidade> BuscarMesAnoPorFundacaoPlanoInscricaoData(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<MovCobrancaRubEntidade>("SELECT DISTINCT mes_comp,                   ano_comp   FROM   am_mov_cobranca_rub   WHERE  cd_fundacao = @CD_FUNDACAO          AND cd_plano = @CD_PLANO          AND num_inscricao = @NUM_INSCRICAO          AND dt_referencia = @DT_REFERENCIA          AND cd_rubrica_cobranca NOT IN (SELECT DISTINCT cd_rubrica_cobranca                                          FROM   am_rubrica_contrib                                          WHERE  cd_fundacao = @CD_FUNDACAO                                                 AND cd_tipo_contribuicao IN                                                     (SELECT DISTINCT cd_contrib_juros                                                      FROM   am_parametro                                                      WHERE  cd_contrib_juros IS NOT NULL                                                             AND cd_fundacao = @CD_FUNDACAO)                                          UNION                                          SELECT DISTINCT cd_rubrica_cobranca                                          FROM   am_rubrica_contrib                                          WHERE  cd_fundacao = @CD_FUNDACAO                                                 AND cd_tipo_contribuicao IN                                                     (SELECT DISTINCT cd_contrib_multa                                                      FROM   am_parametro                                                      WHERE  cd_contrib_multa IS NOT NULL                                                             AND cd_fundacao = @CD_FUNDACAO)                                          UNION                                          SELECT DISTINCT cd_rubrica_cobranca                                          FROM   am_rubrica_contrib                                          WHERE  cd_fundacao = @CD_FUNDACAO                                                 AND cd_tipo_contribuicao IN                                                     (SELECT DISTINCT cd_contrib_atul_monet                                                      FROM   am_parametro                                                      WHERE  cd_contrib_atul_monet IS NOT NULL                                                             AND cd_fundacao = @CD_FUNDACAO))   ORDER  BY ano_comp,             mes_comp", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, DT_REFERENCIA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<MovCobrancaRubEntidade>("SELECT DISTINCT MES_COMP, ANO_COMP FROM AM_MOV_COBRANCA_RUB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO AND DT_REFERENCIA=:DT_REFERENCIA AND CD_RUBRICA_COBRANCA NOT  IN (SELECT DISTINCT CD_RUBRICA_COBRANCA FROM AM_RUBRICA_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_TIPO_CONTRIBUICAO IN (SELECT DISTINCT CD_CONTRIB_JUROS FROM AM_PARAMETRO WHERE CD_CONTRIB_JUROS IS  NOT NULL  AND CD_FUNDACAO=:CD_FUNDACAO) UNION SELECT DISTINCT CD_RUBRICA_COBRANCA FROM AM_RUBRICA_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_TIPO_CONTRIBUICAO IN (SELECT DISTINCT CD_CONTRIB_MULTA FROM AM_PARAMETRO WHERE CD_CONTRIB_MULTA IS  NOT NULL  AND CD_FUNDACAO=:CD_FUNDACAO) UNION SELECT DISTINCT CD_RUBRICA_COBRANCA FROM AM_RUBRICA_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_TIPO_CONTRIBUICAO IN (SELECT DISTINCT CD_CONTRIB_ATUL_MONET FROM AM_PARAMETRO WHERE CD_CONTRIB_ATUL_MONET IS  NOT NULL  AND CD_FUNDACAO=:CD_FUNDACAO)) ORDER BY ANO_COMP, MES_COMP", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, DT_REFERENCIA }).ToList();
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
