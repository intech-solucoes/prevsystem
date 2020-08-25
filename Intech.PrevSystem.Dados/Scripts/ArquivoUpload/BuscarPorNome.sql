/*Config
	RetornaLista
    Retorno
        -ArquivoUploadEntidade
    Parametros
        -NOM_ARQUIVO_LOCAL:string
*/

SELECT * FROM TBG_ARQUIVO_UPLOAD
WHERE
    NOM_ARQUIVO_LOCAL = @NOM_ARQUIVO_LOCAL