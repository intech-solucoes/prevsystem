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
	public abstract class RubricaConcessaoDAO : BaseDAO<RubricaConcessaoEntidade>
	{
		public RubricaConcessaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<RubricaConcessaoEntidade> BuscarPorFundacaoEmpresaRubricaAdesaoPcsDtVigencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_RUBRICA, string ADESAO_PCS, DateTime DT_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricaConcessaoEntidade>("SELECT * FROM   GB_RUBRICA_CONCESSAO AS RC WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_EMPRESA = @CD_EMPRESA )        AND ( CD_RUBRICA = @CD_RUBRICA )        AND ( ADESAO_PCS = @ADESAO_PCS )        AND ( DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA) AS EXPR1                             FROM   GB_RUBRICA_CONCESSAO AS RCC                             WHERE  ( CD_FUNDACAO = RC.CD_FUNDACAO )                                    AND ( CD_EMPRESA = RC.CD_EMPRESA )                                    AND ( CD_RUBRICA = RC.CD_RUBRICA )                                    AND ( ADESAO_PCS = RC.ADESAO_PCS )                                    AND ( DT_VIGENCIA <= @DT_VIGENCIA )) )", new { CD_FUNDACAO, CD_EMPRESA, CD_RUBRICA, ADESAO_PCS, DT_VIGENCIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricaConcessaoEntidade>("SELECT * FROM GB_RUBRICA_CONCESSAO RC WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (CD_RUBRICA=:CD_RUBRICA) AND (ADESAO_PCS=:ADESAO_PCS) AND (DT_VIGENCIA=(SELECT MAX(DT_VIGENCIA) AS EXPR1 FROM GB_RUBRICA_CONCESSAO RCC WHERE (CD_FUNDACAO=RC.CD_FUNDACAO) AND (CD_EMPRESA=RC.CD_EMPRESA) AND (CD_RUBRICA=RC.CD_RUBRICA) AND (ADESAO_PCS=RC.ADESAO_PCS) AND (DT_VIGENCIA<=:DT_VIGENCIA)))", new { CD_FUNDACAO, CD_EMPRESA, CD_RUBRICA, ADESAO_PCS, DT_VIGENCIA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<RubricaConcessaoEntidade> BuscarPorFundacaoEmpresaRubricaDtVigencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_RUBRICA, DateTime DT_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricaConcessaoEntidade>("SELECT * FROM   GB_RUBRICA_CONCESSAO AS RC WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_EMPRESA = @CD_EMPRESA )        AND ( CD_RUBRICA = @CD_RUBRICA )        AND ( ADESAO_PCS <> 'S'               OR ADESAO_PCS <> 'N' )        AND ( DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA) AS EXPR1                             FROM   GB_RUBRICA_CONCESSAO AS RCC                             WHERE  ( CD_FUNDACAO = RC.CD_FUNDACAO )                                    AND ( CD_EMPRESA = RC.CD_EMPRESA )                                    AND ( CD_RUBRICA = RC.CD_RUBRICA )                                    AND ( ADESAO_PCS = RC.ADESAO_PCS )                                    AND ( DT_VIGENCIA <= @DT_VIGENCIA )) )", new { CD_FUNDACAO, CD_EMPRESA, CD_RUBRICA, DT_VIGENCIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricaConcessaoEntidade>("SELECT * FROM GB_RUBRICA_CONCESSAO RC WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (CD_RUBRICA=:CD_RUBRICA) AND (ADESAO_PCS<>'S' OR ADESAO_PCS<>'N') AND (DT_VIGENCIA=(SELECT MAX(DT_VIGENCIA) AS EXPR1 FROM GB_RUBRICA_CONCESSAO RCC WHERE (CD_FUNDACAO=RC.CD_FUNDACAO) AND (CD_EMPRESA=RC.CD_EMPRESA) AND (CD_RUBRICA=RC.CD_RUBRICA) AND (ADESAO_PCS=RC.ADESAO_PCS) AND (DT_VIGENCIA<=:DT_VIGENCIA)))", new { CD_FUNDACAO, CD_EMPRESA, CD_RUBRICA, DT_VIGENCIA }, Transaction).ToList();
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