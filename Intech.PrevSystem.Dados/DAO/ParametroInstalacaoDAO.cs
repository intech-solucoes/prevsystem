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
	public abstract class ParametroInstalacaoDAO : BaseDAO<ParametroInstalacaoEntidade>
	{
		public ParametroInstalacaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual ParametroInstalacaoEntidade BuscarPorFundacao(string CD_FUNDACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ParametroInstalacaoEntidade>("SELECT * FROM   TB_PARAMETRO_INSTALACAO WHERE  CD_FUNDACAO = @CD_FUNDACAO", new { CD_FUNDACAO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ParametroInstalacaoEntidade>("SELECT * FROM TB_PARAMETRO_INSTALACAO WHERE CD_FUNDACAO=:CD_FUNDACAO", new { CD_FUNDACAO }, Transaction);
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