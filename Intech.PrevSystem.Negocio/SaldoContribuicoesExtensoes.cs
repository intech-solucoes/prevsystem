#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Entidades
{
    public static class SaldoContribuicoesExtensoes
    {
        public static void PreencherSaldo(this SaldoContribuicoesEntidade saldo, List<FichaFinanceiraEntidade> contribuicoes, string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo = null)
        {
            //saldo.DataReferencia = DateTime.ParseExact($"01/{contribuicoes.First().MES_REF}/{contribuicoes.First().ANO_REF}", "dd/MM/yyyy", new CultureInfo("pt-BR"));
            saldo.DataReferencia = DateTime.Now;

            var func = new FuncionarioProxy().BuscarPorInscricao(numInscricao);
            var plano = new PlanoProxy().BuscarPorCodigo(cdPlano);
            var planoVinculado = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(cdFundacao, cdEmpresa, func.NUM_MATRICULA, cdPlano);
            var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(cdFundacao, cdEmpresa, cdPlano);

            IndiceEntidade indice;

            if (plano.UTILIZA_PERFIL == "S")
            {
                var perfil = new PerfilInvestIndiceProxy().BuscarPorFundacaoEmpresaPlanoPerfilInvest(cdFundacao, cdEmpresa, cdPlano, planoVinculado.cd_perfil_invest.ToString());
                indice = new IndiceProxy().BuscarUltimoPorCodigo(perfil.CD_CT_RP);
            }
            else
            {
                indice = new IndiceProxy().BuscarUltimoPorCodigo(empresaPlano.IND_RESERVA_POUP);
            }
            
            var dataCota = indice.VALORES.First().DT_IND;

            var valorIndice = indice.BuscarValorEm(dataCota);

            if (cdFundo != null)
            {
                var fundoContrib = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(cdFundacao, cdPlano, cdFundo);

                contribuicoes = contribuicoes.Where(contrib
                    => fundoContrib.Any(fundo => fundo.CD_TIPO_CONTRIBUICAO == contrib.CD_TIPO_CONTRIBUICAO)
                ).ToList();
            }

            foreach(var contribuicao in contribuicoes)
            {
                var dataReferencia = new DateTime(Convert.ToInt32(contribuicao.ANO_REF), Convert.ToInt32(contribuicao.MES_REF), 1);

                if (dataReferencia <= dataCota)
                {
                    if (contribuicao.CD_OPERACAO == "C")
                        saldo.QuantidadeCotasParticipante = saldo.QuantidadeCotasParticipante + (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;
                    else
                        saldo.QuantidadeCotasParticipante = saldo.QuantidadeCotasParticipante - (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;

                    if (contribuicao.CD_OPERACAO == "C")
                        saldo.QuantidadeCotasPatrocinadora = saldo.QuantidadeCotasPatrocinadora + (decimal)contribuicao.QTD_COTA_RP_EMPRESA;
                    else
                        saldo.QuantidadeCotasPatrocinadora = saldo.QuantidadeCotasPatrocinadora - (decimal)contribuicao.QTD_COTA_RP_EMPRESA;

                    saldo.ValorParticipante = saldo.QuantidadeCotasParticipante * valorIndice;
                    saldo.ValorPatrocinadora = saldo.QuantidadeCotasPatrocinadora * valorIndice;
                    saldo.DataCota = dataCota;
                    saldo.ValorCota = valorIndice;
                }
            }
        }
    }
}
