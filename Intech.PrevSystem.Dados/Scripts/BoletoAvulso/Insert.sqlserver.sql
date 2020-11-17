/*Config
    Retorno
        -void
    Parametros
        -CPF:string
        -MATRICULA:string
        -NOME:string
        -CD_PLANO:string
        -DT_EMISSAO:DateTime
        -VALOR:decimal
*/

INSERT INTO TBG_BOLETO_AVULSO (
     CPF
    ,MATRICULA
    ,NOME
    ,CD_PLANO
    ,DT_EMISSAO
    ,VALOR
)
VALUES (
     @CPF
    ,@MATRICULA
    ,@NOME
    ,@CD_PLANO
    ,@DT_EMISSAO
    ,@VALOR
)