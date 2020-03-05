﻿/*Config
    RetornaLista
    Retorno
        -PlanoVinculadoEntidade
    Parametros
        -CPF:string
*/

SELECT CS_PLANOS_VINC.*,
TB_SIT_PLANO.CD_CATEGORIA
FROM CS_PLANOS_VINC
INNER JOIN TB_SIT_PLANO ON TB_SIT_PLANO.CD_SIT_PLANO = CS_PLANOS_VINC.CD_SIT_PLANO
INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO
INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID
WHERE EE_ENTIDADE.CPF_CGC = @CPF