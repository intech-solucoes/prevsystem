/*Config
    RetornaLista
    Retorno
        -WebCapitalSeguradoEntidade
    Parametros
        -COD_CPF:string
*/

SELECT * FROM WEB_CAPITAL_SEGURADO WHERE COD_CPF = @COD_CPF ORDER BY ANO DESC