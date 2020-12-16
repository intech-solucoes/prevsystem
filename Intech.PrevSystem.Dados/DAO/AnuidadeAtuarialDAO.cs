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
	public abstract class AnuidadeAtuarialDAO : BaseDAO<AnuidadeAtuarialEntidade>
	{
		public AnuidadeAtuarialDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual AnuidadeAtuarialEntidade BuscarPorTipoSexoIdade(string TIPO, string SEXO, int IDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<AnuidadeAtuarialEntidade>("SELECT *   FROM TB_ANUIDADE_ATUARIAL    WHERE TIPO = @TIPO     AND SEXO  = @SEXO     AND IDADE = @IDADE     AND DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA)                          FROM TB_ANUIDADE_ATUARIAL                          WHERE TIPO = @TIPO                           AND SEXO  = @SEXO                           AND IDADE = @IDADE)", new { TIPO, SEXO, IDADE });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<AnuidadeAtuarialEntidade>("SELECT * FROM TB_ANUIDADE_ATUARIAL WHERE TIPO=:TIPO AND SEXO=:SEXO AND IDADE=:IDADE AND DT_VIGENCIA=(SELECT MAX(DT_VIGENCIA) FROM TB_ANUIDADE_ATUARIAL WHERE TIPO=:TIPO AND SEXO=:SEXO AND IDADE=:IDADE)", new { TIPO, SEXO, IDADE });
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
