/*Config
    Retorno
        -GrauParentescoEntidade
    Parametros
        -CD_GRAU_PARENTESCO:string
*/

SELECT * 
FROM TB_GRAU_PARENTESCO
WHERE CD_GRAU_PARENTESCO = @CD_GRAU_PARENTESCO