/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -NUM_SEQ_DEP:decimal
*/

DELETE FROM CS_DEPENDENTE 
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO =@NUM_INSCRICAO
  AND NUM_SEQ_DEP = @NUM_SEQ_DEP

