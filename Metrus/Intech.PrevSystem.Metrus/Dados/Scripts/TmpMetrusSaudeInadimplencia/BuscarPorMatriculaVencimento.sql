/*Config
    RetornaLista
    Retorno
        -TmpMetrusSaudeInadimplencia
    Parametros
        -MATRICULA:string
        -DATA:DateTime
        -FUNDACAO:decimal
*/

SELECT MATRICULA
FROM  TMP_MTR_SAUDE_INADIMPLENCIA
WHERE MATRICULA = @MATRICULA
  AND VENCIMENTO = @DATA
  AND CONTRATO = @FUNDACAO