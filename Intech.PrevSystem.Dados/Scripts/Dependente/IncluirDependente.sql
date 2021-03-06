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
        -DT_NASC_DEP:DateTime
        -ABATIMENTO_IRRF:string
        -DT_VALIDADE_DEP:DateTime
        -CD_MOT_PERDA_VALIDADE:string
        -DT_INCLUSAO_DEP:DateTime
        -PLANO_ASSISTENCIAL:string
        -PLANO_PREVIDENCIAL:string
        -DT_INIC_IRRF:DateTime?
        -DT_TERM_IRRF:DateTime?
        -PECULIO:string
        -NUM_PROTOCOLO:string
        -CPF:string
        -IDENTIDADE:string
        -ORGAO_EXP:string
        -DT_EXPEDICAO:DateTime?
        -CD_PLANO:string
        -CD_NACIONALIDADE:string
        -CD_ESTADO_CIVIL:string
        -NATURALIDADE:string
        -UF_NATURALIDADE:string
        -EMAIL_DEP:string
        -FONE_CELULAR:string
        -NUM_BANCO:string
        -NUM_CONTA:string
        -NUM_AGENCIA:string
        -END_DEP:string
        -COMP_END_DEP:string
        -BAIRRO_DEP:string
        -CID_DEP:string
        -UF_DEP:string
        -CD_PAIS:string
        -FONE_DEP:string
        -CEP_DEP:string
*/

INSERT INTO CS_DEPENDENTE 
( CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, 
 ABATIMENTO_IRRF, DT_VALIDADE_DEP, DT_INCLUSAO_DEP, PLANO_ASSISTENCIAL, PLANO_PREVIDENCIAL, CD_MOT_PERDA_VALIDADE, DT_INIC_IRRF,
 DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, 
 CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, 
 NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP
)
VALUES
(
 @CD_FUNDACAO, @NUM_INSCRICAO, @NUM_SEQ_DEP, @NOME_DEP, @CD_GRAU_PARENTESCO, @SEXO_DEP, @DT_NASC_DEP, 
 @ABATIMENTO_IRRF, @DT_VALIDADE_DEP, @DT_INCLUSAO_DEP, @PLANO_ASSISTENCIAL, @PLANO_PREVIDENCIAL, @CD_MOT_PERDA_VALIDADE, @DT_INIC_IRRF,
 @DT_TERM_IRRF, @PECULIO, @NUM_PROTOCOLO, @CPF, @IDENTIDADE, @ORGAO_EXP, @DT_EXPEDICAO, @CD_PLANO, 
 @CD_NACIONALIDADE, @CD_ESTADO_CIVIL, @NATURALIDADE, @UF_NATURALIDADE, @EMAIL_DEP, @FONE_CELULAR, 
 @NUM_BANCO, @NUM_CONTA, @NUM_AGENCIA, @END_DEP, @COMP_END_DEP, @BAIRRO_DEP, @CID_DEP, @UF_DEP, @CD_PAIS, @FONE_DEP, @CEP_DEP
)

