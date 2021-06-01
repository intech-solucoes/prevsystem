/*Config
    RetornaLista
    Retorno
        -LGPDConsentimentoEntidade
    Parametros
        -CPF:string
		-DataExpiracao:DateTime
*/

SELECT *, DATEDIFF(DAY, @DataExpiracao, DTA_CONSENTIMENTO) AS 'DIAS_EXPIRACAO'
FROM WEB_LGPD_CONSENTIMENTO
WHERE COD_CPF = @CPF