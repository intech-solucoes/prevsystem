/*Config
    Retorno
        -RecadastramentoSolicitacaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -NUM_MATRICULA:string
*/

SELECT TOP 1 *
FROM  REC_SOLICITACAO
WHERE NUM_MATRICULA = @NUM_MATRICULA
  AND CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO
  AND IND_FECHADA = 'SIM'
ORDER BY DTA_SOLICITACAO DESC