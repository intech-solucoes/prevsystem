using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Emprestimo
{
    public class EmprestimoHelper
    {
        public ParametrosEntidade Parametros { get; }
        public string CdFundacao { get; }
        public string CdEmpresa { get; }
        public decimal CdModal { get; }
        public decimal CdNatur { get; }
        public string CdPlano { get; }
        public DateTime DataReferencia { get; }

        public string ControleContratosAtivos => string.IsNullOrEmpty(Parametros.CONTROLE_CONTR_ATIVOS) ? "P" : Parametros.CONTROLE_CONTR_ATIVOS;
        public decimal QuantidadeContratosAtivos => Parametros.MAX_CONTR_ATIVOS ?? 0;

        public EmprestimoHelper(string cdFundacao, string cdEmpresa, decimal cdModal, decimal cdNatur, string cdPlano, DateTime dataReferencia)
        {
            Parametros = new ParametrosProxy().Buscar();
            CdFundacao = cdFundacao;
            CdEmpresa = cdEmpresa;
            CdModal = cdModal;
            CdNatur = cdNatur;
            CdPlano = cdPlano;
            DataReferencia = dataReferencia;
        }

        public List<TaxaEncargo> BuscarTaxaEncargo()
        {
            List<TaxaEncargo> taxasEncargos;

            if (!string.IsNullOrEmpty(Parametros.TAXA_EMPR_PLANO) && Parametros.TAXA_EMPR_PLANO == DMN_SN.SIM)
            {
                var taxaEncargoPlano = new TaxasEncargosPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlanoDtInicioVigencia(CdFundacao, CdEmpresa, CdModal, CdNatur, CdPlano, DataReferencia);
                taxasEncargos = TaxaEncargo.Criar(taxaEncargoPlano).ToList();
            }
            else
            {
                var taxaEncargo = new TaxasEncargosProxy().BuscarPorFundacaoEmpresaModalidadeNatureza(CdFundacao, CdEmpresa, CdModal, CdNatur);
                taxasEncargos = TaxaEncargo.Criar(taxaEncargo).ToList();
            }

            return taxasEncargos.OrderBy(x => x.DT_INIC_VIGENCIA).ToList();
        }

        public List<TaxaConcessao> BuscarTaxaConcessao()
        {
            List<TaxaConcessao> taxasConcessao;

            if (!string.IsNullOrEmpty(Parametros.TAXA_EMPR_PLANO) && Parametros.TAXA_EMPR_PLANO == DMN_SN.SIM)
            {
                var taxaConcessaoPlano = new TaxasConcessaoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlano(CdFundacao, CdEmpresa, CdModal, CdNatur, CdPlano);
                taxasConcessao = TaxaConcessao.Criar(taxaConcessaoPlano).ToList();
            }
            else
            {
                var taxaConcessao = new TaxasConcessaoProxy().BuscarPorFundacaoEmpresaModalNatur(CdFundacao, CdEmpresa, CdModal, CdNatur);
                taxasConcessao = TaxaConcessao.Criar(taxaConcessao).ToList();
            }

            return taxasConcessao;
        }
    }
}
