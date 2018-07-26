/*Config
    RetornaLista
    Retorno
        -DateTime
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT DT_REF
 FROM CE_REL_IRRF
WHERE NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_FUNDACAO = @CD_FUNDACAO