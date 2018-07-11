/*Config
    RetornaLista
    Retorno
        -TempoServicoEntidade
    Parametros
        -COD_ENTID:int
*/

SELECT *
 FROM CS_TEMPO_SERVICO
WHERE COD_ENTID = @COD_ENTID
  AND DT_INIC_ATIVIDADE IS NOT NULL