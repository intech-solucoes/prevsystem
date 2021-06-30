/*Config
    RetornaLista
    Retorno
        -MargensCalculadasEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -NUM_SEQ_GR_FAMIL:decimal
*/

SELECT TOP 6 CE_MARGENS_CALCULADAS.*
FROM   CE_MARGENS_CALCULADAS
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_EMPRESA = @CD_EMPRESA )
       AND ( NUM_MATRICULA = @NUM_MATRICULA )
       AND ( NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL )
ORDER  BY DATA_REF DESC 