using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class MensagemCChequeDAO : BaseDAO<MensagemCChequeEntidade>
	{
		public virtual List<MensagemCChequeEntidade> BuscarMensagens(string CD_FUNDACAO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT *  FROM GB_MENSAGEM_CCHEQUE  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND DT_REFERENCIA = @DT_REFERENCIA    AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT * FROM GB_MENSAGEM_CCHEQUE WHERE CD_FUNDACAO=:CD_FUNDACAO AND DT_REFERENCIA=:DT_REFERENCIA AND CD_TIPO_FOLHA=:CD_TIPO_FOLHA", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<MensagemCChequeEntidade> BuscarMensagensCdRubrica(string CD_FUNDACAO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, string CD_EMPRESA, string CD_PLANO, string CD_ESPECIE, int? SEQ_RECEBEDOR, string CD_RUBRICA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT MCC.*  FROM GB_MENSAGEM_CCHEQUE MCC  INNER JOIN GB_FICHA_FINANC_ASSISTIDO FF ON FF.CD_EMPRESA = MCC.CD_EMPRESA                                         AND FF.CD_PLANO = MCC.CD_PLANO                                         AND FF.CD_ESPECIE = MCC.CD_ESPECIE                                         AND FF.CD_RUBRICA = MCC.CD_RUBRICA                                         AND FF.DT_REFERENCIA = MCC.DT_REFERENCIA                                         AND FF.CD_TIPO_FOLHA = MCC.CD_TIPO_FOLHA  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND DT_REFERENCIA = @DT_REFERENCIA    AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND CD_ESPECIE = @CD_ESPECIE    AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR, CD_RUBRICA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT MCC.* FROM GB_MENSAGEM_CCHEQUE  MCC  INNER  JOIN GB_FICHA_FINANC_ASSISTIDO   FF  ON FF.CD_EMPRESA=MCC.CD_EMPRESA AND FF.CD_PLANO=MCC.CD_PLANO AND FF.CD_ESPECIE=MCC.CD_ESPECIE AND FF.CD_RUBRICA=MCC.CD_RUBRICA AND FF.DT_REFERENCIA=MCC.DT_REFERENCIA AND FF.CD_TIPO_FOLHA=MCC.CD_TIPO_FOLHA WHERE CD_FUNDACAO=:CD_FUNDACAO AND DT_REFERENCIA=:DT_REFERENCIA AND CD_TIPO_FOLHA=:CD_TIPO_FOLHA AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND CD_ESPECIE=:CD_ESPECIE AND SEQ_RECEBEDOR=:SEQ_RECEBEDOR", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR, CD_RUBRICA }).ToList();
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
