/*Config
    Retorno
        -FatAtuMetrusG1Entidade
    Parametros
        -TIPO:string
        -IDADE:int
*/

SELECT * FROM GB_FAT_ATU_METRUS_G1
WHERE IDADE = @IDADE
  AND TIPO = @TIPO