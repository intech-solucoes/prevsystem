using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class MensagemProxy : MensagemDAO
    {
        public MensagemEntidade Insert(MensagemEntidade entidade)
        {
            return base.Insert(entidade.TXT_TITULO, entidade.TXT_CORPO, entidade.DTA_MENSAGEM, entidade.DTA_EXPIRACAO, entidade.CD_FUNDACAO, entidade.CD_EMPRESA, entidade.CD_PLANO, entidade.CD_SIT_PLANO, entidade.COD_ENTID,
                                entidade.IND_MOBILE, entidade.IND_PORTAL, entidade.IND_EMAIL, entidade.IND_SMS);
        }
    }
}
