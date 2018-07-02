/*Config
    RetornaLista
    Retorno
        -FundoContribEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -CD_FUNDO:string
*/

SELECT *
FROM TB_FUNDO_CONTRIB
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND CD_FUNDO = @CD_FUNDO