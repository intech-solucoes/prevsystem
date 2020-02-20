/*Config
    RetornaLista
    Retorno
        -WebAreaFundacaoEntidade
    Parametros
        -@OID_AREA_FUNDACAO:decimal
*/

SELECT *
  FROM WEB_AREA_FUNDACAO WAF
      JOIN WEB_ASSUNTO WA ON WAF.OID_AREA_FUNDACAO = WA.OID_AREA_FUNDACAO
WHERE WAF.OID_AREA_FUNDACAO = @OID_AREA_FUNDACAO