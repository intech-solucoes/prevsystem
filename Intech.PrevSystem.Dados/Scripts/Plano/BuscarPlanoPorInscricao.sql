/*Config
    RetornaLista
	Retorno
		-PlanoEntidade
	Parametros
		-NUM_INSCRICAO:string
*/

SELECT P.*
    FROM GB_PROCESSOS_BENEFICIO PB
	    JOIN TB_PLANOS P ON PB.CD_PLANO = P.CD_PLANO
		    AND NUM_INSCRICAO = @NUM_INSCRICAO