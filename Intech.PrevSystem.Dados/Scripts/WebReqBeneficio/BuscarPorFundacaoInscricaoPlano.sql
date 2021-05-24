/*Config
    Retorno
        -WebReqBeneficioEntidade
    Parametros
        -CD_FUNDACAO:string
		-NUM_INSCRICAO:string
		-CD_PLANO:string
*/

SELECT  *
FROM WEB_REQ_BENEFICIO
WHERE CD_FUNDACAO = @CD_FUNDACAO
AND NUM_INSCRICAO = @NUM_INSCRICAO
AND CD_PLANO = @CD_PLANO