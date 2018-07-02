/*Config
    RetornaLista
    Retorno
        -ComposicaoSRCEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
*/

SELECT *
 FROM GB_COMP_SRC
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO