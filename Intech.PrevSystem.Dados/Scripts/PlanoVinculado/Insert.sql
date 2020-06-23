﻿/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
        -DT_INSC_PLANO:DateTime
        -CD_SIT_PLANO:string
        -DT_SITUACAO_ATUAL:DateTime
        -CD_MOTIVO_DESLIG:string
        -DT_DESLIG_PLANO:DateTime?
        -FUNDADOR:string
        -PERC_TAXA_MAXIMA:decimal?
        -GRUPO:string
        -DT_PRIMEIRA_CONTRIB:DateTime?
        -DT_VENC_CARENCIA:DateTime?
        -CD_SIT_INSCRICAO:string
        -TIPO_IRRF:string
        -IDADE_RECEB_BENEF:decimal?
        -CD_TIPO_COBRANCA:string
        -NUM_BANCO:string
        -NUM_AGENCIA:string
        -NUM_CONTA:string
        -DIA_VENC:decimal?
        -CD_GRUPO:string
        -CD_PERFIL_INVEST:decimal?
        -NUM_PROTOCOLO:string
        -VITALICIO:string
        -VL_PERC_VITALICIO:decimal?
        -LEI_108:string
        -SALDO_PROJ:decimal?
        -PECULIO_INV:decimal?
        -PECULIO_MORTE:decimal?
        -INTEGRALIZA_SALDO:string
        -CK_EXTRATO_CST:string
        -DT_EMISSAO_CERTIFICADO:DateTime?
        -TIPO_IRRF_CANC:string
        -IND_OPTANTE_MAXIMA_BASICA:string
        -IND_AFA_JUDICIAL:string
*/

INSERT INTO CS_PLANOS_VINC
(
     CD_FUNDACAO
    ,NUM_INSCRICAO
    ,CD_PLANO
    ,DT_INSC_PLANO
    ,CD_SIT_PLANO
    ,DT_SITUACAO_ATUAL
    ,CD_MOTIVO_DESLIG
    ,DT_DESLIG_PLANO
    ,FUNDADOR
    ,PERC_TAXA_MAXIMA
    ,GRUPO
    ,DT_PRIMEIRA_CONTRIB
    ,DT_VENC_CARENCIA
    ,CD_SIT_INSCRICAO
    ,TIPO_IRRF
    ,IDADE_RECEB_BENEF
    ,cd_tipo_cobranca
    ,NUM_BANCO
    ,NUM_AGENCIA
    ,NUM_CONTA
    ,DIA_VENC
    ,CD_GRUPO
    ,cd_perfil_invest
    ,NUM_PROTOCOLO
    ,VITALICIO
    ,VL_PERC_VITALICIO
    ,LEI_108
    ,SALDO_PROJ
    ,PECULIO_INV
    ,PECULIO_MORTE
    ,INTEGRALIZA_SALDO
    ,CK_EXTRATO_CST
    ,DT_EMISSAO_CERTIFICADO
    ,TIPO_IRRF_CANC
    ,IND_OPTANTE_MAXIMA_BASICA
    ,IND_AFA_JUDICIAL
)
VALUES
(
     @CD_FUNDACAO
    ,@NUM_INSCRICAO
    ,@CD_PLANO
    ,@DT_INSC_PLANO
    ,@CD_SIT_PLANO
    ,@DT_SITUACAO_ATUAL
    ,@CD_MOTIVO_DESLIG
    ,@DT_DESLIG_PLANO
    ,@FUNDADOR
    ,@PERC_TAXA_MAXIMA
    ,@GRUPO
    ,@DT_PRIMEIRA_CONTRIB
    ,@DT_VENC_CARENCIA
    ,@CD_SIT_INSCRICAO
    ,@TIPO_IRRF
    ,@IDADE_RECEB_BENEF
    ,@cd_tipo_cobranca
    ,@NUM_BANCO
    ,@NUM_AGENCIA
    ,@NUM_CONTA
    ,@DIA_VENC
    ,@CD_GRUPO
    ,@cd_perfil_invest
    ,@NUM_PROTOCOLO
    ,@VITALICIO
    ,@VL_PERC_VITALICIO
    ,@LEI_108
    ,@SALDO_PROJ
    ,@PECULIO_INV
    ,@PECULIO_MORTE
    ,@INTEGRALIZA_SALDO
    ,@CK_EXTRATO_CST
    ,@DT_EMISSAO_CERTIFICADO
    ,@TIPO_IRRF_CANC
    ,@IND_OPTANTE_MAXIMA_BASICA
    ,@IND_AFA_JUDICIAL
)