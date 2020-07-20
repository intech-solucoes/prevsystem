/*Config
    RetornaLista
    Retorno
        -ContribuicaoIndividualEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-DATA_ATUAL:DateTime
*/

SELECT * 
FROM CS_CONTRIB_INDIVIDUAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_TIPO_CONTRIBUICAO IN ('09','15')
  AND (DT_FIM IS NULL OR DT_FIM >= @DATA_ATUAL)