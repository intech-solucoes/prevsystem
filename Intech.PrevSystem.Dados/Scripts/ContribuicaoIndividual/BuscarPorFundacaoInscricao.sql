﻿/*Config
    RetornaLista
    Retorno
        -ContribuicaoIndividualEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT *
 FROM CS_CONTRIB_INDIVIDUAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO