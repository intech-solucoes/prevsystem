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
	public abstract class TaxasEncargosPlanoDAO : BaseDAO<TaxasEncargosPlanoEntidade>
	{
		public TaxasEncargosPlanoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<TaxasEncargosPlanoEntidade> BuscarPorFundacaoEmpresaModalidadeNaturezaPlanoDtInicioVigencia(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR, string CD_PLANO, DateTime DT_INIC_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxasEncargosPlanoEntidade>("SELECT * FROM CE_TAXAS_ENCARGOS_PLANO WHERE (CD_FUNDACAO = @CD_FUNDACAO)   AND (CD_EMPRESA = @CD_EMPRESA)   AND (CD_MODAL = @CD_MODAL)   AND (CD_NATUR = @CD_NATUR)   AND (CD_PLANO = @CD_PLANO)   AND (DT_INIC_VIGENCIA <= @DT_INIC_VIGENCIA)   AND (DT_TERM_VIGENCIA IS NULL OR DT_TERM_VIGENCIA = '') ORDER BY DT_INIC_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, CD_PLANO, DT_INIC_VIGENCIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxasEncargosPlanoEntidade>("SELECT * FROM CE_TAXAS_ENCARGOS_PLANO WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (CD_MODAL=:CD_MODAL) AND (CD_NATUR=:CD_NATUR) AND (CD_PLANO=:CD_PLANO) AND (DT_INIC_VIGENCIA<=:DT_INIC_VIGENCIA) AND (DT_TERM_VIGENCIA IS NULL  OR DT_TERM_VIGENCIA='') ORDER BY DT_INIC_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, CD_PLANO, DT_INIC_VIGENCIA }, Transaction).ToList();
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