using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class EntidadeProxy : EntidadeDAO
	{
        public override long Inserir(EntidadeEntidade entidade)
        {
            base.Insert(
                 entidade.COD_ENTID
                ,entidade.SIGLA_ENTID
                ,entidade.NOME_ENTID
                ,entidade.GRP_INVEST
                ,entidade.GRP_ADMINIST
                ,entidade.GRP_PREVI
                ,entidade.GRP_ASSIST
                ,entidade.BANCO
                ,entidade.FUNDACAO
                ,entidade.EMPRESA_SA
                ,entidade.CUSTODIANTE
                ,entidade.CORRETORA
                ,entidade.FORNECEDOR
                ,entidade.PREST_SERV
                ,entidade.PARTICIPANTE
                ,entidade.RECEB_BENEF
                ,entidade.CD_TIPO_CORRESP
                ,entidade.PATROCINADORA
                ,entidade.LOCATARIO
                ,entidade.COD_CUSTOD
                ,entidade.SEGURADORA
                ,entidade.COD_CETIP
                ,entidade.FISIC_JURID
                ,entidade.CPF_CGC
                ,entidade.ISS
                ,entidade.NUM_BANCO
                ,entidade.NUM_AGENCIA
                ,entidade.NUM_CONTA
                ,entidade.END_ENTID
                ,entidade.BAIRRO_ENTID
                ,entidade.CID_ENTID
                ,entidade.UF_ENTID
                ,entidade.CEP_ENTID
                ,entidade.FONE_ENTID
                ,entidade.FAX_ENTID
                ,entidade.CONTA_AUX
                ,entidade.OBS_ENTID
                ,entidade.E_MAIL
                ,entidade.CX_POSTAL
                ,entidade.NR_END_ENTID
                ,entidade.COMP_END_ENTID
                ,entidade.COD_ISIN
                ,entidade.TP_CONTA
                ,entidade.AUTONOMO
                ,entidade.DEPENDENTE
                ,entidade.ISENTO_RETENCAO
                ,entidade.INSCRICAO_INSS
                ,entidade.CBO
                ,entidade.INSCRICAO_ISS
                ,entidade.OBRIG_CONTR
                ,entidade.EMIT_RESP
                ,entidade.SEXO
                ,entidade.DT_NASCIMENTO
                ,entidade.NATURALIDADE
                ,entidade.NACIONALIDADE
                ,entidade.ESTADO_CIVIL
                ,entidade.NOME_PAI
                ,entidade.NOME_MAE
                ,entidade.CONJUGE
                ,entidade.IDENTIDADE
                ,entidade.ORGAO_EXP
                ,entidade.DT_EXPEDICAO
                ,entidade.NATUREZA_DOC
                ,entidade.OCUPACAO_PROF
                ,entidade.NIRE
                ,entidade.ATIVIDADE_PRINC
                ,entidade.REPRES_BENEF
                ,entidade.GERA_DES
                ,entidade.CD_EXTERNO
                ,entidade.SIT_PAT_FINANCEIRA
                ,entidade.SIT_PAT_RENDIMENTOS
                ,entidade.PF_ENQUADRAMENTO
                ,entidade.RECEBE_EMAIL
                ,entidade.SENHA
                ,entidade.SENHA_ANT1
                ,entidade.SENHA_ANT2
                ,entidade.SENHA_ANT3
                ,entidade.SENHA_ANT4
                ,entidade.SENHA_ANT5
                ,entidade.POLIT_EXP
                ,entidade.TIPO_PPE
                ,entidade.COD_OCORRENCIA
                ,entidade.COD_CATEGORIA
                ,entidade.NUM_CONTA_SAL
                ,entidade.NUM_BANCO_SAL
                ,entidade.NUM_AGENCIA_SAL
                ,entidade.AG_RISCO
                ,entidade.COD_IMP_PATRIM
                ,entidade.ATIVO
                ,entidade.TP_REGIME_TRIBUTACAO
                ,entidade.IND_TIPO_CONTA
                ,entidade.E_MAIL_CONTATO
                ,entidade.BLOQUEADA
                ,entidade.NUM_TENTATIVAS
                ,entidade.DT_EXPIRA
                ,entidade.NUM_PROX_SENHA_ALT
                ,entidade.PLANO
                ,entidade.CONSOLIDADO
                ,entidade.RECEB_RESGATE
                ,entidade.DEBITO_AUTO
                ,entidade.AUTORIZA_DEB
                ,entidade.NUM_NIF_EFINANCEIRA
                ,entidade.IND_FATCA
                ,entidade.CD_PAIS_EFINANCEIRA
                ,entidade.IND_DESONERA_CPRB
            );

            return 0;
        }

        public void AtualizarEntidade(EntidadeEntidade entidade)
        {
            base.AtualizarEntidade(entidade.COD_ENTID, entidade.NOME_ENTID, entidade.CPF_CGC, entidade.END_ENTID, entidade.NR_END_ENTID, entidade.COMP_END_ENTID,
                    entidade.BAIRRO_ENTID, entidade.CID_ENTID, entidade.UF_ENTID, entidade.CEP_ENTID, entidade.NUM_BANCO, entidade.NUM_AGENCIA, entidade.NUM_CONTA);
        }
    }
}