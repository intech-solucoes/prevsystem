/*Config
    Retorno
        -WebFatorAtuarialEntidade
    Parametros
		-COD_TABELA:string
		-SEXO:string
		-IDADE:string
		-DATA_ATUAL:DateTime
*/

SELECT * 
FROM WEB_FATOR_ATUARIAL
WHERE COD_TABELA = @COD_TABELA
  AND IND_SEXO = @SEXO
  AND NUM_IDADE_ANOS = @IDADE
  AND DTA_INICIO_VALIDADE = (SELECT MAX(FAT2.DTA_INICIO_VALIDADE)
                               FROM WEB_FATOR_ATUARIAL FAT2
                              WHERE FAT2.COD_TABELA = @COD_TABELA
                                AND DTA_INICIO_VALIDADE <= @DATA_ATUAL)