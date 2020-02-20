using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class WebAssuntoProxy : WebAssuntoDAO
    {
        public List<WebAssuntoEntidade> Pesquisar(WebAssuntoEntidade dadosPesquisa) =>
            base.Pesquisar(dadosPesquisa.TXT_ASSUNTO).ToList();
    }
}
