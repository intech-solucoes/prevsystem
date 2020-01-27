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
    public abstract class MensagemCChequeDAO : BaseDAO<MensagemCChequeEntidade>
    {
        
		public virtual IEnumerable<MensagemCChequeEntidade> BuscarMensagens(string CD_FUNDACAO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, string CD_EMPRESA, string CD_PLANO, string CD_ESPECIE, int? SEQ_RECEBEDOR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT *  FROM GB_MENSAGEM_CCHEQUE  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND DT_REFERENCIA = @DT_REFERENCIA    AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND CD_ESPECIE = @CD_ESPECIE    AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<MensagemCChequeEntidade>("SELECT * FROM GB_MENSAGEM_CCHEQUE WHERE CD_FUNDACAO=:CD_FUNDACAO AND DT_REFERENCIA=:DT_REFERENCIA AND CD_TIPO_FOLHA=:CD_TIPO_FOLHA AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND CD_ESPECIE=:CD_ESPECIE AND SEQ_RECEBEDOR=:SEQ_RECEBEDOR", new { CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR });
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
