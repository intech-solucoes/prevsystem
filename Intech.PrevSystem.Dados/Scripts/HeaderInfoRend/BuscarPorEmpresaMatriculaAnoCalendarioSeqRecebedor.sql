﻿/*Config
    RetornaLista
    Retorno
        -HeaderInfoRendEntidade
    Parametros
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -ANO_CALENDARIO:decimal
        -SEQ_RECEBEDOR:decimal
*/

SELECT TB_HEADER_INFO_REND.*,
    EE_FUNC.NOME_ENTID AS NOME,
    EE_FUNC.CPF_CGC AS CPF,
    EE_ENTIDADE.NOME_ENTID AS NOM_EMPRESA,
    EE_ENTIDADE.CPF_CGC    AS CNPJ_EMPRESA
FROM   TB_HEADER_INFO_REND
INNER JOIN TB_EMPRESA ON TB_HEADER_INFO_REND.CD_EMPRESA = TB_EMPRESA.CD_EMPRESA
INNER JOIN TB_FUNDACAO ON TB_EMPRESA.CD_FUNDACAO = TB_FUNDACAO.CD_FUNDACAO
INNER JOIN EE_ENTIDADE ON TB_FUNDACAO.COD_ENTID = EE_ENTIDADE.COD_ENTID
INNER JOIN GB_RECEBEDOR_BENEFICIO RECEBEDOR ON RECEBEDOR.NUM_MATRICULA = TB_HEADER_INFO_REND.NUM_MATRICULA
							               AND RECEBEDOR.CD_EMPRESA = TB_HEADER_INFO_REND.CD_EMPRESA
INNER JOIN EE_ENTIDADE EE_FUNC ON EE_FUNC.COD_ENTID = RECEBEDOR.COD_ENTID
WHERE TB_HEADER_INFO_REND.NUM_MATRICULA = @NUM_MATRICULA
  AND TB_HEADER_INFO_REND.ANO_CALENDARIO = @ANO_CALENDARIO
  AND TB_HEADER_INFO_REND.CD_EMPRESA = @CD_EMPRESA
  AND RECEBEDOR.SEQ_RECEBEDOR = @SEQ_RECEBEDOR