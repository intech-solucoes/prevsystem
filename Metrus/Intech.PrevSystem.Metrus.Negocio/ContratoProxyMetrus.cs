#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class ContratoProxyMetrus : ContratoProxy
    {
        public List<ContratoEntidade> BuscarPorFundacaoEmpresaInscricao(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO)
        {
            var listaContratos = base.BuscarPorFundacaoInscricao(CD_FUNDACAO, NUM_INSCRICAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
                contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();
                
                if(contrato.CD_SITUACAO == 3)
                    contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
                contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

                if (contrato.CD_SITUACAO == 3)
                    contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaInscricaoSituacao(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoInscricaoSituacao(CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
                contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

                if (contrato.CD_SITUACAO == 3)
                    contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
                contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

                if (contrato.CD_SITUACAO == 3)
                    contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string grupoFamilia, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, grupoFamilia, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
                contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

                if (contrato.CD_SITUACAO == 3)
                    contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }
    }
}
