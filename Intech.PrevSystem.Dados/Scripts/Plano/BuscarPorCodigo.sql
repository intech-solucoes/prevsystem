/*Config
	Retorno
		-PlanoEntidade
	Parametros
		-CD_PLANO:string
*/

SELECT *
FROM TB_PLANOS
WHERE CD_PLANO = @CD_PLANO

