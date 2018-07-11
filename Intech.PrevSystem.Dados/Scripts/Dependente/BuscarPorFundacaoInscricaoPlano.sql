/*Config
    RetornaLista
    Retorno
        -DependenteEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT *
 FROM CS_DEPENDENTE
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_PLANO = @CD_PLANO