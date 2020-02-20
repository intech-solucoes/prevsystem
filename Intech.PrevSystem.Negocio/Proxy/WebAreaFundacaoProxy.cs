using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class WebAreaFundacaoProxy : WebAreaFundacaoDAO
    {
        public List<WebAreaFundacaoEntidade> Pesquisar(WebAreaFundacaoEntidade dadosPesquisa) =>
            base.Pesquisar(dadosPesquisa.DES_AREA_FUNDACAO).ToList();
    }
}
