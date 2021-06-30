/*Config
    RetornaLista
    Retorno
        -HistSalariosEntidade
    Parametros
        -NUM_INSCRICAO:string
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -DT_TERM_VALIDADE:DateTime
*/

SELECT *
FROM   AM_HIST_SALARIOS
WHERE  ( NUM_INSCRICAO = @NUM_INSCRICAO )
       AND ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_PLANO = @CD_PLANO )
       AND ( CD_TIPO_CONTRIBUICAO IN ( '14', '17' ) )
       AND ( DT_TERM_VALIDADE <= @DT_TERM_VALIDADE OR DT_TERM_VALIDADE IS NULL ) 