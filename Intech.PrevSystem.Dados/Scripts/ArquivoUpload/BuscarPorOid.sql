/*Config
    Retorno
        -ArquivoUploadEntidade
    Parametros
        -OID_ARQUIVO_UPLOAD:decimal
*/

SELECT *
FROM TBG_ARQUIVO_UPLOAD
WHERE OID_ARQUIVO_UPLOAD = @OID_ARQUIVO_UPLOAD