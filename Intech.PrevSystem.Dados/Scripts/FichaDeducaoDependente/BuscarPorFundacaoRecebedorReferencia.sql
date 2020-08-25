/*Config
    RetornaLista
    Retorno
        -FichaDeducaoDependenteEntidade
    Parametros
        -CD_FUNDACAO:string
        -SEQ_RECEBEDOR:decimal
        -DT_REFERENCIA:DateTime
*/

SELECT * 
FROM GB_FICHA_DEDUCAO_DEPENDENTE
WHERE CD_FUNDACAO = @CD_FUNDACAO  
  AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR
  AND DT_REFERENCIA = @DT_REFERENCIA