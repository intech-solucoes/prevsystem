﻿/*Config
    Retorno
        -void
    Parametros
        -OID_DOC_ATU_CADASTRAL:decimal
        -OID_ARQUIVO_UPLOAD:decimal
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -SEQ_RECEBEDOR:decimal
*/

INSERT INTO WEB_DOC_ATU_CADASTRAL 
( OID_ARQUIVO_UPLOAD, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR )
VALUES
( @OID_ARQUIVO_UPLOAD, @CD_FUNDACAO, @NUM_INSCRICAO, @SEQ_RECEBEDOR )

