﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PrestacaoParcialDAO : BaseDAO<PrestacaoParcialEntidade>
	{
		public virtual List<PrestacaoParcialEntidade> BuscarPorFundacaoAnoNumeroParcela(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO, decimal PARCELA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrestacaoParcialEntidade>("SELECT *  FROM CE_PRESTACOES_PARCIAIS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND ANO_CONTRATO = @ANO_CONTRATO    AND NUM_CONTRATO = @NUM_CONTRATO    AND PARCELA = @PARCELA", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, PARCELA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrestacaoParcialEntidade>("SELECT * FROM CE_PRESTACOES_PARCIAIS WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO AND PARCELA=:PARCELA", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, PARCELA }).ToList();
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
