/*Config
    Retorno
        -void
    Parametros
        -RESPOSTA_ENVIO:string
        -NUM_TELEFONE:string
        -NUM_MATRICULA:string
        -NUM_INSCRICAO:string
*/

INSERT INTO TBG_LOG_SMS
(
    RESPOSTA_ENVIO, 
    NUM_TELEFONE, 
    NUM_MATRICULA, 
    NUM_INSCRICAO, 
    DTA_ENVIO
) 
VALUES (
    @RESPOSTA_ENVIO, 
    @NUM_TELEFONE, 
    @NUM_MATRICULA, 
    @NUM_INSCRICAO, 
    GETDATE()
)