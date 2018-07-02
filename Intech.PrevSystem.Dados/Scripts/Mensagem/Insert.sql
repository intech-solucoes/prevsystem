/*Config
    Retorno
        -MensagemEntidade
    Parametros
        -TXT_TITULO:string
        -TXT_CORPO:string
        -DTA_MENSAGEM:DateTime
        -DTA_EXPIRACAO:DateTime?
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_SIT_PLANO:string
        -COD_ENTID:decimal?
        -IND_MOBILE:string
        -IND_PORTAL:string
        -IND_EMAIL:string
        -IND_SMS:string
*/

INSERT INTO WEB_MENSAGEM(TXT_TITULO, TXT_CORPO, DTA_MENSAGEM, DTA_EXPIRACAO, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID, IND_MOBILE, IND_PORTAL, IND_EMAIL, IND_SMS)
VALUES (@TXT_TITULO,@TXT_CORPO,@DTA_MENSAGEM,@DTA_EXPIRACAO,@CD_FUNDACAO,@CD_EMPRESA,@CD_PLANO,@CD_SIT_PLANO,@COD_ENTID,@IND_MOBILE,@IND_PORTAL,@IND_EMAIL,@IND_SMS)