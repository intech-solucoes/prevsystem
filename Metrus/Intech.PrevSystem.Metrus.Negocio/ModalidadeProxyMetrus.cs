using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class ModalidadeProxyMetrus : ModalidadeProxy
    {
        public List<ModalidadeEntidade> BuscarAtivasComNaturezas(FuncionarioEntidade funcionario, string cdFundacao, string cdEmpresa, string numMatricula, decimal origem, PlanoVinculadoEntidade plano)
        {
            var modalidades = base.BuscarAtivas().ToList();

            var proxyNaturezas = new NaturezaProxy();
            var proxyFichaFinanceira = new FichaFinanceiraProxy();
            var proxyCarenciasDisponiveis = new CarenciasDisponiveisProxy();
            var proxyFeriados = new FeriadoProxy();

            var feriados = proxyFeriados.BuscarDatas();

            var ativo = plano.CD_CATEGORIA == DMN_CATEGORIA.ATIVO ? "S" : null;
            var assistido = plano.CD_CATEGORIA == DMN_CATEGORIA.ASSISTIDO ? "S" : null;
            var autopatrocinio = plano.CD_CATEGORIA == DMN_CATEGORIA.AUTOPATROCINIO ? "S" : null;
            var diferido = plano.CD_CATEGORIA == DMN_CATEGORIA.DIFERIDO ? "S" : null;

            var tempoContribuicaoParticipante = 0;

            var fichaFinanceira = proxyFichaFinanceira.BuscarPorFundacaoPlanoInscricao(cdFundacao, plano.CD_PLANO, plano.NUM_INSCRICAO);

            // Verifica se foi migrado do plano 1
            var migrado = new PlanoVinculadoProxy().MigradoPlano1(plano.NUM_INSCRICAO) > 0;
            if (migrado)
            {
                tempoContribuicaoParticipante = proxyFichaFinanceira.BuscarPlanoUmDoisPorFundacaoInscricao(cdFundacao, plano.NUM_INSCRICAO).Count();
            }
            else
            {
                if (plano.CD_PLANO == "0001")
                    tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CD_TIPO_CONTRIBUICAO == "01").Count();
                else
                    tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CALC_MARGEM_CONSIG == "S").Count();
            }

            var tempoContribuicao = ObtemTempoContribuicao(tempoContribuicaoParticipante);

            foreach(var modalidade in modalidades)
            {
                modalidade.Naturezas = proxyNaturezas.BuscarPorModalidadePlanoCategoriaTempoContrib(modalidade.CD_MODAL, null, ativo, assistido, autopatrocinio, diferido, tempoContribuicao).ToList();

                if (modalidade.Naturezas.Count == 0)
                    throw new Exception("Participante não possui contribuição suficiente para simular emprestimo");

                foreach(var natureza in modalidade.Naturezas)
                {
                    natureza.Carencias = proxyCarenciasDisponiveis.BuscarPorNatureza(natureza.CD_NATUR).ToList();

                    var margensProxy = new MargensProxy();
                    var margem = margensProxy.BuscarPorFundacaoEmpresaModalidadeNaturezaEmVigencia(plano.CD_FUNDACAO, cdEmpresa, modalidade.CD_MODAL, natureza.CD_NATUR, DateTime.Now);

                    var encargo = new TaxasEncargosProxy().BuscarPorFundacaoEmpresaModalidadeNatureza(plano.CD_FUNDACAO, cdEmpresa, modalidade.CD_MODAL, natureza.CD_NATUR)
                        .Where(x => x.DT_INIC_VIGENCIA <= DateTime.Now && x.DT_TERM_VIGENCIA == null)
                        .OrderBy(x => x.DT_INIC_VIGENCIA)
                        .LastOrDefault();

                    var proxyTaxasConcessao = new TaxasConcessaoProxy();
                    var taxaConcessao = proxyTaxasConcessao.BuscarPorFundacaoEmpresaSeqModalNatur(plano.CD_FUNDACAO, cdEmpresa, encargo.SEQUENCIA, modalidade.CD_MODAL, natureza.CD_NATUR).LastOrDefault();

                    //natureza.MargemConsignavel = CalcularMargem(plano, cdEmpresa, modalidade.CD_MODAL, natureza.CD_NATUR, DateTime.Now, numMatricula, origem, margem, encargo, taxaConcessao);

                    var taxaMargemConsignavel = 0M;

                    if (origem == 1) //ativo, patrocinado
                        taxaMargemConsignavel = margem.TX_ATIVO_PREST_SP ?? 100;
                    else //assistido
                        taxaMargemConsignavel = margem.TX_ASSIST_MC ?? 100;

                    natureza.TaxaMargemConsignavel = taxaMargemConsignavel;
                    natureza.TaxaJuros = taxaConcessao.TX_JUROS.Value;
                }
            }

            return modalidades;
        }
    }
}
