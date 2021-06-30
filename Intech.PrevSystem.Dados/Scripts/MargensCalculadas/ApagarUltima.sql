/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -NUM_SEQ_GR_FAMIL:decimal
*/

DELETE FROM CE_MARGENS_CALCULADAS 
WHERE DATA_REF = (SELECT MAX(DATA_REF) 
                    FROM CE_MARGENS_CALCULADAS 
                   WHERE ( CD_FUNDACAO = @CD_FUNDACAO )
                     AND ( CD_EMPRESA = @CD_EMPRESA )
                     AND ( NUM_MATRICULA = @NUM_MATRICULA )
                     AND ( NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL ))