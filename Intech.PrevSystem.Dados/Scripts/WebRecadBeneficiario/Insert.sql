﻿/*Config
    Retorno
        -long
    Parametros
        -OID_RECAD_DADOS: decimal
		-COD_PLANO: string
		-NUM_SEQ_DEP: decimal
		-NOM_DEPENDENTE: string
		-COD_GRAU_PARENTESCO: string
		-DES_GRAU_PARENTESCO: string
		-DTA_NASCIMENTO: DateTime?
		-COD_SEXO: string
		-DES_SEXO: string
		-COD_CPF: string
		-COD_PERC_RATEIO: decimal
		-IND_OPERACAO: string
		-IND_VALIDO: string
		-IND_HERDEIRO: string
*/

INSERT INTO WEB_RECAD_BENEFICIARIO(
	OID_RECAD_DADOS,
    COD_PLANO,
    NUM_SEQ_DEP,
    NOM_DEPENDENTE,
    COD_GRAU_PARENTESCO,
    DES_GRAU_PARENTESCO,
    DTA_NASCIMENTO,
    COD_SEXO,
    DES_SEXO,
    COD_CPF,
    COD_PERC_RATEIO,
    IND_OPERACAO,
	IND_VALIDO,
	IND_HERDEIRO
)
VALUES(
    @OID_RECAD_DADOS,
    @COD_PLANO,
    @NUM_SEQ_DEP,
    @NOM_DEPENDENTE,
    @COD_GRAU_PARENTESCO,
    @DES_GRAU_PARENTESCO,
    @DTA_NASCIMENTO,
    @COD_SEXO,
    @DES_SEXO,
    @COD_CPF,
    @COD_PERC_RATEIO,
    @IND_OPERACAO,
	@IND_VALIDO,
	@IND_HERDEIRO
)