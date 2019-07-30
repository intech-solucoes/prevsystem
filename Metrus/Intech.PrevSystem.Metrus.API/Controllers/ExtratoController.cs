using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : Controller
    {
        [HttpGet("porCodEntidPlano/{codEntid}/{cdPlano}")]
        public virtual IActionResult GetTiposPorFundacaoPlanoPeriodo(string codEntid, string cdPlano)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceiraProxy = new FichaFinanceiraProxy();

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                var primeiraContrib = fichaFinanceiraProxy.BuscarPrimeiraPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO).First();

                //////////////
                // Datas
                //////////////
                var feriados = new FeriadoProxy().BuscarDatas();

                // Buscar ultima cota
                var plano = new PlanoProxy().BuscarPorCodigo(cdPlano);
                var planoVinculado = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano);
                var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano);
                IndiceEntidade indice;

                if (plano.UTILIZA_PERFIL == "S")
                {
                    var perfil = new PerfilInvestIndiceProxy().BuscarPorFundacaoEmpresaPlanoPerfilInvest(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, planoVinculado.cd_perfil_invest.ToString());
                    indice = new IndiceProxy().BuscarUltimoPorCodigo(perfil.CD_CT_RP);
                }
                else
                {
                    indice = new IndiceProxy().BuscarPorCodigo(empresaPlano.IND_RESERVA_POUP);
                }

                var dataCota = indice.VALORES.First().DT_IND;

                // Preencher datas
                var dataInicio = new DateTime(Convert.ToInt32(primeiraContrib.ANO_REF), Convert.ToInt32(primeiraContrib.MES_REF), 1);
                var dataPrimeiraContribAno = DateTime.Now.PrimeiroDiaDoAno();
                var dataUltimaContribAno = dataCota;
                var dataSaldoAnterior = DateTime.Now.AddYears(-1).UltimoDiaDoAno();
                while (!dataSaldoAnterior.EhDiaUtil(feriados))
                {
                    dataSaldoAnterior = dataSaldoAnterior.AddDays(-1);
                }

                var saldoAnterior = BuscarSaldoNoPeriodo(cdPlano, funcionario, fichaFinanceiraProxy, dataInicio, dataSaldoAnterior);
                var saldoAno = BuscarSaldoNoPeriodo(cdPlano, funcionario, fichaFinanceiraProxy, dataPrimeiraContribAno, dataUltimaContribAno);
                var saldoAtual = BuscarSaldoNoPeriodo(cdPlano, funcionario, fichaFinanceiraProxy, dataInicio, dataUltimaContribAno);

                return Json(new
                {
                    saldoAnterior,
                    saldoAno,
                    saldoAtual
                });

                //// Saldo anterior
                //var dataSaldoAnterior = DateTime.Now.AddYears(-1).UltimoDiaDoAno();
                ////var dataSaldoAnterior = new DateTime(2017, 12, 29);

                //while (!dataSaldoAnterior.EhDiaUtil(feriados))
                //{
                //    dataSaldoAnterior = dataSaldoAnterior.AddDays(-1);
                //}

                //var ficha = fichaFinanceiraProxy.BuscarPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO);
                //var listaSaldoAnterior = ficha
                //    .Where(x => new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) < dataSaldoAnterior)
                //    .ToList();

                //var saldoAnteriorParticipante = listaSaldoAnterior.Sum(x => x.CONTRIB_PARTICIPANTE);
                //var saldoAnteriorPatrocinadora = listaSaldoAnterior.Sum(x => x.CONTRIB_EMPRESA);
                //var saldoAnteriorTotal = saldoAnteriorParticipante + saldoAnteriorPatrocinadora;

                //// Contribuições
                //var dataPrimeiraContribAno = DateTime.Now.PrimeiroDiaDoAno();
                ////var dataUltimaContribAno = DateTime.Now;
                //var dataUltimaContribAno = new DateTime(2019, 4, 1);
                //var listaContribs = ficha
                //    .Where(x => new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) > dataPrimeiraContribAno
                //             && new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) < dataUltimaContribAno)
                //    .ToList();

                //var saldoAnoParticipante = listaContribs.Sum(x => x.CONTRIB_PARTICIPANTE);
                //var saldoAnoPatrocinadora = listaContribs.Sum(x => x.CONTRIB_EMPRESA);
                //var saldoAnoTotal = saldoAnoParticipante + saldoAnoPatrocinadora;

                //// Saldo atual
                //var listaSaldoAtual = new FichaFinanceiraProxy().BuscarPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO)
                //    .Where(x => new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) < dataUltimaContribAno)
                //    .ToList();

                //var saldoAtualParticipante = listaSaldoAtual.Sum(x => x.CONTRIB_PARTICIPANTE);
                //var saldoAtualPatrocinadora = listaSaldoAtual.Sum(x => x.CONTRIB_EMPRESA);
                //var saldoAtualTotal = saldoAtualParticipante + saldoAtualPatrocinadora;

                //return Json(new
                //{
                //    saldoAnterior = new
                //    {
                //        saldoAnteriorParticipante,
                //        saldoAnteriorPatrocinadora,
                //        saldoAnteriorTotal,
                //        dataSaldoAnterior
                //    },
                //    contribuicoes = new
                //    {
                //        dataPrimeiraContribAno,
                //        dataUltimaContribAno,
                //        saldoAnoParticipante,
                //        saldoAnoPatrocinadora,
                //        saldoAnoTotal
                //    },
                //    saldoAtual = new
                //    {
                //        dataAtual = dataUltimaContribAno,
                //        saldoAtualParticipante,
                //        saldoAtualPatrocinadora,
                //        saldoAtualTotal
                //    }
                //});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Saldo BuscarSaldoNoPeriodo(string cdPlano, Entidades.FuncionarioEntidade funcionario, FichaFinanceiraProxy fichaFinanceiraProxy, DateTime dtInicio, DateTime dtFim)
        {
            var saldoBasicaParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundoPeriodo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, "1", dtInicio, dtFim);
            var saldoSuplementarParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundoPeriodo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, "11", dtInicio, dtFim);

            var saldoTotalParticipante = saldoBasicaParticipante.ValorParticipante + saldoSuplementarParticipante.ValorParticipante;

            var saldoBasicaPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundoPeriodo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, "2", dtInicio, dtFim);
            var saldoSuplementarPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundoPeriodo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, "12", dtInicio, dtFim);

            var saldoTotalPatrocinadora = saldoBasicaPatrocinadora.ValorPatrocinadora + saldoSuplementarPatrocinadora.ValorPatrocinadora;

            var saldoTotal = saldoTotalParticipante + saldoTotalPatrocinadora;

            return new Saldo
            {
                SaldoTotalParticipante = saldoTotalParticipante.ToString("C"),
                SaldoTotalPatrocinadora = saldoTotalPatrocinadora.ToString("C"),
                SaldoTotal = saldoTotal.ToString("C"),
                DataInicio = dtInicio,
                DataFim = dtFim
            };
        }
    }

    public class Saldo
    {
        public string SaldoTotalParticipante { get; set; }
        public string SaldoTotalPatrocinadora { get; set; }
        public string SaldoTotal { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}