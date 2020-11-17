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
	public abstract class BoletoAvulsoDAO : BaseDAO<BoletoAvulsoEntidade>
	{
		public BoletoAvulsoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual void Insert(string CPF, string MATRICULA, string NOME, string CD_PLANO, DateTime DT_EMISSAO, decimal VALOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO TBG_BOLETO_AVULSO (       CPF      ,MATRICULA      ,NOME      ,CD_PLANO      ,DT_EMISSAO      ,VALOR  )  VALUES (       @CPF      ,@MATRICULA      ,@NOME      ,@CD_PLANO      ,@DT_EMISSAO      ,@VALOR  )", new { CPF, MATRICULA, NOME, CD_PLANO, DT_EMISSAO, VALOR });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO TBG_BOLETO_AVULSO (OID_BOLETO_AVULSO, CPF, MATRICULA, NOME, CD_PLANO, DT_EMISSAO, VALOR)   VALUES (S_TBG_BOLETO_AVULSO.NEXTVAL, :CPF, :MATRICULA, :NOME, :CD_PLANO, :DT_EMISSAO, :VALOR)", new { CPF, MATRICULA, NOME, CD_PLANO, DT_EMISSAO, VALOR });
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
