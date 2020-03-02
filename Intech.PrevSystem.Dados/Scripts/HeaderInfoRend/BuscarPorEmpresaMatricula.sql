﻿/*Config
    RetornaLista
    Retorno
        -HeaderInfoRendEntidade
    Parametros
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
*/

SELECT TB_HEADER_INFO_REND.*,
    EE_ENTIDADE.NOME_ENTID AS NOM_EMPRESA,
    EE_ENTIDADE.CPF_CGC    AS CNPJ_EMPRESA
FROM   TB_HEADER_INFO_REND
INNER JOIN TB_EMPRESA ON TB_HEADER_INFO_REND.CD_EMPRESA = TB_EMPRESA.CD_EMPRESA
INNER JOIN TB_FUNDACAO ON TB_EMPRESA.CD_FUNDACAO = TB_FUNDACAO.CD_FUNDACAO
INNER JOIN EE_ENTIDADE ON TB_FUNDACAO.COD_ENTID = EE_ENTIDADE.COD_ENTID
WHERE TB_HEADER_INFO_REND.NUM_MATRICULA = @NUM_MATRICULA
  AND TB_HEADER_INFO_REND.CD_EMPRESA = @CD_EMPRESA
ORDER BY TB_HEADER_INFO_REND.ANO_CALENDARIO DESC