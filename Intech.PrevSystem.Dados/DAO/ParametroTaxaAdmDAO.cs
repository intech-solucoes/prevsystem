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
	public abstract class ParametroTaxaAdmDAO : BaseDAO<ParametroTaxaAdmEntidade>
	{
		public ParametroTaxaAdmDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<ParametroTaxaAdmEntidade> BuscarPorFundacaoPlanoContribuicao(string CD_FUNDACAO, string CD_PLANO, string CD_TIPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ParametroTaxaAdmEntidade>("SELECT * FROM   TB_PARAMETRO_TAXA_ADM WHERE  CD_FUNDACAO = @CD_FUNDACAO        AND CD_PLANO = @CD_PLANO        AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO        AND ( '' + ANO_REF + MES_REF = (SELECT MAX('' + ANO_REF + MES_REF)                                        FROM   TB_PARAMETRO_TAXA_ADM PARAMETRO_TAXA_ADM                                        WHERE  PARAMETRO_TAXA_ADM.CD_FUNDACAO = @CD_FUNDACAO                                               AND PARAMETRO_TAXA_ADM.CD_PLANO = @CD_PLANO                                               AND PARAMETRO_TAXA_ADM.CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO) )", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ParametroTaxaAdmEntidade>("SELECT * FROM TB_PARAMETRO_TAXA_ADM WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO AND ('' || ANO_REF || MES_REF=(SELECT MAX('' || ANO_REF || MES_REF) FROM TB_PARAMETRO_TAXA_ADM  PARAMETRO_TAXA_ADM  WHERE PARAMETRO_TAXA_ADM.CD_FUNDACAO=:CD_FUNDACAO AND PARAMETRO_TAXA_ADM.CD_PLANO=:CD_PLANO AND PARAMETRO_TAXA_ADM.CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO))", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO }, Transaction).ToList();
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