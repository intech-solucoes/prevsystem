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
	public abstract class BoletaDAO : BaseDAO<BoletaEntidade>
	{
		public BoletaDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<BoletaEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BoletaEntidade>("SELECT AM_BOLETA.*,      TB_PLANOS.DS_PLANO  FROM AM_BOLETA          INNER JOIN TB_PLANOS ON TB_PLANOS.CD_FUNDACAO = AM_BOLETA.CD_FUNDACAO AND TB_PLANOS.CD_PLANO = AM_BOLETA.CD_PLANO  WHERE AM_BOLETA.SITUACAO = 2    AND AM_BOLETA.CD_TIPO_COBRANCA = '02'    AND AM_BOLETA.DT_PAGTO IS NULL         AND AM_BOLETA.CD_FUNDACAO = @CD_FUNDACAO    AND AM_BOLETA.NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BoletaEntidade>("SELECT AM_BOLETA.*, TB_PLANOS.DS_PLANO FROM AM_BOLETA INNER  JOIN TB_PLANOS  ON TB_PLANOS.CD_FUNDACAO=AM_BOLETA.CD_FUNDACAO AND TB_PLANOS.CD_PLANO=AM_BOLETA.CD_PLANO WHERE AM_BOLETA.SITUACAO=2 AND AM_BOLETA.CD_TIPO_COBRANCA='02' AND AM_BOLETA.DT_PAGTO IS NULL  AND AM_BOLETA.CD_FUNDACAO=:CD_FUNDACAO AND AM_BOLETA.NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual BoletaEntidade BuscarPorFundacaoInscricaoDataInicioDataReferencia(string CD_FUNDACAO, string NUM_INSCRICAO, DateTime DT_INICIO, DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<BoletaEntidade>("SELECT AM_BOLETA.*,      TB_PLANOS.DS_PLANO  FROM AM_BOLETA          INNER JOIN TB_PLANOS ON TB_PLANOS.CD_FUNDACAO = AM_BOLETA.CD_FUNDACAO AND TB_PLANOS.CD_PLANO = AM_BOLETA.CD_PLANO  WHERE AM_BOLETA.SITUACAO = 2    AND AM_BOLETA.CD_TIPO_COBRANCA = '02'    AND AM_BOLETA.DT_PAGTO IS NULL         AND AM_BOLETA.CD_FUNDACAO = @CD_FUNDACAO    AND AM_BOLETA.NUM_INSCRICAO = @NUM_INSCRICAO    AND AM_BOLETA.DT_INICIO = @DT_INICIO    AND AM_BOLETA.DT_REFERENCIA = @DT_REFERENCIA", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INICIO, DT_REFERENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<BoletaEntidade>("SELECT AM_BOLETA.*, TB_PLANOS.DS_PLANO FROM AM_BOLETA INNER  JOIN TB_PLANOS  ON TB_PLANOS.CD_FUNDACAO=AM_BOLETA.CD_FUNDACAO AND TB_PLANOS.CD_PLANO=AM_BOLETA.CD_PLANO WHERE AM_BOLETA.SITUACAO=2 AND AM_BOLETA.CD_TIPO_COBRANCA='02' AND AM_BOLETA.DT_PAGTO IS NULL  AND AM_BOLETA.CD_FUNDACAO=:CD_FUNDACAO AND AM_BOLETA.NUM_INSCRICAO=:NUM_INSCRICAO AND AM_BOLETA.DT_INICIO=:DT_INICIO AND AM_BOLETA.DT_REFERENCIA=:DT_REFERENCIA", new { CD_FUNDACAO, NUM_INSCRICAO, DT_INICIO, DT_REFERENCIA });
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
