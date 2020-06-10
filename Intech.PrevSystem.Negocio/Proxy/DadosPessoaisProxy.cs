#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class DadosPessoaisProxy : DadosPessoaisDAO
    {
        public override DadosPessoaisEntidade BuscarPorCodEntid(string COD_ENTID)
        {
            var dadosPessoais = base.BuscarPorCodEntid(COD_ENTID);

            if(!string.IsNullOrEmpty(dadosPessoais.CPF_CGC))
                dadosPessoais.CPF_CGC = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF);

            if (!string.IsNullOrEmpty(dadosPessoais.SEXO))
                dadosPessoais.DS_SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO";
            else
                dadosPessoais.DS_SEXO = "-";

            return dadosPessoais;
        }

        public override long Inserir(DadosPessoaisEntidade entidade)
        {
            base.Insert(
                 entidade.COD_ENTID
                ,entidade.CD_NACIONALIDADE
                ,entidade.CD_GRAU_INSTRUCAO
                ,entidade.CD_ESTADO_CIVIL
                ,entidade.SEXO
                ,entidade.NATURALIDADE
                ,entidade.UF_NATURALIDADE
                ,entidade.DT_NASCIMENTO
                ,entidade.NU_IDENT
                ,entidade.ORG_EMIS_IDENT
                ,entidade.DT_EMIS_IDENT
                ,entidade.NU_CTPS
                ,entidade.SERIE_CTPS
                ,entidade.UF_EMIS_CTPS
                ,entidade.COD_BANCO_COB
                ,entidade.COD_AGENC_COB
                ,entidade.CD_TIPO_COB
                ,entidade.NUM_CONTA_COB
                ,entidade.NOME_PAI
                ,entidade.NOME_MAE
                ,entidade.CD_PAIS
                ,entidade.NR_DEP_COB
                ,entidade.QTD_DEPENDENTE
                ,entidade.CD_EMP_COB
                ,entidade.PS_DOENCA_CRONICA
                ,entidade.EMAIL_AUX
                ,entidade.FONE_CELULAR
                ,entidade.DT_FALECIMENTO
                ,entidade.ENVIAR_CARTAO
                ,entidade.CARTAO_ENVIADO
                ,entidade.NUMERO_CARTAO
                ,entidade.SEGUNDA_VIA_CARTAO
                ,entidade.CARTAO_CANCELADO
                ,entidade.ALTERAR_DADOS_PORT
                ,entidade.CANCELAR_LIM_PORT
                ,entidade.SEGUNDA_VIA_SENHA
                ,entidade.SEGUNDA_VIA_EXTRATO
                ,entidade.CD_CANCELAMENTO_CARTAO
                ,entidade.LIBERAR_CARTAO
                ,entidade.INTERDICAO
                ,entidade.CNT_ABERT_CRED
                ,entidade.COD_ENTID_CURADOR
                ,entidade.NOME_CONJUGE
                ,entidade.CPF_CONJUGE
                ,entidade.TEMPO_MILITAR
                ,entidade.END_CORREIO
                ,entidade.UF_EMIS_IDENT
                ,entidade.CD_OPERADORA
                ,entidade.APOSENTADO_INSS
                ,entidade.DIR_DOCUMENTOS
                ,entidade.VL_MARGEM_CONSIG
                ,entidade.REG_ESTRANGEIRO
                ,entidade.PAIS_ORIGEM_PASSAPORTE
                ,entidade.DT_CHEGADA
                ,entidade.NOME_SOCIAL
                ,entidade.IND_RECEBER_EMAIL
                ,entidade.ID_EMP_ONLINE
            );

            return 0;
        }
    }
}