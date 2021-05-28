/*Config
    RetornaLista
    Retorno
        -FichaFinancIsencaoEntidade
    Parametros
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT * FROM CC_FICHA_FINANC_ISENCAO
WHERE NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_PLANO = @CD_PLANO