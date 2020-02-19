using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class GrupoUsuarioProxy : GrupoUsuarioDAO
    {
        public List<GrupoUsuarioEntidade> Pesquisar(GrupoUsuarioEntidade dadosPesquisa) =>
            base.Pesquisar(dadosPesquisa.NOM_GRUPO_USUARIO).ToList();

        public override bool DeletarPorChave(object chave)
        {
            new DocumentoPastaProxy().DeletarPorOidGrupoUsuario((decimal)chave);

            return base.DeletarPorChave(chave);
        }
    }
}