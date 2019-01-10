#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class TaxaConcessaoPlanoDAO : BaseDAO<TaxaConcessaoPlanoEntidade>
    {
        
		public virtual IEnumerable<TaxaConcessaoPlanoEntidade> BuscarPorFundacaoEmpresaModalidadeNatureza(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxaConcessaoPlanoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO_PLANO WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_MODAL = @CD_MODAL   AND CD_NATUR = @CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxaConcessaoPlanoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO_PLANO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_MODAL=:CD_MODAL AND CD_NATUR=:CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<TaxaConcessaoPlanoEntidade> BuscarPorFundacaoEmpresaModalidadeNaturezaPlano(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR, string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxaConcessaoPlanoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO_PLANO WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_MODAL = @CD_MODAL   AND CD_NATUR = @CD_NATUR   AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxaConcessaoPlanoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO_PLANO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_MODAL=:CD_MODAL AND CD_NATUR=:CD_NATUR AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, CD_PLANO });
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
