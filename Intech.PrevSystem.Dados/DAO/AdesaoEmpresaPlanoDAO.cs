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
    public abstract class AdesaoEmpresaPlanoDAO : BaseDAO<AdesaoEmpresaPlanoEntidade>
    {
        
		public virtual IEnumerable<AdesaoEmpresaPlanoEntidade> BuscarPorEmpresa(string CD_EMPRESA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<AdesaoEmpresaPlanoEntidade>("SELECT *   FROM WEB_ADESAO_EMPRESA_PLANO  WHERE CD_EMPRESA = @CD_EMPRESA", new { CD_EMPRESA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<AdesaoEmpresaPlanoEntidade>("SELECT * FROM WEB_ADESAO_EMPRESA_PLANO WHERE CD_EMPRESA=:CD_EMPRESA", new { CD_EMPRESA });
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
