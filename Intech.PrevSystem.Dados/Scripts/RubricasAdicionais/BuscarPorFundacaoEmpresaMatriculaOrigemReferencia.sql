/*Config
    RetornaLista
    Retorno
        -RubricasAdicionaisEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -CD_ORIGEM:decimal
        -DATA_REF_ATUAL:DateTime
        -DATA_REF_ANTERIOR:DateTime
*/

SELECT *
FROM CE_RUBRICAS_ADCIONAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND NUM_MATRICULA = @NUM_MATRICULA
  AND CD_ORIGEM = @CD_ORIGEM 
  AND DATA_REF = (SELECT MAX(DATA_REF) AS DATA_REF
                    FROM CE_RUBRICAS_ADCIONAIS
                    WHERE DATA_REF <= @DATA_REF_ATUAL
                        AND DATA_REF >= @DATA_REF_ANTERIOR)