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
    public abstract class WebRecadBeneficiarioDAO : BaseDAO<WebRecadBeneficiarioEntidade>
    {
        
		public virtual long Insert( decimal OID_RECAD_DADOS,  string COD_PLANO,  decimal NUM_SEQ_DEP,  string NOM_DEPENDENTE,  string COD_GRAU_PARENTESCO,  string DES_GRAU_PARENTESCO,  DateTime DTA_NASCIMENTO,  string COD_SEXO,  string DES_SEXO,  string COD_CPF,  decimal COD_PERC_RATEIO,  string IND_OPERACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_BENEFICIARIO(  	OID_RECAD_DADOS,      COD_PLANO,      NUM_SEQ_DEP,      NOM_DEPENDENTE,      COD_GRAU_PARENTESCO,      DES_GRAU_PARENTESCO,      DTA_NASCIMENTO,      COD_SEXO,      DES_SEXO,      COD_CPF,      COD_PERC_RATEIO,      IND_OPERACAO  )  VALUES(      @OID_RECAD_DADOS,      @COD_PLANO,      @NUM_SEQ_DEP,      @NOM_DEPENDENTE,      @COD_GRAU_PARENTESCO,      @DES_GRAU_PARENTESCO,      @DTA_NASCIMENTO,      @COD_SEXO,      @DES_SEXO,      @COD_CPF,      @COD_PERC_RATEIO,      @IND_OPERACAO  )", new { OID_RECAD_DADOS, COD_PLANO, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, COD_SEXO, DES_SEXO, COD_CPF, COD_PERC_RATEIO, IND_OPERACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_BENEFICIARIO (OID_RECAD_BENEFICIARIO,OID_RECAD_DADOS, COD_PLANO, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, COD_SEXO, DES_SEXO, COD_CPF, COD_PERC_RATEIO, IND_OPERACAO) VALUES (S_WEB_RECAD_BENEFICIARIO.NEXTVAL,:OID_RECAD_DADOS, :COD_PLANO, :NUM_SEQ_DEP, :NOM_DEPENDENTE, :COD_GRAU_PARENTESCO, :DES_GRAU_PARENTESCO, :DTA_NASCIMENTO, :COD_SEXO, :DES_SEXO, :COD_CPF, :COD_PERC_RATEIO, :IND_OPERACAO)", new { OID_RECAD_DADOS, COD_PLANO, NUM_SEQ_DEP, NOM_DEPENDENTE, COD_GRAU_PARENTESCO, DES_GRAU_PARENTESCO, DTA_NASCIMENTO, COD_SEXO, DES_SEXO, COD_CPF, COD_PERC_RATEIO, IND_OPERACAO });
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
