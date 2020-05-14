using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class RubricasPrevidencialDAO : BaseDAO<RubricasPrevidencialEntidade>
	{
		public virtual List<RubricasPrevidencialEntidade> BuscarIncideLiquido(string INCID_LIQUIDO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT *  FROM GB_RUBRICAS_PREVIDENCIAL  WHERE INCID_LIQUIDO = @INCID_LIQUIDO", new { INCID_LIQUIDO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT * FROM GB_RUBRICAS_PREVIDENCIAL WHERE INCID_LIQUIDO=:INCID_LIQUIDO", new { INCID_LIQUIDO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<RubricasPrevidencialEntidade> BuscarIncideLiquidoMargemConsig(string INCID_LIQUIDO, string INCID_MARGEM_CONSIG)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT *  FROM GB_RUBRICAS_PREVIDENCIAL  WHERE INCID_LIQUIDO = @INCID_LIQUIDO    AND INCID_MARGEM_CONSIG = @INCID_MARGEM_CONSIG", new { INCID_LIQUIDO, INCID_MARGEM_CONSIG }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT * FROM GB_RUBRICAS_PREVIDENCIAL WHERE INCID_LIQUIDO=:INCID_LIQUIDO AND INCID_MARGEM_CONSIG=:INCID_MARGEM_CONSIG", new { INCID_LIQUIDO, INCID_MARGEM_CONSIG }).ToList();
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
