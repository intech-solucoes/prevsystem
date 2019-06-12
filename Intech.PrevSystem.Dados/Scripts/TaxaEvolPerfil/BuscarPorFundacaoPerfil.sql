/*Config
    RetornaLista
    Retorno
        -TaxaEvolPerfilEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PERFIL_INVEST:decimal
*/

SELECT * FROM CS_TAXA_EVOL_PERFIL
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PERFIL_INVEST = @CD_PERFIL_INVEST