﻿#region Usings
using Intech.Lib.Web.API;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ContratoProxy : ContratoDAO
    {
        public ContratoProxy(IDbTransaction tx = null) : base(tx) { }

        public override List<ContratoEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
        {
            var listaContratos = base.BuscarPorFundacaoInscricao(CD_FUNDACAO, NUM_INSCRICAO);
            var retorno = new List<ContratoEntidade>();

            foreach (var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override List<ContratoEntidade> BuscarPorFundacaoInscricaoSituacao(string CD_FUNDACAO, string NUM_INSCRICAO, decimal CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoInscricaoSituacao(CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO);
            var retorno = new List<ContratoEntidade>();

            foreach (var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override List<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, decimal CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO).ToList();
            var retorno = new List<ContratoEntidade>();

            foreach(var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override List<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string grupoFamilia, decimal CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, grupoFamilia, CD_SITUACAO).ToList();
            var retorno = new List<ContratoEntidade>();

            foreach (var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override List<ContratoEntidade> BuscarPorFundacaoInscricaoGrupoFamiliaNotSituacao(string CD_FUNDACAO, string NUM_INSCRICAO, string NUM_SEQ_GR_FAMIL)
        {
            var listaContratos = base.BuscarPorFundacaoInscricaoGrupoFamiliaNotSituacao(CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_GR_FAMIL);
            var retorno = new List<ContratoEntidade>();

            foreach (var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override List<ContratoEntidade> BuscarPorFundacaoInscricaoNotSituacao(string CD_FUNDACAO, string NUM_INSCRICAO)
        {
            var listaContratos = base.BuscarPorFundacaoInscricaoNotSituacao(CD_FUNDACAO, NUM_INSCRICAO);
            var retorno = new List<ContratoEntidade>();

            foreach (var contrato in listaContratos)
                retorno.Add(BuscarDetalhesContratos(CD_FUNDACAO, contrato));

            return retorno;
        }

        public override ContratoEntidade BuscarDetalhePorFundacaoInscricaoAnoNumero(string CD_FUNDACAO, string NUM_INSCRICAO, string ANO_CONTRATO, string NUM_CONTRATO)
        {
            var contrato = base.BuscarDetalhePorFundacaoInscricaoAnoNumero(CD_FUNDACAO, NUM_INSCRICAO, ANO_CONTRATO, NUM_CONTRATO);

            contrato = BuscarDetalhesContratos(CD_FUNDACAO, contrato);

            return contrato;
        }
        
        public override ContratoEntidade BuscarDetalhePorFundacaoInscricaoAnoNumeroSeqFamilia(string CD_FUNDACAO, string NUM_INSCRICAO, string ANO_CONTRATO, string NUM_CONTRATO, string NUM_SEQ_GR_FAMIL)
        {
            var contrato = base.BuscarDetalhePorFundacaoInscricaoAnoNumeroSeqFamilia(CD_FUNDACAO, NUM_INSCRICAO, ANO_CONTRATO, NUM_CONTRATO, NUM_SEQ_GR_FAMIL);

            contrato = BuscarDetalhesContratos(CD_FUNDACAO, contrato);

            return contrato;
        }

        public override ContratoEntidade BuscarPorFundacaoAnoNumContrato(string CD_FUNDACAO, string ANO_CONTRATO, string NUM_CONTRATO)
        {
            var contrato = base.BuscarPorFundacaoAnoNumContrato(CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO);
            return BuscarDetalhesContratos(CD_FUNDACAO, contrato);
        }

        #region Métodos Privados

        private static ContratoEntidade BuscarDetalhesContratos(string CD_FUNDACAO, ContratoEntidade contrato)
        {
            contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
            contrato.Natureza = new NaturezaProxy().BuscarPorCdNatur(contrato.CD_NATUR);
            contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

            contrato.Prestacoes.ForEach(prestacao =>
            {
                prestacao.DES_VL_RECEBIDO = prestacao.VL_RECEBIDO != 0 ? prestacao.VL_RECEBIDO.Value.ToString("C") : string.Empty;
            });

            contrato.DES_NUM_CONTRATO = $"{contrato.NUM_CONTRATO}/{contrato.ANO_CONTRATO}";
            contrato.DES_PARCELAS = $"{contrato.Prestacoes.Count(x => x.DT_PAGTO != null)}/{contrato.PRAZO}";

            return contrato;
        }

        #endregion
    }
}
