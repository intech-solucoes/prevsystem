﻿/*Config
    RetornaLista
    Retorno
        -TipoContribuicaoEntidade
    Parametros
        -CD_PLANO:string
        -CD_TIPO_RESGATE:string
*/

SELECT TB_TIPO_CONTRIBUICAO.*
FROM TB_TIPO_CONTRIBUICAO
WHERE (CD_TIPO_CONTRIBUICAO IN
         (SELECT DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO
          FROM DR_PARAMETROS_RESGATE
          INNER JOIN TB_TIPO_CONTRIBUICAO AS TB_TIPO_CONTRIBUICAO_1 ON TB_TIPO_CONTRIBUICAO_1.CD_TIPO_CONTRIBUICAO = DR_PARAMETROS_RESGATE.CD_TIPO_CONTRIBUICAO
          WHERE (DR_PARAMETROS_RESGATE.CD_PLANO = @CD_PLANO)
            AND (DR_PARAMETROS_RESGATE.CD_TIPO_RESGATE = @CD_TIPO_RESGATE)))