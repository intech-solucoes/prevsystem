﻿/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -COD_ENTID:decimal
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -CD_CARGO:string
        -CD_FUNCAO:string
        -CD_LOTACAO:string
        -CD_NIVEL_SALARIAL:string
        -DT_ADMISSAO:DateTime?
        -CD_SIT_EMPRESA:string
        -DT_SITUACAO_EMPRESA:DateTime?
        -CD_MOTIVO_DEMISSAO:string
        -DT_DEMISSAO:DateTime?
        -AUTO_MANTENEDOR:string
        -FONE_TRAB:string
        -FAX_TRAB:string
        -RAMAL_TRAB:string
        -AGENDA:string
        -CD_LOCALIDADE:string
        -CD_OCUPACAO:decimal?
        -ORGAO_EXT:string
        -SETOR_EXT:string
        -CONTATO_EXT:string
        -FONE_EXT:string
        -RAMAL_EXT:string
        -CD_EMP_NEW:string
        -NUM_PROTOCOLO:string
        -DT_RECADASTRO:DateTime?
        -COD_VINC:string
        -COD_CERTA:string
        -COD_ORIGEM:string
        -COD_PAG:string
        -VL_REND_BASE:decimal?
        -DT_INF_PPE:DateTime?
        -TEMP_SERV:decimal?
        -VL_BASE:decimal?
        -CD_SEQ_CPF:string
        -NUM_MATRICULA_SIAPE:string
        -DT_APOSENT:DateTime?
        -CD_APOSENT_SUJ:string
        -EMAIL_FUNC:string
        -CK_INADIPLENTE:string
        -EXTRATO_IMPRESSO:string
        -DT_VINCULO_FUNDACAO:DateTime?
        -IND_ELEGIBILIDADE:string
        -DT_TERMO:DateTime?
        -IND_PART_RATIFICADO:string
        -PERC_PECULIO:decimal?
        -AGENDA2:string
*/

INSERT INTO CS_FUNCIONARIO
(
     CD_FUNDACAO
    ,NUM_INSCRICAO
    ,COD_ENTID
    ,CD_EMPRESA
    ,NUM_MATRICULA
    ,CD_CARGO
    ,CD_FUNCAO
    ,CD_LOTACAO
    ,CD_NIVEL_SALARIAL
    ,DT_ADMISSAO
    ,CD_SIT_EMPRESA
    ,DT_SITUACAO_EMPRESA
    ,CD_MOTIVO_DEMISSAO
    ,DT_DEMISSAO
    ,AUTO_MANTENEDOR
    ,FONE_TRAB
    ,FAX_TRAB
    ,RAMAL_TRAB
    ,AGENDA
    ,CD_LOCALIDADE
    ,CD_OCUPACAO
    ,ORGAO_EXT
    ,SETOR_EXT
    ,CONTATO_EXT
    ,FONE_EXT
    ,RAMAL_EXT
    ,CD_EMP_NEW
    ,NUM_PROTOCOLO
    ,DT_RECADASTRO
    ,COD_VINC
    ,COD_CERTA
    ,COD_ORIGEM
    ,COD_PAG
    ,VL_REND_BASE
    ,DT_INF_PPE
    ,TEMP_SERV
    ,VL_BASE
    ,CD_SEQ_CPF
    ,NUM_MATRICULA_SIAPE
    ,DT_APOSENT
    ,CD_APOSENT_SUJ
    ,EMAIL_FUNC
    ,CK_INADIPLENTE
    ,EXTRATO_IMPRESSO
    ,DT_VINCULO_FUNDACAO
    ,IND_ELEGIBILIDADE
    ,DT_TERMO
    ,IND_PART_RATIFICADO
    ,PERC_PECULIO
    ,AGENDA2
)
VALUES
(
     @CD_FUNDACAO
    ,@NUM_INSCRICAO
    ,@COD_ENTID
    ,@CD_EMPRESA
    ,@NUM_MATRICULA
    ,@CD_CARGO
    ,@CD_FUNCAO
    ,@CD_LOTACAO
    ,@CD_NIVEL_SALARIAL
    ,@DT_ADMISSAO
    ,@CD_SIT_EMPRESA
    ,@DT_SITUACAO_EMPRESA
    ,@CD_MOTIVO_DEMISSAO
    ,@DT_DEMISSAO
    ,@AUTO_MANTENEDOR
    ,@FONE_TRAB
    ,@FAX_TRAB
    ,@RAMAL_TRAB
    ,@AGENDA
    ,@CD_LOCALIDADE
    ,@CD_OCUPACAO
    ,@ORGAO_EXT
    ,@SETOR_EXT
    ,@CONTATO_EXT
    ,@FONE_EXT
    ,@RAMAL_EXT
    ,@CD_EMP_NEW
    ,@NUM_PROTOCOLO
    ,@DT_RECADASTRO
    ,@COD_VINC
    ,@COD_CERTA
    ,@COD_ORIGEM
    ,@COD_PAG
    ,@VL_REND_BASE
    ,@DT_INF_PPE
    ,@TEMP_SERV
    ,@VL_BASE
    ,@CD_SEQ_CPF
    ,@NUM_MATRICULA_SIAPE
    ,@DT_APOSENT
    ,@CD_APOSENT_SUJ
    ,@EMAIL_FUNC
    ,@CK_INADIPLENTE
    ,@EXTRATO_IMPRESSO
    ,@DT_VINCULO_FUNDACAO
    ,@IND_ELEGIBILIDADE
    ,@DT_TERMO
    ,@IND_PART_RATIFICADO
    ,@PERC_PECULIO
    ,@AGENDA2
)