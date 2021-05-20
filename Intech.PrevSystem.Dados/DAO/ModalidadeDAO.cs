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
	public abstract class ModalidadeDAO : BaseDAO<ModalidadeEntidade>
	{
		public ModalidadeDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<ModalidadeEntidade> BuscarAtivas()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE SITUACAO = 'A'", new {  }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE SITUACAO='A'", new {  }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ModalidadeEntidade BuscarPorCodigo(decimal CD_MODAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE CD_MODAL = @CD_MODAL", new { CD_MODAL }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE CD_MODAL=:CD_MODAL", new { CD_MODAL }, Transaction);
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