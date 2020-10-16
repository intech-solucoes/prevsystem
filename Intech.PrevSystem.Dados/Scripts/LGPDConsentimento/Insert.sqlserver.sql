/*Config
    Retorno
        -void
    Parametros
        -COD_IDENTIFICADOR:string
        -CD_FUNDACAO:string
        -COD_CPF:string
        -DTA_CONSENTIMENTO:DateTime
        -TXT_IPV4:string
        -TXT_IPV6:string
        -TXT_DISPOSITIVO:string
        -TXT_ORIGEM:string
*/

INSERT INTO WEB_LGPD_CONSENTIMENTO 
(
     COD_IDENTIFICADOR
    ,CD_FUNDACAO
    ,COD_CPF
    ,DTA_CONSENTIMENTO
    ,TXT_IPV4
    ,TXT_IPV6
    ,TXT_DISPOSITIVO
    ,TXT_ORIGEM
) VALUES (
    @COD_IDENTIFICADOR,
    @CD_FUNDACAO,
    @COD_CPF,
    @DTA_CONSENTIMENTO,
    @TXT_IPV4,
    @TXT_IPV6,
    @TXT_DISPOSITIVO,
    @TXT_ORIGEM
)