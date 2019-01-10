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
    public abstract class TaxasConcessaoDAO : BaseDAO<TaxasConcessaoEntidade>
    {
        
		public virtual IEnumerable<TaxasConcessaoEntidade> BuscarPorFundacaoEmpresaSeqModalNatur(string CD_FUNDACAO, string CD_EMPRESA, decimal SEQUENCIA, decimal CD_MODAL, decimal CD_NATUR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxasConcessaoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND SEQUENCIA = @SEQUENCIA   AND CD_MODAL = @CD_MODAL   AND CD_NATUR = @CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, SEQUENCIA, CD_MODAL, CD_NATUR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxasConcessaoEntidade>("SELECT * FROM CE_TAXAS_CONCESSAO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND SEQUENCIA=:SEQUENCIA AND CD_MODAL=:CD_MODAL AND CD_NATUR=:CD_NATUR", new { CD_FUNDACAO, CD_EMPRESA, SEQUENCIA, CD_MODAL, CD_NATUR });
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
