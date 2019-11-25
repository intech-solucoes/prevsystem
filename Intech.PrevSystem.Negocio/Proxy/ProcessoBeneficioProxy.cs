using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ProcessoBeneficioProxy : ProcessoBeneficioDAO
    {
        public override IEnumerable<ProcessoBeneficioEntidade> BuscarPorFundacaoEmpresaInscricaoPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string CD_PLANO)
        {
            var processos = base.BuscarPorFundacaoEmpresaInscricaoPlano(CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO, CD_PLANO);

            foreach (var processo in processos)
            {
                var meses = 12;

                if (processo.OPCAO_RECB_13 == DMN_SN.SIM)
                    meses = 13;

                var mesesRecebimento = 100M / processo.VL_PARCELA_MENSAL.Value;

                mesesRecebimento = mesesRecebimento / meses;
                var fracaoMeses = mesesRecebimento % Math.Floor(mesesRecebimento);
                fracaoMeses = fracaoMeses * 12;

                var totalAnos = Convert.ToInt32(Math.Floor(mesesRecebimento));
                var totalMeses = Convert.ToInt32(Math.Floor(fracaoMeses));

                processo.DT_APOSENTADORIA = processo.DT_CONCESSAO.Value.AddYears(totalAnos).AddMonths(totalMeses);
                processo.DS_PROCESSO = $"{processo.DS_ESPECIE} - {processo.NUM_PROCESSO}/{processo.ANO_PROCESSO}";
                processo.ESPECIE_ANO_NUM_PROCESSO = $"{processo.CD_ESPECIE}{processo.ANO_PROCESSO}{processo.NUM_PROCESSO}";
            }

            return processos;
        }

        public IEnumerable<ProcessoBeneficioEntidade> BuscarPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, bool pensionista)
        {
            IEnumerable<ProcessoBeneficioEntidade> processos;

            if(pensionista)
                processos = base.BuscarPorFundacaoEmpresaMatriculaPlanoPensionista(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);
            else
                processos = base.BuscarPorFundacaoEmpresaMatriculaPlanoFuncionario(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);

            foreach (var processo in processos)
            {
                //var mesesRecebimento = (int)processo.SALDO_ATUAL / (int)(processo.SALDO_ATUAL * processo.VL_PARCELA_MENSAL / 100);
                //var mesesRecebimento = 100M / processo.VL_PARCELA_MENSAL.Value;

                //mesesRecebimento = mesesRecebimento / 13;
                //var fracaoMeses = mesesRecebimento % Math.Floor(mesesRecebimento);
                //fracaoMeses = fracaoMeses * 12;

                //var totalAnos = Convert.ToInt32(Math.Floor(mesesRecebimento));
                //var totalMeses = Convert.ToInt32(Math.Floor(fracaoMeses));

                //processo.DT_APOSENTADORIA = processo.DT_INICIO_FUND.Value.AddYears(totalAnos).AddMonths(totalMeses);
                processo.DS_PROCESSO = $"{processo.DS_ESPECIE} - {processo.NUM_PROCESSO}/{processo.ANO_PROCESSO}";
                processo.ESPECIE_ANO_NUM_PROCESSO = $"{processo.CD_ESPECIE}{processo.ANO_PROCESSO}{processo.NUM_PROCESSO}";
            }

            return processos;
        }

        public ProcessoBeneficioEntidade BuscarAtivoPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
        {
            var listaProcessos = base.BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);

            var situacoesBloqueadas = new string[] { "03", "04", "06", "07", "12", "20" };

            var processo = listaProcessos.First(x => !situacoesBloqueadas.Contains(x.CD_SITUACAO));

            return processo;
        }
    }
}