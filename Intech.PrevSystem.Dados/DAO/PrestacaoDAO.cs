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
    public abstract class PrestacaoDAO : BaseDAO<PrestacaoEntidade>
    {
		public virtual IEnumerable<PrestacaoEntidade> BuscarPorFundacaoContrato(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO   AND NUM_CONTRATO = @NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<PrestacaoEntidade>("SELECT * FROM CE_PRESTACOES WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND NUM_CONTRATO=:NUM_CONTRATO ORDER BY SEQ_PREST", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
