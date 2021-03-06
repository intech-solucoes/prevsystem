﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class GrauParentescoDAO : BaseDAO<GrauParentescoEntidade>
	{
		public GrauParentescoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<GrauParentescoEntidade> BuscarOrderAlfabetica()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT *   FROM TB_GRAU_PARENTESCO  ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<GrauParentescoEntidade> BuscarOrderAlfabeticaComTipoHerdeiro()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT *   FROM TB_GRAU_PARENTESCO  WHERE TIPO_HERDEIRO IS NOT NULL  ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO WHERE TIPO_HERDEIRO IS  NOT NULL  ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual GrauParentescoEntidade BuscarPorCodigo(string CD_GRAU_PARENTESCO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT *  FROM TB_GRAU_PARENTESCO  WHERE CD_GRAU_PARENTESCO = @CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO WHERE CD_GRAU_PARENTESCO=:CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<GrauParentescoEntidade> ObterTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT CD_GRAU_PARENTESCO, DS_GRAU_PARENTESCO  FROM TB_GRAU_PARENTESCO  ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT CD_GRAU_PARENTESCO, DS_GRAU_PARENTESCO FROM TB_GRAU_PARENTESCO ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
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
