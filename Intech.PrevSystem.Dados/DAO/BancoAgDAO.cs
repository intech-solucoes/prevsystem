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
	public abstract class BancoAgDAO : BaseDAO<BancoAgEntidade>
	{
		public BancoAgDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<BancoAgEntidade> BuscarAgenciasCodBanco(string COD_BANCO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT *  FROM  TB_BANCO_AG  WHERE COD_BANCO = @COD_BANCO    AND COD_AGENC <> '00000'", new { COD_BANCO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT * FROM TB_BANCO_AG WHERE COD_BANCO=:COD_BANCO AND COD_AGENC<>'00000'", new { COD_BANCO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<BancoAgEntidade> BuscarBancos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT DISTINCT COD_BANCO, DESC_BCO_AG  FROM TB_BANCO_AG  WHERE COD_AGENC = '00000'  ORDER BY COD_BANCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT DISTINCT COD_BANCO, DESC_BCO_AG FROM TB_BANCO_AG WHERE COD_AGENC='00000' ORDER BY COD_BANCO", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<BancoAgEntidade> BuscarBancosConcat()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT COD_BANCO, ('' + COD_BANCO + ' - ' + DESC_BCO_AG) AS DESC_BCO_AG  FROM TB_BANCO_AG  WHERE COD_AGENC = '00000'  ORDER BY COD_BANCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BancoAgEntidade>("SELECT COD_BANCO, ('' || COD_BANCO || ' - ' || DESC_BCO_AG) AS DESC_BCO_AG FROM TB_BANCO_AG WHERE COD_AGENC='00000' ORDER BY COD_BANCO", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual BancoAgEntidade BuscarPorCodBancoCodAgencia(string COD_BANCO, string COD_AGENC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<BancoAgEntidade>("SELECT *  FROM  TB_BANCO_AG  WHERE COD_BANCO = @COD_BANCO    AND COD_AGENC = @COD_AGENC", new { COD_BANCO, COD_AGENC });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<BancoAgEntidade>("SELECT * FROM TB_BANCO_AG WHERE COD_BANCO=:COD_BANCO AND COD_AGENC=:COD_AGENC", new { COD_BANCO, COD_AGENC });
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
