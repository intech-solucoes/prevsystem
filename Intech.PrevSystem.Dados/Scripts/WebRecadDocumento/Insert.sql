/*Config
    Retorno
        -long
    Parametros
        -OID_RECAD_DADOS: decimal
	    -TXT_TITULO: string
		-TXT_NOME_FISICO: string
*/

INSERT INTO WEB_RECAD_DOCUMENTO(
	OID_RECAD_DADOS,
    TXT_TITULO,
    TXT_NOME_FISICO
)
VALUES(
    @OID_RECAD_DADOS,
    @TXT_TITULO,
    @TXT_NOME_FISICO
)