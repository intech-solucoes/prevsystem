/*Config
    RetornaLista
    Retorno
        -AdesaoEmpresaPlanoEntidade
    Parametros
        -CD_EMPRESA:string
*/

SELECT * 
FROM WEB_ADESAO_EMPRESA_PLANO
WHERE CD_EMPRESA = @CD_EMPRESA