using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class DependenteProxy : DependenteDAO
	{
        public override long Inserir(DependenteEntidade entidade)
        {
            base.Insert(
                 entidade.CD_FUNDACAO
                ,entidade.NUM_INSCRICAO
                ,entidade.NUM_SEQ_DEP
                ,entidade.NOME_DEP
                ,entidade.CD_GRAU_PARENTESCO
                ,entidade.SEXO_DEP
                ,entidade.DT_NASC_DEP
                ,entidade.ABATIMENTO_IRRF
                ,entidade.DT_VALIDADE_DEP
                ,entidade.CD_MOT_PERDA_VALIDADE
                ,entidade.DT_INCLUSAO_DEP
                ,entidade.PLANO_ASSISTENCIAL
                ,entidade.PLANO_PREVIDENCIAL
                ,entidade.DT_INIC_IRRF
                ,entidade.DT_TERM_IRRF
                ,entidade.PECULIO
                ,entidade.PERC_PECULIO
                ,entidade.NUM_PROTOCOLO
                ,entidade.DT_INC_MOV
                ,entidade.DT_EXC_MOV
                ,entidade.CD_SIT_PLANO_MOV
                ,entidade.POLIT_EXP
                ,entidade.CPF
                ,entidade.IDENTIDADE
                ,entidade.ORGAO_EXP
                ,entidade.DT_EXPEDICAO
                ,entidade.CD_OCUPACAO
                ,entidade.BENEF_IND
                ,entidade.CD_PLANO
                ,entidade.UF_IDENT_DEP
                ,entidade.CD_NACIONALIDADE
                ,entidade.CD_ESTADO_CIVIL
                ,entidade.NATURALIDADE
                ,entidade.UF_NATURALIDADE
                ,entidade.EMAIL_DEP
                ,entidade.FONE_CELULAR
                ,entidade.NOME_PAI
                ,entidade.NOME_MAE
                ,entidade.ISS
                ,entidade.NUM_BANCO
                ,entidade.NUM_AGENCIA
                ,entidade.NUM_CONTA
                ,entidade.END_DEP
                ,entidade.NR_END_DEP
                ,entidade.COMP_END_DEP
                ,entidade.BAIRRO_DEP
                ,entidade.CID_DEP
                ,entidade.UF_DEP
                ,entidade.CD_PAIS
                ,entidade.FONE_DEP
                ,entidade.FONE_COM_DEP
                ,entidade.CEP_DEP
                ,entidade.PLANO_SAUDE
                ,entidade.DT_RECONHECIMENTO
                ,entidade.CD_TIPO_CORRESP
                ,entidade.CX_POSTAL
            );

            return 0;
        }
    }
}
