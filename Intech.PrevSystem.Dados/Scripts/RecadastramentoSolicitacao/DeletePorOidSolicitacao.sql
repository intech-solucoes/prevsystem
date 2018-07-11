/*Config
    Retorno
        -RecadastramentoSolicitacaoValorEntidade
    Parametros
        -OID_SOLICITACAO:decimal
*/


DELETE FROM REC_SOLICITACAO
WHERE OID_SOLICITACAO = @OID_SOLICITACAO