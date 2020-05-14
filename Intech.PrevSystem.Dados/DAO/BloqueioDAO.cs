using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class BloqueioDAO : BaseDAO<BloqueioEntidade>
	{
		public virtual List<BloqueioEntidade> BuscarBloqueioEmprestimoPorCodEntid(string COD_ENTID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<BloqueioEntidade>("SELECT *   FROM CS_BLOQUEIO  INNER JOIN TB_TIPO_BLOQUEIO ON TB_TIPO_BLOQUEIO.CD_TIPO_BLOQUEIO = CS_BLOQUEIO.CD_TIPO_BLOQUEIO  WHERE TB_TIPO_BLOQUEIO.BLOQUEIO_EM = 'S'    AND CS_BLOQUEIO.COD_ENTID = @COD_ENTID", new { COD_ENTID }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<BloqueioEntidade>("SELECT * FROM CS_BLOQUEIO INNER  JOIN TB_TIPO_BLOQUEIO  ON TB_TIPO_BLOQUEIO.CD_TIPO_BLOQUEIO=CS_BLOQUEIO.CD_TIPO_BLOQUEIO WHERE TB_TIPO_BLOQUEIO.BLOQUEIO_EM='S' AND CS_BLOQUEIO.COD_ENTID=:COD_ENTID", new { COD_ENTID }).ToList();
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
