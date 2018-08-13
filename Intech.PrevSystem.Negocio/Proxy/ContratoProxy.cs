﻿#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ContratoProxy : ContratoDAO
    {
        public override IEnumerable<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO).ToList();

            foreach(var contrato in listaContratos)
                yield return BuscarDetalhesContratos(CD_FUNDACAO, contrato);
        }

        public override IEnumerable<ContratoEntidade> BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string grupoFamilia, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, grupoFamilia, CD_SITUACAO).ToList();

            foreach (var contrato in listaContratos)
                yield return BuscarDetalhesContratos(CD_FUNDACAO, contrato);
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
