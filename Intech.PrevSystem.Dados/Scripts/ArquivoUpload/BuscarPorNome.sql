/*Config
	RetornaLista
    Retorno
        -ArquivoUploadEntidade
    Parametros
        -NOM_ARQUIVO_ORIGINAL:string
*/

SELECT * FROM TBG_ARQUIVO_UPLOAD
WHERE
    NOM_ARQUIVO_ORIGINAL = @NOM_ARQUIVO_ORIGINAL