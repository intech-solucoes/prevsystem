/*Config
    RetornaLista
    Retorno
        -RecebedorBeneficioEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_INSCRICAO:string
*/

SELECT RB.*
FROM GB_RECEBEDOR_BENEFICIO RB
WHERE RB.CD_FUNDACAO = @CD_FUNDACAO
  AND RB.CD_EMPRESA = @CD_EMPRESA
  AND RB.NUM_INSCRICAO = @NUM_INSCRICAO