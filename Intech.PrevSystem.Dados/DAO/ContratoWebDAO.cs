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
	public abstract class ContratoWebDAO : BaseDAO<ContratoWebEntidade>
	{
		public ContratoWebDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual int BuscarQuantidadeEmDeferimento(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(*) FROM CE_CONTRATOS_WEB WHERE CD_FUNDACAO = @CD_FUNDACAO   AND NUM_INSCRICAO = @NUM_INSCRICAO   AND CONTRATO_MIGRADO IN ('N', 'E')", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(*) FROM CE_CONTRATOS_WEB WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CONTRATO_MIGRADO IN ('N', 'E')", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual int BuscarUltimoNumeroContrato(string CD_FUNDACAO, int ANO_CONTRATO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT TOP 1 NUM_CONTRATO FROM CE_CONTRATOS_WEB WHERE CD_FUNDACAO = @CD_FUNDACAO   AND ANO_CONTRATO = @ANO_CONTRATO ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT NUM_CONTRATO FROM CE_CONTRATOS_WEB WHERE CD_FUNDACAO=:CD_FUNDACAO AND ANO_CONTRATO=:ANO_CONTRATO AND ROWNUM <= 1  ORDER BY NUM_CONTRATO DESC", new { CD_FUNDACAO, ANO_CONTRATO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void InserirContratoWeb(string CD_FUNDACAO, decimal ANO_CONTRATO, int NUM_CONTRATO, decimal CD_MODAL, decimal CD_NATUR, decimal CD_SITUACAO, decimal? CD_MOTIVO_QUIT, string NUM_INSCRICAO, decimal? NUM_SEQ_GR_FAMIL, decimal? SEQ_RUBRICA, decimal PRAZO, DateTime DT_SOLICITACAO, DateTime DT_CREDITO, DateTime? DT_CREDITO_AUX, DateTime? DT_QUITACAO, DateTime? DT_REF_QUITACAO, decimal? VL_SOLICITADO, decimal? VL_LIQUIDO, decimal? VL_TX_ADM, decimal? VL_TX_SEGURO, decimal? VL_TX_INAD, decimal? VL_TX_RENOVACAO, decimal? VL_IOF, decimal? VL_CORRIGIDO, decimal? VL_ANTECIPADO, decimal? VL_PRESTACAO, decimal? VL_LIMITE, decimal? VL_BASE_CALC, decimal? VL_PERC_CALC, decimal? VL_MARGEM_CONSIG, decimal? VL_REMUNERACAO, decimal? VL_DESCONTO_AUT, decimal? VL_PRINC_QUITACAO, decimal? VL_JUROS_QUITACAO, decimal? VL_PREST_ATRASO, decimal? VL_JUROS_PREST_ATRASO, decimal? VL_JUROS_MORA_PREST, decimal? VL_MULTA_PREST, decimal? TX_JUROS, decimal? TX_APLICADA, decimal? CD_REPRESENTANTE, string GEROU_CREDITO, decimal? VL_REFORMADO, decimal? VL_JUROS_PREST_MES, decimal? VL_DESCONTO_QUITACAO, decimal? VL_DEBITOS, decimal? VL_PREST_ATRASO_CONCESSAO, decimal? VL_PREST_MES_CONCESSAO, decimal? VL_PRINC_PREST_ATRASO, decimal? VL_CORR_PREST_ATRASO, string OBSERVACAO, decimal? VL_RESIDUO_AMORTIZACAO, string CD_SIT_FUNDACAO, decimal? VL_TX_INVALIDEZ, int? COD_CONVENIO, string CD_FORMA_PAGTO, decimal? VL_RESERVA_POUPANCA, DateTime? DT_PREST_ATUALIZADA, decimal? VL_CORRECAO_SALDO_QUITACAO, string NUM_BANCO, string NUM_AGENCIA, string NUM_CONTA, string CD_PLANO, decimal? CARENCIA, decimal? VL_INSS, string BLOQUEIO_COBRANCA, string IP_ORIGEM, string CONTRATO_MIGRADO, decimal? VL_MARGEN_LIVRE, decimal? ADE_NUMERO, decimal? VALOR_ECONSIG_ANT, string ALT_DADOS_BANCARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO CE_CONTRATOS_WEB (CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, CD_MODAL, CD_NATUR, CD_SITUACAO, CD_MOTIVO_QUIT, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, SEQ_RUBRICA, PRAZO, DT_SOLICITACAO, DT_CREDITO, DT_CREDITO_AUX, DT_QUITACAO, DT_REF_QUITACAO, VL_SOLICITADO, VL_LIQUIDO, VL_TX_ADM, VL_TX_SEGURO, VL_TX_INAD, VL_TX_RENOVACAO, VL_IOF, VL_CORRIGIDO, VL_ANTECIPADO, VL_PRESTACAO, VL_LIMITE, VL_BASE_CALC, VL_PERC_CALC, VL_MARGEM_CONSIG, VL_REMUNERACAO, VL_DESCONTO_AUT, VL_PRINC_QUITACAO, VL_JUROS_QUITACAO, VL_PREST_ATRASO, VL_JUROS_PREST_ATRASO, VL_JUROS_MORA_PREST, VL_MULTA_PREST, TX_JUROS, TX_APLICADA, CD_REPRESENTANTE, GEROU_CREDITO, VL_REFORMADO, VL_JUROS_PREST_MES, VL_DESCONTO_QUITACAO, VL_DEBITOS, VL_PREST_ATRASO_CONCESSAO, VL_PREST_MES_CONCESSAO, VL_PRINC_PREST_ATRASO, VL_CORR_PREST_ATRASO, OBSERVACAO, VL_RESIDUO_AMORTIZACAO, CD_SIT_FUNDACAO, VL_TX_INVALIDEZ, COD_CONVENIO, CD_FORMA_PAGTO, VL_RESERVA_POUPANCA, DT_PREST_ATUALIZADA, VL_CORRECAO_SALDO_QUITACAO, NUM_BANCO, NUM_AGENCIA, NUM_CONTA, CD_PLANO, CARENCIA, IP_ORIGEM, VL_INSS, CONTRATO_MIGRADO, VL_MARGEN_LIVRE, BLOQUEIO_COBRANCA, ADE_NUMERO, VALOR_ECONSIG_ANT, ALT_DADOS_BANCARIO) VALUES (@CD_FUNDACAO,         @ANO_CONTRATO,         @NUM_CONTRATO,         @CD_MODAL,         @CD_NATUR,         @CD_SITUACAO,         @CD_MOTIVO_QUIT,         @NUM_INSCRICAO,         @NUM_SEQ_GR_FAMIL,         @SEQ_RUBRICA,         @PRAZO,         @DT_SOLICITACAO,         @DT_CREDITO,         @DT_CREDITO_AUX,         @DT_QUITACAO,         @DT_REF_QUITACAO,         @VL_SOLICITADO,         @VL_LIQUIDO,         @VL_TX_ADM,         @VL_TX_SEGURO,         @VL_TX_INAD,         @VL_TX_RENOVACAO,         @VL_IOF,         @VL_CORRIGIDO,         @VL_ANTECIPADO,         @VL_PRESTACAO,         @VL_LIMITE,         @VL_BASE_CALC,         @VL_PERC_CALC,         @VL_MARGEM_CONSIG,         @VL_REMUNERACAO,         @VL_DESCONTO_AUT,         @VL_PRINC_QUITACAO,         @VL_JUROS_QUITACAO,         @VL_PREST_ATRASO,         @VL_JUROS_PREST_ATRASO,         @VL_JUROS_MORA_PREST,         @VL_MULTA_PREST,         @TX_JUROS,         @TX_APLICADA,         @CD_REPRESENTANTE,         @GEROU_CREDITO,         @VL_REFORMADO,         @VL_JUROS_PREST_MES,         @VL_DESCONTO_QUITACAO,         @VL_DEBITOS,         @VL_PREST_ATRASO_CONCESSAO,         @VL_PREST_MES_CONCESSAO,         @VL_PRINC_PREST_ATRASO,         @VL_CORR_PREST_ATRASO,         @OBSERVACAO,         @VL_RESIDUO_AMORTIZACAO,         @CD_SIT_FUNDACAO,         @VL_TX_INVALIDEZ,         @COD_CONVENIO,         @CD_FORMA_PAGTO,         @VL_RESERVA_POUPANCA,         @DT_PREST_ATUALIZADA,         @VL_CORRECAO_SALDO_QUITACAO,         @NUM_BANCO,         @NUM_AGENCIA,         @NUM_CONTA,         @CD_PLANO,         @CARENCIA,         @IP_ORIGEM,         @VL_INSS,         @CONTRATO_MIGRADO,         @VL_MARGEN_LIVRE,         @BLOQUEIO_COBRANCA,         @ADE_NUMERO,         @VALOR_ECONSIG_ANT,         @ALT_DADOS_BANCARIO)", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, CD_MODAL, CD_NATUR, CD_SITUACAO, CD_MOTIVO_QUIT, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, SEQ_RUBRICA, PRAZO, DT_SOLICITACAO, DT_CREDITO, DT_CREDITO_AUX, DT_QUITACAO, DT_REF_QUITACAO, VL_SOLICITADO, VL_LIQUIDO, VL_TX_ADM, VL_TX_SEGURO, VL_TX_INAD, VL_TX_RENOVACAO, VL_IOF, VL_CORRIGIDO, VL_ANTECIPADO, VL_PRESTACAO, VL_LIMITE, VL_BASE_CALC, VL_PERC_CALC, VL_MARGEM_CONSIG, VL_REMUNERACAO, VL_DESCONTO_AUT, VL_PRINC_QUITACAO, VL_JUROS_QUITACAO, VL_PREST_ATRASO, VL_JUROS_PREST_ATRASO, VL_JUROS_MORA_PREST, VL_MULTA_PREST, TX_JUROS, TX_APLICADA, CD_REPRESENTANTE, GEROU_CREDITO, VL_REFORMADO, VL_JUROS_PREST_MES, VL_DESCONTO_QUITACAO, VL_DEBITOS, VL_PREST_ATRASO_CONCESSAO, VL_PREST_MES_CONCESSAO, VL_PRINC_PREST_ATRASO, VL_CORR_PREST_ATRASO, OBSERVACAO, VL_RESIDUO_AMORTIZACAO, CD_SIT_FUNDACAO, VL_TX_INVALIDEZ, COD_CONVENIO, CD_FORMA_PAGTO, VL_RESERVA_POUPANCA, DT_PREST_ATUALIZADA, VL_CORRECAO_SALDO_QUITACAO, NUM_BANCO, NUM_AGENCIA, NUM_CONTA, CD_PLANO, CARENCIA, VL_INSS, BLOQUEIO_COBRANCA, IP_ORIGEM, CONTRATO_MIGRADO, VL_MARGEN_LIVRE, ADE_NUMERO, VALOR_ECONSIG_ANT, ALT_DADOS_BANCARIO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO CE_CONTRATOS_WEB (CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, CD_MODAL, CD_NATUR, CD_SITUACAO, CD_MOTIVO_QUIT, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, SEQ_RUBRICA, PRAZO, DT_SOLICITACAO, DT_CREDITO, DT_CREDITO_AUX, DT_QUITACAO, DT_REF_QUITACAO, VL_SOLICITADO, VL_LIQUIDO, VL_TX_ADM, VL_TX_SEGURO, VL_TX_INAD, VL_TX_RENOVACAO, VL_IOF, VL_CORRIGIDO, VL_ANTECIPADO, VL_PRESTACAO, VL_LIMITE, VL_BASE_CALC, VL_PERC_CALC, VL_MARGEM_CONSIG, VL_REMUNERACAO, VL_DESCONTO_AUT, VL_PRINC_QUITACAO, VL_JUROS_QUITACAO, VL_PREST_ATRASO, VL_JUROS_PREST_ATRASO, VL_JUROS_MORA_PREST, VL_MULTA_PREST, TX_JUROS, TX_APLICADA, CD_REPRESENTANTE, GEROU_CREDITO, VL_REFORMADO, VL_JUROS_PREST_MES, VL_DESCONTO_QUITACAO, VL_DEBITOS, VL_PREST_ATRASO_CONCESSAO, VL_PREST_MES_CONCESSAO, VL_PRINC_PREST_ATRASO, VL_CORR_PREST_ATRASO, OBSERVACAO, VL_RESIDUO_AMORTIZACAO, CD_SIT_FUNDACAO, VL_TX_INVALIDEZ, COD_CONVENIO, CD_FORMA_PAGTO, VL_RESERVA_POUPANCA, DT_PREST_ATUALIZADA, VL_CORRECAO_SALDO_QUITACAO, NUM_BANCO, NUM_AGENCIA, NUM_CONTA, CD_PLANO, CARENCIA, IP_ORIGEM, VL_INSS, CONTRATO_MIGRADO, VL_MARGEN_LIVRE, BLOQUEIO_COBRANCA, ADE_NUMERO, VALOR_ECONSIG_ANT, ALT_DADOS_BANCARIO) VALUES (:CD_FUNDACAO, :ANO_CONTRATO, :NUM_CONTRATO, :CD_MODAL, :CD_NATUR, :CD_SITUACAO, :CD_MOTIVO_QUIT, :NUM_INSCRICAO, :NUM_SEQ_GR_FAMIL, :SEQ_RUBRICA, :PRAZO, :DT_SOLICITACAO, :DT_CREDITO, :DT_CREDITO_AUX, :DT_QUITACAO, :DT_REF_QUITACAO, :VL_SOLICITADO, :VL_LIQUIDO, :VL_TX_ADM, :VL_TX_SEGURO, :VL_TX_INAD, :VL_TX_RENOVACAO, :VL_IOF, :VL_CORRIGIDO, :VL_ANTECIPADO, :VL_PRESTACAO, :VL_LIMITE, :VL_BASE_CALC, :VL_PERC_CALC, :VL_MARGEM_CONSIG, :VL_REMUNERACAO, :VL_DESCONTO_AUT, :VL_PRINC_QUITACAO, :VL_JUROS_QUITACAO, :VL_PREST_ATRASO, :VL_JUROS_PREST_ATRASO, :VL_JUROS_MORA_PREST, :VL_MULTA_PREST, :TX_JUROS, :TX_APLICADA, :CD_REPRESENTANTE, :GEROU_CREDITO, :VL_REFORMADO, :VL_JUROS_PREST_MES, :VL_DESCONTO_QUITACAO, :VL_DEBITOS, :VL_PREST_ATRASO_CONCESSAO, :VL_PREST_MES_CONCESSAO, :VL_PRINC_PREST_ATRASO, :VL_CORR_PREST_ATRASO, :OBSERVACAO, :VL_RESIDUO_AMORTIZACAO, :CD_SIT_FUNDACAO, :VL_TX_INVALIDEZ, :COD_CONVENIO, :CD_FORMA_PAGTO, :VL_RESERVA_POUPANCA, :DT_PREST_ATUALIZADA, :VL_CORRECAO_SALDO_QUITACAO, :NUM_BANCO, :NUM_AGENCIA, :NUM_CONTA, :CD_PLANO, :CARENCIA, :IP_ORIGEM, :VL_INSS, :CONTRATO_MIGRADO, :VL_MARGEN_LIVRE, :BLOQUEIO_COBRANCA, :ADE_NUMERO, :VALOR_ECONSIG_ANT, :ALT_DADOS_BANCARIO)", new { CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO, CD_MODAL, CD_NATUR, CD_SITUACAO, CD_MOTIVO_QUIT, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL, SEQ_RUBRICA, PRAZO, DT_SOLICITACAO, DT_CREDITO, DT_CREDITO_AUX, DT_QUITACAO, DT_REF_QUITACAO, VL_SOLICITADO, VL_LIQUIDO, VL_TX_ADM, VL_TX_SEGURO, VL_TX_INAD, VL_TX_RENOVACAO, VL_IOF, VL_CORRIGIDO, VL_ANTECIPADO, VL_PRESTACAO, VL_LIMITE, VL_BASE_CALC, VL_PERC_CALC, VL_MARGEM_CONSIG, VL_REMUNERACAO, VL_DESCONTO_AUT, VL_PRINC_QUITACAO, VL_JUROS_QUITACAO, VL_PREST_ATRASO, VL_JUROS_PREST_ATRASO, VL_JUROS_MORA_PREST, VL_MULTA_PREST, TX_JUROS, TX_APLICADA, CD_REPRESENTANTE, GEROU_CREDITO, VL_REFORMADO, VL_JUROS_PREST_MES, VL_DESCONTO_QUITACAO, VL_DEBITOS, VL_PREST_ATRASO_CONCESSAO, VL_PREST_MES_CONCESSAO, VL_PRINC_PREST_ATRASO, VL_CORR_PREST_ATRASO, OBSERVACAO, VL_RESIDUO_AMORTIZACAO, CD_SIT_FUNDACAO, VL_TX_INVALIDEZ, COD_CONVENIO, CD_FORMA_PAGTO, VL_RESERVA_POUPANCA, DT_PREST_ATUALIZADA, VL_CORRECAO_SALDO_QUITACAO, NUM_BANCO, NUM_AGENCIA, NUM_CONTA, CD_PLANO, CARENCIA, VL_INSS, BLOQUEIO_COBRANCA, IP_ORIGEM, CONTRATO_MIGRADO, VL_MARGEN_LIVRE, ADE_NUMERO, VALOR_ECONSIG_ANT, ALT_DADOS_BANCARIO });
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