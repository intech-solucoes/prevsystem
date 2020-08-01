using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebFatorAtuarialDAO : BaseDAO<WebFatorAtuarialEntidade>
	{
		public virtual WebFatorAtuarialEntidade BuscarPorCodTabelaSexoIdadeDataAtual(string COD_TABELA, string SEXO, string IDADE, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebFatorAtuarialEntidade>("SELECT *   FROM WEB_FATOR_ATUARIAL  WHERE COD_TABELA = @COD_TABELA    AND IND_SEXO = @SEXO    AND NUM_IDADE_ANOS = @IDADE    AND DTA_INICIO_VALIDADE = (SELECT MAX(FAT2.DTA_INICIO_VALIDADE)                                 FROM WEB_FATOR_ATUARIAL FAT2                                WHERE FAT2.COD_TABELA = @COD_TABELA                                  AND DTA_INICIO_VALIDADE <= @DATA_ATUAL)", new { COD_TABELA, SEXO, IDADE, DATA_ATUAL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebFatorAtuarialEntidade>("SELECT * FROM WEB_FATOR_ATUARIAL WHERE COD_TABELA=:COD_TABELA AND IND_SEXO=:SEXO AND NUM_IDADE_ANOS=:IDADE AND DTA_INICIO_VALIDADE=(SELECT MAX(FAT2.DTA_INICIO_VALIDADE) FROM WEB_FATOR_ATUARIAL  FAT2  WHERE FAT2.COD_TABELA=:COD_TABELA AND DTA_INICIO_VALIDADE<=:DATA_ATUAL)", new { COD_TABELA, SEXO, IDADE, DATA_ATUAL });
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
