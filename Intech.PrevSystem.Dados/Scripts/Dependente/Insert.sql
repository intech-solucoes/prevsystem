﻿/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -NUM_SEQ_DEP:decimal
        -NOME_DEP:string
        -CD_GRAU_PARENTESCO:string
        -SEXO_DEP:string
        -DT_NASC_DEP:DateTime?
        -ABATIMENTO_IRRF:string
        -DT_VALIDADE_DEP:DateTime?
        -CD_MOT_PERDA_VALIDADE:string
        -DT_INCLUSAO_DEP:DateTime?
        -PLANO_ASSISTENCIAL:string
        -PLANO_PREVIDENCIAL:string
        -DT_INIC_IRRF:DateTime?
        -DT_TERM_IRRF:DateTime?
        -PECULIO:string
        -PERC_PECULIO:decimal?
        -NUM_PROTOCOLO:string
        -DT_INC_MOV:DateTime?
        -DT_EXC_MOV:DateTime?
        -CD_SIT_PLANO_MOV:string
        -POLIT_EXP:string
        -CPF:string
        -IDENTIDADE:string
        -ORGAO_EXP:string
        -DT_EXPEDICAO:DateTime?
        -CD_OCUPACAO:decimal?
        -BENEF_IND:string
        -CD_PLANO:string
        -UF_IDENT_DEP:string
        -CD_NACIONALIDADE:string
        -CD_ESTADO_CIVIL:string
        -NATURALIDADE:string
        -UF_NATURALIDADE:string
        -EMAIL_DEP:string
        -FONE_CELULAR:string
        -NOME_PAI:string
        -NOME_MAE:string
        -ISS:string
        -NUM_BANCO:string
        -NUM_AGENCIA:string
        -NUM_CONTA:string
        -END_DEP:string
        -NR_END_DEP:string
        -COMP_END_DEP:string
        -BAIRRO_DEP:string
        -CID_DEP:string
        -UF_DEP:string
        -CD_PAIS:string
        -FONE_DEP:string
        -FONE_COM_DEP:string
        -CEP_DEP:string
        -PLANO_SAUDE:string
        -DT_RECONHECIMENTO:DateTime?
        -CD_TIPO_CORRESP:string
        -CX_POSTAL:string
*/

INSERT INTO CS_DEPENDENTE
(
     CD_FUNDACAO
    ,NUM_INSCRICAO
    ,NUM_SEQ_DEP
    ,NOME_DEP
    ,CD_GRAU_PARENTESCO
    ,SEXO_DEP
    ,DT_NASC_DEP
    ,ABATIMENTO_IRRF
    ,DT_VALIDADE_DEP
    ,CD_MOT_PERDA_VALIDADE
    ,DT_INCLUSAO_DEP
    ,PLANO_ASSISTENCIAL
    ,PLANO_PREVIDENCIAL
    ,DT_INIC_IRRF
    ,DT_TERM_IRRF
    ,PECULIO
    ,PERC_PECULIO
    ,NUM_PROTOCOLO
    ,DT_INC_MOV
    ,DT_EXC_MOV
    ,CD_SIT_PLANO_MOV
    ,POLIT_EXP
    ,CPF
    ,IDENTIDADE
    ,ORGAO_EXP
    ,DT_EXPEDICAO
    ,CD_OCUPACAO
    ,BENEF_IND
    ,CD_PLANO
    ,UF_IDENT_DEP
    ,CD_NACIONALIDADE
    ,CD_ESTADO_CIVIL
    ,NATURALIDADE
    ,UF_NATURALIDADE
    ,EMAIL_DEP
    ,FONE_CELULAR
    ,NOME_PAI
    ,NOME_MAE
    ,ISS
    ,NUM_BANCO
    ,NUM_AGENCIA
    ,NUM_CONTA
    ,END_DEP
    ,NR_END_DEP
    ,COMP_END_DEP
    ,BAIRRO_DEP
    ,CID_DEP
    ,UF_DEP
    ,CD_PAIS
    ,FONE_DEP
    ,FONE_COM_DEP
    ,CEP_DEP
    ,PLANO_SAUDE
    ,DT_RECONHECIMENTO
    ,CD_TIPO_CORRESP
    ,CX_POSTAL
)
VALUES
(
     @CD_FUNDACAO
    ,@NUM_INSCRICAO
    ,@NUM_SEQ_DEP
    ,@NOME_DEP
    ,@CD_GRAU_PARENTESCO
    ,@SEXO_DEP
    ,@DT_NASC_DEP
    ,@ABATIMENTO_IRRF
    ,@DT_VALIDADE_DEP
    ,@CD_MOT_PERDA_VALIDADE
    ,@DT_INCLUSAO_DEP
    ,@PLANO_ASSISTENCIAL
    ,@PLANO_PREVIDENCIAL
    ,@DT_INIC_IRRF
    ,@DT_TERM_IRRF
    ,@PECULIO
    ,@PERC_PECULIO
    ,@NUM_PROTOCOLO
    ,@DT_INC_MOV
    ,@DT_EXC_MOV
    ,@CD_SIT_PLANO_MOV
    ,@POLIT_EXP
    ,@CPF
    ,@IDENTIDADE
    ,@ORGAO_EXP
    ,@DT_EXPEDICAO
    ,@CD_OCUPACAO
    ,@BENEF_IND
    ,@CD_PLANO
    ,@UF_IDENT_DEP
    ,@CD_NACIONALIDADE
    ,@CD_ESTADO_CIVIL
    ,@NATURALIDADE
    ,@UF_NATURALIDADE
    ,@EMAIL_DEP
    ,@FONE_CELULAR
    ,@NOME_PAI
    ,@NOME_MAE
    ,@ISS
    ,@NUM_BANCO
    ,@NUM_AGENCIA
    ,@NUM_CONTA
    ,@END_DEP
    ,@NR_END_DEP
    ,@COMP_END_DEP
    ,@BAIRRO_DEP
    ,@CID_DEP
    ,@UF_DEP
    ,@CD_PAIS
    ,@FONE_DEP
    ,@FONE_COM_DEP
    ,@CEP_DEP
    ,@PLANO_SAUDE
    ,@DT_RECONHECIMENTO
    ,@CD_TIPO_CORRESP
    ,@CX_POSTAL
)