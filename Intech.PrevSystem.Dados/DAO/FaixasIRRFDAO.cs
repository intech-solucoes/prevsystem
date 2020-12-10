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
	public abstract class FaixasIRRFDAO : BaseDAO<FaixasIRRFEntidade>
	{
		public FaixasIRRFDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FaixasIRRFEntidade> BuscarPorValorFaixa(decimal VALOR_FAIXA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixasIRRFEntidade>("SELECT       TB_FAIXAS_IRRF.*,       TB_IRRF.VALOR_ABATIMENTO_DEP,       TB_IRRF.ABATIMENTO_ACIMA_65ANOS   FROM   TB_FAIXAS_IRRF          INNER JOIN TB_IRRF                  ON TB_FAIXAS_IRRF.DT_REFERENCIA = TB_IRRF.DT_REFERENCIA                     AND TB_FAIXAS_IRRF.TIPO_IRRF = TB_IRRF.TIPO_IRRF   WHERE  ( TB_FAIXAS_IRRF.TIPO_IRRF = 1 )          AND ( TB_FAIXAS_IRRF.DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1                                                FROM   TB_FAIXAS_IRRF AS A                                                WHERE  ( TIPO_IRRF = 1 )) )          AND ( TB_IRRF.DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1                                         FROM   TB_IRRF AS B                                         WHERE  ( TIPO_IRRF = 1 )) )          AND ( TB_FAIXAS_IRRF.VALOR_FAIXA >= @VALOR_FAIXA )   ORDER  BY TB_FAIXAS_IRRF.VALOR_FAIXA", new { VALOR_FAIXA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixasIRRFEntidade>("SELECT TB_FAIXAS_IRRF.*, TB_IRRF.VALOR_ABATIMENTO_DEP, TB_IRRF.ABATIMENTO_ACIMA_65ANOS FROM TB_FAIXAS_IRRF INNER  JOIN TB_IRRF  ON TB_FAIXAS_IRRF.DT_REFERENCIA=TB_IRRF.DT_REFERENCIA AND TB_FAIXAS_IRRF.TIPO_IRRF=TB_IRRF.TIPO_IRRF WHERE (TB_FAIXAS_IRRF.TIPO_IRRF=1) AND (TB_FAIXAS_IRRF.DT_REFERENCIA=(SELECT MAX(DT_REFERENCIA) AS EXPR1 FROM TB_FAIXAS_IRRF A WHERE (TIPO_IRRF=1))) AND (TB_IRRF.DT_REFERENCIA=(SELECT MAX(DT_REFERENCIA) AS EXPR1 FROM TB_IRRF B WHERE (TIPO_IRRF=1))) AND (TB_FAIXAS_IRRF.VALOR_FAIXA>=:VALOR_FAIXA) ORDER BY TB_FAIXAS_IRRF.VALOR_FAIXA", new { VALOR_FAIXA }).ToList();
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
