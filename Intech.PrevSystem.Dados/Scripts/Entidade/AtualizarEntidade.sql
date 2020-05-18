/*Config
    Retorno
        -void
    Parametros
        -COD_ENTID:string
        -NOME_ENTID:string
        -CPF_CGC:string
        -END_ENTID:string
        -NR_END_ENTID:string
        -COMP_END_ENTID:string
        -BAIRRO_ENTID:string
        -CID_ENTID:string
        -UF_ENTID:string
        -CEP_ENTID:string
        -NUM_BANCO:string
        -NUM_AGENCIA:string
        -NUM_CONTA:string
*/

UPDATE EE_ENTIDADE
SET NOME_ENTID = @NOME_ENTID, CPF_CGC = @CPF_CGC, END_ENTID = @END_ENTID, NR_END_ENTID = @NR_END_ENTID, COMP_END_ENTID = @COMP_END_ENTID, BAIRRO_ENTID = @BAIRRO_ENTID, 
CID_ENTID = @CID_ENTID, UF_ENTID = @UF_ENTID, CEP_ENTID = @CEP_ENTID, NUM_BANCO =@NUM_BANCO, NUM_AGENCIA = @NUM_AGENCIA, NUM_CONTA = @NUM_CONTA
WHERE COD_ENTID = @COD_ENTID
