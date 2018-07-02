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
    public abstract class ModalidadeDAO : BaseDAO<ModalidadeEntidade>
    {
		public virtual ModalidadeEntidade BuscarPorCodigo(decimal CD_MODAL)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE CD_MODAL = @CD_MODAL", new { CD_MODAL });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<ModalidadeEntidade>("SELECT * FROM CE_MODALIDADE WHERE CD_MODAL=:CD_MODAL", new { CD_MODAL });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
