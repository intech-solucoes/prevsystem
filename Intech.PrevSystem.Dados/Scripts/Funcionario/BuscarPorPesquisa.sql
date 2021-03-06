﻿/*Config
	RetornaLista
    Retorno
        -FuncionarioEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_SIT_PLANO:string
        -NUM_MATRICULA:string
		-NOME:string
        -CPF:string
*/

SELECT DISTINCT *
FROM   VW_FUNC_PLANO_DADOS
WHERE (CD_FUNDACAO = @CD_FUNDACAO OR @CD_FUNDACAO IS NULL)
  AND (CD_EMPRESA = @CD_EMPRESA OR @CD_EMPRESA IS NULL)
  AND (CD_PLANO = @CD_PLANO OR @CD_PLANO IS NULL)
  AND (CD_SIT_PLANO = @CD_SIT_PLANO OR @CD_SIT_PLANO IS NULL)
  AND (NUM_MATRICULA LIKE '%' + @NUM_MATRICULA + '%' OR @NUM_MATRICULA IS NULL) 
  AND (NOME_ENTID LIKE '%' + @NOME + '%' OR @NOME IS NULL)
  AND (CPF_CGC LIKE '' + @CPF + '%' OR @CPF IS NULL)