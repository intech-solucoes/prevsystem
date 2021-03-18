﻿/*Config
    Retorno
        -void
    Parametros
		-CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
        -SEQUENCIA:decimal
        -ANO_CONTRATO_ANT:decimal
        -NUM_CONTRATO_ANT:decimal
        -VL_PRINC_QUITACAO:decimal
        -VL_JUROS_QUITACAO:decimal
        -VL_PREST_ATRASO:decimal
        -VL_CORR_PREST_ATRASO:decimal
        -VL_PRINC_PREST_ATRASO:decimal
        -VL_JUROS_PREST_ATRASO:decimal
        -VL_JUROS_MORA_PREST:decimal
        -VL_MULTA_PREST:decimal
        -VL_REFORMADO:decimal
        -VL_JUROS_PREST_MES:decimal
        -VL_PREST_MES:decimal
        -VL_CORRECAO_SALDO_QUITACAO:decimal
        -VL_DESCONTO_QUITACAO:decimal
        -VL_PRINC_PREST_MES:decimal
        -VL_SEGURO_QUIT:decimal
        -VL_SEGURO_PRORATA:decimal
        -VL_ADM_PRORATA:decimal
        -VL_CORR_PRINC_PREST_MES:decimal
        -VL_CORR_JUROS_PREST_MES:decimal
        -VL_TX_ADM_MES_QUIT:decimal
        -VL_IOF_COMPL_QUIT:decimal
*/

INSERT INTO CE_CONTRATOS_ANTERIORES
            (CD_FUNDACAO,
             ANO_CONTRATO,
             NUM_CONTRATO,
             SEQUENCIA,
             ANO_CONTRATO_ANT,
             NUM_CONTRATO_ANT,
             VL_PRINC_QUITACAO,
             VL_JUROS_QUITACAO,
             VL_PREST_ATRASO,
             VL_CORR_PREST_ATRASO,
             VL_PRINC_PREST_ATRASO,
             VL_JUROS_PREST_ATRASO,
             VL_JUROS_MORA_PREST,
             VL_MULTA_PREST,
             VL_REFORMADO,
             VL_JUROS_PREST_MES,
             VL_PREST_MES,
             VL_CORRECAO_SALDO_QUITACAO,
             VL_DESCONTO_QUITACAO,
             VL_PRINC_PREST_MES,
             VL_SEGURO_QUIT,
             VL_SEGURO_PRORATA,
             VL_ADM_PRORATA,
             VL_CORR_PRINC_PREST_MES,
             VL_CORR_JUROS_PREST_MES,
             VL_TX_ADM_MES_QUIT,
             VL_IOF_COMPL_QUIT)
VALUES      (@CD_FUNDACAO,
             @ANO_CONTRATO,
             @NUM_CONTRATO,
             @SEQUENCIA,
             @ANO_CONTRATO_ANT,
             @NUM_CONTRATO_ANT,
             @VL_PRINC_QUITACAO,
             @VL_JUROS_QUITACAO,
             @VL_PREST_ATRASO,
             @VL_CORR_PREST_ATRASO,
             @VL_PRINC_PREST_ATRASO,
             @VL_JUROS_PREST_ATRASO,
             @VL_JUROS_MORA_PREST,
             @VL_MULTA_PREST,
             @VL_REFORMADO,
             @VL_JUROS_PREST_MES,
             @VL_PREST_MES,
             @VL_CORRECAO_SALDO_QUITACAO,
             @VL_DESCONTO_QUITACAO,
             @VL_PRINC_PREST_MES,
             @VL_SEGURO_QUIT,
             @VL_SEGURO_PRORATA,
             @VL_ADM_PRORATA,
             @VL_CORR_PRINC_PREST_MES,
             @VL_CORR_JUROS_PREST_MES,
             @VL_TX_ADM_MES_QUIT,
             @VL_IOF_COMPL_QUIT) 