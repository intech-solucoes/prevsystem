/*Config
    Retorno
        -AnuidadeAtuarialEntidade
    Parametros
        -TIPO:string
        -SEXO:string
        -IDADE:int
*/

 SELECT *
 FROM TB_ANUIDADE_ATUARIAL 
 WHERE TIPO = @TIPO
   AND SEXO  = @SEXO
   AND IDADE = @IDADE
   AND DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA)
                        FROM TB_ANUIDADE_ATUARIAL 
                       WHERE TIPO = @TIPO
                         AND SEXO  = @SEXO
                         AND IDADE = @IDADE)