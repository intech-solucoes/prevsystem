﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class ComposicaoSRCDAO : BaseDAO<ComposicaoSRCEntidade>
	{
		public virtual List<ComposicaoSRCEntidade> BuscarePorFundacaoEmpresaPlano(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ComposicaoSRCEntidade>("SELECT *   FROM GB_COMP_SRC  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ComposicaoSRCEntidade>("SELECT * FROM GB_COMP_SRC WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO }).ToList();
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
