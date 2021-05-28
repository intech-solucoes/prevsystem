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
	public abstract class TipoContribuicaoDAO : BaseDAO<TipoContribuicaoEntidade>
	{
		public TipoContribuicaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<TipoContribuicaoEntidade> BuscarPorPlanoTipoResgate(string CD_PLANO, string CD_TIPO_RESGATE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TipoContribuicaoEntidade>("SELECT TB_TIPO_CONTRIBUICAO.* FROM TB_TIPO_CONTRIBUICAO WHERE (CD_TIPO_CONTRIBUICAO IN          (SELECT DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO           FROM DR_PARAMETROS_RESGATE           INNER JOIN TB_TIPO_CONTRIBUICAO AS TB_TIPO_CONTRIBUICAO_1 ON TB_TIPO_CONTRIBUICAO_1.CD_TIPO_CONTRIBUICAO = DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO           WHERE (DR_PARAMETROS_RESGATE.CD_PLANO = @CD_PLANO)             AND (DR_PARAMETROS_RESGATE.CD_TIPO_RESGATE = @CD_TIPO_RESGATE)))", new { CD_PLANO, CD_TIPO_RESGATE }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TipoContribuicaoEntidade>("SELECT TB_TIPO_CONTRIBUICAO.* FROM TB_TIPO_CONTRIBUICAO WHERE (CD_TIPO_CONTRIBUICAO IN (SELECT DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO FROM DR_PARAMETROS_RESGATE INNER  JOIN TB_TIPO_CONTRIBUICAO TB_TIPO_CONTRIBUICAO_1  ON TB_TIPO_CONTRIBUICAO_1.CD_TIPO_CONTRIBUICAO=DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO WHERE (DR_PARAMETROS_RESGATE.CD_PLANO=:CD_PLANO) AND (DR_PARAMETROS_RESGATE.CD_TIPO_RESGATE=:CD_TIPO_RESGATE)))", new { CD_PLANO, CD_TIPO_RESGATE }, Transaction).ToList();
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