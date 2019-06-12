using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades
{
    public class InfoRendGrupoEntidade
    {
        public string COD_GRUPO { get; set; }
        public string DES_GRUPO { get; set; }
        public List<InfoRendEntidade> Itens { get; set; }
    }
}
