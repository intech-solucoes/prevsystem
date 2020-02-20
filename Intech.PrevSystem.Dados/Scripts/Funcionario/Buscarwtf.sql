﻿/*Config
    Retorno
        -FuncionarioEntidade
    Parametros
        -COD_ENTID:string
*/

SELECT
	EE_ENTIDADE.NOME_ENTID,     
	TB_LOTACAO.DS_LOTACAO,
	TB_CARGO.DS_CARGO,
	EE-ENTIDADE.CPF_CGC,
	CS_FUNCIONARIO.* 
FROM CS_FUNCIONARIO 
INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID 
LEFT JOIN TB_LOTACAO ON TB_LOTACAO.CD_LOTACAO = CS_FUNCIONARIO.CD_LOTACAO
                    AND TB_LOTACAO.CD_EMPRESA = CS_FUNCIONARIO.CD_EMPRESA
LEFT JOIN TB_CARGO ON TB_CARGO.CD_CARGO = CS_FUNCIONARIO.CD_CARGO
                  AND TB_CARGO.CD_EMPRESA = CS_FUNCIONARIO.CD_EMPRESA
WHERE CS_FUNCIONARIO.COD_ENTID = @COD_ENTID
ORDER BY CS_FUNCIONARIO.DT_ADMISSAO DESC