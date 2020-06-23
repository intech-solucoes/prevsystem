﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebRecadDepedenteIRDAO : BaseDAO<WebRecadDepedenteIREntidade>
	{
		public virtual long Insert( decimal OID_RECAD_DADOS,  decimal NUM_SEQ_DEP,  string NOM_DEPENDENTE,  string COD_GRAU_PARENTESCO,  string DES_GRAU_PARENTESCO,  DateTime DTA_NASCIMENTO,  DateTime DTA_INICIO_IRRF,  DateTime DTA_TERMINO_IRRF,  string COD_SEXO,  string DES_SEXO,  string COD_CPF,  string IND_OPERACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DEPENDENTE_IR(  	OID_RECAD_DADOS,      NUM_SEQ_DEP,      NOM_DEPENDENTE,      COD_GRAU_PARENTESCO,      DES_GRAU_PARENTESCO,      DTA_NASCIMENTO,      DTA_INICIO_IRRF,      DTA_TERMINO_IRRF,      COD_SEXO,      DES_SEXO,      COD_CPF,      IND_OPERACAO  )  VALUES(      @OID_RECAD_DADOS,      @NUM_SEQ_DEP,      @NOM_DEPENDENTE,      @COD_GRAU_PARENTESCO,      @DES_GRAU_PARENTESCO,      @DTA_NASCIMENTO,      @DTA_INICIO_IRRF,      @DTA_TERMINO_IRRF,      @COD_SEXO,      @DES_SEXO,      @COD_CPF,      @IND_OPERACAO  )", new { OID_RECAD_DADOS, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, DTA_INICIO_IRRF, DTA_TERMINO_IRRF, COD_SEXO, DES_SEXO, COD_CPF, IND_OPERACAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DEPENDENTE_IR (OID_RECAD_DEPENDENTE_IR,OID_RECAD_DADOS, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, DTA_INICIO_IRRF, DTA_TERMINO_IRRF, COD_SEXO, DES_SEXO, COD_CPF, IND_OPERACAO) VALUES (S_WEB_RECAD_DEPENDENTE_IR.NEXTVAL,:OID_RECAD_DADOS, :NUM_SEQ_DEP, :NOM_DEPENDENTE, :COD_GRAU_PARENTESCO, :DES_GRAU_PARENTESCO, :DTA_NASCIMENTO, :DTA_INICIO_IRRF, :DTA_TERMINO_IRRF, :COD_SEXO, :DES_SEXO, :COD_CPF, :IND_OPERACAO)", new { OID_RECAD_DADOS, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, DTA_INICIO_IRRF, DTA_TERMINO_IRRF, COD_SEXO, DES_SEXO, COD_CPF, IND_OPERACAO });
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
