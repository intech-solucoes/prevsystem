﻿#region Usings
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
    public abstract class AdesaoDAO : BaseDAO<AdesaoEntidade>
    {
        
		public virtual AdesaoEntidade BuscarPorCpf(string COD_CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoEntidade>("SELECT *  FROM WEB_ADESAO  WHERE COD_CPF = @COD_CPF", new { COD_CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoEntidade>("SELECT * FROM WEB_ADESAO WHERE COD_CPF=:COD_CPF", new { COD_CPF });
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