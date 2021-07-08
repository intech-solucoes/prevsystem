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
	public abstract class TaxasSegurosTabeladosDAO : BaseDAO<TaxasSegurosTabeladosEntidade>
	{
		public TaxasSegurosTabeladosDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<TaxasSegurosTabeladosEntidade> BuscarPorFundacaoEmpresaPrazoDataCreditoIdade(string CD_FUNDACAO, string CD_EMPRESA, decimal PRAZO, DateTime DATA_CREDITO, int IDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxasSegurosTabeladosEntidade>("SELECT * FROM  CE_TAXAS_SEGUROS_TABELADOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA)                       FROM   CE_TAXAS_SEGUROS_TABELADOS                       WHERE  CD_FUNDACAO = @CD_FUNDACAO                               AND CD_EMPRESA = @CD_EMPRESA                               AND PRAZO = @PRAZO                               AND DT_VIGENCIA <= @DATA_CREDITO)   AND ( IDADE = @IDADE OR @IDADE IS NULL )   AND PRAZO = @PRAZO", new { CD_FUNDACAO, CD_EMPRESA, PRAZO, DATA_CREDITO, IDADE }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxasSegurosTabeladosEntidade>("SELECT * FROM CE_TAXAS_SEGUROS_TABELADOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND DT_VIGENCIA=(SELECT MAX(DT_VIGENCIA) FROM CE_TAXAS_SEGUROS_TABELADOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND PRAZO=:PRAZO AND DT_VIGENCIA<=:DATA_CREDITO) AND (IDADE=:IDADE OR :IDADE IS NULL ) AND PRAZO=:PRAZO", new { CD_FUNDACAO, CD_EMPRESA, PRAZO, DATA_CREDITO, IDADE }, Transaction).ToList();
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