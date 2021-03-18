/*Config
    Retorno
        -void
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:string
        -NUM_CONTRATO:string
        -CD_PLANO:string
        -DATA_INSCRICAO:DateTime
*/

INSERT INTO CE_PLANOS_CONTRATO
            (CD_FUNDACAO,
             ANO_CONTRATO,
             NUM_CONTRATO,
             CD_PLANO,
             DATA_INSCRICAO)
VALUES      (@CD_FUNDACAO,
             @ANO_CONTRATO,
             @NUM_CONTRATO,
             @CD_PLANO,
             @DATA_INSCRICAO) 