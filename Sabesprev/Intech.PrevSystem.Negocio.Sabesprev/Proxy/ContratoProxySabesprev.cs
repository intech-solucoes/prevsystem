#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Sabesprev.Proxy
{
    public class ContratoProxySabesprev : ContratoProxy
    {
        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string grupoFamilia, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, grupoFamilia, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }
    }
}
