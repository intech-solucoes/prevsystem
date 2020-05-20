/*Config
    Retorno
        -DependenteSequencialEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT MAX(NUM_SEQ_DEP) AS NUM_SEQ_DEP
 FROM CS_DEPENDENTE
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
