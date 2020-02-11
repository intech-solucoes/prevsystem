/*Config
    RetornaLista
    Retorno
        -WebAreaFundacaoEntidade
    Parametros
        -@OID_ASSUNTO:string
*/

SELECT *
  FROM WEB_AREA_FUNDACAO WAF
      JOIN WEB_ASSUNTO WA ON WAF.OID_AREA_FUNDACAO = WA.OID_AREA_FUNDACAO
 WHERE OID_ASSUNTO = @OID_ASSUNTO