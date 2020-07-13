using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades
{
    public class WebRecadParticipanteDadosEntidade
    {
        public string CD_FUNDACAO { get; set; }
        public string SEQ_RECEBEDOR { get; set; }
        public string NUM_INSCRICAO { get; set; }
        public string CD_EMPRESA { get; set; }
        public string NOM_EMPRESA { get; set; }
        public string NUM_MATRICULA { get; set; }
        public string NOME_ENTID { get; set; }
        public string DT_NASCIMENTO { get; set; }
        public string CPF_CGC { get; set; }
        public string NU_IDENT { get; set; }
        public string ORG_EMIS_IDENT { get; set; }
        public string DT_EMIS_IDENT { get; set; }
        public string NATURALIDADE { get; set; }
        public string UF_NATURALIDADE { get; set; }
        public string NOME_MAE { get; set; }
        public string NOME_PAI { get; set; }
        public string CD_ESTADO_CIVIL { get; set; }
        public string NOME_CONJUGE { get; set; }
        public string CPF_CONJUGE { get; set; }
        public string CEP_ENTID { get; set; }
        public string END_ENTID { get; set; }
        public string NR_END_ENTID { get; set; }
        public string COMP_END_ENTID { get; set; }
        public string BAIRRO_ENTID { get; set; }
        public string CID_ENTID { get; set; }
        public string UF_ENTID { get; set; }
        public string CD_PAIS { get; set; }
        public string EMAIL_AUX { get; set; }
        public string FONE_CELULAR { get; set; }
        public string FONE_ENTID { get; set; }
        public string NUM_BANCO { get; set; }
        public string NUM_AGENCIA { get; set; }
        public string NUM_CONTA { get; set; }
        public string POLIT_EXP { get; set; }
        public string NUM_PROCESSO_PREV { get; set; }
        public string CD_ESPECIE_INSS { get; set; }
        public List<PlanoEntidade> Planos { get; set; }
    }
}
