using Intech.Lib.Mobile.Servico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class EntidadeServico : BaseServico<EntidadeEntidade>
    {
        public EntidadeServico(string apiUrl) : base(apiUrl) { }

        public async Task<EntidadeEntidade> BuscarPorCodEntid(int codEntid) =>
            await ExecutarGet($"/entidade/porCodEntid/{codEntid}");
    }
}
