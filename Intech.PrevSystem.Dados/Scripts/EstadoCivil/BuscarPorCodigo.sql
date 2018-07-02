/*Config
    Retorno
        -EstadoCivilEntidade
    Parametros
        -CD_ESTADO_CIVIL:string
*/

SELECT * 
FROM CS_ESTADO_CIVIL
WHERE CD_ESTADO_CIVIL = @CD_ESTADO_CIVIL