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
	public abstract class TempoServicoDAO : BaseDAO<TempoServicoEntidade>
	{
		public TempoServicoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<TempoServicoEntidade> BuscarPorCodEntid(int COD_ENTID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TempoServicoEntidade>("SELECT *  FROM CS_TEMPO_SERVICO WHERE COD_ENTID = @COD_ENTID   AND DT_INIC_ATIVIDADE IS NOT NULL", new { COD_ENTID }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TempoServicoEntidade>("SELECT * FROM CS_TEMPO_SERVICO WHERE COD_ENTID=:COD_ENTID AND DT_INIC_ATIVIDADE IS  NOT NULL ", new { COD_ENTID }, Transaction).ToList();
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