using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class GrauInstrucaoDAO : BaseDAO<GrauInstrucaoEntidade>
	{
		public virtual List<GrauInstrucaoEntidade> ObterTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauInstrucaoEntidade>("SELECT *  FROM CS_GRAU_INSTRUCAO  ORDER BY DS_GRAU_INSTRUCAO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauInstrucaoEntidade>("SELECT * FROM CS_GRAU_INSTRUCAO ORDER BY DS_GRAU_INSTRUCAO", new {  }).ToList();
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
