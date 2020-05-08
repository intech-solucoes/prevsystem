﻿/*Config
    RetornaLista
    Retorno
        -DependenteEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT DEP.CD_FUNDACAO,
       DEP.NUM_INSCRICAO,
       DEP.NUM_SEQ_DEP,
	   GP.CD_GRAU_PARENTESCO,
       GP.DS_GRAU_PARENTESCO,       
       DEP.NOME_DEP,
       DEP.DT_NASC_DEP,
       DEP.SEXO_DEP,       
       DEP.CPF,
       DEP.PERC_PECULIO,
	   CD_PLANO
FROM CS_DEPENDENTE DEP
  INNER JOIN TB_GRAU_PARENTESCO GP ON GP.CD_GRAU_PARENTESCO = DEP.CD_GRAU_PARENTESCO
WHERE DEP.CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_PLANO = @CD_PLANO
  AND PLANO_PREVIDENCIAL = 'S' --FIXO
ORDER BY GP.TIPO_VALIDADE DESC 