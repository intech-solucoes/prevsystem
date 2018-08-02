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
    public abstract class FundacaoDAO : BaseDAO<FundacaoEntidade>
    {
        
		public virtual FundacaoEntidade BuscarPorCodigo(string CD_FUNDACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FundacaoEntidade>("SELECT TB_FUNDACAO.*,     EE_ENTIDADE.NOME_ENTID,     EE_ENTIDADE.END_ENTID,     EE_ENTIDADE.BAIRRO_ENTID,     EE_ENTIDADE.CEP_ENTID,     EE_ENTIDADE.UF_ENTID,     EE_ENTIDADE.FONE_ENTID,     EE_ENTIDADE.FAX_ENTID,     EE_ENTIDADE.CPF_CGC FROM TB_FUNDACAO INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = TB_FUNDACAO.COD_ENTID WHERE CD_FUNDACAO = @CD_FUNDACAO", new { CD_FUNDACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FundacaoEntidade>("SELECT TB_FUNDACAO.*, EE_ENTIDADE.NOME_ENTID, EE_ENTIDADE.END_ENTID, EE_ENTIDADE.BAIRRO_ENTID, EE_ENTIDADE.CEP_ENTID, EE_ENTIDADE.UF_ENTID, EE_ENTIDADE.FONE_ENTID, EE_ENTIDADE.FAX_ENTID, EE_ENTIDADE.CPF_CGC FROM TB_FUNDACAO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=TB_FUNDACAO.COD_ENTID WHERE CD_FUNDACAO=:CD_FUNDACAO", new { CD_FUNDACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}
		public virtual IEnumerable<FundacaoEntidade> BuscarTodas()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FundacaoEntidade>("SELECT  	ENT.NOME_ENTID, 	TB_FUNDACAO.* FROM TB_FUNDACAO INNER JOIN EE_ENTIDADE ENT ON ENT.COD_ENTID = TB_FUNDACAO.COD_ENTID", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FundacaoEntidade>("SELECT ENT.NOME_ENTID, TB_FUNDACAO.* FROM TB_FUNDACAO INNER  JOIN EE_ENTIDADE   ENT  ON ENT.COD_ENTID=TB_FUNDACAO.COD_ENTID", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
