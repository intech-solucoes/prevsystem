/*Config
    RetornaLista
    Retorno
        -FaixaValorContribEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -CD_TIPO_CONTRIBUICAO:string
        -CD_MANTENEDORA:string
*/

SELECT *
FROM  TB_FAIXA_VALOR_CONTRIB
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO
  AND CD_MANTENEDORA = @CD_MANTENEDORA