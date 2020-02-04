﻿/*Config
    RetornaLista
    Retorno
        -FuncionarioEntidade
    Parametros
        -CPF:string
*/

SELECT EE_ENTIDADE.NOME_ENTID,
    CS_PLANOS_VINC.CD_SIT_PLANO,
    CS_FUNCIONARIO.* 
FROM CS_FUNCIONARIO 
INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID 
INNER JOIN CS_PLANOS_VINC ON CS_PLANOS_VINC.CD_FUNDACAO = CS_FUNCIONARIO.CD_FUNDACAO
                         AND CS_PLANOS_VINC.NUM_INSCRICAO = CS_FUNCIONARIO.NUM_INSCRICAO
INNER JOIN TB_SIT_PLANO ON TB_SIT_PLANO.CD_SIT_PLANO = CS_PLANOS_VINC.CD_SIT_PLANO
WHERE EE_ENTIDADE.CPF_CGC = @CPF 
ORDER BY DT_ADMISSAO DESC