using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class RubricaDAO : BaseDAO<RubricaEntidade>
	{
		public virtual List<RubricaEntidade> BuscarPorFundacaoEmpresaMargemConsig(string CD_FUNDACAO, string CD_EMPRESA, string MARGEM_CONSIG)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricaEntidade>("SELECT *  FROM TB_RUBRICA  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND MARGEM_CONSIG = @MARGEM_CONSIG", new { CD_FUNDACAO, CD_EMPRESA, MARGEM_CONSIG }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricaEntidade>("SELECT * FROM TB_RUBRICA WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND MARGEM_CONSIG=:MARGEM_CONSIG", new { CD_FUNDACAO, CD_EMPRESA, MARGEM_CONSIG }).ToList();
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
