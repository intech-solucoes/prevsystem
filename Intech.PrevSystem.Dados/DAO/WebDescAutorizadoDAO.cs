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
	public abstract class WebDescAutorizadoDAO : BaseDAO<WebDescAutorizadoEntidade>
	{
		public WebDescAutorizadoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<WebDescAutorizadoEntidade> BuscarPorEmpresaPlanoIndAtivo(string CD_EMPRESA, string CD_PLANO, string IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebDescAutorizadoEntidade>("SELECT DA.*  FROM WEB_DESC_AUTORIZADO DA     INNER JOIN WEB_DESC_AUTORIZADO_EM_PL EP ON EP.OID_DESC_AUTORIZADO = DA.OID_DESC_AUTORIZADO WHERE EP.CD_EMPRESA = @CD_EMPRESA   AND EP.CD_PLANO = @CD_PLANO   AND IND_ATIVO = @IND_ATIVO ORDER BY NUM_ORDEM", new { CD_EMPRESA, CD_PLANO, IND_ATIVO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebDescAutorizadoEntidade>("SELECT DA.* FROM WEB_DESC_AUTORIZADO  DA  INNER  JOIN WEB_DESC_AUTORIZADO_EM_PL   EP  ON EP.OID_DESC_AUTORIZADO=DA.OID_DESC_AUTORIZADO WHERE EP.CD_EMPRESA=:CD_EMPRESA AND EP.CD_PLANO=:CD_PLANO AND IND_ATIVO=:IND_ATIVO ORDER BY NUM_ORDEM", new { CD_EMPRESA, CD_PLANO, IND_ATIVO }, Transaction).ToList();
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