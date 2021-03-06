﻿/*Config
    RetornaLista
    Retorno
        -RecebedorBeneficioEntidade
    Parametros
        -CPF:string
*/

SELECT RB.*
FROM GB_RECEBEDOR_BENEFICIO RB
    INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID
    LEFT OUTER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = EE.COD_ENTID 
    INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO
                 AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO
    INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE
WHERE RB.CD_TIPO_RECEBEDOR = 'G'
  AND EE.CPF_CGC = @CPF
  AND EB.CD_GRUPO_ESPECIE IN ('2', '4')