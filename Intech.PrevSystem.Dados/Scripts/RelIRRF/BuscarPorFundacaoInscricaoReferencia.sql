/*Config
    Retorno
        -RelIRRFEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -DT_REF:DateTime
*/

SELECT *
 FROM CE_REL_IRRF
WHERE NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_FUNDACAO = @CD_FUNDACAO
  AND DT_REF = @DT_REF