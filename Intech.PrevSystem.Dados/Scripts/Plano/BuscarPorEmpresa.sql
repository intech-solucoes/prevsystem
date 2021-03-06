﻿/*Config
	RetornaLista
	Retorno
		-PlanoEntidade
	Parametros
		-CD_EMPRESA:string
*/

SELECT 
	ENT_EMP.NOME_ENTID AS NOME_EMPRESA,
	TB_EMPRESA_PLANOS.CD_EMPRESA,
	TB_EMPRESA_PLANOS.CD_PLANO,
	TB_PLANOS.DS_PLANO
FROM TB_EMPRESA EMP
INNER JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID
INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_EMPRESA = EMP.CD_EMPRESA
INNER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = TB_EMPRESA_PLANOS.CD_PLANO
WHERE EMP.CD_EMPRESA = @CD_EMPRESA

