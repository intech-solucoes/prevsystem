/*Config
    Retorno
        -DadosPessoaisEntidade
    Parametros
        -CD_PESSOA:int
*/

SELECT RB.SQ_PROCESSO,
       RB.CD_PESSOA_RECEB,
       PE.NO_PESSOA,
       PF.NR_CPF,
       CASE
            WHEN PF.IR_SEXO = 'M' THEN 'MASCULINO'
            WHEN PF.IR_SEXO = 'F' THEN 'FEMININO'
            ELSE 'NÃO INFORMADO'
       END AS IR_SEXO,
       PF.DT_NASCIMENTO,
       PF.NO_MAE,
       PF.NO_PAI,
       PF.NO_NATURALIDADE,
       CASE 
            WHEN PF.EE_POLITICAMENTE_EXPOSTO = 'S' THEN 'SIM'
            ELSE 'NÃO'
       END  AS EE_POLITICAMENTE_EXPOSTO,
       CASE 
            WHEN PF.EE_US_PERSON = 'S' THEN 'SIM'
            ELSE 'NÃO'
       END  AS EE_US_PERSON,
       PF.CD_ESTADO_CIVIL,
       EC.DS_ESTADO_CIVIL,
       PF.CD_GRAU_INSTRUCAO,
       GI.DS_GRAU_INSTRUCAO,
       PF.SQ_PAIS_NACIONALIDADE,
       PA.NO_PAIS AS NO_PAIS_NACIONALIDADE,
       CB.CD_BANCO,
       BA.NO_BANCO,
       BAC.CD_AGENCIA,
       BAC.DV_AGENCIA,
       CB.NR_CC,
       CB.DV_CC,
       EP.SQ_ENDERECO,
       EP.CD_TIPO_ENDERECO,
       TE.DS_TIPO_ENDERECO,
       EP.CD_MUNICIPIO,
       MU.DS_MUNICIPIO,
       EP.CD_UF,
       EP.NR_CEP,
       EP.DS_ENDERECO,
       EP.NR_ENDERECO,
       EP.DS_COMPLEMENTO,
       EP.NO_BAIRRO,
       EP.NR_FONE,
       EP.NR_CELULAR,
       EP.NO_EMAIL,
       EP.SQ_TIPO_LOGRADOURO,
       TL.NO_TIPO_LOGRADOURO                            
  FROM fi_recebedor_beneficio RB
       INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = RB.CD_PESSOA_RECEB
       INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = RB.CD_PESSOA_RECEB
       LEFT OUTER JOIN fi_conta_bancaria CB ON CB.SQ_CONTA_BANCARIA = PE.SQ_CONTA_BANCARIA
       LEFT OUTER JOIN fi_banco BA ON BA.CD_BANCO = CB.CD_BANCO
       LEFT OUTER JOIN fi_banco_agencia BAC ON BAC.CD_BANCO = CB.CD_BANCO
            AND BAC.CD_PESSOA_AGENCIA = CB.CD_PESSOA_AGENCIA
       LEFT OUTER JOIN fi_estado_civil EC ON EC.CD_ESTADO_CIVIL = PF.CD_ESTADO_CIVIL
       LEFT OUTER JOIN fi_grau_instrucao GI ON GI.CD_GRAU_INSTRUCAO = PF.CD_GRAU_INSTRUCAO
       LEFT OUTER JOIN fi_paises PA ON PA.SQ_PAIS = PF.SQ_PAIS_NACIONALIDADE
       LEFT OUTER JOIN fi_endereco_pessoa EP ON EP.CD_PESSOA = PF.CD_PESSOA
            AND EP.SQ_ENDERECO = (SELECT MAX(EP2.SQ_ENDERECO)
                                    FROM fi_endereco_pessoa EP2
                                   WHERE EP2.CD_PESSOA = PF.CD_PESSOA
                                     AND EP2.IR_CORRESPONDENCIA = 'S')
       LEFT OUTER JOIN fi_tipo_endereco TE ON TE.CD_TIPO_ENDERECO = EP.CD_TIPO_ENDERECO
       LEFT OUTER JOIN fi_municipio MU ON MU.CD_MUNICIPIO = EP.CD_MUNICIPIO
       LEFT OUTER JOIN fi_tipo_logradouro TL on TL.SQ_TIPO_LOGRADOURO = EP.SQ_TIPO_LOGRADOURO
WHERE RB.SQ_GRUPO_FAMILIAR > 0
  AND RB.CD_PESSOA_RECEB = @CD_PESSOA