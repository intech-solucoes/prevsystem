﻿/*Config
    Retorno
        -FuncionarioEntidade
    Parametros
        -COD_ENTID:string
*/

SELECT      
	EE_ENTIDADE.NOME_ENTID,     
	CS_FUNCIONARIO.* 
FROM CS_FUNCIONARIO 
INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID 
WHERE CS_FUNCIONARIO.COD_ENTID = @COD_ENTID