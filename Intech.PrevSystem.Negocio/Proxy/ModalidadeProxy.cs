using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ModalidadeProxy : ModalidadeDAO
    {
        public List<ModalidadeEntidade> BuscarAtivasComNaturezas(string cdFundacao, string cdPlano, string cdCategoria, string numInscricao)
        {
            var modalidades = base.BuscarAtivas().ToList();

            var proxyNaturezas = new NaturezaProxy();
            var proxyFichaFinanceira = new FichaFinanceiraProxy();

            var ativo = cdCategoria == DMN_CATEGORIA.ATIVO ? "S" : null;
            var assistido = cdCategoria == DMN_CATEGORIA.ASSISTIDO ? "S" : null;
            var autopatrocinio = cdCategoria == DMN_CATEGORIA.AUTOPATROCINIO ? "S" : null;
            var diferido = cdCategoria == DMN_CATEGORIA.DIFERIDO ? "S" : null;
            
            var tempoContribuicaoParticipante = 0;

            var fichaFinanceira = proxyFichaFinanceira.BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao);

            // Verifica se foi migrado do plano 1
            var migrado = new PlanoVinculadoProxy().MigradoPlano1(numInscricao) > 0;
            if (migrado)
            {
                tempoContribuicaoParticipante = proxyFichaFinanceira.BuscarPlanoUmDoisPorFundacaoInscricao(cdFundacao, numInscricao).Count();
            }
            else
            {
                if (cdPlano == "0001")
                    tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CD_TIPO_CONTRIBUICAO == "01").Count();
                else
                    tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CALC_MARGEM_CONSIG == "S").Count();
            }

            var tempoContribuicao = ObtemTempoContribuicao(tempoContribuicaoParticipante);

            modalidades.ForEach(x =>
            {
                x.Naturezas = proxyNaturezas.BuscarPorModalidadePlanoCategoriaTempoContrib(x.CD_MODAL, null, ativo, assistido, autopatrocinio, diferido, tempoContribuicao).ToList();
            });

            return modalidades;
        }

        private int ObtemTempoContribuicao(int tempoContribuicaoParticipante)
        {
            if (tempoContribuicaoParticipante < 12)
                return tempoContribuicaoParticipante;

            else if (tempoContribuicaoParticipante >= 12 && tempoContribuicaoParticipante < 24)
                return 12;

            else if (tempoContribuicaoParticipante >= 24 && tempoContribuicaoParticipante < 36)
                return 24;

            else if (tempoContribuicaoParticipante >= 36 && tempoContribuicaoParticipante < 48)
                return 36;

            else if (tempoContribuicaoParticipante >= 48 && tempoContribuicaoParticipante < 60)
                return 48;

            else
                return 60;
        }
    }
}
