﻿/*Config
    Retorno
        -long
    Parametros
        -DTA_UPLOAD:DateTime
        -IND_STATUS:decimal
        -NOM_ARQUIVO_LOCAL:string
        -NOM_ARQUIVO_ORIGINAL:string
        -NOM_DIRETORIO_LOCAL:string
*/

INSERT INTO TBG_ARQUIVO_UPLOAD(DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL)
VALUES(
    @DTA_UPLOAD, 
    @IND_STATUS, 
    @NOM_ARQUIVO_LOCAL, 
    @NOM_ARQUIVO_ORIGINAL, 
    @NOM_DIRETORIO_LOCAL
)