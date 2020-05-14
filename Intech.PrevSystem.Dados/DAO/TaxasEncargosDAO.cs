using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class TaxasEncargosDAO : BaseDAO<TaxasEncargosEntidade>
	{
		public virtual List<TaxasEncargosEntidade> BuscarPorFundacaoEmpresaModalidadeNatureza(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxasEncargosEntidade>("SELECT *  FROM CE_TAXAS_ENCARGOS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_MODAL = @CD_MODAL    AND CD_NATUR = @CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxasEncargosEntidade>("SELECT * FROM CE_TAXAS_ENCARGOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_MODAL=:CD_MODAL AND CD_NATUR=:CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR }).ToList();
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
