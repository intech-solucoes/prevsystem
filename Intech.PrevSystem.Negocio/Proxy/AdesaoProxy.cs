using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class AdesaoProxy : AdesaoDAO
	{
        public override long Inserir(AdesaoEntidade entidade)
        {
            entidade.COD_TELEFONE_CELULAR = entidade.COD_TELEFONE_CELULAR.LimparMascara();
            entidade.COD_TELEFONE_FIXO = entidade.COD_TELEFONE_FIXO.LimparMascara();

            return base.Inserir(entidade);
        }
    }
}
