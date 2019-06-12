using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class PerfilInvestProxy : PerfilInvestDAO
    {
        public PerfilInvestEntidade BuscarPorCodigoComEvolucoes(string cdPerfilInvest)
        {
            var perfil = base.BuscarPorCodigo(cdPerfilInvest);

            perfil.TaxasProjetadas = new TaxaEvolPerfilProxy().BuscarPorFundacaoPerfil(perfil.CD_FUNDACAO, perfil.CD_PERFIL_INVEST).ToList();

            return perfil;
        }
    }
}