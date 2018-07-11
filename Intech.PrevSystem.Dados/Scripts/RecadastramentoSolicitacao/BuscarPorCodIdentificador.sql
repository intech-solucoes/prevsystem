/*Config
    Retorno
        -RecadastramentoSolicitacaoEntidade
    Parametros
        -COD_IDENTIFICADOR:string
*/

SELECT *
FROM  REC_SOLICITACAO
WHERE COD_IDENTIFICADOR = @COD_IDENTIFICADOR