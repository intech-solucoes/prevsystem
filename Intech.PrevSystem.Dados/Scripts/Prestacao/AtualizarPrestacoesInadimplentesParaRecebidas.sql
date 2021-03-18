/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
        -DT_VENC:DateTime
        -DT_PAGTO:DateTime
*/

UPDATE CE_PRESTACOES
SET    CD_ORIGEM_REC = 6,
       DT_PAGTO = @DT_PAGTO,
       ORIGEM_LANC = 'REC. REFORMA'
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( ANO_CONTRATO = @ANO_CONTRATO )
       AND ( NUM_CONTRATO = @NUM_CONTRATO )
       AND ( DT_VENC <= @DT_VENC )
       AND ( DT_PAGTO IS NULL )
       AND ( CD_ORIGEM_REC IS NULL
              OR CD_ORIGEM_REC = 50
              OR CD_ORIGEM_REC = 0
              OR CD_ORIGEM_REC = 5 )
       AND ( TIPO IN ( 'P', 'I' ) ) 